using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanshetModule
{
    public static class FileManager
    {
        public static List<Tablet> ReadFromFile(string filename)
        {
            List<Tablet> tablets = new List<Tablet>();

            string[] lines = File.ReadAllLines(filename);

            foreach (var item in lines)
            {
                string[] arr = item.Split();

                Tablet t = new Tablet();
                t.Model = arr[0];
                t.VolumeMemory = int.Parse(arr[1]);
                t.Rating = int.Parse(arr[2]);
                t.Cost = decimal.Parse(arr[3]);

                tablets.Add(t);
            }

            return tablets;
        }

        public static void SaveInFile(string filename, List<Tablet> tablets)
        {
            StreamWriter sw = new StreamWriter(filename);

            foreach (var item in tablets)
            {
                string line = string.Format($"{item.Model} {item.VolumeMemory} {item.Rating} {item.Cost}");

                sw.WriteLine(line);
            }

            sw.Close();
        }
    }
}
