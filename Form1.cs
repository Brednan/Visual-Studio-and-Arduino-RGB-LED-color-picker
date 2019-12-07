using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Arduino
{
    public partial class MainUpdate : Form
    {
        bool ON;

        public MainUpdate()
        {
            InitializeComponent();
            serialPort1.PortName = "COM5";
            serialPort1.Open();
            ON = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ON = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("000000000");
            ON = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // if(ON == true)
          //  {
            //    serialPort1.Write(RGB_To_HEX(trackBar1, trackBar2, trackBar3));
           // }
           if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                serialPort1.Write(RGB_To_HEX(colorDialog1.Color));
            }
        }
        private String RGB_To_HEX(Color colorDialog)
        {
            int red_ = colorDialog.R;
            string redString = Convert.ToString(red_);

            if(redString.Length < 3 && redString.Length == 2)
            {
                redString = redString + " ";
            }
            else if (redString.Length < 2 && redString.Length == 1)
            {
                redString = redString + "  ";
            }

            int blue_ = colorDialog.G;
            string blueString = Convert.ToString(blue_);

            if(blueString.Length == 2)
            {
                blueString = blueString + " ";
            }
            else if(blueString.Length == 1)
            {
                blueString = blueString + "  ";

            }

            int green_ = colorDialog.B;
            string greenString = Convert.ToString(green_);

            if (greenString.Length == 2)
            {
                greenString = greenString + " ";
            }
            else if(greenString.Length == 1)
            {
                greenString = greenString + "  ";
            }
            string fullRGB = redString + greenString + blueString;
            Console.WriteLine(fullRGB.Length);
            return fullRGB;
        }
    }
}
