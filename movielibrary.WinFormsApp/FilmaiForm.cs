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
using movielibrary.WinFormsApp.Models;
using System.Diagnostics;

namespace movielibrary.WinFormsApp
{
    public partial class FilmaiForm : Form
    {
        public FilmaiForm()
        {
            InitializeComponent();

            var db = new movielibraryContext();
            foreach (Movie movie in db.Movies)
            {
                var picturebox = new PictureBox()
                {
                    Name = movie.MovieId.ToString(),
                    Size = new Size(150, 230),
                    ImageLocation = movie.Photo,
                    SizeMode = PictureBoxSizeMode.StretchImage,                    
                };
                var label = new Label()
                {                    
                    Text = movie.Title,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.TopCenter,
                };

                picturebox.Controls.Add(label);
                flowLayoutPanel1.Controls.Add(picturebox);           


                picturebox.DoubleClick += new EventHandler(this.pictureboxDoubleClick);
            }
        }

        private void pictureboxDoubleClick(object sender, EventArgs e)
        {
            //PictureBox currentpicturebox = (PictureBox)sender;
            //// #1. Make second form
            //Filmas form = new Filmas(int.Parse(currentpicturebox.Name)); //konstruktorius, paima filmo id 
            //form.Width = this.Width;
            //form.Height = this.Height;

            //// #3. Set second form's start position as same as parent form
            //form.StartPosition = FormStartPosition.Manual;
            //form.Location = new Point(this.Location.X, this.Location.Y);

            //// #4. Set parent form's visible to false
            //this.Visible = false;

            //// #5. Open second dialog
            //form.ShowDialog();
            //// #6. Set parent form's visible to true
            //this.Visible = true;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Somevariables.Offset += 4;
           // ImageLoad(Somevariables.Offset);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    // flowLayoutPanel1.Controls.Clear();
            //    //FilmaiForm();
            //    // #1. Make second form
            //    Form form = new FilmaiForm(); //konstruktorius, paima filmo id 
            //    form.Width = this.Width;
            //    form.Height = this.Height;

            //    // #3. Set second form's start position as same as parent form
            //    form.StartPosition = FormStartPosition.Manual;
            //    form.Location = new Point(this.Location.X, this.Location.Y);

            //    form.Show();
            //    this.Close();
            //
        }
    }
}
