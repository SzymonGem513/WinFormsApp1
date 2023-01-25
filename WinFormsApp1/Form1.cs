using System.Diagnostics;
using System.Runtime.InteropServices;
using ProcessPixelCSLib;
namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.labelThreadsValue.Text = trackBarThreads.Value.ToString();
        }

        [DllImport("GrayscaleASM.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int MyProc(int test1,int test2);

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
                    ProcessPixelCS processPixelObj = new ProcessPixelCS();
                    Color pixel = newImage.GetPixel(i, j);
                    Color newPixel = processPixelObj.processPixel(pixel);
                    newImage.SetPixel(i, j, newPixel);

                }
                sw.Stop();
                long elapsedTicks = sw.ElapsedTicks;
                this.labelTimeValue.Text = elapsedTicks.ToString();
            }
            //display the new image
            pictureBox2.Image = newImage;
            label5.Text = MyProc(2, 3).ToString();


            //[DllImport("GrayscaleASM.dll")]
            //static unsafe extern void ProcAsm2();


        }

        private void button3_Click(object sender, EventArgs e)
        {
                label5.Text = "Wykonano operacje na ASM";
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
} 