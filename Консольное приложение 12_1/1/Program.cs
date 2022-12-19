using System;

namespace _1
{
    class Program
    {
        class Mas
        {
            //Поля класса
            int[,] IntArray;
            int[][] intArray;
            int n;
            //Конструктор класса
            public Mas(int n)
            {
                this.n = n;
                IntArray = new int[n, n];
            }

            public Mas()
            {
            }

            //Метод ввода массива с клавиатуры
            public void Input()
            {
                Console.WriteLine("Ввод элементов массива: ");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Элемент №[{0},{1}]= ", i, j);
                                IntArray[i, j] = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Неверный ввод");
                            }
                        }
                    }
                }
            }
            //Метод вывода массива
            public void Print()
            {
                Console.WriteLine("Mассив: ");
                for (int i = 0; i < n; i++, Console.WriteLine())
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0,5} ", IntArray[i, j]);
                    }
                }
            }
            //Метод, вычисляющий сумму столбцов
            public void Sum(int stl)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += IntArray[i, stl];
                }
                Console.WriteLine("Сумма = " + sum);

            }
            //позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения);
            public int Kol_Zero_Element
            {
                get
                {
                    int count = 0;
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            if (IntArray[i, j] == 0)
                                count++;
                        }
                    return count;
                }
            }
            // позволяющее установить значение всех элементы главной диагонали массива равное скаляру (доступное только для записи).
            public int Scal
            {
                set
                {
                    for (int i = 0; i < n; i++)
                        IntArray[i, i] = value;
                }
            }
            //Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
            public int this[int index1, int index2]
            {
                get { return IntArray[index1, index2]; }
            }

            //операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
            public static Mas operator ++(Mas obj)
            {
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.n; j++)
                        obj.IntArray[i, j] = obj.IntArray[i, j] + 1;
                return obj;
            }

            public static Mas operator --(Mas obj)
            {
                for (int i = 0; i < obj.n; i++)
                    for (int j = 0; j < obj.n; j++)
                        obj.IntArray[i, j] = obj.IntArray[i, j] - 1;
                return obj;
            }
           // Перегрузка  оператора " true ": обращение к экземпляру класса дает значение true, если двумерный массив является квадратным
            
            public static bool operator true(Mas p)
            {
                int n = p.IntArray.GetLength(0);
                int m = p.IntArray.GetLength(1);
                if (n == m) return true;
                else return false;
            }
            // Перегрузка  оператора " false ": обращение к экземпляру класса дает значение false, если двумерный массив является прямоугольным
            public static bool operator false(Mas p)
            {
                int n = p.IntArray.GetLength(0);
                int m = p.IntArray.GetLength(1);
                if (n != m) return false;
                else return true;
            }
            // Перегрузка операции бинарный " + ": сложить два массива соответствующих размерностей

            public static Mas operator +(Mas a, Mas b)
            {
                if (a.IntArray.GetLength(1) != b.IntArray.GetLength(0)) throw new Exception("Матрицы нельзя сложить");
                int[,] intArray = new int[a.IntArray.GetLength(0), b.IntArray.GetLength(1)];
                Mas result = new Mas(a.IntArray.GetLength(0));
                for (int i = 0; i < a.IntArray.GetLength(0); i++)
                {
                    for (int j = 0; j < a.IntArray.GetLength(1); j++)
                    {
                        result.IntArray[i, j] = a[i, j] + b[i, j];
                    }
                }
                result.Print();
                return result;
            }
            public static implicit operator Mas(int[,]mas)
            {
                return new Mas(mas);

            }
            //Преобразования в ступенчатый массив (явное преобразование)
            public static explicit operator int[,](Mas mas)
            {
                return mas.IntArray;
            }
            //Заполнение двухмерного массива исходя из уже заполненного ступенчатого
            public Mas(int[,] mas)
            {
                intArray = new int[mas.GetLength(0)][];
                for (int i = 0; i < intArray.Length; ++i)
                {
                    intArray[i] = new int[mas.GetLength(0)];
                    for (int j = 0; j < intArray[i].Length; ++j)
                    {
                        intArray[i][j] = mas[i,j];
                    }
                }
            }
            public void Print1()
            {
                Console.WriteLine("Mассив: ");
                for (int i = 0; i < intArray.Length; i++, Console.WriteLine())
                {
                    for (int j = 0; j < intArray[i].Length; j++)
                    {
                        Console.Write("{0,5} ", intArray[i][j]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int n, stl, scal, i, j;
            while (true)
            {
                try
                {
                    Console.Write("Введите размерность массива (n*n): ");
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Минимальное значение 1");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Mas mas = new Mas(n);
            mas.Input();
            mas.Print();
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите номер столбца: ");
                    stl = int.Parse(Console.ReadLine());
                    if (stl < 0)
                    {
                        Console.WriteLine("Число должно быть положительным");
                        continue;
                    }
                    if (stl > (n - 1))
                    {
                        Console.WriteLine("Значение должно быть меньше");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            mas.Sum(stl);
            Console.ReadKey();
            Console.WriteLine("Количество нулевых элементов: {0}", mas.Kol_Zero_Element);
            Console.ReadKey();
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите значение скаляра: ");
                    scal = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Console.WriteLine("Все элементы главной диагонали равны скаляру: ");
            mas.Scal = scal;
            mas.Print();
            Console.ReadKey();
            Console.WriteLine("Введите индексы элемента: ");
            while (true)
            {
                try
                {
                    Console.Write("Введите первый индекс:");
                    i = int.Parse(Console.ReadLine());
                    Console.Write("Введите второй индекс:");
                    j = int.Parse(Console.ReadLine());
                    if ((i < -1) || (j < -1))
                    {
                        Console.WriteLine("Значение должно быть положительным");
                        continue;
                    }
                    else if (i > n - 1)
                    {
                        Console.WriteLine("Значение должно быть меньше " + n);
                        continue;
                    }
                    else if (j > n - 1)
                    {
                        Console.WriteLine("Значение должно быть меньше " + n);
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод!!!");
                }
            }
            Console.WriteLine("Число по индексу: " + mas[i, j]);
            Console.ReadKey();

            Console.WriteLine("\nОперация ++: одновременно увеличивает значение всех элементов массива на 1;");
            mas++;
            mas.Print();
            Console.ReadKey();

            Console.WriteLine("\nОперация --: одновременно уменьшает значение всех элементов массива на 1;");
            mas--;
            mas.Print();
            Console.ReadKey();

            if (mas) Console.WriteLine("Массив является квадратным");
            else Console.WriteLine("Массив не является квадратным");
            Console.ReadKey();

            int n_1;
            Console.WriteLine("Введите второй массив: ");
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите размерность");
                    n_1 = int.Parse(Console.ReadLine());
                    if (n_1 <= 0)
                    {
                        Console.WriteLine("Минимальное значение 1");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Mas mas_2 = new Mas(n_1);
            mas_2.Input();
            Console.WriteLine("Сумма двух элементов массива");
            mas += mas_2;
            Console.ReadKey();
            Mas mas16 = mas;
            mas16.Print();
            Mas mas17 = (int[,])mas16;
            mas17.Print1();
        }
    }
}
