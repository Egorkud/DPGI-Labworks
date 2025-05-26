using System;
using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Оголошення змінної _adoAssistant на рівні класу
        private AdoAssistant _adoAssistant;

        public MainWindow()
        {
            InitializeComponent();
            _adoAssistant = new AdoAssistant(); // Ініціалізуємо помічник
        }

        // Метод, який викликається при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        // Оновлення таблиці
        public void RefreshData()
        {
            listProducts.ItemsSource = _adoAssistant.TableLoad().DefaultView;
        }

        // Створити новий запис
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _adoAssistant.InsertGood(
                    txtArticleNum.Text,
                    txtName.Text,
                    txtUnit.Text,
                    decimal.Parse(txtQuantity.Text),
                    decimal.Parse(txtPrice.Text)
                );

                MessageBox.Show("Запис додано!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        // Оновити запис
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                _adoAssistant.UpdateGood(
                    id,
                    txtArticleNum.Text,
                    txtName.Text,
                    txtUnit.Text,
                    decimal.Parse(txtQuantity.Text),
                    decimal.Parse(txtPrice.Text)
                );

                MessageBox.Show("Запис оновлено!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        // Видалити запис
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                _adoAssistant.DeleteGood(id);

                MessageBox.Show("Запис видалено!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
