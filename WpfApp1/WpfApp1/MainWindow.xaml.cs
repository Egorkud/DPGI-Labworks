using System.Windows;
using System.Windows.Input;
using System.IO;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Створення та реєстрація прив'язки команд обробників

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save,
                execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open,
                execute_Open, canExecute_Open);
            CommandBindings.Add(openCommand);

            CommandBinding deleteCommand = new CommandBinding(ApplicationCommands.Delete,
                execute_Delete, canExecute_Delete);
            CommandBindings.Add(deleteCommand);

            CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy,
                execute_Copy, canExecute_Copy);
            CommandBindings.Add(copyCommand);

            CommandBinding pasteCommand = new CommandBinding(ApplicationCommands.Paste,
                execute_Paste, canExecute_Paste);
            CommandBindings.Add(pasteCommand);
        }

        // Обробник події для команди Save
        private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox.Text.Trim().Length > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        // Обробник події для збереження тексту в файл
        private void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("E:\\КПІ\\3 Курс\\GI\\Lab2File.txt", textBox.Text);
            MessageBox.Show("Файл збережено!");
        }

        // Обробник події для команди Open
        private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Обробник події для відкриття файлу
        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (dlg.ShowDialog() == true)
                {
                    textBox.Text = File.ReadAllText(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка відкриття файлу: " + ex.Message);
            }
        }

        // Обробник для команди Delete
        private void canExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        // Обробник події для видалення тексту
        private void execute_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox.SelectionLength > 0)
                textBox.SelectedText = "";
            else
                textBox.Clear();

        }
        // Обробник для команди Copy
        private void canExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox.SelectionLength > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        // Обробник події для копіювання тексту
        private void execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Copy();
        }

        // Обробник для команди Paste
        private void canExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        // Обробник події для вставки тексту
        private void execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Paste();
        }
    }
}