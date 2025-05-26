using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Оголошення змінної myTable на рівні класу
        private AdoAssistant _adoAssistant;

        public MainWindow()
        {
            InitializeComponent();
            // Ініціалізуємо екземпляр AdoAssistant
            _adoAssistant = new AdoAssistant(); // Замінили на ініціалізацію поля класу
        }

        // Метод для завантаження даних з бази
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            listProducts.ItemsSource = _adoAssistant.TableLoad().DefaultView;
        }

    }
}
