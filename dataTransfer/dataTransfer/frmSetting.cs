using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dataTransfer
{
    public partial class frmSetting : Form
    {
        mod md = new mod();
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter sda;

        public frmSetting()
        {
            InitializeComponent();

            conn = md.getConn();
            comm = md.getComm();
            sda = md.getSda();

            dgOrg.CurrentCellDirtyStateChanged += new EventHandler(dgOrg_CurrentCellDirtyStateChanged);
            dgTabel.CurrentCellDirtyStateChanged += new EventHandler(dgTabel_CurrentCellDirtyStateChanged);
        }

        private void loadOrg() {
            if (conn.State == ConnectionState.Closed) 
            { 
                conn.Open(); 
            }

            comm.Connection = conn;
            comm.CommandText = "select org_code, org_name CABANG from m_organization where org_code not in " +
                                "(select msp_org_cd from m_setup_parameter)";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 10000;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0) {
                int index = 0;
                for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
                {
                    dgOrg.Rows.Add();
                    index = dgOrg.Rows.Count - 1;
                    dgOrg[1, index].Value = ds.Tables[0].Rows[a][0].ToString();
                    dgOrg[2, index].Value = ds.Tables[0].Rows[a][1].ToString();
                }
            }
        }

        private void loadTables()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            comm.Connection = conn;
            comm.CommandText = "USE information_schema;" +
                            " SELECT table_name, column_name FROM COLUMNS WHERE table_schema='factorysystem' AND column_key='pri' AND ordinal_position='1'";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 10000;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int index = 0;
                for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
                {
                    dgTabel.Rows.Add();
                    index = dgTabel.Rows.Count - 1;
                    dgTabel[1, index].Value = ds.Tables[0].Rows[a][0].ToString();
                    dgTabel[2, index].Value = ds.Tables[0].Rows[a][1].ToString();
                }
            }
        }

        private void dgOrg_CurrentCellDirtyStateChanged(object sender, EventArgs e) { 
            
        }

        private void dgTabel_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            loadOrg();
            loadTables();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (dgOrg.IsCurrentCellInEditMode) dgOrg.EndEdit();
            if (dgTabel.IsCurrentCellInEditMode) dgTabel.EndEdit();

            for (int a = 0; a <= dgOrg.Rows.Count - 1; a++) {
                MessageBox.Show(dgOrg[1,a].Value.ToString());
            }
        }
    }
}