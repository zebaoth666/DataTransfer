using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace dataTransfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //this code provide for only single instance running, if another instance already run, then kill else run
            Mutex mt = null;

            try
            {
                mt = Mutex.OpenExisting("dataTransfer");
            }
            catch (WaitHandleCannotBeOpenedException) { 
                
            }

            if (mt == null)
            {
                //if mutex doesnot exists create it and launch the app.
                mt = new Mutex(true, "dataTransfer");
                Application.Run(new frmMenu());

                //tell GC not to destroy the mutex until the app is running
                //and release the mutex when the app exists.
                GC.KeepAlive(mt);
                mt.ReleaseMutex();
            }
            else {
                mt.Close();
                MessageBox.Show("Aplikasi sudah berjalan","Data Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}