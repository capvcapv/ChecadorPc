namespace VisorAsistencias
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelFiltros = new Panel();
            labelEquipo = new Label();
            comboBoxEquipos = new ComboBox();
            labelFechaInicio = new Label();
            dateTimePickerFechaInicio = new DateTimePicker();
            labelFechaFin = new Label();
            dateTimePickerFechaFin = new DateTimePicker();
            buttonBuscar = new Button();
            splitContainer = new SplitContainer();
            dataGridViewCapturas = new DataGridView();
            panelDetalles = new Panel();
            panelBotones = new Panel();
            buttonAnterior = new Button();
            buttonSiguiente = new Button();
            buttonGuardarFoto = new Button();
            labelDetalles = new Label();
            pictureBoxFoto = new PictureBox();
            panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCapturas).BeginInit();
            panelDetalles.SuspendLayout();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // panelFiltros
            // 
            panelFiltros.Controls.Add(labelEquipo);
            panelFiltros.Controls.Add(comboBoxEquipos);
            panelFiltros.Controls.Add(labelFechaInicio);
            panelFiltros.Controls.Add(dateTimePickerFechaInicio);
            panelFiltros.Controls.Add(labelFechaFin);
            panelFiltros.Controls.Add(dateTimePickerFechaFin);
            panelFiltros.Controls.Add(buttonBuscar);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 0);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Padding = new Padding(10);
            panelFiltros.Size = new Size(1200, 100);
            panelFiltros.TabIndex = 1;
            // 
            // labelEquipo
            // 
            labelEquipo.AutoSize = true;
            labelEquipo.Location = new Point(10, 15);
            labelEquipo.Name = "labelEquipo";
            labelEquipo.Size = new Size(47, 15);
            labelEquipo.TabIndex = 0;
            labelEquipo.Text = "Equipo:";
            // 
            // comboBoxEquipos
            // 
            comboBoxEquipos.Location = new Point(80, 15);
            comboBoxEquipos.Name = "comboBoxEquipos";
            comboBoxEquipos.Size = new Size(200, 23);
            comboBoxEquipos.TabIndex = 1;
            // 
            // labelFechaInicio
            // 
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(300, 15);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(73, 15);
            labelFechaInicio.TabIndex = 2;
            labelFechaInicio.Text = "Fecha Inicio:";
            // 
            // dateTimePickerFechaInicio
            // 
            dateTimePickerFechaInicio.Location = new Point(380, 15);
            dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            dateTimePickerFechaInicio.Size = new Size(150, 23);
            dateTimePickerFechaInicio.TabIndex = 3;
            // 
            // labelFechaFin
            // 
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(550, 15);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(60, 15);
            labelFechaFin.TabIndex = 4;
            labelFechaFin.Text = "Fecha Fin:";
            // 
            // dateTimePickerFechaFin
            // 
            dateTimePickerFechaFin.Location = new Point(620, 15);
            dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            dateTimePickerFechaFin.Size = new Size(150, 23);
            dateTimePickerFechaFin.TabIndex = 5;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(800, 15);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(80, 23);
            buttonBuscar.TabIndex = 6;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 100);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dataGridViewCapturas);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelDetalles);
            splitContainer.Size = new Size(1200, 600);
            splitContainer.SplitterDistance = 967;
            splitContainer.TabIndex = 0;
            // 
            // dataGridViewCapturas
            // 
            dataGridViewCapturas.AllowUserToAddRows = false;
            dataGridViewCapturas.Dock = DockStyle.Fill;
            dataGridViewCapturas.Location = new Point(0, 0);
            dataGridViewCapturas.Name = "dataGridViewCapturas";
            dataGridViewCapturas.ReadOnly = true;
            dataGridViewCapturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCapturas.Size = new Size(967, 600);
            dataGridViewCapturas.TabIndex = 0;
            dataGridViewCapturas.CellClick += dataGridViewCapturas_CellClick;
            // 
            // panelDetalles
            // 
            panelDetalles.Controls.Add(panelBotones);
            panelDetalles.Controls.Add(labelDetalles);
            panelDetalles.Controls.Add(pictureBoxFoto);
            panelDetalles.Dock = DockStyle.Fill;
            panelDetalles.Location = new Point(0, 0);
            panelDetalles.Name = "panelDetalles";
            panelDetalles.Padding = new Padding(10);
            panelDetalles.Size = new Size(229, 600);
            panelDetalles.TabIndex = 0;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(buttonAnterior);
            panelBotones.Controls.Add(buttonSiguiente);
            panelBotones.Controls.Add(buttonGuardarFoto);
            panelBotones.Dock = DockStyle.Bottom;
            panelBotones.Location = new Point(10, 540);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(10);
            panelBotones.Size = new Size(209, 50);
            panelBotones.TabIndex = 0;
            // 
            // buttonAnterior
            // 
            buttonAnterior.Location = new Point(10, 10);
            buttonAnterior.Name = "buttonAnterior";
            buttonAnterior.Size = new Size(80, 23);
            buttonAnterior.TabIndex = 0;
            buttonAnterior.Text = "← Anterior";
            buttonAnterior.Click += buttonAnterior_Click;
            // 
            // buttonSiguiente
            // 
            buttonSiguiente.Location = new Point(100, 10);
            buttonSiguiente.Name = "buttonSiguiente";
            buttonSiguiente.Size = new Size(80, 23);
            buttonSiguiente.TabIndex = 1;
            buttonSiguiente.Text = "Siguiente →";
            buttonSiguiente.Click += buttonSiguiente_Click;
            // 
            // buttonGuardarFoto
            // 
            buttonGuardarFoto.Location = new Point(190, 10);
            buttonGuardarFoto.Name = "buttonGuardarFoto";
            buttonGuardarFoto.Size = new Size(100, 23);
            buttonGuardarFoto.TabIndex = 2;
            buttonGuardarFoto.Text = "Guardar Foto";
            buttonGuardarFoto.Click += buttonGuardarFoto_Click;
            // 
            // labelDetalles
            // 
            labelDetalles.BorderStyle = BorderStyle.FixedSingle;
            labelDetalles.Dock = DockStyle.Top;
            labelDetalles.Location = new Point(10, 360);
            labelDetalles.Name = "labelDetalles";
            labelDetalles.Size = new Size(209, 80);
            labelDetalles.TabIndex = 1;
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxFoto.Dock = DockStyle.Top;
            pictureBoxFoto.Location = new Point(10, 10);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(209, 350);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFoto.TabIndex = 2;
            pictureBoxFoto.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(splitContainer);
            Controls.Add(panelFiltros);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visor de Asistencias";
            Load += Form1_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCapturas).EndInit();
            panelDetalles.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
        }

        private ComboBox comboBoxEquipos;
        private DateTimePicker dateTimePickerFechaInicio;
        private DateTimePicker dateTimePickerFechaFin;
        private Button buttonBuscar;
        private DataGridView dataGridViewCapturas;
        private PictureBox pictureBoxFoto;
        private Label labelDetalles;
        private Button buttonAnterior;
        private Button buttonSiguiente;
        private Button buttonGuardarFoto;
        private Panel panelFiltros;
        private Label labelEquipo;
        private Label labelFechaInicio;
        private Label labelFechaFin;
        private SplitContainer splitContainer;
        private Panel panelDetalles;
        private Panel panelBotones;
    }
}