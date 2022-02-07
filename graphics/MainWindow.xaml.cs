using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace graphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Converting method for creating BitmapImage ready to be rendered
        /// </summary>
        private BitmapImage BmpImageFromBmp(Bitmap bmp)
        {
            using (var memory = new System.IO.MemoryStream())
            {
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

        /// <summary>
        /// Main method
        /// </summary>
        private void Render()
        {
            Bitmap bmp = new Bitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight);
            for (int xcount = 0; xcount < bmp.Width / 2; xcount++)
            {
                for (int ycount = 0; ycount < bmp.Height / 3; ycount++)
                {
                    bmp.SetPixel(xcount, ycount, Color.Black);
                }
            }
            image.Source = BmpImageFromBmp(bmp);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {

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
