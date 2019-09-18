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
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Net;

namespace dataTransfer
{
    /*
        pseudo code export database file to local file
        
        from list tables of xml, desc each table and set filter statement for each table (almost each...).
        after that, flush all data into notepad. After done with flushing, pack all notepad files with zip...
    */

    public class export
    {
        mod md = new mod();
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter sda;
        List<string> listFiles = new List<string>();
        static string path="";
        static int lastTag;
        static DateTime lastDate;
        String log = "";

        public void setPath(string locate) {
            path = locate;
        }

        public void loopTableChild(int index, string table, string OrgCode){
            try
            {
                string txtSql = " where tag_no=0 ";
                switch (index)
                {
                    case 0:
                        //header
                        loaddata("select " + descTable(table) + " from t_transfer_out_hdr where tag_no=0 and toh_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_transfer_out_dtl d, t_transfer_out_hdr where tag_no=0" +
                                    " and toh_doc_no=tod_doc_no and toh_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 1:
                        loaddata("select " + descTable(table) + " from s_stock_movement " + txtSql + " and move_org_cd='" +
                                   OrgCode + "'", table, "HEADER");
                        break;
                    case 2:
                        //header
                        loaddata("select " + descTable(table) + " from t_delivery_goods_hdr " + txtSql +
                                " and t_deliv_org_cd='" + OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_delivery_goods_dtl d, t_delivery_goods_hdr " + txtSql +
                                    " and t_deliv_doc_no=t_delivd_doc_no and t_deliv_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 3:
                        //header
                        loaddata("select " + descTable(table) + " from t_inventory_control_hdr " + txtSql + " and ti_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_inventory_control_dtl d, t_inventory_control_hdr" +
                                    txtSql + " and ti_doc_no=tid_doc_no and ti_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 4:
                        //header
                        loaddata("select " + descTable(table) + " from t_inventory_controlu_hdr " + txtSql + " and ti_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_inventory_controlu_dtl d, t_inventory_controlu_hdr" +
                                    txtSql + " and ti_doc_no=tid_doc_no and ti_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 5:
                        //header
                        loaddata("select " + descTable(table) + " from t_product_hdr " + txtSql + " and pro_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_product_dtl d, t_product_hdr" + txtSql +
                                    " and pro_doc_no=prod_doc_no and pro_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 6:
                        //header
                        loaddata("select " + descTable(table) + " from t_purchase_order_hdr " + txtSql + " and po_org_cd='" +
                                    OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_purchase_order_dtl d, t_purchase_order_hdr" + txtSql +
                                    " and po_doc_no=pod_doc_no and po_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 7:
                        //header
                        loaddata("select " + descTable(table) + " from t_retur_purchase_hdr " + txtSql + " and rph_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_retur_purchase_dtl d, t_retur_purchase_hdr" + txtSql +
                                    " and rph_doc_no=rpd_doc_no and rph_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 8:
                        //header
                        loaddata("select " + descTable(table) + " from t_sales_order_hdr " + txtSql + " and so_org_cd='" +
                                    OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_sales_order_dtl d, t_sales_order_hdr" + txtSql +
                                    " and so_doc_no=sod_doc_no and so_org_cd='" + OrgCode + "'", table, "DETAIL");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "store") +
                                    " from t_sales_order_store d, t_sales_order_hdr" + txtSql +
                                    " and so_doc_no=st_so_doc_no and so_org_cd='" + OrgCode + "'", table, "DETAIL1");
                        break;
                    case 9:
                        //header
                        loaddata("select " + descTable(table) + " from t_stock_adj_hdr " + txtSql + " and adjust_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select d." + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_stock_adj_dtl d, t_stock_adj_hdr h" + txtSql +
                                    " and h.adjust_doc_no=d.adjust_doc_no and adjust_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 10:
                        //header
                        loaddata("select " + descTable(table) + " from t_transfer_in_hdr " + txtSql + " and tih_org_cd='" +
                                    OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_transfer_in_dtl d, t_transfer_in_hdr h" + txtSql +
                                    " and h.tih_doc_no=d.tid_doc_no and tih_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    case 11:
                        //header
                        loaddata("select " + descTable(table) + " from t_work_in_process_hdr " + txtSql, table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_work_in_process_dtl d, t_work_in_process_hdr h" + txtSql +
                                    " and h.twip_doc_no=d.twid_doc_no", table, "DETAIL");
                        break;
                    case 12:
                        //header
                        loaddata("select " + descTable(table) + " from t_goods_receipt_hdr " + txtSql + " and grh_org_cd='" + OrgCode +
                                    "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_goods_receipt_dtl d, t_goods_receipt_hdr h" + txtSql +
                                    " and h.grh_doc_no=d.grd_doc_no and grh_org_cd='" + OrgCode +
                                    "'", table, "DETAIL");
                        break;
                    case 13:
                        loaddata("select " + descTable(table) + " from s_stock_master " + txtSql + " and stock_org_cd='" +
                                OrgCode + "'", table, "HEADER");
                        break;
                    case 14:
                        //header
                        loaddata("select " + descTable(table) + " from t_req_stock_hdr " + txtSql + " and rs_org_cd='" +
                                OrgCode + "'", table, "HEADER");

                        //detail
                        loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                                    " from t_req_stock_dtl d, t_req_stock_hdr" + txtSql +
                                    " and rs_doc_no=rsd_doc_no and rs_org_cd='" + OrgCode + "'", table, "DETAIL");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex){
                log = "Gagal Export : " + ex.ToString();
            }
        }

        public void loopTableParent(int index, string table, string OrgCode, string orgCodeDesc, string tanggal, string waktu) {
            try
            {
                string txtSql = "";

                txtSql = " where mod_date>" + tanggal.Substring(tanggal.Length - 4, 4) + "-" +
                        tanggal.Substring(4, 2) + "-" + tanggal.Substring(0, 2) + " " + waktu;

                if (table.Substring(0, 1) == "m")
                {
                    if (table == "m_item" || table == "m_style" || table == "m_category")
                    {
                        txtSql = txtSql + " and " + table.Substring(3, 50) + "_type='RM'";
                    }
                    else if (table == "m_customer_sub")
                    {
                        txtSql = txtSql + " and mcs_customer_status='O'";
                    }
                    else if (table == "m_organization")
                    {
                        txtSql = txtSql + " and org_status='O'";
                    }

                    loaddata("select " + descTable(table) + " from " + table + txtSql, table, "HEADER");
                }
                else if (table.Substring(0, 1) == "t")
                {
                    //header request
                    loaddata("select " + descTable(table) + " from t_req_stock_hdr " + txtSql + " and rs_org_cd='" +
                              OrgCode + "' and rs_to_org_cd='" + orgCodeDesc + "'", table, "HEADER");

                    //detail request
                    loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                              " from t_req_stock_dtl d, t_req_stock_hdr" + txtSql +
                              " and rs_doc_no=rsd_doc_no and rs_to_org_cd='" + OrgCode +
                              "' and rs_org_cd='" + orgCodeDesc + "'", table, "DETAIL");

                    //hdr transfer
                    loaddata("select " + descTable("t_transfer_out_hdr") + " from t_transfer_out_hdr " + txtSql +
                            " toh_org_cd='" + OrgCode + "' and toh_to_org_cd='" + orgCodeDesc + "'", table, "HEADER");

                    //dtl transfer
                    loaddata("select " + descTable(table.Substring(0, (table.Length - 3)) + "dtl") +
                              " from t_transfer_out_dtl d, t_transfer_out_hdr" + txtSql +
                              " and toh_doc_no=tod_doc_no and toh_to_org_cd='" + OrgCode +
                              "' and rs_org_cd='" + orgCodeDesc + "'", table, "DETAIL");
                }
                else
                {
                    loaddata("select " + descTable(table) + " from " + table + txtSql, table, "HEADER");
                }

                if (table == "m_item")
                {
                    //m_size_definition
                    string txt = "select distinct s.* from m_item, m_size_definition s, m_style " +
                                txtSql + " and msd_style_id=item_style_id;";
                    loaddata(txt, "m_size_definition", "HEADER");

                    //m_size_link_group
                    txt = "selec s.* from m_size_link_group s, m_size_group g " + txtSql +
                        " and s.size_group_id=g.size_group_id;";
                    loaddata(txt, "m_size_link_group", "HEADER");
                }
            }
            catch (Exception ex) {
                log = "Gagal Export : " + ex.ToString();
            }
        }

        //describe each table
        private string descTable(String tabName){
            string txt = "";

            try
            {
                conn = md.getConn();
                comm = md.getComm();
                sda = md.getSda();

                if (conn.State == ConnectionState.Closed) conn.Open();

                //get description of table
                comm.Connection = conn;
                comm.CommandText = "desc " + tabName;
                comm.CommandTimeout = 10000;
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                sda.SelectCommand = comm;
                sda.Fill(ds);
                conn.Close();

                //put into list 1d
                List<string> list = new List<string>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
                    {
                        list.Add(ds.Tables[0].Rows[a][0].ToString() + "~" + ds.Tables[0].Rows[a][1].ToString());
                    }
                }

                //start to divide first column and second column
                string[] str;
                str = list[0].Split('~');
                txt = str[0].ToString();

                //loop each row to syntesize full text of list of columns
                for (int b = 1; b <= list.Count - 1; b++)
                {
                    str = list[b].Split('~');

                    switch (str[1].ToString())
                    {
                        case "datetime":
                            txt = txt + ", date_format(" + str[0].ToString() + ",'%Y-%m-%d %H:%i:%s')";
                            break;
                        case "double":
                            txt = txt + ", ifnull(" + str[0].ToString() + ")";
                            break;
                        case "decimal":
                            txt = txt + ", ifnull(" + str[0].ToString() + ")";
                            break;
                        case "int":
                            txt = txt + ", ifnull(" + str[0].ToString() + ",0)";
                            break;
                        default:
                            txt = txt + ", " + str[0].ToString();
                            break;
                    }
                }

                //return txt that contains full columns list
                return txt;
            }
            catch (Exception ex)
            {
                return txt;
                log = "Gagal Export : " + ex.ToString();
            }
        }

        //load data from database
        public void loaddata(string strSQL, string table, string stat)
        {
            try
            {
                string fileName = "";

                if (conn.State == ConnectionState.Closed) conn.Open();

                DataSet ds = new DataSet();
                comm.CommandText = strSQL;
                comm.CommandTimeout = 10000;
                comm.CommandType = CommandType.Text;
                sda.SelectCommand = comm;
                sda.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    switch (stat)
                    {
                        case "DETAIL":
                            fileName = path + table.Substring(0, (table.Length - 3)) + "dtl.txt";
                            break;
                        case "DETAIL1":
                            fileName = path + table.Substring(0, (table.Length - 3)) + "store.txt";
                            break;
                        default:
                            fileName = path + table + ".txt";
                            break;
                    }
                }

                exportText(ds.Tables[0], fileName);
                listFiles.Add(fileName);
            }
            catch (Exception ex)
            {
                log = "Gagal Export : " + ex.ToString();
            }
        }

        //flush data from database into notepad file
        public void exportText(DataTable table, String location){
            try
            {
                StreamWriter writer = new StreamWriter(path);

                foreach (DataRow row in table.Rows)
                {
                    for (int a = 0; a <= table.Columns.Count - 1; a++)
                    {
                        writer.Write(row[a].ToString());
                        if (a != table.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.Write("|");
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                log = "Gagal Export : " + ex.ToString();
            }
        }

        //pack the notepad files into zip
        public bool Zip (ArrayList al, string dstFile, int bufferSize){
            try
            {
                FileStream fileStreamIn = null;
                FileStream fileStreamOut = new FileStream(dstFile, FileMode.Create, FileAccess.Write);
                ZipOutputStream zipOutStream = new ZipOutputStream(fileStreamOut);
                zipOutStream.Password = "S@lvation99";
                Byte[] buffer = new Byte[bufferSize - 1];

                int size;
                for (int i = 0; i <= al.Count - 1; i++)
                {
                    ZipEntry entryx = new ZipEntry(Path.GetFileName(al[i].ToString()));
                    zipOutStream.PutNextEntry(entryx);
                    fileStreamIn = new FileStream(al[i].ToString(), FileMode.Open, FileAccess.Read);
                    do
                    {
                        size = fileStreamIn.Read(buffer, 0, buffer.Length);
                        zipOutStream.Write(buffer, 0, size);
                    } while (size > 0);

                    fileStreamIn.Flush();
                    fileStreamIn.Dispose();
                    fileStreamIn.Close();
                }

                zipOutStream.Close();
                fileStreamOut.Close();

                string fileToDelete;
                for (int i = 0; i < al.Count - 1; i++) {
                    fileToDelete = al[i].ToString();
                    if (System.IO.File.Exists(fileToDelete) == true) {
                        System.IO.File.Delete(fileToDelete);
                    }
                }

                return true;
            }
            catch (Exception ex) {
                string fileToDelete;
                for (int i = 0; i < al.Count - 1; i++)
                {
                    fileToDelete = al[i].ToString();
                    if (System.IO.File.Exists(fileToDelete) == true)
                    {
                        System.IO.File.Delete(fileToDelete);
                    }
                }

                return false;

                log = "Gagal Export : " + ex.ToString();
            }
        }

        private void uploadFiles()
        {
            string url = "203.217.172.70";
            string user = "bucchcom";
            string pass = "S@lv4tion123";

            //check if any file zip exists
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*.zip");

            foreach (FileInfo file in files){
                //upload file
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(url);
                req.Proxy = null;
                req.Method = WebRequestMethods.Ftp.UploadFile;
                req.Credentials = new NetworkCredential(user, pass);
                req.UseBinary = true;
                req.UsePassive = true;
                byte[] data = File.ReadAllBytes(file.ToString());

            }
        }
    }
}