using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;


namespace Lab4
{
    // Клас доступу до БД
    public class AdoAssistant
    {
        // Отримуємо рядок з'єднання з файлу App.config
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DPGI"].ConnectionString;

        // Метод читання даних з DataTable
        DataTable dt = null;// Посилання на об'єкт DataTable

        public DataTable TableLoad()
        {
            if (dt == null) return dt;// Завантажимо таблицю лише один раз
            // Заповнюємо об'єкт таблиці даними з БД
            dt = new DataTable();

            // Створюємо об'єкт підключення
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Завантажує дані 
                command.CommandText = "SELECT Id, Articule, Unit, Amount, Price FROM Goods";

                try
                {
                    // Метод сам відкриває БД і сам її закриває
                    adapter.Fill(dt);
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка підключення до БД");
                }
            }
            return dt;
        }

    }
}