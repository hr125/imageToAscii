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

namespace ImageToASCII_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ImageToASCII imageToAscii;
        string fileName;
        
        private void openImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                fileName = openFileDialog1.FileName;

                buttonCreateAscii.Enabled = true;
                groupBox2.Enabled = true;
            }
        }

        private void buttonCreateAscii_Click(object sender, EventArgs e)
        {
            imageToAscii = new ImageToASCII(fileName);

            resizer();
            imageToAscii.Execute();

            richTextBox1.Text = "";

            for (int i = 0; i < imageToAscii.RGBCharPrinted.Length; i++)
            {
                richTextBox1.Text += imageToAscii.RGBCharPrinted[i];
                richTextBox1.Text += Environment.NewLine;
            }
                
        }
        private void resizer()
        {
            if (textBoxReWidth.Text.Length != 0 && textBoxReHeight.Text.Length != 0)
            {
                int w = int.Parse(textBoxReWidth.Text);
                int h = int.Parse(textBoxReHeight.Text);

                if (w > 1000 || h > 1000)
                    MessageBox.Show("Width or height cannot be greater than 1000");
                else if (w == 0 || h == 0)
                    MessageBox.Show("Width or height cannot be 0");
                else
                    imageToAscii.Resize(w, h);
            }
        }

    }
}
