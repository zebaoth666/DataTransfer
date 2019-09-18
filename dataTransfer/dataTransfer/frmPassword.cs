using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dataTransfer
{
    public partial class frmPassword : Form
    {
        public string asal;
        public frmPassword()
        {
            InitializeComponent();
            this.txtPassword.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (txtPassword.Text == "S@lv4tion123")
                {
                    if (asal == "koneksi")
                    {
                        this.Dispose();
                        frmKoneksi konek = new frmKoneksi();
                        konek.ShowDialog();
                    }
                    else {
                        this.Dispose();
                        frmSetting konek = new frmSetting();
                        konek.ShowDialog();
                    }                    
                }
                else {
                    this.Dispose();
                }
            }
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
