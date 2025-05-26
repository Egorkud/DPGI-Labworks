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
        DataTable? dt = null;// Посилання на об'єкт DataTable

        public DataTable? TableLoad()
        {
            if (dt != null) return dt;// Завантажимо таблицю лише один раз
            // Заповнюємо об'єкт таблиці даними з БД
            dt = new DataTable();

            // Створюємо об'єкт підключення
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Завантажує дані 
                command.CommandText = "SELECT Id, Articule, Name, Unit, Amount, Price FROM Goods";

                try
                {
                    // Метод сам відкриває БД і сам її закриває
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка підключення до БД: \n{ex.Message}");
                }
            }
            return dt;
        }

        public void InsertGood(string articule, string name, string unit, decimal amount, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Goods (Articule, Name, Unit, Amount, Price) VALUES (@Articule, @Name, @Unit, @Amount, @Price)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Articule", articule);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Price", price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void UpdateGood(int id, string articule, string name, string unit, decimal amount, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Goods SET Articule = @Articule, Name = @Name, Unit = @Unit, Amount = @Amount, Price = @Price WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Articule", articule);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Price", price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGood(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Goods WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}