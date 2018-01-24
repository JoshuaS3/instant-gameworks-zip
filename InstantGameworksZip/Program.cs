using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace InstantGameworksZip
{
    class Program
    {
        [STAThread]
        static void Main() {
            OpenFileDialog inputFiles = new OpenFileDialog();
            inputFiles.Title = "Select files to place in binary";
            inputFiles.Multiselect = true;
            inputFiles.InitialDirectory = @"C:\";
            if (inputFiles.ShowDialog() == DialogResult.OK)
            {
                string[] fileLocations = inputFiles.FileNames;

                SaveFileDialog outputDialog = new SaveFileDialog();
                outputDialog.Title = "Select file to output to";
                outputDialog.InitialDirectory = @"C:\";
                outputDialog.Filter = "IGWD files|*.igwd";
                outputDialog.OverwritePrompt = true;
                if (outputDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFile = outputDialog.FileName;

                    long Beginning = DateTime.Now.Ticks / 10000000;
                    Console.WriteLine("Beginning");

                    FileStream fileStream = new FileStream(outputFile, FileMode.Create);
                    BinaryWriter fileWriter = new BinaryWriter(fileStream);

                    int fileCount = 0;
                    foreach (string file in fileLocations)
                    {
                        Console.WriteLine("Appending " + Path.GetFileName(file));
                        fileWriter.Write(fileCount);
                        fileWriter.Write("{{{" + Path.GetFileName(file) + "}}}");
                        fileWriter.Write("\n\n\n");
                        fileWriter.Write(File.ReadAllBytes(file));
                        fileCount++;
                    }
                    fileWriter.Close();

                    Console.WriteLine("Output to " + outputFile);
                    Console.WriteLine("Finished (" + (DateTime.Now.Ticks / 10000000 - Beginning) + " seconds)");
                    Console.WriteLine("Press any key to continue . . . ");
                    Console.ReadKey();
                }
            }
        }
    }
}
