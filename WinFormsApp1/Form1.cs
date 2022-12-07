using System.Diagnostics;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.labelThreadsValue.Text = trackBarThreads.Value.ToString();
        }

        Bitmap loadedImage = null;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.bmp; *.png)| *.bmp; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //get the file name 
                string fileName = openFileDialog1.FileName;
                //read the file into a bitmap
                Bitmap bitmap = new Bitmap(fileName);
                //display the image in the picturebox
                pictureBox1.Image = bitmap;

                loadedImage = bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.labelTimeValue.Text = 0.ToString();
            //create a new image
            Bitmap newImage = loadedImage;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            //loop through the image pixels
            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    //get the pixel value
                    Color pixel = newImage.GetPixel(i, j);
                    //apply the monochromatic filter
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    Color newColor = Color.FromArgb(average, average, average);
                    //set the new pixel value
                    newImage.SetPixel(i, j, newColor);
                }
            }
            sw.Stop();
            long elapsedTicks = sw.ElapsedTicks;
            this.labelTimeValue.Text = elapsedTicks.ToString();

            //display the new image
            pictureBox2.Image = newImage;
        }

        private void trackBarThreads_Scroll(object sender, EventArgs e)
        {
            this.labelThreadsValue.Text = trackBarThreads.Value.ToString();
        }


    }
} 