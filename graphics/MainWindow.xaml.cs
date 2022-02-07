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

using System.Drawing;
using Color = System.Drawing.Color;

namespace graphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage BmpImageFromBmp(Bitmap bmp) { //converting tool
            using (var memory = new System.IO.MemoryStream()) {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
        private void Render() { //main method
            Bitmap bmp = new Bitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight);
            for (int xcount = 0; xcount < bmp.Width / 2; xcount++) {
                for (int ycount = 0; ycount < bmp.Height / 3; ycount++) {
                    bmp.SetPixel(xcount, ycount, Color.Black);
                }
            }
            image.Source = BmpImageFromBmp(bmp);
        }

        public MainWindow() {
            InitializeComponent();
        }

        private void start_button_Click(object sender, RoutedEventArgs e) {

            text.Text = "размеры картинки: " + canvas.ActualHeight + ", " + canvas.ActualWidth;

            Render();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            text.Text = "размеры картинки: " + canvas.ActualHeight + ", " + canvas.ActualWidth;

            Render();
        }
    }
}
