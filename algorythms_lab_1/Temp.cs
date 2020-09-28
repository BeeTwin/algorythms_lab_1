using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace algorythms_lab_1
{
    public class Temp
    {
        public int[] temp;

        public Temp(int size)
        {
            temp = new int[size];
            for (var i = 0; i < size; i++)
                temp[i] = new Random().Next(1, 200);
        }

        public void Tempo()
        {
            temp.OrderBy(x => x).ToArray().ToArray();
        }
    }
}
