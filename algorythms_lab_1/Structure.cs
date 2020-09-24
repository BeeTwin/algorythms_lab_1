using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace algorythms_lab_1
{
    class Structure
    {
        public int[] massiv;
        //tea

        public Structure(int size)
        {
            massiv = new int[size];
            for (var i = 0; i < size; i++)
                massiv[i] = new Random().Next(0, 100);
        }

        public void Algorythm()
        {
            massiv.OrderBy(x => x);
            Thread.Sleep(massiv.Length);
        }
    }
}
