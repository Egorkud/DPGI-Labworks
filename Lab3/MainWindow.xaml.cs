using System.Windows;
using System.Windows.Input;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Оголошення команди для отримання відповіді.
        public static RoutedCommand GetAnswerCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            // Додавання прив'язки команди до методу її виконання.
            CommandBindings.Add(new CommandBinding(GetAnswerCommand, ExecuteGetAnswerCommand));
        }

        // Метод, який виконується при натисканні кнопки
        private void ExecuteGetAnswerCommand(object sender, ExecutedRoutedEventArgs e)
        {
            // Перевірка, чи користувач ввів питання. Якщо поле пусте - показується повідомлення.
            if (string.IsNullOrWhiteSpace(QuestionTextBox.Text))
            {
                AnswerLabel.Text = "Будь ласка, введіть питання.";
                return;
            }

            // Масив можливих відповідей
            string[] answers = { "Так", "Ні", "Скоріше так", "Скоріше ні" };

            // Генерація випадкового індексу та вибір однієї відповіді.
            Random rnd = new Random();
            int index = rnd.Next(answers.Length);

            // Вивід відповіді у відповідний елемент інтерфейсу - TextBlock
            AnswerLabel.Text = answers[index];
        }
    }
}