using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SynopsisViews
{
    /// <summary>
    /// Interaction logic for Thumbnail.xaml
    /// </summary>
    public partial class Thumbnail : UserControl
    {
        private BitmapSource _bitmap;
        private int _bitmapWidth = 80;
        private int _bitmapHeight = 80;
        private readonly PixelFormat _pixelFormat = PixelFormats.Bgra32;
        private int _bitmapStride;
        private byte[] _bitmapPixels;

        public Thumbnail()
        {
            _bitmapStride = (_bitmapWidth * _pixelFormat.BitsPerPixel + 7) / 8;
            _bitmapPixels = new byte[_bitmapStride * _bitmapHeight];

            InitializeComponent();

            DrawTestPattern();

            _bitmap = BitmapSource.Create(
                                            _bitmapWidth,
                                            _bitmapHeight,
                                            96,
                                            96,
                                            _pixelFormat,
                                            null,
                                            _bitmapPixels,
                                            _bitmapStride);


            this.MainImage.Source = _bitmap;
        }

        private void DrawTestPattern()
        {
            for (int i = 2; i < _bitmapHeight / 2; i += 2)
            {
                for (int j = 0; j < _bitmapWidth / 2; j += 2)
                {
                    SetPixel(j, i, Colors.Red);
                }
            }

            SetPixel(0, 0, Colors.Green);
            SetPixel(79, 0, Colors.Blue);
            SetPixel(0, 79, Colors.Black);
            SetPixel(79, 79, Colors.Brown);
        }

        private void SetPixel(int x, int y, Color c)
        {
            // Not entirely accurate, some pixels should be split between lines, but close enough
            //y = (int)(y * _lineRatio);
            if (x < _bitmapWidth && y < _bitmapHeight)
            {
                int pixelOffset = y * _bitmapStride + x * 4;
                //_bitmapPixels[pixelOffset] += (byte)(_lineRatio * c.B);
                //_bitmapPixels[pixelOffset + 1] += (byte)(_lineRatio * c.G);
                //_bitmapPixels[pixelOffset + 2] += (byte)(_lineRatio * c.R);
                //_bitmapPixels[pixelOffset + 3] += (byte)(_lineRatio * 255);

                _bitmapPixels[pixelOffset] += (byte)(c.B);
                _bitmapPixels[pixelOffset + 1] += (byte)(c.G);
                _bitmapPixels[pixelOffset + 2] += (byte)(c.R);
                _bitmapPixels[pixelOffset + 3] += (byte)(255);
            }
        }
    }
}
