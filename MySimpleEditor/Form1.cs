using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MySimpleEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            SaveFile();


        }

        private void SaveFile()
        {
            if (lblFileName.Text.Length == 0)
            {
                diagSave.ShowDialog();
                if (diagSave.FileName != "")
                {
                    File.WriteAllText(diagSave.FileName, txtContent.Text);
                    lblFileName.Text = diagSave.FileName;
                    lblFileFreshStatus.Text = "";
                }
                else
                {
                    lblStatus.Text = "you did not enter a name for the file to be saved";

                }

            }
            else
            {
                File.WriteAllText(lblFileName.Text, txtContent.Text);
                lblFileFreshStatus.Text = "";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            diagOpen.Filter = "TextFile|*.txt|Docutatn|*.docx";
            diagOpen.ShowDialog();

           txtContent.Text= File.ReadAllText(diagOpen.FileName);
            lblFileName.Text = diagOpen.FileName;


        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            lblFileFreshStatus.Text = "*";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(lblFileFreshStatus.Text=="*")
            {
                DialogResult exitdiagResult = MessageBox.Show("There are Unsaved Changes to the file, Do you Want to Save these Cahnges?","Alert!, Unsaved Changes",MessageBoxButtons.YesNo);

                if (exitdiagResult == DialogResult.Yes) 
                {
                    SaveFile();
                
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagFont.ShowDialog();
            txtContent.Font = diagFont.Font;
        }
    }
}
