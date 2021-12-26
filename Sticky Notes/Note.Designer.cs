namespace Sticky_Notes
{
    partial class Note
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.notesRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // notesRTB
            // 
            this.notesRTB.BackColor = System.Drawing.SystemColors.MenuBar;
            this.notesRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notesRTB.Location = new System.Drawing.Point(12, 12);
            this.notesRTB.Name = "notesRTB";
            this.notesRTB.Size = new System.Drawing.Size(401, 426);
            this.notesRTB.TabIndex = 0;
            this.notesRTB.Text = "";
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 305);
            this.Controls.Add(this.notesRTB);
            this.Name = "Note";
            this.Text = "Note";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox notesRTB;
    }
}