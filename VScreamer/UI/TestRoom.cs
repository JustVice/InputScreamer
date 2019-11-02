using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            //FORM CENTERED ON SCREEN
            this.StartPosition = FormStartPosition.CenterScreen;

            //MAKES IMPOSIBLE TO MAXIMIZE THE FORM.
            this.MaximizeBox = false;
            ADD_ITEMS_INSIDE_LISTBOX();
        }

        private void ADD_ITEMS_INSIDE_LISTBOX()
        {
            ListBoxItem temp = new ListBoxItem("Item1", "info1", "info22", "info333");
            ListBoxItem temp2 = new ListBoxItem("Item2", "info1", "info22", "info333");
            ListBoxItem temp3 = new ListBoxItem("Item3", "info1", "info22", "info333");
            ListBoxItem temp4 = new ListBoxItem("Item4", "info1", "info22", "info333");
            this.listBox1.Items.Add(temp);
            this.listBox1.Items.Add(temp2);
            this.listBox1.Items.Add(temp3);
            this.listBox1.Items.Add(temp4);
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

        private void button2_get_screen_resolution_Click(object sender, EventArgs e)
        {
            //GETS SCREEN RESOLUTION DIMENTIONS
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

            MessageBox.Show("Screen resolution: " + screenWidth + "x" + screenHeight);
        }

        private void button2_set_form_with_screen_resolution_Click(object sender, EventArgs e)
        {
            //CHANGES FORM SIZE TO THE SAME AS THE SCREEN RESOLUTION
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

            int screenWidth_INT = Int32.Parse(screenWidth);
            int screenHeight_INT = Int32.Parse(screenHeight);

            this.Size = new System.Drawing.Size(screenWidth_INT, screenHeight_INT);

            //ALSO MOVES THE FORM TO X=0 Y=0 POSITION
            this.Location = new Point(0, 0);
        }

        #region ListBoxItem object

        class ListBoxItem
        {
            public String itemName { get; set; }
            public String itemInfo1 { get; set; }
            public String itemInfo2 { get; set; }
            public String itemInfo3 { get; set; }
            public int id { get; set; }

            public ListBoxItem()
            {
                Random rnd = new Random();
                this.id = rnd.Next(1, 9999999);
            }

            public ListBoxItem(string itemName,
                string itemInfo1,
                string itemInfo2,
                string itemInfo3)
            {
                this.itemName = itemName;
                this.itemInfo1 = itemInfo1;
                this.itemInfo2 = itemInfo2;
                this.itemInfo3 = itemInfo3;
                Random rnd = new Random();
                this.id = rnd.Next(1, 9999999);
            }

            public override string ToString()
            {
                return this.itemName;
            }
        }
        #endregion

        private void button2_add_item_on_list_Click(object sender, EventArgs e)
        {
            //ADDS OBJECTS INSIDE LIST.

            string ITEM_NAME = this.textBox1_add_item_on_list.Text;
            if (ITEM_NAME != "")
            {
                ListBoxItem item = new ListBoxItem(ITEM_NAME, "info1", "info22", "info333");
                this.listBox1.Items.Add(item);
                this.textBox1_add_item_on_list.Text = "";
            }
        }

        private void button2_delete_selected_item_Click(object sender, EventArgs e)
        {
            //REMOVES ITEMS FROM LISTBOX

            ListBoxItem SELECTED_ITEM = this.listBox1.SelectedItem as ListBoxItem;
            if (SELECTED_ITEM != null)
            {
                ListBoxItem TEMP_FILE;

                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    TEMP_FILE = listBox1.Items[i] as ListBoxItem;
                    if (TEMP_FILE.id == SELECTED_ITEM.id)
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void listbox1_click(object sender, EventArgs e)
        {
            //WHEN AN ITEM IS SELECTED INSIDE THE LISTBOX, THE ITEM'S NAME WILL BE
            //SHOWN INSIDE THE EDIT TEXTBOX.

            ListBoxItem SELECTED_ITEM = this.listBox1.SelectedItem as ListBoxItem;
            if (SELECTED_ITEM != null)
                this.textBox1_edit_file_name.Text = SELECTED_ITEM.itemName;
        }

        private void button2_edit_file_name_Click(object sender, EventArgs e)
        {
            //EDITS LISTBOX ITEMS.

            ListBoxItem SELECTED_ITEM = this.listBox1.SelectedItem as ListBoxItem;
            if (SELECTED_ITEM != null)
            {
                ListBoxItem ITEM_SEATCH;

                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    ITEM_SEATCH = listBox1.Items[i] as ListBoxItem;
                    if (ITEM_SEATCH.id == SELECTED_ITEM.id)
                    {
                        SELECTED_ITEM.itemName = this.textBox1_edit_file_name.Text;
                        listBox1.Items.RemoveAt(i);
                        listBox1.Items.Insert(i, SELECTED_ITEM);
                        this.textBox1_edit_file_name.Text = "";
                    }
                }

            }
        }

        #region Threads

        private void button2_run_thread_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(RUN_THREAD_METHOD);
            t.Start();
        }

        private void RUN_THREAD_METHOD()
        {
            //CHANGES A LABEL INFO WITH THREAD
            //SOURCE:https://social.msdn.microsoft.com/Forums/vstudio/en-US/a83a8655-76b8-4225-b38d-3b33eb67aafc/c-threading-changing-label?forum=csharpgeneral

            for (int i = 0; i < 2000; i++)
            {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.label1_thread_counter.Text = "Thread counter: " + i;
                    });
                Thread.Sleep(100);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(RUN_THREAD_METHOD2);
            t.Start();
        }

        private void RUN_THREAD_METHOD2()
        {
            for (int i = 0; i < 2000; i++)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.label1_thread_counter_2.Text = "Thread counter: " + i;
                });
                Thread.Sleep(100);
            }
        }

        #endregion
        // 2. Import the RegisterHotKey Method
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        private void button2_global_hotkey_set_Click(object sender, EventArgs e)
        {
            
        // 3. Register HotKey

        // Set an unique id to your Hotkey, it will be used to
        // identify which hotkey was pressed in your code to execute something
        int UniqueHotkeyId = 1;
            // Set the Hotkey triggerer the F9 key 
            // Expected an integer value for F9: 0x78, but you can convert the Keys.KEY to its int value
            // See: https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            int HotKeyCode = (int)Keys.F9;
            // Register the "F9" hotkey
            Boolean F9Registered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );

            // 4. Verify if the hotkey was succesfully registered, if not, show message in the console
            if (F9Registered)
            {
                Console.WriteLine("Global Hotkey F9 was succesfully registered");
            }
            else
            {
                Console.WriteLine("Global Hotkey F9 couldn't be registered !");
            }
            protected override void WndProc(ref Message m)
        {
            // 5. Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                // MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                if (id == 1)
                {
                    MessageBox.Show("F9 Was pressed !");
                }
            }

            base.WndProc(ref m);
        }
    }
    }
}
