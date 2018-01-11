using PlanshetModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanshetConsoleApp
{
    class Program
    {
        static List<Tablet> _tablets = new List<Tablet>();

        static void Read()
        {
            Console.WriteLine("Введите имя файла (с путем)");
            string filename = Console.ReadLine();

            _tablets.AddRange(FileManager.ReadFromFile(filename));
        }

        static void Show(List<Tablet> tablets)
        {
            Console.WriteLine("Модель\tПамять\tРейтинг\tСтоимость");

            foreach (var item in tablets)
            {
                Console.WriteLine($"{item.Model}\t{item.VolumeMemory}\t{item.Rating}\t{item.Cost}");
            }

            Console.WriteLine();
        }

        static void Save(List<Tablet> tablets)
        {
            Console.WriteLine("Введите имя файла (с путем)");
            string filename = Console.ReadLine();

            FileManager.SaveInFile(filename, tablets);
        }

        static Tablet Create()
        {
            Tablet t = new Tablet();

            Console.WriteLine("Введите модель");
            t.Model = Console.ReadLine();

            Console.WriteLine("Введите объем памяти");
            t.VolumeMemory = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите рейтинг");
            t.Rating = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите стоимость");
            t.Cost = decimal.Parse(Console.ReadLine());

            return t;
        }

        static void Choice()
        {
            decimal sum = 0;

            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("M = ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("R = ");
            int r = int.Parse(Console.ReadLine());

            var chipTablets = ChoiceManager.GetChipsTablet(_tablets, k, m, r, out sum);

            Show(chipTablets);
            Console.WriteLine("Сумма = " + sum);
        }

        static void Main(string[] args)
        {
            int oper = 0;

            do
            {
                Console.WriteLine("0.Выход");
                Console.WriteLine("1.Загрузка из файла");
                Console.WriteLine("2.Сохранение в файл");
                Console.WriteLine("3.Создать новый");
                Console.WriteLine("4.Подобрать планшеты");
                Console.WriteLine("5.Распечатать все");

                oper = int.Parse(Console.ReadLine());

                switch (oper)
                {
                    case 1:
                        Read();
                        break;
                    case 2:
                        Save(_tablets);
                        break;
                    case 3:
                        _tablets.Add(Create());
                        break;
                    case 4:
                        Choice();
                        break;
                    case 5:
                        Show(_tablets);
                        break;
                }

                Console.WriteLine();
            }
            while (oper != 0);
        }
    }
}
