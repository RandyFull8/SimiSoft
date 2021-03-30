using DevExpress.XtraEditors;
using SimiSoft.BML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimiSoft
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                if(new Usuario
                {
                    username=txtUsuario.Text,
                    password=txtPasword.Text
                }.Login()!=null)
                {
                    XtraMessageBox.Show("Acceso correcto");
                    DialogResult = DialogResult.OK;

                    this.Hide();

                    frmMain frm2 = new frmMain();

                    frm2.Show();
                } else
                {
                    XtraMessageBox.Show("Error en las credenciales");
                    txtPasword.Text = "";
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                    //
                }
            }
        }
            
        private bool Validar()
        {
            var ban = false; 
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.ErrorText = "Ingresa el usuario";
                txtUsuario.Focus();
                ban = true;
            }
            if(string.IsNullOrEmpty(txtPasword.Text))
            {
                txtPasword.ErrorText = "Ingresa una contraseña";
                if(!ban)
                {
                    txtPasword.Focus();
                    ban = true;
                }
                
            }
            return !ban;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}