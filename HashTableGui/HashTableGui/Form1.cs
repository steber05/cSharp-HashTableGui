using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTableGui
{
    public partial class HashTableApplication : Form
    {
        public HashTableApplication()
        {
            InitializeComponent();
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            LiveStock animal;
            try
            {
                animal = Database.allAnimals[Convert.ToInt32(idTextBox.Text)];
                animal.displayInfo();
            }
            catch (Exception ex)
            {
                if(Database.allAnimals.Count > 0)
                {
                    MessageBox.Show("Invalid ID!");
                    idTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Please choose a database first\n\t Press F4");
                    idTextBox.Text = "";
                }
                
            }
            
        }

        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                queryButton.PerformClick();
            }
        }

        private void EstablishConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Choose database file";
            file.Filter = "All files | *.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Database.InitializeDatabase(file.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("\tInvalid file!\nPlease choose a valid file");
                    establishConnectionToolStripMenuItem.PerformClick();
                }
            }
        }

        private void QueryIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queryButton.PerformClick();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
//have to add file reading and error checking and read database after file reading instead of on load
