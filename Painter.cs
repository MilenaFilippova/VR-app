using System;
using System.IO;

namespace Painter
{
    class Program
    {
        public static void Main()
        {
            try 
            { using (StreamReader sr = new StreamReader("D:\\ISU\\inputPainter.txt"))
                {
                    int size = 100, k = 0, empty_sum = 0;
                    string line="", line2="";
                    int[] array_number = new int[size];
                    int[,] picture = new int[50, 50];

                    //читаем весь текст построчно и собираем в одну строку
                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = line2 + " " + line;
                    }
                    string[] split = line2.Split(new Char[] { ' ', '\t' }); //делим строку на символы без пробелов
                    foreach (string s in split)
                    {
                        if (s.Trim() != "")
                        {
                            try{
                                array_number[k] = Int32.Parse(s);   //переводим строку в массив int
                                k++;
                            }
                            catch (FormatException) { Console.WriteLine("Can't Parsed '{0}'", s);}
                        }
                    }
                    
                    int weight = array_number[0];   //присваиваем значения в переменные
                    int height = array_number[1];
                    int n = array_number[2];

                    for (int i = 0; i < height; ++i)
                    {
                        for (int j = 0; j < weight; ++j)
                        {
                            picture[i,j] = 0;
                        }
                    }
                    int flag = 0;
                    while (n > 0)
                    {
                        for (int i = array_number[3 + flag+ 1]; i < array_number[3 + flag + 3]; i++) //y1 y2
                        {
                            for (int j = array_number[3+flag]; j < array_number[3 + flag + 2]; j++) //x1 x2
                            {
                                picture[i, j] = 1;
                            }
                        }
                        flag += 4;
                        n--;
                    }
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < weight; j++)
                        {
                            if (picture[i,j] == 0)
                            {
                                empty_sum++;    //считаем пустую площадь
                            }
                        }
                    }
                    Console.WriteLine(" Empty square= "  + empty_sum);

                    StreamWriter sw = new StreamWriter("D:\\ISU\\outputPainter.txt");
                    sw.WriteLine(empty_sum);    //выыодим в файл
                    sr.Close(); //закрываем потоки
                    sw.Close();
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
