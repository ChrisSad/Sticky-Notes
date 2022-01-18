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

/* TODO
 * - Set the startup location to manual then load it in the same location the note was left in on previous use. Location should be save locally, default location is center of screen and the location should be reset if location is outside the screen size/resolution.
 * - Add way to change font, text size/colour, underline, strikeout,
 * - Add a picture to the DELETE NOTE button in the toolbar
 * - When the note manager (notepad) is minimized, stop the other notes from minimizing aswell.
 */


namespace Sticky_Notes
{
    public partial class Note : Form
    {
        public string noteID { get; set; }
        public string noteData { get; private set; }

        public Note()
        {
            InitializeComponent();
            //notesRTB.KeyDown += noteRTB_KeyPress;
        }

        public void updateInfo(string id, string info)
        {
            noteID = id;
            string noteFileName = info;

            StreamReader sr = new StreamReader(noteFileName);
            noteData = sr.ReadToEnd();
            sr.Close();


            notesRTB.Text = noteData;
        }

        public void newNote(int id)
        {
            noteID = id.ToString();
            try
            {
                StreamWriter sw = File.CreateText($"note{noteID}.txt");
                sw.Close();
                using (var main = new StreamWriter("notes.txt",true))
                {
                    main.WriteLine($"note{noteID}.txt");
                    main.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be written in:\n" + ex.Message);
            }
        }


        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {

                using (var sw = new StreamWriter($"note{noteID}.txt"))
                {
                    sw.WriteLine(noteData);
                    sw.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be read:\n" + ex.Message);
            }

        }


        private void notesRTB_KeyUp(object sender, KeyEventArgs e)
        {
            //noteData += e.KeyChar;
            noteData = notesRTB.Text;
        }

        private void deleteToolSripButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> filenames = new List<string>();
                using (var main = new StreamReader("notes.txt"))
                {
                    while (!main.EndOfStream)
                    {
                        string line = main.ReadLine();
                        filenames.Add(line);
                    }
                    main.Close();
                }

                using (var main = new StreamWriter("notes.txt", false))
                {
                    foreach (string filename in filenames)
                    {
                        if (!filename.Equals($"note{noteID}.txt"))
                        {
                            main.WriteLine(filename);
                        }
                    }
                    main.Close();
                }

                File.Delete($"note{noteID}.txt");
                Form.ActiveForm.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("The file could not be written in:\n" + ex.Message);
            }
        }
    }
}
