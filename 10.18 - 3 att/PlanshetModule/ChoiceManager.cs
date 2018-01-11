using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanshetModule
{
    public static class ChoiceManager
    {
        public static List<Tablet> GetChipsTablet(List<Tablet> list, int k, int m, int r, out decimal sum)
        {
            List<Tablet> newTablets = new List<Tablet>();

            foreach (var item in list)
            {
                if (item.VolumeMemory >= m && item.Rating >= r)
                {
                    newTablets.Add(item);
                }
            }

            //список всех планшетов подходящих под заданные критерии
            newTablets = newTablets.OrderBy(t => t.Cost).ToList();

            List<Tablet> chipTablets = new List<Tablet>();

            int count = 0;
            sum = 0;

            foreach (var item in newTablets)
            {
                if (count == k)
                    break;

                chipTablets.Add(item);

                count++;
                sum += item.Cost;
            }

            return chipTablets;
        }
    }
}
