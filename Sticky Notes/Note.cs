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


namespace Sticky_Notes
{
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
        }

        public void updateInfo(string info)
        {
            this.notesRTB.Text = info;

        }
    }
}
