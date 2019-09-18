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
using System.Net;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;
using System.Collections;

namespace dataTransfer
{
    /*
        pseudo code import database file to local file
        
        from list tables of xml, desc each table and set filter statement for each table (almost each...).
        after that, flush all data into notepad. After done with flushing, pack all notepad files with zip...
    */

    public class import
    {
        mod md = new mod();
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter sda;
        MySqlTransaction trc;
        List<string> listFiles = new List<string>();
        string inputfilepath;
        string ftphost = "203.217.172.70";
        const string ftpfilepath = "/public_ftp/trial/";
        string ftpfullpath;
        string branchcode;
        string namafiletemp;
        string ftpfullpathwithfile;
        string local;
        string table_setup;
        string table_temp;
        string pull_location_setup;
        string temp_pull_location_setup;
        string filenametemp;
        string username = "bucchcom";
        string pass = "S@lv4tion123";
        string newfilename;
        Boolean M_FLAG;
        Boolean m_sukses;
        string Trace;
        Boolean M_Smart= true;
        long lasttaginc;
        string codepengirim;
        string codepenerima;
        ArrayList al = new ArrayList();
        String FileToDelete;
        int i;
        String drive;
        String log;

        //cek branchnya
        public string branch()
        {
            try
            {
                conn = md.getConn();
                comm = md.getComm();
                sda = md.getSda();

                table_setup = "";
                table_temp = "";
                if (conn.State == ConnectionState.Closed) conn.Open();

                // ambil code org
                comm.Connection = conn;
                comm.CommandText = "select msp_org_cd from m_setup_parameter ";
                comm.CommandTimeout = 10000;
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                sda.SelectCommand = comm;
                sda.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    table_temp = ds.Tables[0].Rows[0][0].ToString();
                }
                return table_setup = table_temp;
            }
            catch (Exception ex)
            {
                log = "Gagal Ambil Branch : " + ex.Message.ToString();
                return "";
            }
        }
        // get location path pull
        public string location()
        {
            try
            {
                conn = md.getConn();
                comm = md.getComm();
                sda = md.getSda();

                pull_location_setup = "";
                temp_pull_location_setup = "";
                if (conn.State == ConnectionState.Closed) conn.Open();
                //get description of table
                comm.Connection = conn;
                comm.CommandText = "select msp_import_location from m_setup_parameter ";
                comm.CommandTimeout = 10000;
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                sda.SelectCommand = comm;
                sda.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return temp_pull_location_setup = ds.Tables[0].Rows[0][0].ToString();
                }
                return pull_location_setup = temp_pull_location_setup;
            }
            catch(Exception ex)
            {
                log = "Gagal Ambil Location Pull : "+ ex.Message.ToString();
                return "";
            }
        }
        //download file from FTP
        public void DownloadFileFTP(string codeasal,string codecabang, string lasttagtemp)
        {
            try
            {
                String line;
                inputfilepath = location();
                List<string> filename = new List<string>();
                ftpfullpath = "ftp://" + ftphost + ftpfilepath;
                List<string> FtpListing = new List<string>();
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                request.Credentials = new NetworkCredential(username, pass);

                request.Method = WebRequestMethods.Ftp.ListDirectory;

                filenametemp = "";
                // dapetting smua list filenamenya
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, true))
                        {
                            //while (!reader.EndOfStream)
                            while ((line = reader.ReadLine()) != null)
                            {
                                filenametemp = line;
                                if (filenametemp != "." && filenametemp != "..")
                                {
                                  if (filenametemp.Substring(filenametemp.Length - 3, 3).ToString() == "zip")
                                   {
                                        FtpListing.Add(filenametemp);
                                   }
                                }
                            }
                        }
                    }
                }
                //sortir sesuai kebutuhan aja
                ftpfullpathwithfile = "";
                local = "";
                //cek dahulu apakah dia pusat atau cabang
                if (codecabang == "0"){
                    //ini untuk cabang
                    branchcode = branch();
                }
                else
                {
                    //ini untuk pusat
                    branchcode = codecabang;
                }
                namafiletemp = "";
                string namafiletemppengirim = "";
                lasttaginc = Convert.ToInt64(lasttagtemp) + 1;
                List<string> namafile = new List<string>();
                FtpListing.Sort();
                foreach (string value in FtpListing)
                {
                    namafiletemp = value.Substring(5, 3);
                    if (codecabang == "0")
                    { // for cabang
                        if (namafiletemp == branchcode)
                        {
                            namafile.Add(value);
                        }
                    }else
                    { //for pusat
                        namafiletemppengirim = value.Substring(2, 3);
                        if (namafiletemp == codeasal && namafiletemppengirim == codecabang)
                        {
                            namafile.Add(value);
                        }
                    }
                }
                //begin downloadFileFTP
                if (namafile.Count > 0)
                {
                    namafile.Sort();
                    foreach (string value in namafile)
                    {
                        ftpfullpathwithfile = ftpfullpath + "/" + value;
                        using (WebClient request1 = new WebClient())
                        {
                            request1.Credentials = new NetworkCredential(username, pass);
                            byte[] fileData = request1.DownloadData(ftpfullpathwithfile);
                            local = inputfilepath + value;
                            //kalau ada di local maka hapus dahulu yang di local
                            if (File.Exists(local) == true)
                            {
                                File.SetAttributes(local, FileAttributes.Normal);
                                File.Delete(local);
                            }
                            using (FileStream file = File.Create(local))
                            {
                                file.Write(fileData, 0, fileData.Length);
                                file.Close();
                            }
                        }
                    }
                    //delete file ftpnya
                    deleteftpfile(namafile, branchcode, lasttaginc, codeasal);
                }
            }catch(Exception ex)
            {
                log = "Gagal Download Dari Ftp : "+ex.Message.ToString();
            }  
        }
        private void deleteftpfile(List<string> deletefile,string branchcode,long lasttag,string codeasal)
        {
            try
            {
                Boolean lanjut = true;
                ftpfullpath = "ftp://" + ftphost + ftpfilepath;
                deletefile.Sort();
                foreach (string value in deletefile)
                {
                    lanjut = false;
                    ftpfullpathwithfile = ftpfullpath + "/" + value;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpfullpathwithfile);
                    request.Credentials = new NetworkCredential(username, pass);
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                }
                //begin pull
                if (!lanjut)
                {
                    beginpull(codeasal, lasttag, branchcode);
                }
            }
            catch(Exception ex)
            {
                log = "Gagal Delete Ftp File : "+ ex.Message.ToString();
            }
        }
        // start to pull
        public void beginpull(string codeasal, long lasttag, string branchcode)
        {
            try
            {
                codepengirim = "";
                codepenerima = "";
                if (codeasal == "0")
                {
                    codepengirim = "001";
                    codepenerima = branchcode;
                } 
                else
                {
                    codepengirim = branchcode;
                    codepenerima = "001";
                }
                string namafile= "DT"+codepengirim+codepenerima+"-"+Convert.ToString(lasttag)+".zip";
                string loc = location();
                drive = loc.Substring(0, 1);
                List<string> filename = new List<string>();
                int mi = 0;
                int mx = 0;
                Random rand = new Random();
                filename.AddRange(filepull());
                filename.Sort();
                String filedestination;
                String filefrom;
                foreach (string value in filename)
                {
                    if (value == namafile)
                    {
                        //masuk nih...
                        mi = Convert.ToInt32(rand.Next(0,100) * 10);
                        if (mi == 1) {
                             mx = 500;
                        }else if(mi == 2) {
                            mx = 700;
                        }else if(mi == 3) {
                            mx = 300;
                        }else if(mi == 4) {
                            mx = 200;
                        }else if(mi == 5) { 
                            mx = 900;
                        }else if(mi == 6) {
                            mx = 1200;
                        }else if(mi == 7) {
                            mx = 200;
                        }else if (mi == 8) {
                            mx = 500;
                        }else if (mi == 9) {
                            mx = 600;
                        }else{
                            mx = 700;
                       }
                        newfilename = loc + value;
                        System.Threading.Thread.Sleep(mx);
                        //start a new thread to unzip it
                        Thread ta = new Thread(UnZipx);
                        ta.Start();
                        //----------------------------------------------------------

                        do {
                           
                        }while (M_Smart == true);
                       //update lasttag dan namafile
                        M_Smart = true;
                        if (m_sukses == true)
                        {
                            filedestination =  drive + ":\\Data Transfer\\imported\\" + value;
                            filefrom = loc + value ;
                            if (File.Exists(filedestination) == true)
                            {
                                File.SetAttributes(filedestination, FileAttributes.Normal);
                                File.Delete(filedestination);
                            }
                            File.Move(filefrom,filedestination);
                            namafile = "DT" + codepengirim + codepenerima + "-" + Convert.ToString(lasttaginc) + ".zip";
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                log = "Gagal Pull Data : "+ex.Message.ToString();
            }
        }
        private void UnZipx()
        {
            UnZip(newfilename, location(), 4096);
        }
        private void UnZip(string srcfile,string location,int buffersize)
        {
            try
            {
                Trace = "";
                M_FLAG = true;
                m_sukses = true;
                FileInfo ff = new FileInfo(srcfile);
                // pasti masuk
                Trace = "Gagal Membuka File";
                conn = md.getConn();
                comm = md.getComm();
                sda = md.getSda();
                trc = md.getTrans();

                if (conn.State == ConnectionState.Closed) conn.Open();
                trc = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trc;

                FileStream fileStreamIn = new FileStream(srcfile, FileMode.Open, FileAccess.Read);
                ZipInputStream zipInStream = new ZipInputStream(fileStreamIn);
                zipInStream.Password = "S@lv4tion99";
                ZipEntry entry = zipInStream.GetNextEntry();
                FileStream fileStreamOut;
                int size;
                Byte[] buffer = new Byte[buffersize - 1];
                al.Clear();
                do
                {
                    fileStreamOut = new FileStream((location + "\\") + entry.Name, FileMode.Create, FileAccess.Write);

                    do
                    {
                        size = zipInStream.Read(buffer, 0, buffer.Length);
                        fileStreamOut.Write(buffer, 0, size);
                    } while (size > 0);
                    al.Add(entry);
                    entry = zipInStream.GetNextEntry();
                    fileStreamOut.Flush();
                    fileStreamOut.Dispose();
                    fileStreamOut.Close();
                } while (entry != null);
                zipInStream.Close();
                fileStreamIn.Close();
                String namaTable;
                String FileToDelete;
                int a;
                String filename;
                String arraykolom;
                for (a = 0; a <= al.Count - 1; a++)
                {
                    Trace = "Gagal menjalankan bulk insert " + al[a].ToString();
                    filename = location + al[a].ToString();
                    namaTable = al[a].ToString().Substring(0, al[a].ToString().Length - 4);

                    arraykolom = "";

                    //buat table temporary
                    comm.CommandText = "create temporary table temp like " + namaTable;
                    comm.CommandTimeout = 10000;
                    comm.ExecuteNonQuery();

                    //drop semua index di table temporary
                    comm.CommandText = "drop index `primary` on temp";
                    comm.CommandTimeout = 10000;
                    comm.ExecuteNonQuery();

                    //rangkai array kolom
                    comm.CommandText = "select column_name from information_schema.COLUMNS WHERE TABLE_NAME='" + namaTable +
                                       "' and table_schema='factorysystem'";
                    comm.CommandTimeout = 10000;
                    DataSet ds = new DataSet();
                    sda.SelectCommand = comm;
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        arraykolom = ds.Tables[0].Rows[0][0].ToString() + "=values(" +
                                     ds.Tables[0].Rows[0][0].ToString() + ")";
                        int x;
                        for (x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                        {
                            arraykolom = arraykolom + ", " + ds.Tables[0].Rows[x][0].ToString() + "=values(" +
                                         ds.Tables[0].Rows[x][0].ToString() + ")";
                        }
                    }
                    //exe import file
                    comm.CommandText = "LOAD DATA LOCAL INFILE '" + filename + "'" +
                                                    " INTO TABLE temp" +
                                                    " FIELDS TERMINATED BY ';' " +
                                                    " LINES TERMINATED BY '|\r\n' ";
                    comm.CommandTimeout = 10000;
                    comm.ExecuteNonQuery();

                    //insert from temp_table into ori_table
                    comm.CommandText = "insert into " + namaTable +
                                        " select * from temp on duplicate key update " + arraykolom;
                    comm.CommandTimeout = 10000;
                    comm.ExecuteNonQuery();

                    //drop temp. table
                    comm.CommandText = "drop temporary table temp";
                    comm.CommandTimeout = 10000;
                    comm.ExecuteNonQuery();
                }
                //--------------INSERT TO LOG ---------------------
                Trace = "Gagal insert ke log";
                comm.CommandText = "insert into rxl_data_transfer_pull_log values('" + codepenerima + "','" + codepengirim +
                                        "','" + lasttaginc + "',now())";
                comm.CommandTimeout = 10000;
                comm.ExecuteNonQuery();

                //---------------------------------------------------
                trc.Commit();

                Trace = "Penghapusan file gagal";
                lasttaginc++;
                //----------------DELETE FILE-----------------------
                for (i= 0; i<=al.Count - 1;i++)
                {
                    FileToDelete = location + al[i].ToString();
                    if (File.Exists(FileToDelete) == true) {
                           File.Delete(FileToDelete);
                    }
                }
                //---------------------------------------------------
            }
            catch( Exception ex)
            {
                log = "Gagal Unzip dan insert data : " + ex.Message.ToString();
                trc.Rollback();
                m_sukses = false;
                //----------------DELETE FILE-----------------------
                
                for (i = 0; i <= al.Count - 1; i++)
                {
                    FileToDelete = location + al[i].ToString();
                    if (File.Exists(FileToDelete) == true)
                    {
                        File.Delete(FileToDelete);
                    }
                }
                //---------------------------------------------------
            }
            finally
            {
                M_Smart = false;
                conn.Close();
            }
           
        }
        //get file zip in local
        public List<string> filepull()
        {
            List<string> listRange = new List<string>();
            try
            {
                listRange.Clear();
                DirectoryInfo folderInfo = new DirectoryInfo(location());
                FileInfo[] arrFilesInFolder;
                arrFilesInFolder = folderInfo.GetFiles("*.zip");
                foreach (FileInfo value in arrFilesInFolder)
                {
                    listRange.Add(value.Name);
                }
                return listRange;
            }
            catch (Exception ex)
            {
                listRange.Clear();
                log = "Gagal Ambil File Local : "+ex.Message.ToString();
                return listRange;
            }
        }
    }
}