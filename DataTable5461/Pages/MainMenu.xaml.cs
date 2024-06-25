using System.Windows;
using System.Windows.Controls;


namespace DataTable5461.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Frame _frame;
        public MainMenu(Frame frmMain)
        {
            InitializeComponent();

            _frame = frmMain; 
        }

        private void btnOneDimensionalArray_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new OneDemensionalArray());
        }

        private void btnTwoDimensionalArray_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new TwoDemensionalArray());
        }
    }
}
