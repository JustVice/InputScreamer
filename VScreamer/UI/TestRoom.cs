using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VScreamer.UI
{
    public partial class TestRoom : Form
    {
        public TestRoom()
        {
            InitializeComponent();
            UI_SETTINGS();
        }

        private void UI_SETTINGS()
        {
            //MAKES IMPOSIBLE TO MAXIMIZE THE FORM.
            this.MaximizeBox = false;
        }

        private Boolean BORDER_STYLE_SHOWING = true;
        private Boolean FORM_RESIZED = false;

        private void button1_show_application_folder_path_Click(object sender, EventArgs e)
        {
            //TO SHOW APPLICATION FOLDER PATH.
            string applicationFolderPath = System.IO.Directory.GetCurrentDirectory();

            //SHOWS ON CONSOLE AND MESSAGE BOX.
            Console.WriteLine(applicationFolderPath);
            MessageBox.Show(applicationFolderPath);
        }

        private void button1_form_border_disappear_Click(object sender, EventArgs e)
        {
            //MAKES THE BORDER STYLE BAR DISAPPEAR OF BE SHOWN.
            if (this.BORDER_STYLE_SHOWING)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.BORDER_STYLE_SHOWING = false;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.BORDER_STYLE_SHOWING = true;
            }

        }

        private void button1_change_form_position_Click(object sender, EventArgs e)
        {
            //CHANGES FORM POSITION
            this.Location = new Point(0, 0);
        }

        private void button1_change_form_size_Click(object sender, EventArgs e)
        {
            //MAKES THE FORM CHANGE ITS SIZE.
            if (this.FORM_RESIZED)
            {
                this.Size = new System.Drawing.Size(689, 402);
                this.FORM_RESIZED = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(300, 300);
                this.FORM_RESIZED = true;
            }

        }

        private void button1_create_folder_Click(object sender, EventArgs e)
        {
            //CREATES A FOLDER INSIDE THE SAME PATH WHERE THE APPLICATION IS LOCATED.

            String FOLDER_NAME = textBox1_create_folder_name_for_the_folder.Text;
            string applicationFolderPath = System.IO.Directory.GetCurrentDirectory();
            if (FOLDER_NAME != "")
            {
                Directory.CreateDirectory(applicationFolderPath + "\\" + FOLDER_NAME);
                MessageBox.Show("Folder " + FOLDER_NAME + " created.");
            }
            else
            {
                Directory.CreateDirectory(applicationFolderPath + "\\Folder created from Test Room");
                MessageBox.Show("Folder created.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new System.Drawing.Size(0, 0);
            MessageBox.Show("Form tiny.");
        }

        private void button2_open_file_chooser_Click(object sender, EventArgs e)
        {
            //OPENS FILE CHOOSER AND GETS A STRING OF THE FILE CHOOSEN PATH.

            OpenFileDialog OPEN_FILE_DIALOG = new OpenFileDialog();
            if (OPEN_FILE_DIALOG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string PATH_STRING = OPEN_FILE_DIALOG.FileName;
                MessageBox.Show(PATH_STRING);
            }
        }

        private void button2_check_if_file_exists_Click(object sender, EventArgs e)
        {
            //CHECKS IF A FILE EXISTS.

            String FILE_PATH = textBox1_check_if_file_exist.Text;
            if (FILE_PATH != "")
            {
                bool status = File.Exists(FILE_PATH);
                if (status)
                    MessageBox.Show("File " + FILE_PATH + " exists.");
                else
                    MessageBox.Show("File " + FILE_PATH + " does not exist.");
            }
        }

        private void button2_load_image_and_show_Click(object sender, EventArgs e)
        {
            //OPENS FILE CHOOSER TO SELECT AN IMAGE AN SET IT INSIDE A PICTURE BOX.

            OpenFileDialog OPEN_FILE_DIALOG = new OpenFileDialog();
            if (OPEN_FILE_DIALOG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string IMAGE_PATH = OPEN_FILE_DIALOG.FileName;
                Image image = Image.FromFile(IMAGE_PATH);
                this.pictureBox1_load_image_and_show.Image = image;
            }
        }

        private void button2_select_mp3_file_and_play_it_Click(object sender, EventArgs e)
        {
            //PLAYS A .MP3 FILE
            //SOURCE: http://csharpexamples.com/play-mp3-wav-files-synchronous-asynchronous-c/
            OpenFileDialog OPEN_FILE_DIALOG = new OpenFileDialog();
            if (OPEN_FILE_DIALOG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string MP3_PATH = OPEN_FILE_DIALOG.FileName;

                var mediaPlayer = new MediaPlayer.MediaPlayer();
                mediaPlayer.FileName = MP3_PATH;
                mediaPlayer.Play();

            }
        }

        private void button2_select_wav_file_and_play_it_Click(object sender, EventArgs e)
        {
            //PLAYS A .WAV FILE
            //SOURCE: http://csharpexamples.com/play-mp3-wav-files-synchronous-asynchronous-c/
            OpenFileDialog OPEN_FILE_DIALOG = new OpenFileDialog();
            if (OPEN_FILE_DIALOG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string WAV_PATH = OPEN_FILE_DIALOG.FileName;

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = WAV_PATH;
                player.Play(); //in another thread
                player.Play(); //in same thread
            }
        }
    }
}
