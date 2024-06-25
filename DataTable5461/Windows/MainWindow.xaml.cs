using DataTable5461.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTable5461.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmName.Navigate(new MainMenu(frmName));
        }

        public void GoToMainMenu()
        {
            //Если история пустая, очищать нечего
            if 
                (!frmName.CanGoBack && !frmName.CanGoForward)
            { 
                return; 
            }
            // Очистка истории
            var entry = frmName.RemoveBackEntry();
            while (entry != null)
            {
                entry = frmName.RemoveBackEntry();
            }
            //Переход в главное меню
            frmName.Navigate(new MainMenu(frmName));
        }
       

        private void mltGoMenu_Click(object sender, RoutedEventArgs e)
        {
            
                GoToMainMenu();
            
        }
    
        private void mltExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void mltGoBack_Click(object sender, RoutedEventArgs e)
        { 
            if(!frmName.CanGoBack) 
            {
            return;
            }
            else 
            {
                frmName.GoBack();
            }            
        }
        private void mltGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (!frmName.CanGoForward)
            {
                return;
            }
            else 
            {
            frmName.GoForward();
            }           
        }

        private void mltDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Тогузов Максим группа ИСП-22","Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mltAbout_Click(object sender, RoutedEventArgs e)
        {
            //Вывод справки в заыисимости от открытой страницы
            switch (Title)
            {
                case "Работа с одномерным массивом":
                    MessageBox.Show("Ввести n целых чисел.\n" +
                        "  Найти произведение чисел > 2. Результат вывести на экран.", "Задание 1", MessageBoxButton.OK, MessageBoxImage.Information);
                break;

                case "Работа с двухмерным массивом":
                    MessageBox.Show("Ввести n целых чисел.\n" +
                        "Дана целочисленная матрица размера M * N, \n" +
                        "Найти минимальный среди максимальных элементов ее \r\nстолбцов." , "Задание 2", MessageBoxButton.OK, MessageBoxImage.Information);
                break;

                default:
                    MessageBox.Show("Вариант 9", "Практическая работа 21-22", MessageBoxButton.OK, MessageBoxImage.Information);
                break;
            }
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Действительно хотите завершить работу с программой?","Выход из программы", 
                                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No;
        }

        private void frmName_ContentRendered(object sender, EventArgs e)
        {
            if (frmName.CanGoBack)
            {
                mltGoBack.IsEnabled = true; 
            }
            else
            { 
                mltGoBack.IsEnabled = false; 
            }

            if (frmName.CanGoForward)
            { 
             mltGoForward.IsEnabled = true;
            }
            else 
            { 
                mltGoForward.IsEnabled = false; 
            }
        }

        
        private void mltAbt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел.\n" +
                       "  Найти произведение чисел > 2. Результат вывести на экран.", "Задание 1 ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mltAbt1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N. Найти номер последнего из ее столбцов,\n" +
                "Дана целочисленная матрица размера M * N, \n" +
                "Найти минимальный среди максимальных элементов ее \r\nстолбцов.", "Задание 2", MessageBoxButton.OK, MessageBoxImage.Information);
        }      
    }
}