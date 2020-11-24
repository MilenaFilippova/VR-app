//Судоку размера n называется квадрат со стороной n2, разделенный на n2 средних квадратов со стороной n, каждый из которых разделен на n2 маленьких квадратов. В каждом маленьком квадрате записано число от 1 до n2.
using System;
using System.IO;


namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("D:\\ISU\\inputSudoku.txt"))
                {
                    int N = 0, k = 0;
                    int[,] Numbers = new int[100, 100];
                    string line, line2 = "";
                    line = sr.ReadLine();
                    N = Int32.Parse(line);   //переводим строку в  int
                    int[] Arr_num = new int[N * N * N * N];

                    //читаем весь текст построчно и собираем в одну строку
                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = line2 + " " + line;
                    }
                    sr.Close(); //закрываем потоки
                    string[] split_str = line2.Split(new Char[] { ' ', '\t' }); //делим строку на символы без пробелов
                    foreach (string s in split_str)
                    {
                        if (s.Trim() != "")
                        {
                            try
                            {
                                Arr_num[k] = Int32.Parse(s);
                                k++;
                            }
                            catch (FormatException) { Console.WriteLine("Can't Parsed '{0}'"); }
                        }
                    }
                    k = 0;
                    for (int i = 0; i < N * N; ++i)
                    {
                        for (int j = 0; j < N * N; ++j)
                        {
                            Numbers[i, j] = Arr_num[k];    //получили двумерный массив данных int
                            Arr_num[k] = 0; //зануляем массив
                            k++;
                        }
                    }

                    k = 0;
                    for (int i = 0; i < N * N; ++i) // проверка по строкам
                    {
                        for (int j = 0; j < N * N; ++j)
                        {
                            Arr_num[Numbers[i, j]] += 1;
                        }
                        for (int l = 1; i <= N * N; ++i)
                            if (Arr_num[l] == 0)
                                ++k;
                        for (int m = 1; i <= N * N; ++i)
                            Arr_num[m] = 0;
                    }

                    for (int j = 0; j < N * N; ++j) // проверка по столбцам
                    {
                        for (int i = 0; i < N * N; ++i)
                        {
                            Arr_num[Numbers[i, j]] += 1;
                        }
                        for (int l = 1; j <= N * N; ++j)
                            if (Arr_num[l] == 0)
                            {
                                ++k;
                            }
                        for (int m = 1; j <= N * N; ++j)
                            Arr_num[m] = 0;
                    }

                    for (int i = 0; i < N; ++i) // проверка по внутренним квадратам
                    {
                        for (int j = 0; j < N; ++j)
                        {
                            for (int m = 0; m <= N * N; ++m)
                                Arr_num[m] = 0;
                            for (int y = i * N; y < i * N + N; ++y)
                            {

                                for (int x = j * N; x < j * N + N; ++x)
                                {
                                    Arr_num[Numbers[y, x]] = 1;
                                }
                            }
                            for (int c = 1; c <= N * N; ++c)
                                if (Arr_num[c] == 0)
                                {
                                    ++k;
                                }
                        }
                    }
                    StreamWriter sw = new StreamWriter("D:\\ISU\\outputSudoku.txt");
                    if (k == 0)
                    {
                        sw.WriteLine("Correct");    //выыодим в файл
                        Console.WriteLine("Correct");
                    }
                    else
                    {
                        sw.WriteLine("Incorrect");    
                        Console.WriteLine("Incorrect");
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
    }
}
