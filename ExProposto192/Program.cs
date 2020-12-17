using System;
using System.IO;
using System.Globalization;

namespace ExProposto192
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o path absolut do arquivo: ");
            string PathAbsolutoOrigem = Console.ReadLine();

            string PathAbsolutoDestino = Path.GetDirectoryName(PathAbsolutoOrigem) + @"\out\"+Path.GetFileName(PathAbsolutoOrigem);

            string[] Arq = File.ReadAllLines(PathAbsolutoOrigem);

            Directory.CreateDirectory(Path.GetDirectoryName(PathAbsolutoDestino));

            using (StreamWriter sw = File.AppendText(PathAbsolutoDestino))
            {
                foreach (string item in Arq)
                {
                    string[] linha = item.Split(',');

                    double total = double.Parse(linha[1]) * double.Parse(linha[2]);
                    sw.WriteLine(linha[0]+", "+total.ToString("F2",CultureInfo.InvariantCulture));
                }                
            }
        }
    }
}
