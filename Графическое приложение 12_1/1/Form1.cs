using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private int n, stl, scal, i, j;
        public Form1()
        {
            InitializeComponent();
        }
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
            public void Input1(RichTextBox mas1_textBox)
            {
                var sNums = new string[n, n];
                var arr1 = mas1_textBox.Text.Split('\n');
                if (arr1.Length != n)
                {
                    MessageBox.Show("Длина массива не соответствует введенному!");
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if (arr2.Length != n)
                    {
                        MessageBox.Show("Длина массива не соответствует введенному!");
                        return;
                    }
                    for (int j = 0; j < n; j++)
                    {

                        sNums[i, j] = arr2[j];
                    }
                }

                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            IntArray[i, j] = int.Parse(sNums[i, j]);
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный ввод данных. Попробуйте снова");
                    return;
                }
            }
            public void Input2(RichTextBox mas2_textBox)
            {
                var sNums = new string[n, n];
                var arr1 = mas2_textBox.Text.Split('\n');
                if (arr1.Length != n)
                {
                    MessageBox.Show("Длина массива не соответствует введенному!");
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if (arr2.Length != n)
                    {
                        MessageBox.Show("Длина массива не соответствует введенному!");
                        return;
                    }
                    for (int j = 0; j < n; j++)
                    {

                        sNums[i, j] = arr2[j];
                    }
                }

                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            IntArray[i, j] = int.Parse(sNums[i, j]);
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный ввод данных. Попробуйте снова");
                    return;
                }
            }
            //Метод вывода массива
            public void Print(RichTextBox res_textBox)
            {
                res_textBox.Text += "Mассив: " + '\n';
                for (int i = 0; i < n; i++, res_textBox.Text += "\n")
                {
                    for (int j = 0; j < n; j++)
                    {
                        res_textBox.Text += IntArray[i, j] + " ";
                    }
                }
            }
            //Метод, вычисляющий сумму столбцов
            public void Sum(int stl, RichTextBox res_textBox)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += IntArray[i, stl];
                }
                res_textBox.Text += "Сумма = " + sum + '\n';

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
                return result;
            }
            public static implicit operator Mas(int[,] mas)
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
                        intArray[i][j] = mas[i, j];
                    }
                }
            }
            public void Print1(RichTextBox res_textBox)
            {
               res_textBox.Text+="Mассив: "+'\n';
                for (int i = 0; i < intArray.Length; i++, res_textBox.Text += "\n")
                {
                    for (int j = 0; j < intArray[i].Length; j++)
                    {
                        res_textBox.Text += intArray[i][j]+" ";
                    }
                }
            }

        }

        private void res_Button_Click(object sender, EventArgs e)
        {
            if (n_textBox.Text == "" || mas1_textBox.Text == "" ||mas2_TextBox.Text==""|| skl_textBox.Text == "" || stl_textBox.Text == "")
            {
                MessageBox.Show("Введены не все данные");
            }
            else
            {
                res_textBox.Text = "";
                try
                {
                    n = int.Parse(n_textBox.Text);
                    if (n <= 0)
                    {
                        MessageBox.Show("Минимальное значение 1");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }
            }
            Mas mas = new Mas(n);
            mas.Input1(mas1_textBox);
            mas.Print(res_textBox);
            try
            {
                stl = int.Parse(stl_textBox.Text);
                if (stl < 0)
                {
                    MessageBox.Show("Число должно быть положительным");
                    return;
                }
                if (stl > (n - 1))
                {
                    MessageBox.Show("Значение должно быть меньше");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
                return;
            }
            mas.Sum(stl, res_textBox);
            res_textBox.Text += "Количество нулевых элементов: " + mas.Kol_Zero_Element + '\n';
            try
            {
                scal = int.Parse(skl_textBox.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
                return;
            }
            res_textBox.Text += "Все элементы главной диагонали равны скаляру: " + '\n';
            mas.Scal = scal;
            mas.Print(res_textBox);
            try
            {
                i = int.Parse(i_textBox.Text);
                j = int.Parse(j_TextBox.Text);
                if ((i < -1) || (j < -1))
                {
                    MessageBox.Show("Значение должно быть положительным");
                    return;
                }
                else if (i > n - 1)
                {
                    MessageBox.Show("Значение должно быть меньше " + n);
                    return;
                }
                else if (j > n - 1)
                {
                    MessageBox.Show("Значение должно быть меньше " + n);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!!!");
                return;
            }
            res_textBox.Text+="Число по индексу: " + mas[i, j];
            res_textBox.Text += "Операция ++: одновременно увеличивает значение всех элементов массива на 1;";
            mas++;
            mas.Print(res_textBox);
            res_textBox.Text += "Операция --: одновременно уменьшает значение всех элементов массива на 1;";
            mas--;
            mas.Print(res_textBox);
            if (mas) res_textBox.Text += "Массив является квадратным" + '\n';
            else res_textBox.Text += "Массив не является квадратным" + '\n';
            Mas mas_2 = new Mas(n);
            mas_2.Input2(mas2_TextBox);
            res_textBox.Text += "Сумма двух элементов массива"+'\n';
            mas += mas_2;
            mas.Print(res_textBox);
            Mas mas16 = mas;
            mas16.Print(res_textBox);
            Mas mas17 = (int[,])mas16;
            mas17.Print1(res_textBox);
        }
    }
}
