using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class photoSetUserInfo : Form
    {
        private string textBoxInput = "";
        public photoSetUserInfo()
        {
            InitializeComponent();
        }

        private void photoSetId_TextChanged(object sender, EventArgs e)
        {
            textBoxInput = photoSetId.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
        }
    }
}
