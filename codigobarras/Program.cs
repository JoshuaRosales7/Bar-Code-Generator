using System;
using System.Drawing;
using ZXing;
using ZXing.Rendering;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generador de Código de Barras");

        // Ingresa el texto que deseas convertir en código de barras
        Console.Write("Ingresa el texto para el código de barras: ");
        string texto = Console.ReadLine() ?? "TextoPredeterminado";

        // Llama al método para generar el código de barras
        GenerarCodigoBarras(texto);

        Console.ReadLine();
    }

    static void GenerarCodigoBarras(string texto)
    {
        // Crear una instancia de BarcodeWriter
        var barcodeWriter = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 300, // Ancho de la imagen en píxeles
                Height = 100 // Alto de la imagen en píxeles
            }
        };

        // Generar el código de barras como un objeto PixelData
        var pixelData = barcodeWriter.Write(texto);

        // Convertir PixelData en un objeto Bitmap
        var barcodeBitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

for (int y = 0; y < pixelData.Height; y++)
{
    for (int x = 0; x < pixelData.Width; x++)
    {
        int offset = y * pixelData.Width + x;
        int pixelValue = pixelData.Pixels[offset];

        // Si el valor del píxel es 0, establece el color a blanco, de lo contrario, establece el color a negro
        Color color = (pixelValue == 0) ? Color.White : Color.Black;

        barcodeBitmap.SetPixel(x, y, color);
    }
}



        // Guardar el código de barras como un archivo de imagen (puedes cambiarlo según tus necesidades)
        barcodeBitmap.Save("CodigoBarras.png");

        Console.WriteLine("Código de barras generado con éxito. El archivo se ha guardado como CodigoBarras.png");
    }
}
