using System;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WIndowsForm
{
    public partial class RegisterForm : Form
    {
        private readonly AuthApiClient _authApiClient;
        private bool _isUpdatingTelefono = false;

        public RegisterForm()
        {
            _authApiClient = new AuthApiClient();
            InitializeComponent();
            ConfigurarFormulario();
        }

        private async void ConfigurarFormulario()
        {
            // Solo Profesor y Alumno (NO Administrador)
            cmbTipoPersona.Items.Clear();
            cmbTipoPersona.Items.Add("Profesor");
            cmbTipoPersona.Items.Add("Alumno");
            cmbTipoPersona.SelectedIndex = 0;

            // Cargar planes (opcional)
            cmbPlan.Items.Clear();
            cmbPlan.Items.Add(new { Text = "(Sin plan asignado)", Value = (int?)null });
            
            try
            {
                var planApiClient = new PlanApiClient();
                var planes = await planApiClient.GetAllAsync();
                foreach (var plan in planes)
                {
                    cmbPlan.Items.Add(new { Text = $"{plan.Descripcion} - {plan.DescripcionEspecialidad}", Value = (int?)plan.Id });
                }
            }
            catch
            {
                // Si falla la carga de planes, continuar con solo la opción "Sin plan"
            }
            
            cmbPlan.DisplayMember = "Text";
            cmbPlan.ValueMember = "Value";
            cmbPlan.SelectedIndex = 0;
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                btnRegistrar.Enabled = false;
                btnRegistrar.Text = "Registrando...";
                this.Cursor = Cursors.WaitCursor;

                var planSeleccionado = cmbPlan.SelectedItem as dynamic;
                int? idPlan = planSeleccionado?.Value;

                var request = new RegisterRequestDto
                {
                    UsuarioNombre = txtUsuarioNombre.Text.Trim(),
                    Password = txtPassword.Text,
                    Email = txtEmail.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Legajo = null, // El legajo se autogenera en el backend
                    TipoPersona = cmbTipoPersona.SelectedIndex == 1 ? TipoPersonaDto.Alumno : TipoPersonaDto.Profesor,
                    IdPlan = idPlan  // Puede ser null
                };

                var response = await _authApiClient.RegisterAsync(request);

                if (response.Success)
                {
                    string planInfo = idPlan.HasValue ? $"\nPlan: {planSeleccionado.Text}" : "\nPlan: Sin asignar";
                    
                    MessageBox.Show(
                        $"Registro exitoso!\n\n{response.Message}\n\nUsuario: {request.UsuarioNombre}\nTipo: {request.TipoPersona}{planInfo}\n\nYa puede iniciar sesión con sus credenciales.",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        $"Error al registrar:\n\n{response.Message}",
                        "Error de Registro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error inesperado al registrar:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegistrar.Enabled = true;
                btnRegistrar.Text = "Registrar";
                this.Cursor = Cursors.Default;
            }
        }

        private void lnkVolverLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioNombre.Focus();
                return false;
            }

            if (txtUsuarioNombre.Text.Length < 4)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Debe ingresar un email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Debe ingresar la dirección.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            if (cmbTipoPersona.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de persona.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoPersona.Focus();
                return false;
            }

            var edad = DateTime.Now.Year - dtpFechaNacimiento.Value.Year;
            if (dtpFechaNacimiento.Value > DateTime.Now.AddYears(-edad)) edad--;

            if (edad < 15)
            {
                MessageBox.Show("La persona debe tener al menos 15 años.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaNacimiento.Focus();
                return false;
            }

            return true;
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono == null || _isUpdatingTelefono) return;
            
            var cursorPosition = txtTelefono.SelectionStart;
            var textoOriginal = txtTelefono.Text;
            var textoLimpio = new System.Text.StringBuilder();
            
            foreach (var c in textoOriginal)
            {
                if (char.IsDigit(c) || c == '+' || c == '-' || c == ' ')
                {
                    textoLimpio.Append(c);
                }
            }
            
            if (textoOriginal != textoLimpio.ToString())
            {
                _isUpdatingTelefono = true;
                txtTelefono.Text = textoLimpio.ToString();
                txtTelefono.SelectionStart = Math.Min(cursorPosition, txtTelefono.Text.Length);
                _isUpdatingTelefono = false;
            }
        }
    }
}