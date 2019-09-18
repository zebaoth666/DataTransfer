using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

using System.Text;

namespace dataTransfer
{
    public class mod
    {
        public static String conString;
        public MySqlConnection conn;
        public MySqlCommand comm;
        public MySqlDataAdapter sda;
        public MySqlDataReader sdr = null;
        public MySqlTransaction trans;
        public Boolean ini;

        public void setConString(string txt) {
            conString = txt;
        }

        public String getConString()
        {
            return conString;
        }
        
        public MySqlConnection getConn()
        {
            getConString();
            conn = new MySqlConnection(conString);
            return conn;
        }

        public MySqlCommand getComm()
        {
            comm=new MySqlCommand();
            return comm;
        }

        public MySqlDataAdapter getSda()
        {
            sda = new MySqlDataAdapter();
            return sda;
        }

        public MySqlDataReader getSdr()
        {
            return sdr;
        }

        public MySqlTransaction getTrans()
        {
            return trans;
        }

        public void setIni(Boolean ini) {
            this.ini = ini;
        }
    }
}
