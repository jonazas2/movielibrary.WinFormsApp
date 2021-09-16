using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using movielibrary.WinFormsApp.Models;
using System.Diagnostics;

namespace movielibrary.WinFormsApp
{
    public partial class AddNewFilm : Form
    {
        // When you scale image size remember the aspect ratio which is 1:0.675 !!!!!!

        public AddNewFilm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var movie = new Movie
            {
                Title = textBox1.Text,
                ReleaseDate = dateTimePicker2.Value,
                Length = dateTimePicker1.Value.TimeOfDay,
                Description = textBox2.Text,
                Photo = textBox3.Text,               
            };

            var context = new movielibraryContext();

            context.AddAsync(movie);
            context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = textBox3.Text;

            //if picture is null leave textbox enabled, something is not fully working need fixing
            textBox3.Enabled = pictureBox1.Image == null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox3.Text = null;
            pictureBox1.Image = null;
        }

        //public AddNewFilm(int ID) 
        //{            
        //    InitializeComponent();
        //    MovieID = ID;
        //    this.ActiveControl = label1;
        //    LoadFilm();
        //    LoadingListboxes();
        //    LoadingListboxesFromMovie();
        //    button1.Enabled = false;
        //    if (!String.IsNullOrEmpty(oldimage)) pictureBox1_null = false;
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1_null)
        //    {
        //        MessageBox.Show("Neįdėjote nuotraukos!!!");
        //        return;
        //    }

        //    string filmname = textBox1.Text.Replace(" ", "_");
        //    string length = dateTimePicker1.Value.ToLongTimeString();
        //    string year = dateTimePicker2.Value.ToShortDateString();
        //    string description = textBox2.Text;

        //    try
        //    {
        //        if (!String.IsNullOrEmpty(textBox1.Text) && length != null)
        //        {
        //            if (listBox2.Items.Count < 1)
        //            {
        //                MessageBox.Show("Privaloma pridėti bent vieną režisierių!!!");
        //                return;
        //            }

        //            MemoryStream ms = new MemoryStream();
        //            Bitmap image = new Bitmap(pictureBox1.Image);
        //            string imagename = pictureBox1.Name;
        //            image.Save(ms, ImageFormat.Jpeg);

        //            try
        //            {
        //                blob.UploadImgToBlob(pictureBox1.Name, ms);
        //                MovieID = azuresql.AddFilm(filmname, year, length, imagename, description);

        //                foreach (var item in listBox2.Items)
        //                {
        //                    int rezisieriaus_id = int.Parse(item.ToString().Split(',')[0]);
        //                    azuresql.AddRezisierius(MovieID, rezisieriaus_id);
        //                }

        //                foreach (var item in listBox3.Items)
        //                {
        //                    int aktorius_id = int.Parse(item.ToString().Split(',')[0]);
        //                    azuresql.AddAktorius(MovieID, aktorius_id);
        //                }

        //                MessageBox.Show("Sėkmingai pridėjote filmą!!!");
        //                this.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //            finally
        //            {
        //                azuresql.CloseConnection();
        //            }
        //        }
        //        else
        //            MessageBox.Show("Neįvedėte pilnai duomenų!!!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}



        //private void LoadFilm()
        //{
        //    string sql = "SELECT Id, Pavadinimas, Description, Isleidimo_data, Trukme, Image FROM filmai WHERE ID =" + MovieID;

        //    DataTable data = azuresql.GetDataTable(sql);
        //    string pavadinimas = data.Rows[0][1].ToString();
        //    string description = data.Rows[0][2].ToString();
        //    string isleidimo_data = data.Rows[0][3].ToString();
        //    string trukme = data.Rows[0][4].ToString();
        //    oldimage = data.Rows[0][5].ToString();


        //    pictureBox1.ImageLocation = blob.BlobUri(oldimage);
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        //    textBox1.Text = pavadinimas.Replace('_', ' ');
        //    textBox2.Text = description;
        //    dateTimePicker1.Text = trukme;
        //    dateTimePicker2.Text = isleidimo_data;
        //    pictureBox1.Name = oldimage;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
        //    if (pictureBox1_null)
        //    {
        //        MessageBox.Show("Neįdėjote nuotraukos!!!");
        //        return;
        //    }

        //    string pavadinimas = textBox1.Text.Replace(' ', '_');
        //    string description = textBox2.Text;
        //    string length = dateTimePicker1.Value.ToLongTimeString();
        //    string year = dateTimePicker2.Value.ToShortDateString();

        //    try
        //    {
        //        if (!String.IsNullOrEmpty(textBox1.Text) && length != null)
        //        {
        //            string image = pictureBox1.Name;
        //            MemoryStream ms = new MemoryStream();
        //            Bitmap imagebtm = new Bitmap(pictureBox1.Image);
        //            imagebtm.Save(ms, ImageFormat.Jpeg);

        //            blob.UploadImgToBlob(pictureBox1.Name, ms);
        //            azuresql.UpdateFilm(MovieID, pavadinimas, year, length, image, description);
        //            azuresql.DeleteRezisierius(MovieID);
        //            azuresql.DeleteAktorius(MovieID);

        //            foreach (var item in listBox2.Items)
        //            {
        //                int rezisierius_id = int.Parse(item.ToString().Split(',')[0]);
        //                azuresql.AddRezisierius(MovieID, rezisierius_id);
        //            }

        //            foreach (var item in listBox3.Items)
        //            {
        //                int aktorius_id = int.Parse(item.ToString().Split(',')[0]);
        //                azuresql.AddAktorius(MovieID, aktorius_id);
        //            }

        //            MessageBox.Show("Sveikinu sėkmingai atnaujinote duomenis!!!", "Duomenys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            this.Close();
        //        }
        //        else
        //            MessageBox.Show("Neįvedėte pilnai duomenų!!!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        Console.WriteLine("this is where it be");
        //    }
        //    finally
        //    {
        //        azuresql.CloseConnection();
        //    }
        }

        //private void LoadListbox(ListBox list, string sql)
        //{
        //    DataTable data = azuresql.GetDataTable(sql);
        //    foreach (DataRow row in data.Rows)
        //    {
        //        int id = (int)row[0];
        //        string firstname = row[1].ToString();
        //        string lastname = row[2].ToString();
        //        list.Items.Add(string.Format("{0}, {1} {2}", id, firstname, lastname));
        //    }
        //}

        //private void LoadingListboxes()
        //{
        //    string a_sql = "SELECT ID, first_name, last_name FROM zmogus ORDER BY last_name";
        //    LoadListbox(listBox1, a_sql);
        //}

        //private void LoadingListboxesFromMovie()
        //{
        //    //Loading all Directors from selected Movie to Listbox
        //    string r_sql = "SELECT zmogus.ID, first_name, last_name FROM zmogus, f_rezisierius WHERE movie_ID = " + MovieID + "AND zmogus.ID = person_ID";
        //    LoadListbox(listBox2, r_sql);

        //    //Loading all Actors from selected Movie to Listbox
        //    string a_sql = "SELECT zmogus.ID, first_name, last_name FROM zmogus, f_aktorius WHERE movie_ID = " + MovieID + "AND zmogus.ID = person_ID";
        //    LoadListbox(listBox3, a_sql);
        //}

        private void AddItembtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox2.Items.Contains(listBox1.SelectedItem)) return;

            listBox2.Items.Add(listBox1.SelectedItem);
        }
        private void AddItembtn2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox3.Items.Contains(listBox1.SelectedItem)) return;

            listBox3.Items.Add(listBox1.SelectedItem);
        }

        private void RemoveItembtn_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1) return;

            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }
        private void RemoveItembtn2_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1) return;

            listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }


    }
}
