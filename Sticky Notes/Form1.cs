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

namespace Sticky_Notes
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();

            retrieveNotes();
        }

        public void retrieveNotes()
        {
            try
            {
                string text;
                using (var sr = new StreamReader("notes.txt"))
                {
                    text = sr.ReadToEnd();
                    
                }
                notesRTB.Text = text;
            }
            catch (IOException e)
            {
                MessageBox.Show("The file could not be read:\n"+e.Message);
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)//new note button
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)//save button
        {
            try
            {
                using (var sr = new StreamWriter("notes.txt"))
                {
                    sr.Write(notesRTB.Text);

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be written in:\n" + ex.Message);
            }
        }

        
    }
}
