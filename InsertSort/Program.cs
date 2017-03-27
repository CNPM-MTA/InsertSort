using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSort
{
    class Program
    {
        public const int MAX = 1000;
        public const int READ_SUCCESS = 0;
        public const int ERR_FILE_PATH = 1;
        public const int ERR_CANNOT_CONVERT_NUMBER = 2;
        public const int ERR_SIZE_REQUEST = 3;

        public static void Main(string[] args)
        {
            double[] arr = new double[MAX];
            int n = 0;
            switch (read_from_file("insert_sort.txt", ref arr, ref n))
            {
                case READ_SUCCESS:
                    {
                        Console.WriteLine("Read success");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            Console.Write(arr[i] + "\t");
                        }
                        break;
                    }
                case ERR_FILE_PATH: Console.WriteLine("Error file path"); break;
                case ERR_SIZE_REQUEST: Console.WriteLine("Error size request"); break;
                case ERR_CANNOT_CONVERT_NUMBER: Console.WriteLine("Error cannot convert to number"); break;
                default: Console.WriteLine("default"); break;
            }

            InsertSort.InsertionSort(ref arr, ref n);
            Console.WriteLine("\n\n\nSort success!!!");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.ReadKey();
        }
        private static int read_from_file(String fileName, ref double[] list, ref int size)
        {
            string[] lines = new String[MAX];
            try
            {
                 lines = System.IO.File.ReadAllLines(fileName);
            }
            catch(IOException e)
            {
                Console.Write(e);
                return ERR_FILE_PATH;
            }

            int out_size = 0;
            size = out_size;
            if(lines.Length > 1)
            {
                if (int.TryParse(lines[0].ToString().Trim(), out out_size))
                {
                    size = out_size;
                }
                else return ERR_CANNOT_CONVERT_NUMBER;
                if (size < 0) return ERR_SIZE_REQUEST;

            }
            int i = 1, j = 0, temp = 0, count = 0;
            list = new double[size];
            String[] row = new String[size];
            if (size > 0 && size < MAX)
            {
                while (i < lines.Length && count < size)
                {
                    row = lines[i].ToString().Trim().Split(' ');
                    for (j = 0; j < row.Length && count < size; j++)
                    {
                        if (int.TryParse(row[j].ToString().Trim(), out temp))
                        {
                            list[count] = temp; count++;
                        }
                        else return ERR_CANNOT_CONVERT_NUMBER;
                    }
                    i++;
                }
            }
            else return ERR_SIZE_REQUEST;
            return READ_SUCCESS;
        }
    }
}
