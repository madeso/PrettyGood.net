using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RemoveEmptyDirectories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dWork_DoWork(object sender, DoWorkEventArgs e)
        {
            var source = (string)e.Argument;
            mess("started on " + source);

            work(source);

            mess("done");
        }

        private void work(string dir)
        {
            if (false == Directory.Exists(dir))
            {
                mess(dir + " doesnt exist");
                return;
            }

            List<string> dirs = new List<string>(Directory.GetDirectories(dir));
            foreach (var sub in dirs)
            {
                work(sub);
            }

            int filescount = Directory.GetFiles(dir).Count();
            int dircount = Directory.GetDirectories(dir).Count();
            if (dircount + filescount > 0)
            {
                bool abort = true;
                if( filescount == 1 )
                {
                    var filename = Directory.GetFiles(dir)[0];
                    if (Path.GetFileName(filename).ToLower() == "thumbs.db")
                    {
                        try
                        {
                            File.Delete(filename);
                            abort = false;
                        }
                        catch (Exception e)
                        {
                            mess(e.Message);
                        }
                    }
                    else
                    {
                        mess(filename + " is stopping removal of directory <" + dir + ">");
                    }
                }

                if( abort )
                {
                    if( dircount == 0 ) mess("ignoring " + dir +" since it contains " + filescount + " files...");
                    if (filescount < 10)
                    {
                        foreach (var f in Directory.GetFiles(dir))
                        {
                            mess("   " + f + ": " + new FileInfo(f).Attributes.ToString());
                        }
                    }
                    return;
                }
            }

            try
            {
                var di = new DirectoryInfo(dir);
                di.Attributes = FileAttributes.Normal;
                
                Directory.Delete(dir);
            }
            catch (Exception e)
            {
                mess("ERROR: " + dir + " was not removed, " + e.Message);
                return;
            }

            mess(dir + " removed!");
        }

        private void mess(string m)
        {
            dWork.ReportProgress(0, m);
        }

        private void dGo_Click(object sender, EventArgs e)
        {
            dGo.Enabled = false;
            dInput.Enabled = false;
            dOutput.Text = "";
            dWork.RunWorkerAsync(dInput.Text);
        }

        private void dWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dOutput.AppendText((string)e.UserState + Environment.NewLine);
        }

        private void dWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dGo.Enabled = true;
            dInput.Enabled = true;
        }
    }
}
