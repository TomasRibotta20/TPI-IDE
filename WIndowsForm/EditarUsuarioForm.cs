using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace WIndowsForm
{
    public partial class EditarUsuarioForm : Form
    {
        private readonly UsuarioDto _usuario;
        private readonly bool _esNuevo;
        private readonly PlanApiClient _planApiClient;

        public UsuarioDto UsuarioEditado { get; private set; }
        public bool Guardado { get; private set; }

        // Los controles están definidos en el Designer.cs

        public EditarUsuarioForm(UsuarioDto usuario = null)
        {
            _usuario = usuario ?? new UsuarioDto { Habilitado = true };
            _esNuevo = usuario == null;
            _planApiClient = new PlanApiClient();

            InitializeComponent();
            
            this.Text = _esNuevo ? "Nuevo Usuario" : "Editar Usuario";
            
            // Configurar eventos
            cmbTipoUsuario.SelectedIndexChanged += CmbTipoUsuario_SelectedIndexChanged;
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            txtTelefono.KeyPress += TxtTelefono_KeyPress;
            
            ConfigurarFormulario();
            
            this.Load += async (s, e) => await CargarDatosAsync();
        }

        private void ConfigurarFormulario()
        {
            // Configurar etiquetas de contraseña según el modo
            lblContrasenia.Text = _esNuevo ? "Contraseña*:" : "Contraseña:";
            lblConfirmarContrasenia.Text = _esNuevo ? "Confirmar Contraseña*:" : "Confirmar Contraseña:";
            
            // Configurar fecha de nacimiento por defecto
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-18);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cmbTipoUsuario.SelectedItem?.ToString();
            
            if (tipo == "Administrador")
            {
                // Ocultar panel de persona
                panelPersona.Visible = false;
                this.Height = 435;
            }
            else
            {
                // Mostrar panel de persona
                panelPersona.Visible = true;
                this.Height = 735;
            }
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Cargar planes
                var planes = await _planApiClient.GetAllAsync();
                cmbPlan.Items.Clear();
                cmbPlan.Items.Add(new { Id = (int?)null, Display = "(Sin plan asignado)" });
                foreach (var plan in planes)
                {
                    cmbPlan.Items.Add(new { Id = (int?)plan.Id, Display = $"{plan.Descripcion} - {plan.DescripcionEspecialidad}" });
                }
                cmbPlan.DisplayMember = "Display";
                cmbPlan.ValueMember = "Id";
                cmbPlan.SelectedIndex = 0;

                // Cargar datos del usuario si es edición
                if (!_esNuevo)
                {
                    txtId.Text = _usuario.Id.ToString();
                    txtUsuario.Text = _usuario.UsuarioNombre;
                    txtEmail.Text = _usuario.Email;
                    chkHabilitado.Checked = _usuario.Habilitado;

                    // Determinar tipo
                    if (_usuario.PersonaId == null)
                    {
                        cmbTipoUsuario.SelectedItem = "Administrador";
                    }
                    else if (_usuario.persona != null)
                    {
                        if (_usuario.persona.TipoPersona == TipoPersonaDto.Profesor)
                        {
                            cmbTipoUsuario.SelectedItem = "Profesor";
                        }
                        else
                        {
                            cmbTipoUsuario.SelectedItem = "Alumno";
                        }

                        // Cargar datos de persona
                        txtNombre.Text = _usuario.persona.Nombre;
                        txtApellido.Text = _usuario.persona.Apellido;
                        txtDireccion.Text = _usuario.persona.Direccion ?? "";
                        txtTelefono.Text = _usuario.persona.Telefono ?? "";
                        dtpFechaNacimiento.Value = _usuario.persona.FechaNacimiento;

                        if (_usuario.persona.IdPlan.HasValue)
                        {
                            var planItem = cmbPlan.Items.Cast<dynamic>()
                                .FirstOrDefault(x => x.Id == _usuario.persona.IdPlan.Value);
                            if (planItem != null)
                                cmbPlan.SelectedItem = planItem;
                        }
                    }
                }
                else
                {
                    // Nuevo: seleccionar Administrador por defecto
                    cmbTipoUsuario.SelectedItem = "Administrador";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async Task GuardarAsync()
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("El email es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("El formato del email no es válido. Por favor, ingrese un email válido (ejemplo: usuario@dominio.com).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return;
                }

                if (_esNuevo && string.IsNullOrWhiteSpace(txtContrasenia.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria para usuarios nuevos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasenia.Focus();
                    return;
                }

                // Validar confirmación de contraseña
                if (!string.IsNullOrWhiteSpace(txtContrasenia.Text))
                {
                    if (txtContrasenia.Text != txtConfirmarContrasenia.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden. Por favor, verifique que ambas contraseñas sean idénticas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtConfirmarContrasenia.Focus();
                        txtConfirmarContrasenia.SelectAll();
                        return;
                    }
                }

                string tipoUsuario = cmbTipoUsuario.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(tipoUsuario))
                {
                    MessageBox.Show("Debe seleccionar el tipo de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar datos de persona si NO es administrador
                if (tipoUsuario != "Administrador")
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre es obligatorio para Profesores y Alumnos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombre.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtApellido.Text))
                    {
                        MessageBox.Show("El apellido es obligatorio para Profesores y Alumnos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtApellido.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("La dirección es obligatoria para Profesores y Alumnos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                        return;
                    }
                }

                Cursor.Current = Cursors.WaitCursor;

                // Construir DTO
                UsuarioEditado = new UsuarioDto
                {
                    Id = _esNuevo ? 0 : _usuario.Id,
                    UsuarioNombre = txtUsuario.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Contrasenia = string.IsNullOrWhiteSpace(txtContrasenia.Text) ? null : txtContrasenia.Text,
                    Habilitado = chkHabilitado.Checked,
                    TipoUsuario = tipoUsuario
                };

                if (tipoUsuario != "Administrador")
                {
                    // Incluir datos de persona
                    var planSeleccionado = cmbPlan.SelectedItem as dynamic;
                    int? idPlan = planSeleccionado?.Id;

                    UsuarioEditado.persona = new PersonaDto
                    {
                        Id = _usuario.persona?.Id ?? 0,
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        TipoPersona = tipoUsuario == "Profesor" ? TipoPersonaDto.Profesor : TipoPersonaDto.Alumno,
                        IdPlan = idPlan,
                        Legajo = _usuario.persona?.Legajo ?? 0  // Se autogenera en el backend
                    };

                    // Copiar datos de persona al UsuarioDto (para compatibilidad con el backend)
                    UsuarioEditado.Direccion = txtDireccion.Text.Trim();
                    UsuarioEditado.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();
                    UsuarioEditado.FechaNacimiento = dtpFechaNacimiento.Value;
                    UsuarioEditado.IdPlan = idPlan;
                }

                Guardado = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
