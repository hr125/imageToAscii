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
    class ImageToASCII
    {
        private Bitmap img;
        private Color pixelColor;
        private byte rgb;

        private string[] rgbCharPrinted;//array that ends at each line or width, holds the size of the image height

        public string file;

        public ImageToASCII(string f)
        {
            file = f;
            img = new Bitmap(file);
        }
        
        public void Execute()//call this method to create the whole thing
        {
            rgbCharPrinted = new string[img.Height];

            for (int i = 0; i < img.Height; i++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    pixelColor = img.GetPixel(x, i);
                    ConvertToBlackAndWhite(x,i);

                    rgbCharPrinted[i] += GetPixelValue().ToString();
                }
            }
        }

        private void ConvertToBlackAndWhite(int x,int i)
        {
            rgb = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
            img.SetPixel(x, i, Color.FromArgb(rgb, rgb, rgb));
        }

        private char GetPixelValue()
        {
            if (rgb >= 0 && rgb < 50)
                return '.';
            else if (rgb >= 50 && rgb < 100)
                return ',';
            else if (rgb >= 100 && rgb < 150)
                return 'o';
            else if (rgb >= 150 && rgb < 200)
                return 'O';
            else // (rgb >= 200 && rgb <= 255)
                return '@';
        }

        public void Resize(int width, int height)
        {
            img = new Bitmap(img, width, height);//an overload for the bitmap class that changes the size of another bitmap
        }

        public string[] RGBCharPrinted
        {
            get { return rgbCharPrinted; }
        }
       
    }
}
