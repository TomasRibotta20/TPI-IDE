using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WIndowsForm
{
    public partial class EditarComisionForm : Form
    {
        private readonly ComisionDto _comision;
        private readonly bool _esNuevo;
        private readonly PlanApiClient _planApiClient = new PlanApiClient();

        public ComisionDto ComisionEditada { get; private set; }
        public bool Guardado { get; private set; }

        public EditarComisionForm(ComisionDto comision = null)
        {
            InitializeComponent();
            _comision = comision ?? new ComisionDto();
            _esNuevo = comision == null;

            ConfigurarFormulario();
            this.Load += async (_, __) => await CargarDatosAsync();
        }



        private void ConfigurarFormulario()
        {
            Text = _esNuevo ? "Nueva Comisión" : "Editar Comisión";

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (_, __) => Close();

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            if (_esNuevo)
            {
                lblIdComision.Visible = false;
                txtIdComision.Visible = false;
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }

            comboPlanes.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Configurar el control numérico para el año de especialidad sin límite superior
            numAnioEspecialidad.Minimum = 1;
            numAnioEspecialidad.Maximum = 9999; // Máximo valor permitido por NumericUpDown
            numAnioEspecialidad.Value = 1;
            
            // Permitir entrada manual de valores (sin restricción)
            numAnioEspecialidad.TextAlign = HorizontalAlignment.Right;
        }

        private async Task CargarDatosAsync()
        {
            await CargarPlanesAsync();

            if (!_esNuevo)
            {
                txtIdComision.Text = _comision.IdComision.ToString();
                txtDescComision.Text = _comision.DescComision;
                numAnioEspecialidad.Value = _comision.AnioEspecialidad;
                comboPlanes.SelectedValue = _comision.IdPlan;
            }
        }

        private async Task CargarPlanesAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var planes = await _planApiClient.GetAllAsync();
                var lista = planes.ToList();
                comboPlanes.DataSource = lista;
                comboPlanes.DisplayMember = "Descripcion";
                comboPlanes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescComision.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboPlanes.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un plan.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComisionEditada = new ComisionDto
            {
                IdComision = _esNuevo ? 0 : _comision.IdComision,
                DescComision = txtDescComision.Text.Trim(),
                AnioEspecialidad = (int)numAnioEspecialidad.Value,
                IdPlan = (int)comboPlanes.SelectedValue
            };

            Guardado = true;
            Close();
        }
    }
}