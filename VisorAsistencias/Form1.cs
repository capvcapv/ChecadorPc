using System.Data;

namespace VisorAsistencias
{
    public partial class Form1 : Form
    {
        private CapturaRepository capturaRepository;
        private List<Captura> capturaActual;
        private int indiceActual = 0;

        public Form1()
        {
            InitializeComponent();
            string connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");
            capturaRepository = new CapturaRepository(connectionString);
            CargarFormulario();
        }

        private void CargarFormulario()
        {
            // Cargar equipos únicos en el ComboBox
            List<string> equipos = capturaRepository.ObtenerEquiposUnicos();
            equipos.Insert(0, "Todos");

            comboBoxEquipos.DataSource = equipos;
            comboBoxEquipos.SelectedIndex = 0;

            // Establecer fechas predeterminadas
            dateTimePickerFechaInicio.Value = DateTime.Now.AddDays(-7);
            dateTimePickerFechaFin.Value = DateTime.Now;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string equipoSeleccionado = comboBoxEquipos.SelectedItem?.ToString();
                DateTime fechaInicio = dateTimePickerFechaInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFechaFin.Value.Date.AddHours(23).AddMinutes(59);

                if (equipoSeleccionado == "Todos")
                {
                    capturaActual = capturaRepository.ObtenerCapturasEntreFechas(fechaInicio, fechaFin);
                }
                else
                {
                    var todasLasCapturas = capturaRepository.ObtenerCapturasPortipo(equipoSeleccionado);
                    capturaActual = todasLasCapturas
                        .Where(c => c.FechaHora >= fechaInicio && c.FechaHora <= fechaFin)
                        .ToList();
                }

                if (capturaActual.Count == 0)
                {
                    MessageBox.Show("No se encontraron capturas con los filtros especificados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCapturas.DataSource = null;
                    pictureBoxFoto.Image = null;
                    labelDetalles.Text = "";
                    return;
                }

                // Mostrar en DataGridView
                MostrarEnDataGrid();
                indiceActual = 0;
                MostrarFoto(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEnDataGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Equipo", typeof(string));
            dt.Columns.Add("Fecha/Hora", typeof(string));

            foreach (var captura in capturaActual)
            {
                dt.Rows.Add(captura.Id, captura.NombreEquipo, captura.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            dataGridViewCapturas.DataSource = dt;
            dataGridViewCapturas.Columns["Id"].Width = 50;
            dataGridViewCapturas.Columns["Equipo"].Width = 150;
            dataGridViewCapturas.Columns["Fecha/Hora"].Width = 200;
        }

        private void dataGridViewCapturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceActual = e.RowIndex;
                MostrarFoto(indiceActual);
            }
        }

        private void MostrarFoto(int indice)
        {
            if (indice >= 0 && indice < capturaActual.Count)
            {
                var captura = capturaActual[indice];
                pictureBoxFoto.Image = captura.Foto;
                labelDetalles.Text = $"Equipo: {captura.NombreEquipo}\nFecha/Hora: {captura.FechaHora:yyyy-MM-dd HH:mm:ss}\nID: {captura.Id}";
            }
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                MostrarFoto(indiceActual);
                dataGridViewCapturas.CurrentCell = dataGridViewCapturas.Rows[indiceActual].Cells[0];
            }
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            if (indiceActual < capturaActual.Count - 1)
            {
                indiceActual++;
                MostrarFoto(indiceActual);
                dataGridViewCapturas.CurrentCell = dataGridViewCapturas.Rows[indiceActual].Cells[0];
            }
        }

        private void buttonGuardarFoto_Click(object sender, EventArgs e)
        {
            if (pictureBoxFoto.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Imagen JPEG|*.jpg|Imagen PNG|*.png|Todos los archivos|*.*";
                saveFileDialog.DefaultExt = "jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFoto.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("Foto guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}