using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"Carga.txt"; // Reemplaza con la ruta completa del archivo de texto

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo no se encontró en la ruta especificada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Se produjo un error al leer el archivo: " + ex.Message);
        }

        Console.ReadLine();
    }
}