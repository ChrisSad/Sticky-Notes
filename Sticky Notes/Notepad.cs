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
using System.Data.SqlClient;

//TODO change the text files used to store data with sql databases


namespace Sticky_Notes
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();

            retrieveNotes();
        }

        private List<string> filenames;

        public void retrieveNotes()
        {
            try
            {
                filenames = new List<string>();

                using (var sr = new StreamReader("notes.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        filenames.Add(sr.ReadLine());
                    }
                }

                displayNotes(filenames);
                
            }
            catch (IOException e)
            {
                MessageBox.Show("The file could not be read:\n"+e.Message);
            }
        }

        public void displayNotes(List<String> filenames)
        {
            foreach (string filename in filenames)
            {
                Note a = new Note();
                a.updateInfo(filename);
                a.Show();

                notesRTB.Text += filename + "\n";
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)//new note button
        {

            foreach(string filename in filenames)
            {

            }

            using (StreamWriter sw = File.CreateText("new.txt"))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
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
