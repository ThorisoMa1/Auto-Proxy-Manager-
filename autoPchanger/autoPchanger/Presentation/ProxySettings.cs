using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoPchanger.Presentation
{
    public partial class ProxySettings : Form
    {
        NotifyIcon notifyIcon1 = new NotifyIcon();
        string ssID = null;
        

        public ProxySettings(string ssIDName)
        {
            this.ssID = ssIDName;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtProxy.ValidatingType= typeof(System.Net.IPAddress);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextBoxValdation())
            {
                Business.Lists.InUse = false;
                //will activate the other dbmethod to insert the proxy
                DataAccess.DataAccess.Insert_ProxyAndPort(txtProxy.Text.ToLower(),txtPort.Text, ssID);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please dont leave anything empty");
            }

          
            
            
         

           
        }
        private bool TextBoxValdation()
        {
            if (string.IsNullOrEmpty(txtPort.Text)|| string.IsNullOrEmpty(txtProxy.Text))
                {
                return false;
                }
           return true;
        }//used to make sure that no box is empty

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Business.Lists.InUse = false;
            this.Close();
        }
    }
}
