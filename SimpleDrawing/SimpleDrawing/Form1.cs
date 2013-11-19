using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageColorData iCD = new imageColorData();
            Bitmap img = new Bitmap("C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg");
            Dictionary<String, List<Color>> colorStructsOfImage = iCD.getColorsInImage(img);
            //float avgBrightnessByColor = iCD.calcAverageBrightnessByColor("Violet");
            //float percentageOfColor = iCD.percentageOfColorInImage("Yellow");
            label1.Text = iCD.percentageOfColorInImage("Violet").ToString();
            label2.Text = iCD.percentageOfColorInImage("Indigo").ToString();
            label3.Text = iCD.percentageOfColorInImage("Blue").ToString();
            label4.Text = iCD.percentageOfColorInImage("Green").ToString();
            label5.Text = iCD.percentageOfColorInImage("Yellow").ToString();
            label6.Text = iCD.percentageOfColorInImage("Orange").ToString();
            label7.Text = iCD.percentageOfColorInImage("Red").ToString();

            label17.Text = iCD.calcAverageBrightnessByColor("Violet").ToString();
            label18.Text = iCD.calcAverageBrightnessByColor("Indigo").ToString();
            label19.Text = iCD.calcAverageBrightnessByColor("Blue").ToString();
            label20.Text = iCD.calcAverageBrightnessByColor("Green").ToString();
            label21.Text = iCD.calcAverageBrightnessByColor("Yellow").ToString();
            label22.Text = iCD.calcAverageBrightnessByColor("Orange").ToString();
            label23.Text = iCD.calcAverageBrightnessByColor("Red").ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
