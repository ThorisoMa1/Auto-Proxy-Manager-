using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoPchanger.Business;

namespace autoPchanger.Presentation
{
    public partial class SettingsUpdate : Form
    {
        string SSID;
        public SettingsUpdate()
        {
            
            InitializeComponent();

       }

        private void SettingsUpdate_Load(object sender, EventArgs e)
        {
            SSID = Lists.ssid;
          
            txtProxy.ValidatingType = typeof(System.Net.IPAddress);
            lbl_upade.Text = lbl_upade.Text + " " + SSID;
            MessageBox.Show("pleas leave fields blank and press okay  if you want proxy to be blank");
            Lists.pause = true;
            Lists.recentConnection = false;
            

        }
        private bool TextBoxValdation()
        {
            if (string.IsNullOrEmpty(txtPort.Text) || string.IsNullOrEmpty(txtProxy.Text))
            {
                return false;
            }
            return true;
        }//used to make sure that no box is empty

        private void button1_Click(object sender, EventArgs e)
        {
            
                Business.Lists.InUse = false;
            //will activate the other dbmethod to insert the proxy
            if (!string.IsNullOrEmpty(SSID))
            {
                txtProxy.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;//exludes the mask for now
                txtPort.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string s = txtProxy.MaskedTextProvider.ToDisplayString() ;

                if (!string.IsNullOrEmpty(txtPort.MaskedTextProvider.ToString())||!string.IsNullOrEmpty(txtProxy.MaskedTextProvider.ToString()) )
                {
                    txtProxy.TextMaskFormat = MaskFormat.IncludeLiterals;//exludes the mask for now
                    txtPort.TextMaskFormat = MaskFormat.IncludeLiterals;
                    DataAccess.DataAccess.Update_Proxy(SSID, txtProxy.Text, txtPort.Text);
                }
                else
                {
                    DataAccess.DataAccess.Update_Proxy(SSID, null,null);
                }
                
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Setting have been updated");
                Lists.pause = false;
                //Lists.Setproxy = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please connect to a known network an then try update the seetings");
                Lists.pause = false;
                this.Close();
            }
            
           
             
           
               
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Lists.pause = false;
            this.Close();

        }
    }
}
