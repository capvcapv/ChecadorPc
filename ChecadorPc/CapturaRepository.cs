using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.Json;

namespace ChecadorPc
{
    public class CapturaRepository
    {
        private readonly string _connectionString;
        private static readonly HttpClient client = new HttpClient();

        public CapturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool GuardarCaptura(Captura captura)
        {
            try
            {
                // Obtener la fecha y hora de México
                DateTime fechaHoraMexico = ObtenerFechaHoraMexico();
                captura.FechaHora = fechaHoraMexico;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO Capturas (NombreEquipo, FechaHora, Foto) VALUES (@NombreEquipo, @FechaHora, @Foto)", connection))
                    {
                        // Convertir Bitmap a array de bytes
                        byte[] fotoBytes = ConvertirBitmapABytes(captura.Foto);

                        command.Parameters.AddWithValue("@NombreEquipo", captura.NombreEquipo);
                        command.Parameters.AddWithValue("@FechaHora", captura.FechaHora);
                        command.Parameters.AddWithValue("@Foto", fotoBytes);

                        int resultado = command.ExecuteNonQuery();
                        return resultado > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}", "Error");
                return false;
            }
        }

        private DateTime ObtenerFechaHoraMexico()
        {
            try
            {
                // API de zona horaria para México (America/Mexico_City)
                string url = "https://worldtimeapi.org/api/timezone/America/Mexico_City";
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    using (JsonDocument doc = JsonDocument.Parse(content))
                    {
                        JsonElement root = doc.RootElement;
                        if (root.TryGetProperty("datetime", out JsonElement dateTimeElement))
                        {
                            string dateTimeString = dateTimeElement.GetString();
                            // Parsear la fecha y hora
                            if (DateTime.TryParse(dateTimeString, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime dateTime))
                            {
                                return dateTime;
                            }
                        }
                    }
                }

                // Si falla la API, usar la hora local del sistema (respaldo)
                TimeZoneInfo mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mexicoTimeZone);
            }
            catch
            {
                // Respaldo: usar zona horaria del sistema
                TimeZoneInfo mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mexicoTimeZone);
            }
        }

        private byte[] ConvertirBitmapABytes(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}