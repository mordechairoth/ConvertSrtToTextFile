using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SrtToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write the file path of the folder you want to dycrypt the files from:");
            string path = Console.ReadLine();

            var srtFiles = Directory.GetFiles(path).Where(f => f.ToLower().EndsWith(".srt"));

            Console.WriteLine("Enter path of the folder where you want to store the new files:");

            path = Console.ReadLine();

            Console.WriteLine("Creating new files...");
            foreach(var file in srtFiles)
            {
                var sb = new StringBuilder();
                var fileContent = File.ReadAllLines(file);

                

                for (int i = 2; i < fileContent.Length; i+=4)
                {
                    sb.Append(fileContent[i] + "\n");
                }

                string fileName = Path.GetFileName(Path.ChangeExtension(file, "txt"));

                File.WriteAllText(path + Path.DirectorySeparatorChar + fileName, sb.ToString());


            }
            Console.WriteLine("finished!");



        }
    }
}
