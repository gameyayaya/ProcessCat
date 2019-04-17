using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessCat
{
    public partial class ProcessCat : Form
    {

        string[] s ;
        public ProcessCat()
        {
            InitializeComponent();
            ReadIni();
            InitTimer();
        }

        public void InitTimer()
        {
            try
            {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 3000; // in miliseconds
                timer1.Start();
            }
            catch (Exception err)
            {

                
            }

        }

        // 模版【timer trigger】, trigger by timer1
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "掃描時間戳記 : " + System.DateTime.Now.ToString();
                CatRun();
            }
            catch (Exception err)
            {

            }


        }

        private void CatRun()
        {
            s = richTextBox1.Lines.ToArray();
            foreach (var item in s)
            {
                Process[] processes = Process.GetProcessesByName(item.Trim().Replace("\n\r",""));
                if (processes.Length > 0)
                {
                    richTextBox1.Find(item.Trim());
                    richTextBox1.SelectionColor = Color.Green;
                }
                else
                {
                    richTextBox1.Find(item.Trim());
                    richTextBox1.SelectionColor = Color.Red;
                }
                richTextBox1.Select(0, 0);
            }
           
        }

        public void ReadIni()
        {
            try
            {
                string line;
                System.IO.StreamReader file =
                    new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\ProcessCat_Config.ini");
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox1.Text += line + "\n";
                }
            }
            catch (Exception)
            {

            }
        }




    }
}
