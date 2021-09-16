using movielibrary.WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movielibrary.WinFormsApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new movielibraryContext();
            var actor = db.Actors.FirstOrDefault();
            textBox1.Text = actor.FirstName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            FilmaiForm filmai = new FilmaiForm(); //this is the change, code for redirect  

            // #2. Set second form's size
            filmai.Width = this.Width;
            filmai.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            filmai.StartPosition = FormStartPosition.Manual;
            filmai.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            filmai.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            var filmai = new AddNewFilm(); //this is the change, code for redirect  

            // #2. Set second form's size
            filmai.Width = this.Width;
            filmai.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            filmai.StartPosition = FormStartPosition.Manual;
            filmai.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            filmai.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;
        }
    }
}
