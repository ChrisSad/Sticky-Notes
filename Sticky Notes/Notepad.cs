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

/* TODO 
 * - change the text files used to store data with sql databases
 * - Set form start up location to the location it was previously closed at
 * - Resize the textbox when the form is resized
*/

namespace Sticky_Notes
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();

            retrieveNotes();

            autoSaveTimer.Enabled = true;
            autoSaveTimer.Interval = 10000;//10 seconds
            autoSaveTimer.Start();

            timeLBL.Text = DateTime.Now.ToString();
        }

        private List<string> filenames;
        private List<Note> notes =  new List<Note>();

        public void retrieveNotes()
        {
            try
            {
                filenames = new List<string>();

                using (var sr = new StreamReader("notes.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        filenames.Add(line);
                    }
                    sr.Close();
                }
                if (filenames.Count > 0)
                    displayNotes();

                
            }
            catch (IOException e)
            {
                MessageBox.Show("The file could not be read:\n"+e.Message);
            }
        }

        public void displayNotes()
        {
            for (int i = 0; i < filenames.Count; i++)
            {
                Note note = new Note();
                note.updateInfo(i.ToString(),filenames[i]);
                notes.Add(note);
                note.Show();

                allNotesRTB.Text += filenames[i] + "\n";
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)//new note button
        {
            Note note = new Note();
            note.newNote(filenames.Count);
            filenames.Add($"note{filenames.Count}.txt");
            notes.Add(note);
            //note.KeyPreview = true;
            note.Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)//save button
        {
            foreach (Note note in notes)
            {
                try
                {
                    using (var sw = new StreamWriter($"note{note.noteID}.txt"))
                    {
                        sw.Write(note.noteData);
                        sw.Close();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("The file could not be found in:\n" + ex.Message);
                }

            }
            timeLBL.Text = DateTime.Now.ToString();
        }

        private void autoSaveTimer_Tick(object sender, EventArgs e)//timer interval set to 10 seconds (set in the initialization)
        {
            allNotesRTB.Clear();
            foreach (Note note in notes)
            {
                allNotesRTB.Text += $"note{note.noteID}.txt\n";

                try
                {
                    using (var sw = new StreamWriter($"note{note.noteID}.txt"))
                    {
                        sw.Write(note.noteData);
                        sw.Close();
                        timeLBL.Text = DateTime.Now.ToString();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("The file could not be found in:\n" + ex.Message);
                }

            }

            timeLBL.Text = DateTime.Now.ToString();
        }
    }
}
