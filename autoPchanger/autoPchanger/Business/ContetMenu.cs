using System;
using System.Diagnostics;
using System.Windows.Forms;

using autoPchanger.Presentation;
using System.Drawing;
using autoPchanger.Properties;

namespace autoPchanger.Business
{
    class ContetMenu
    {
        bool isUpdateLoaded = false;
        bool isAboutLoaded = false;
        ContextMenuStrip menu;
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator seporator;

            // Pause
            item = new ToolStripMenuItem();
            item.Text = "Pause";
            item.Click += new EventHandler(Pause_Click);
            item.Image = Resources.pause;
            item.Name = "Pause";
            menu.Items.Add(item);



            // About.
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(About_Click);
            item.Image = Resources.About;
            menu.Items.Add(item);

            //Update
            item = new ToolStripMenuItem();
            item.Text = "Update";
            item.Click += new EventHandler(Update_Click);
            item.Image = Resources.settings1;
            menu.Items.Add(item);

            // Separator.
            seporator = new ToolStripSeparator();
            menu.Items.Add(seporator);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.exit;
            menu.Items.Add(item);




            return menu;
        }
        void Exit_Click(object sender, EventArgs e)
        {
            //quits the applicaiton
            Lists.Stop = true;
            Application.Exit();
        }
        void About_Click(object sender, EventArgs e)
        {

            if (!isAboutLoaded)
            {

                isAboutLoaded = true;
                AboutUs ub;
                //shows the aboutus box
                ub = new AboutUs();
                ub.ShowDialog();
                isAboutLoaded = false;
            }
        }//shows what this thing is used for 
        void Explorer_Click(object sender, EventArgs e)
        {
            //this will be used to pause the application
        }
        void Pause_Click(object sender, EventArgs e)
        {
            Business.Lists.pause = true;
            menu.Items[menu.Items.IndexOfKey("Pause")].Text = "resume";
            menu.Items[menu.Items.IndexOfKey("Pause")].Click -=new EventHandler(Pause_Click);
            menu.Items[menu.Items.IndexOfKey("Pause")].Click += new EventHandler(Resume_Click);
            menu.Items[menu.Items.IndexOfKey("Pause")].Image = Resources.play1;
            menu.Items[menu.Items.IndexOfKey("Pause")].Name = "resume";
     
            Business.Lists.treyIcon.ShowNotification("paused");
            //ProxyTraySettings p = new ProxyTraySettings();
            //p.ShowNotification();
           
            //ShowNotification();



        }
        void Resume_Click(object sender, EventArgs e)
        {
            Business.Lists.pause = false;
            menu.Items[menu.Items.IndexOfKey("resume")].Text = "pause";
            menu.Items[menu.Items.IndexOfKey("resume")].Click -= new EventHandler(Resume_Click);
            menu.Items[menu.Items.IndexOfKey("resume")].Click += new EventHandler(Pause_Click);
            menu.Items[menu.Items.IndexOfKey("resume")].Image = Resources.pause;
            menu.Items[menu.Items.IndexOfKey("resume")].Name = "Pause";
            Business.Lists.treyIcon.ShowNotification("resuming");


        }
        void Update_Click(object sender, EventArgs e)
        {

            if (!isUpdateLoaded)
            {

                isUpdateLoaded = true;
                SettingsUpdate su;
                //shows the aboutus box
                su = new SettingsUpdate();
                su.ShowDialog();
                isUpdateLoaded = false;
            }



            Business.Lists.treyIcon.ShowNotification("update");


        }

        //private ToolTip PauseCreation() { }

    }
}
