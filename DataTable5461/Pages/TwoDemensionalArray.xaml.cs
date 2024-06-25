using DataTable5461.Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTable5461.Pages
{
    /// <summary>
    /// Логика взаимодействия для TwoDemensionalArray.xaml
    /// </summary>
    public partial class TwoDemensionalArray : Page
    {
        public TwoDemensionalArray()
        {
            InitializeComponent();
        }
        int[,] mas;
        int n, m;
        private void dgTwoDimensionalArray_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }


        private void btnFillArray_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxColumnValue.Text != null && txtBoxRowValue.Text != null)
            {
                if (int.TryParse(txtBoxColumnValue.Text, out int randMin) && int.TryParse(txtBoxMaxValue.Text, out int randMax))
                {                                      
                        if (randMin > -1000 && randMax < 1000)
                        {
                            if (randMin == 0 && (randMax == 0 || randMax == 1))
                            {
                                MessageBox.Show("Диапазон должен быть больше или меньше нуля", "Ошибка");
                            }                           
                            else
                            {
                                txtBoxResult.Clear();
                                n = Convert.ToInt32(txtBoxColumnValue.Text);
                                m = Convert.ToInt32(txtBoxRowValue.Text);
                                mas = new int[n, m];
                                Random rnd = new Random();
                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < m; j++)
                                    {
                                        mas[i, j] = rnd.Next(-10, randMax);
                                    }
                                }
                                dgTwoDimensionalArray.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели слишком большой диапазон", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }                                     
                }
                else
                {
                    MessageBox.Show("Введите в диапазон число", "Ошибка" ,MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели значения в диапазон", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                int M = mas.GetLength(0);
                int N = mas.GetLength(1);
                int minOfMax = int.MaxValue;

                for (int j = 0; j < N; j++)
                {
                    int maxInColumn = int.MinValue;

                    for (int i = 0; i < M; i++)
                    {
                        if (mas[i, j] > maxInColumn)
                        {
                            maxInColumn = mas[i, j];
                        }
                    }

                    if (maxInColumn < minOfMax)
                    {
                        minOfMax = maxInColumn;
                    }
                }

                txtBoxResult.Text = minOfMax.ToString();
            }
            else
            {
                MessageBox.Show("Заполните поле значениями!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | .txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if(save.ShowDialog() == true) 
            {
            StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));

                for (int i = 0; i <  mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        file.WriteLine(mas[i, j]);
                    }
                }
                file.Close();
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
             OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if(open.ShowDialog() == true) 
            {
            StreamReader file = new StreamReader(open.FileName);
                int rows = Convert.ToInt32(file.ReadLine());
                int cols = Convert.ToInt32(file.ReadLine());
                int rowsNum = 0; int colsNum = 0;

                mas = new int[rows, cols];
                for(int i = 0; i < mas.GetLength(0); i++)
                {
                     colsNum++;
                    rowsNum = 0;

                    for (int j = 0; j < mas.GetLength(1); j++) 
                    {
                        mas[i, j] = Convert.ToInt32(file.ReadLine());
                        rowsNum++;
                    }
                }
                file.Close();
                dgTwoDimensionalArray.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                dgTwoDimensionalArray.ItemsSource = null;
                mas = null;
            }
            else
            {
                MessageBox.Show("Заполните поле значениями!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtBoxColumnValue.Clear();
            txtBoxRowValue.Clear();
            txtBoxMaxValue.Clear();
        }
    }
}
