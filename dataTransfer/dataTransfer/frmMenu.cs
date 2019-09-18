using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace dataTransfer
{
    public partial class frmMenu : Form
    {
        export ex = new export();
        import im = new import();
        mod md = new mod();
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter sda;
        Boolean online = false;
        Boolean autohide = false;
        int span = 0;
        public string myString;
        static string orgCode;

        public frmMenu()
        {
            InitializeComponent();
        }

        private Boolean cekSetting(){
            //cek setting koneksi
            if (File.Exists(Directory.GetCurrentDirectory() + "\\config.xml"))
            {
                md.setIni(false);
                return true;
            }
            else {
                md.setIni(true);
                return false;
            }
        }

        private void loadSetting() {
            String server="", port="", username="", password="", db="";

            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + "\\config.xml");

            XmlNodeList list = doc.GetElementsByTagName("Connection");

            if (list.Count > 0)
            {
                foreach (XmlNode nodeParent in list)
                {
                    foreach (XmlNode nodeChild in nodeParent.ChildNodes)
                    {
                        switch (nodeChild.Name)
                        {
                            case "Server":
                                server = nodeChild.InnerText;
                                break;
                            case "Port":
                                port = nodeChild.InnerText;
                                break;
                            case "Username":
                                username = nodeChild.InnerText;
                                break;
                            case "Password":
                                password = nodeChild.InnerText;
                                break;
                            case "Database":
                                db = nodeChild.InnerText;
                                break;
                            default:
                                break;
                        };
                    }
                }
            }

            try
            {
                myString = "server=" + server + "; port=" + port + "; username=" + username +
                    "; password=" + password + "; database=" + db + ";";

                md.setConString(myString);
                conn = md.getConn();
                comm = md.getComm();
                sda = md.getSda();

                conn.Open();
            }
            catch (MySqlException ex)
            {
                frmKoneksi konek = new frmKoneksi();
                konek.ShowDialog();
            }
            finally { 
                conn.Close(); 
            }
        }

        private String loadExPath() {
            string path="";

            if (conn.State == ConnectionState.Closed) conn.Open();
            comm.Connection = conn;
            comm.CommandText = "select msp_org_cd, msp_export_location from m_setup_parameter";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                orgCode = ds.Tables[0].Rows[0][0].ToString();
                path = ds.Tables[0].Rows[0][1].ToString();
                return path;
            }
            else {
                MessageBox.Show("Lokasi export belum disetting. Harap hubungi IT Anda", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return path;
                Application.Exit();
            }
        }

        private String loadImPath()
        {
            string path = "";

            if (conn.State == ConnectionState.Closed) conn.Open();
            comm.Connection = conn;
            comm.CommandText = "select msp_import_location from m_setup_parameter";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //orgCode = ds.Tables[0].Rows[0][0].ToString();
                path = ds.Tables[0].Rows[0][0].ToString();
                return path;
            }
            else
            {
                MessageBox.Show("Lokasi import belum disetting. Harap hubungi IT Anda", "Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return path;
                //Application.Exit();
            }
        }

        private void loadExLastTagChild()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            comm.Connection = conn;
            comm.CommandText = "select rdtpl_last_tag last_tag, last_updated_date last_date from rxl_data_transfer_push_log" +
                            " order by rdtpl_last_tag desc limit 1";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLastTagExport.Text = ds.Tables[0].Rows[0][0].ToString();
                txtLastDateExport.Text = ds.Tables[0].Rows[0][1].ToString();
            }
        }

        private void loadExLastTagParent()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            comm.Connection = conn;
            comm.CommandText = "select org_code KODE_CABANG, org_name NAMA_CABANG," +
                                " max(ifnull(rdtpl_last_tag,0)) as NO_EXPORT_AKHIR, " +
                                " date_format(ifnull(max(last_updated_date),'2014-01-01'),'%d-%m-%Y') TANGGAL_EXPORT," +
                                " concat('DT','001',org_code,'-',ifnull(max(rdtpl_last_tag),0)+1) as NO_EXPORT_BRKT, '' as STATUS," +
                                " date_format(ifnull(max(last_updated_date),'00:00:00'),'%H:%i:%s') WAKTU_EXPORT" +
                                " from m_organization left join rxl_data_transfer_push_log on org_code=rdtpl_to_org_cd" +
                                " where org_code<>'" + orgCode + "' and org_status='O' group by org_code, org_name;";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgListExport.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
                dgListExport.DataSource = ds.Tables[0].DefaultView;
                dgListExport.ReadOnly = true;
                dgListExport.Columns[0].Visible = false;
                dgListExport.Columns[dgListExport.Columns.Count - 1].Visible = false;
                dgListExport.Columns[dgListExport.Columns.Count - 2].Visible = false;
            }
        }

        private void loadImLastTagChild()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            comm.Connection = conn;
            comm.CommandText = "select ifnull(rdtpl_last_tag last_tag,0), last_updated_date last_date from rxl_data_transfer_pull_log" +
                            " order by rdtpl_last_tag desc limit 1";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLastTagImport.Text = ds.Tables[0].Rows[0][0].ToString();
                txtLastDateImport.Text = ds.Tables[0].Rows[0][1].ToString();
            }
        }

        private void loadImLastTagParent()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            comm.Connection = conn;
            comm.CommandText = "select org_code KODE_CABANG, org_name NAMA_CABANG," +
                                " max(ifnull(rdtpl_last_tag,0)) as NO_IMPORT_AKHIR, " +
                                " date_format(ifnull(max(last_updated_date),'2014-01-01'),'%d-%m-%Y') TANGGAL_IMPORT," +
                                " concat('DT','001',org_code,'-',ifnull(max(rdtpl_last_tag),0)+1) as NO_IMPORT_BRKT, '' as STATUS," +
                                " date_format(ifnull(max(last_updated_date),'00:00:00'),'%H:%i:%s') WAKTU_IMPORT" +
                                " from m_organization left join rxl_data_transfer_pull_log on org_code=rdtpl_from_org_cd" +
                                " where org_code<>'" + orgCode + "' and org_status='O' group by org_code, org_name;";
            comm.CommandTimeout = 10000;
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = comm;
            sda.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgListImport.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
                dgListImport.DataSource = ds.Tables[0].DefaultView;
                dgListImport.ReadOnly = true;
                dgListImport.Columns[0].Visible = false;
                dgListImport.Columns[dgListExport.Columns.Count - 1].Visible = false;
                dgListImport.Columns[dgListExport.Columns.Count - 2].Visible = false;
            }
        }

        private void myPingCompletedCallBack(object sender, PingCompletedEventArgs e) {
            if (e.Cancelled || e.Error != null)
            {
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.Icon = new Icon(Directory.GetCurrentDirectory() + "\\circle_red.ico");
                }
                else
                {
                    lblStatus.Text = "Offline";
                    picStatus.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\red.png");
                    online = false;
                }
            }
            
            if (e.Reply.Status == IPStatus.Success)
            {
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.Icon = new Icon(Directory.GetCurrentDirectory() + "\\btn_green.ico");
                }
                else {
                    lblStatus.Text = "Online";
                    picStatus.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\green_ball.png");
                    online = true;
                }
            }
            else {
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.Icon = new Icon(Directory.GetCurrentDirectory() + "\\btn_red.ico");
                }
                else
                {
                    lblStatus.Text = "Offline";
                    picStatus.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\red.png");
                    online = false;
                }
            }
        }

        private void checkInternet() {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(myPingCompletedCallBack);
            try
            {
                myPing.SendAsync("203.217.172.70", 3000, new byte[32], new PingOptions(64, true));
                //myPing.SendAsync("www.google.com", 3000, new byte[32], new PingOptions(64, true));
            }
            catch {
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.Icon = new Icon(Directory.GetCurrentDirectory() + "\\btn_red.ico");
                }
                else
                {
                    lblStatus.Text = "Offline";
                    picStatus.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\red.png");
                    online = false;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------

        private void frmMenu_Load(object sender, EventArgs e)
        {
            if (cekSetting() == false)
            {
                frmKoneksi konek = new frmKoneksi();
                konek.ShowDialog();
            }
            else {
                notifyIcon1.Visible = false;
                loadSetting();
                txtPathExport.Text = loadExPath();
                txtPathImport.Text = loadImPath();

                if (orgCode == "001")
                {
                    //export side
                    loadExLastTagParent();
                    panel5.Dock = DockStyle.Fill;
                    panel4.Visible = false;

                    //import side
                    loadImLastTagParent();
                    panel7.Dock = DockStyle.Fill;
                    panel6.Visible = false;
                }
                else {
                    loadExLastTagChild();
                    panel4.Dock = DockStyle.Fill;
                    panel5.Visible = false;

                    //import side
                    loadImLastTagChild();
                    panel6.Dock = DockStyle.Fill;
                    panel7.Visible = false;
                }

                timer1.Enabled = true;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkInternet();

            if (autohide == true) {
                if (span == 100)
                {
                    notifyIcon1.Visible = true;
                    this.Hide();
                }
                else {
                    span += 1;
                }
            }
        }

        private void cbAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoHide.Checked)
            {
                autohide = true;
                span = 0;
            }
            else {
                autohide = false;
                span = 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPassword pass = new frmPassword();
            pass.asal = "koneksi";
            pass.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPassword pass = new frmPassword();
            pass.asal = "setting";
            pass.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (online==true) { 
                //export side
                if (Directory.EnumerateFileSystemEntries(txtPathExport.Text, "*.zip").ToList<string>().Count > 0) {
                   ex.setPath(txtPathExport.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            if (orgCode == "001")
            {
                for (i = 0; i <= dgListImport.Rows.Count - 1; i++)
                {
                    im.DownloadFileFTP("001",dgListImport.Rows[i].Cells[1].Value.ToString(), dgListImport.Rows[i].Cells[3].Value.ToString());
                }
                loadImLastTagParent();
            }
            else
            {
                im.DownloadFileFTP("0", "0", txtLastTagImport.Text);
                loadImLastTagChild();
            }
           
        }
    }
}
