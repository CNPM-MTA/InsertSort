using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSort
{
    class InsertSort
    {
        public static void InsertionSort(ref double [] a, ref int n)
        {
            double tam;
            int j, i;
            for (i = 0; i < n; i++)
            {
                tam = a[i];
                j = i - 1;
                while ((j > 0) && (tam < a[j]))
                {
                    a[j + 1] = a[j];
                    j = j - 1;
                }
                a[j + 1] = tam;
            }
        }
    }
}
