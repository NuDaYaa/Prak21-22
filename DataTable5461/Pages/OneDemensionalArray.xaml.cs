using DataTable5461.Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTable5461.Pages
{
    /// <summary>
    /// Логика взаимодействия для OneDemensionalArray.xaml
    /// </summary>
    public partial class OneDemensionalArray : Page
    {
        int[] _array;
        public OneDemensionalArray()
        {
            InitializeComponent();
        }

        private void dgOneDimensionalArray_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Считывание индекса редактируемого элемента
            int i = e.Column.DisplayIndex;
            //Редактирование выбранного элемента
            if (int.TryParse(((TextBox)e.EditingElement).Text, out int element))
                {
                 _array[i] = element;
                 
                }
            else
            {
                MessageBox.Show("Введённое значение не является целым числом", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _array[i] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }
        //Создание массива заданного размера.
        private int[] CreateArray(int ItemsCount)
        { 
          return new int[ItemsCount];
        }

        //Создание представления для массива.

        private DataView CreateDefaultView(int[] array) => VisualArray.ToDataTable(_array).DefaultView;
       



      
        //Заполнение созданного массива
        private void btnFillArray_Click(object sender, RoutedEventArgs e)
        {                      
            if (int.TryParse(txtBoxItemsCount.Text, out int ItemsCount) &&
                int.TryParse(txtBoxMinValue.Text, out int MinValue) &&
                int.TryParse(txtBoxMaxValue.Text, out int MaxValue))
            {
                if (MinValue < MaxValue)
                {
                    _array = new int[ItemsCount];
                    Random rnd = new Random();

                    for (int i = 0; i < _array.Length; i++)
                    {
                        _array[i] = rnd.Next(MaxValue);
                    }
                    dgOneDimensionalArray.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
                }
                else 
                {
                    MessageBox.Show("Минимальное значение больше максимального!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }               
            }      
            else 
            {
                MessageBox.Show("Введите корректное значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtBoxItemsCount.Clear();
            txtBoxMinValue.Clear();
            txtBoxMaxValue.Clear();
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            if (_array != null)
            {
                int product = 1;
                bool found = false;

                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i] > 2)
                    {
                        product *= _array[i];
                        found = true;
                    }
                }

                if (found)
                {
                    txtBoxResult.Text = Convert.ToString(product);
                }
                else
                {
                    txtBoxResult.Text = "Нет чисел больше 2.";
                }
            }
            else
            {
                MessageBox.Show("Заполните поле значениями!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_array != null)
            {
                dgOneDimensionalArray.ItemsSource = null;
                _array = null;
            }
            else 
            {
                MessageBox.Show("Заполните поле значениями!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtBoxItemsCount.Clear();
            txtBoxMinValue.Clear();
            txtBoxMaxValue.Clear();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt*";
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {

                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(_array.Length);
                for (int i =0; i < _array.Length; ++i) 
                {
                    file.WriteLine(_array[i]);
                }
                file.Close();
            }
        }
        
        private void btnOpen_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true) 
            {
            StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                _array = new int[len];
                for (int i = 0; i < _array.Length; i++)
                {
                    _array[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
                dgOneDimensionalArray.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;

            }
        }
    }
}
