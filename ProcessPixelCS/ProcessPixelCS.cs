using System.Diagnostics;
using System.Drawing;

namespace ProcessPixelCSLib
{
    public class ProcessPixelCS
    {
        public Color processPixel(Color pixel)
        {
            int averagePixelValue = (pixel.R + pixel.G + pixel.B) / 3;
            Color grayPixel = Color.FromArgb(averagePixelValue, averagePixelValue, averagePixelValue);
            return grayPixel;
        }
    }
}