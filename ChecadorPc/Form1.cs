using System.Diagnostics;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ChecadorPc
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice videoCaptureDevice;
        private Bitmap fotoCaptured;
        private ManualResetEvent frameReceivedEvent = new ManualResetEvent(false);
        private CapturaRepository capturaRepository;

        public Form1()
        {
            InitializeComponent();
            string connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");
            capturaRepository = new CapturaRepository(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap fotoCamara = CapturarFotoWebcam();

                if (fotoCamara == null)
                {
                    MessageBox.Show("No se pudo capturar la foto de la webcam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pictureBox1.Image = fotoCamara;

                string nombreEquipo = Environment.MachineName;

                var captura = new Captura
                {
                    Foto = fotoCamara,
                    NombreEquipo = nombreEquipo
                };

                // Guardar en SQL Server
                bool guardado = capturaRepository.GuardarCaptura(captura);

                if (guardado)
                {
                    MessageBox.Show($"Captura guardada correctamente.\nEquipo: {captura.NombreEquipo}\nFecha/Hora: {captura.FechaHora:yyyy-MM-dd HH:mm:ss}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la captura en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap CapturarFotoWebcam()
        {
            try
            {
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("No se encontraron cámaras disponibles.", "Error");
                    return null;
                }

                int cameraIndex = 0;
                if (videoDevices.Count > 1)
                {
                    cameraIndex = MostrarSeleccionCamara(videoDevices);
                    if (cameraIndex == -1)
                        return null;
                }

                videoCaptureDevice = new VideoCaptureDevice(videoDevices[cameraIndex].MonikerString);
                fotoCaptured = null;
                frameReceivedEvent.Reset();

                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();

                frameReceivedEvent.WaitOne(5000);

                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();

                return fotoCaptured;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al capturar: {ex.Message}", "Error");
                return null;
            }
            finally
            {
                if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    videoCaptureDevice.WaitForStop();
                }
            }
        }

        private int MostrarSeleccionCamara(FilterInfoCollection videoDevices)
        {
            using (Form selectionForm = new Form())
            {
                selectionForm.Text = "Seleccionar Cámara";
                selectionForm.Width = 300;
                selectionForm.Height = 150;
                selectionForm.StartPosition = FormStartPosition.CenterParent;

                ComboBox comboBox = new ComboBox();
                comboBox.Left = 10;
                comboBox.Top = 20;
                comboBox.Width = 260;
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    comboBox.Items.Add(videoDevices[i].Name);
                }
                comboBox.SelectedIndex = 0;

                Button okButton = new Button();
                okButton.Text = "Aceptar";
                okButton.Left = 100;
                okButton.Top = 60;
                okButton.Height = 30;
                okButton.Click += (s, e) => selectionForm.DialogResult = DialogResult.OK;

                selectionForm.Controls.Add(comboBox);
                selectionForm.Controls.Add(okButton);

                return selectionForm.ShowDialog(this) == DialogResult.OK ? comboBox.SelectedIndex : -1;
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            fotoCaptured = (Bitmap)eventArgs.Frame.Clone();
            frameReceivedEvent.Set();
        }
    }
}