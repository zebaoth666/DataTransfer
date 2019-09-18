using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using System.IO;

namespace dataTransfer
{
    public partial class frmKoneksi : Form
    {
        private MySqlConnection conn;
        private MySqlCommand comm;
        private MySqlDataAdapter sda;
        
        public frmKoneksi()
        {
            InitializeComponent();
        }

        private Boolean cekKoneksi() {
            Boolean hasil = false;

            mod md = new mod();
            md.setConString("server=" + txtServer.Text + "; port=" + txtPort.Text + "; user id=" + txtUserName.Text + "; password=" + txtPassword.Text + "; database=information_schema");
            conn = md.getConn();
            sda = md.getSda();
            comm = md.getComm();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandText = "select schema_name DATABASE_LIST from schemata";
                comm.CommandType = CommandType.Text;
                comm.CommandTimeout = 1000;
                DataSet ds = new DataSet();
                sda.SelectCommand = comm;
                sda.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0) {
                    cmbDB.Properties.DataSource = ds.Tables[0].DefaultView;
                    cmbDB.Properties.DisplayMember = "DATABASE_LIST";
                    cmbDB.Properties.ValueMember = "DATABASE_LIST";

                    cmbDB.Enabled = true;
                }                
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Koneksi gagal", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return hasil;
        }

        private void saveSetting() {
            if (cmbDB.EditValue == "")
            {
                MessageBox.Show("Silakan pilih database yang tersedia", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbDB.Focus();
            }
            else {
                mod md = new mod();
                md.setConString("server=" + txtServer.Text + "; port=" + txtPort.Text + "; username=" + txtUserName.Text +
                        "; password=" + txtPassword.Text + "; database=" + cmbDB.EditValue + ";");

                if (File.Exists(Directory.GetCurrentDirectory() + "\\config.xml"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\config.xml");
                }
                
                createXML();
            }
        }

        private void createXML() {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("config.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Connection");

                writer.WriteStartElement("Server");
                writer.WriteString(txtServer.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Port");
                writer.WriteString(txtPort.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Username");
                writer.WriteString(txtUserName.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(txtPassword.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Database");
                writer.WriteString(cmbDB.Text);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                this.Dispose();
            }
            catch(SystemException ex) {
                MessageBox.Show(ex.Message,"Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTes_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "")   //kalo server kosong
            {
                MessageBox.Show("Silakan input data Server", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtServer.Focus();
            }
            else {
                if (txtPort.Text == "")     //kalo port kosong
                {
                    MessageBox.Show("Silakan input data Port", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPort.Focus();
                }
                else {
                    if (txtUserName.Text == "")     //kalo username kosong
                    {   //kalo username kosong
                        MessageBox.Show("Silakan input data Username", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUserName.Focus();
                    }
                    else {
                        if (txtPassword.Text == "")
                        {   //kalo password kosong
                            MessageBox.Show("Silakan input data Password", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtPassword.Focus();
                        }
                        else {
                            cekKoneksi();
                        }
                    }
                }
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            mod md = new mod();

            if (md.ini == false)
            {
                this.Dispose();
            }
            else {
                Application.Exit();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            saveSetting();
        }

        private void frmKoneksi_Load(object sender, EventArgs e)
        {
            txtServer.Focus();
        }
    }
}
