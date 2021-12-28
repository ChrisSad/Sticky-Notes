using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Sticky_Notes
{
    public partial class Note : Form
    {
        public string noteID { get; set; }
        public string noteData { get; private set; }

        public Note()
        {
            InitializeComponent();
            notesRTB.KeyPress += noteRTB_KeyPress;
        }

        public void updateInfo(string info)
        {
            noteID = info.Split(' ')[0];
            string[] line = info.Split(' ').ToArray();
            for (int i = 1; i < line.Length; i++)
            {
                noteData += line[i]+" ";
            }
            notesRTB.Text = noteData;
        }

        public void newNote(int id)
        {
            noteID = id.ToString();
            try
            {
                using (var sr = new StreamWriter("notes.txt",true))
                {
                    sr.WriteLine($"{noteID} ");
                    sr.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be written in:\n" + ex.Message);
            }
        }

        void noteRTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show($"{e.KeyChar}");
            noteData += e.KeyChar;

            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //reads the text file and saves the entire list to a array
            //writes array in the text file with the data changed for the row with the same id

            List<string> lines = new List<string>();
            try
            {

                using (var sr = new StreamReader("notes.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
                    sr.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be read:\n" + ex.Message);
            }

            try
            {

                using (var sw = new StreamWriter("notes.txt"))
                {
                    foreach (var line in lines)
                    {
                        if (line.Split(' ')[0].Equals(noteID))
                        {
                            sw.WriteLine($"{noteID} {noteData}");
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                    sw.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be written in:\n" + ex.Message);
            }
        }
    }
}
