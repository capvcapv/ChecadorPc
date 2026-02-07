using System.Data;
using System.Data.SqlClient;

namespace VisorAsistencias
{
    public class CapturaRepository
    {
        private readonly string _connectionString;

        public CapturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Captura> ObtenerTodasLasCapturas()
        {
            List<Captura> capturas = new List<Captura>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Id, NombreEquipo, FechaHora, Foto FROM Capturas ORDER BY FechaHora DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] fotoBytes = (byte[])reader["Foto"];
                                Bitmap foto = ConvertirBytesABitmap(fotoBytes);

                                capturas.Add(new Captura
                                {
                                    Id = (int)reader["Id"],
                                    NombreEquipo = reader["NombreEquipo"].ToString(),
                                    FechaHora = (DateTime)reader["FechaHora"],
                                    Foto = foto
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar capturas: {ex.Message}", "Error");
            }

            return capturas;
        }

        public List<Captura> ObtenerCapturasPortipo(string nombreEquipo)
        {
            List<Captura> capturas = new List<Captura>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Id, NombreEquipo, FechaHora, Foto FROM Capturas WHERE NombreEquipo = @NombreEquipo ORDER BY FechaHora DESC", connection))
                    {
                        command.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] fotoBytes = (byte[])reader["Foto"];
                                Bitmap foto = ConvertirBytesABitmap(fotoBytes);

                                capturas.Add(new Captura
                                {
                                    Id = (int)reader["Id"],
                                    NombreEquipo = reader["NombreEquipo"].ToString(),
                                    FechaHora = (DateTime)reader["FechaHora"],
                                    Foto = foto
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar capturas: {ex.Message}", "Error");
            }

            return capturas;
        }

        public List<Captura> ObtenerCapturasEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Captura> capturas = new List<Captura>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Id, NombreEquipo, FechaHora, Foto FROM Capturas WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin ORDER BY FechaHora DESC", connection))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        command.Parameters.AddWithValue("@FechaFin", fechaFin);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] fotoBytes = (byte[])reader["Foto"];
                                Bitmap foto = ConvertirBytesABitmap(fotoBytes);

                                capturas.Add(new Captura
                                {
                                    Id = (int)reader["Id"],
                                    NombreEquipo = reader["NombreEquipo"].ToString(),
                                    FechaHora = (DateTime)reader["FechaHora"],
                                    Foto = foto
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar capturas: {ex.Message}", "Error");
            }

            return capturas;
        }

        public List<string> ObtenerEquiposUnicos()
        {
            List<string> equipos = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT DISTINCT NombreEquipo FROM Capturas ORDER BY NombreEquipo", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                equipos.Add(reader["NombreEquipo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar equipos: {ex.Message}", "Error");
            }

            return equipos;
        }

        private Bitmap ConvertirBytesABitmap(byte[] imageBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return new Bitmap(ms);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}