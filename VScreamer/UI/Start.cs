using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VScreamer.UI;

namespace VScreamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //BUTTON TO OPEN TEST ROOM.
        private void button1_test_room_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new TestRoom();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
