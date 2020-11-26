//Требуется решить невырожденную систему, состоящую из N линейных уравнений с N неизвестными:
using System;
using System.IO;

namespace Sistems
{
    class Program
    {
        static void Main(string[] args)
        {
            string line, line2 = "";
            int N = 0, k = 0;


            try
            {
                using (StreamReader sr = new StreamReader("D:\\ISU\\inputSistems.txt"))
                {
                    N = Int32.Parse(sr.ReadLine());
                    int[,] Numbers = new int[N, N];
                    int[,] Numbers_check = new int[N, N];
                    int[] Arr_num = new int[N * 3];
                    int[] C = new int[N];

                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = line2 + " " + line;
                    }
                    sr.Close(); //закрываем потоки
                    string[] split_str = line2.Split(new Char[] { ' ', '\t' }); //делим строку на символы без пробелов
                    for (int i = 1; i < split_str.Length; i++)
                    {
                        if (split_str[i].Trim() != "")
                        {
                            try
                            {
                                Arr_num[k] = Int32.Parse(split_str[i]);
                                k++;
                            }
                            catch (FormatException) { Console.WriteLine("Can't Parsed '{0}'"); }
                        }
                    }
                    k = 0;
                    for (int i = 0; i < N; ++i)
                    {
                        for (int j = 0; j < N; ++j)
                        {
                            Numbers[i, j] = Arr_num[k];    //получили двумерный массив данных int
                            k++;
                        }
                        C[i] = Arr_num[k];
                        k++;
                    }
                    int dec1 = Sist(Numbers, N);
                    Array.Copy(Numbers, Numbers_check, N * N);

                    k = 0;
                    int[] decision = new int[N];
                    StreamWriter sw = new StreamWriter("D:\\ISU\\outputSistems.txt");
                    for (int i = 0; i < N; i++)
                    {
                        Array.Copy(Numbers, Numbers_check, N * N);
                        for (int j = 0; j < N; j++)
                        {
                            Numbers_check[j, i] = C[j];
                        }
                        int dec2 = Sist(Numbers_check, N);
                        decision [k]= dec2 / dec1;
                        System.Console.Write("Решение" + (i + 1) + "= " + decision[k] + "\n");
                        sw.WriteLine(decision[k]+ " ");
                        k++;
                    }

                    sw.Close();//закрываем поток
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static int Sist(int[,] matrix, int size)
        {
            int det = 0;
            int degree = 1;
            if (size == 1)
            {
                return matrix[0, 0];
            }
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int[,] newMatrix = new int[size - 1, size - 1];
                for (int j = 0; j < size; j++)
                {
                    DelRowAndCol(matrix, size, 0, j, newMatrix);
                    det = det + (degree * matrix[0, j] * Sist(newMatrix, size - 1));
                    degree = -degree;
                }
            }

            return det;
        }
        public static void DelRowAndCol(int[,] matrix, int size, int row, int col, int[,] newMatrix)
        {
            int offsetRow = 0;
            int offsetCol = 0;
            for (int i = 0; i < size - 1; i++)
            {
                if (i == row)
                {
                    offsetRow = 1;
                }

                offsetCol = 0;
                for (int j = 0; j < size - 1; j++)
                {
                    if (j == col)
                    {
                        offsetCol = 1;
                    }
                    newMatrix[i, j] = matrix[i + offsetRow, j + offsetCol];
                }
            }

        }
    }
}
