using System;
using System.IO;

namespace VisualStudio_filters_Translator
{
    internal class Program
    {
        private static void Main()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".filters")
                {
                    string fileText = File.ReadAllText(file);
                    fileText = fileText.Replace("Исходные файлы", "Source Files");
                    fileText = fileText.Replace("Файлы заголовков", "Header Files");
                    fileText = fileText.Replace("Файлы ресурсов", "Resource Files");
                    File.WriteAllText(file, fileText);
                    Console.WriteLine($"[DONE] {file} : Success.");

                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("[ERROR] Can't find file with '.filters' extesion");

            Console.ReadKey();
        }
    }
}
