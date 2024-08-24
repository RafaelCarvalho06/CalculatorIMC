using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CalculatorIMC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            double altura;
            double peso;
            double imc;
            string categoriaIMC;
            string imageUrl = "";

            // Validação para garantir que os valores são numéricos
            if (double.TryParse(Altura.Text, out  altura) && double.TryParse(Peso.Text, out  peso))
            {
                 imc = peso / (altura * altura);

                if (imc < 18.5)
                {
                    categoriaIMC = "Baixo peso";
                    imageUrl = "~/imagens/Baixo Peso.jpg";
                }
                else if (imc >= 18.5 && imc <= 24.9)
                {
                    categoriaIMC = "Peso normal";
                    imageUrl = "~/imagens/Peso Normal.jfif";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    categoriaIMC = "Excesso de peso";
                        imageUrl = "~/imagens/excesso peso.jpg";
                }
                else if (imc >= 30 && imc <= 34.9)
                {
                    categoriaIMC = "Obesidade grau I (Moderada)";
                    imageUrl = "~/imagens/Obesidade grau I.png";
                }
                else if (imc >= 35 && imc <= 39.9)
                {
                    categoriaIMC = "Obesidade grau II (Severa)";
                    imageUrl = "~/imagens/Obesidade grau II.jfif";
                }
                else // IMC >= 40
                {
                    categoriaIMC = "Obesidade grau III (Mórbida)";
                    imageUrl = "~/imagens/Obesidade grau III.jpg";
                }
                ResultLabel.Text = $"Seu IMC é {imc:F2}. Categoria: {categoriaIMC}";
                ResultLabel.CssClass = "alert alert-info";
                ResultImage.ImageUrl = imageUrl;

                SaveIMCToDatabase(Nome.Text, altura, peso, imc);
            }
            else
            {
                ResultLabel.Text = "Por favor, insira valores válidos para altura e peso.";
                ResultLabel.CssClass = "alert alert-danger";
            }
        }

        private void SaveIMCToDatabase(string nome, double altura, double peso, double imc)
        {
            string connectionString = "Server=DESKTOP-RJ8U3LT;Database=teste;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO IMC (Nome_user, altura, peso, IMC, Date) VALUES (@Nome, @altura, @peso, @IMC, @Date)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@altura", altura);
                    command.Parameters.AddWithValue("@peso", peso);
                    command.Parameters.AddWithValue("@IMC", imc);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
