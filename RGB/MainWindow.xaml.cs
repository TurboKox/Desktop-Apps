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

namespace RGB
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte red, green, blue, redBuffer, greenBuffer, blueBuffer;
        SolidColorBrush bg = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
        }

        //*********************************************************

        private void ClearValue(ref byte color, ref byte buffer, ref Slider slider, ref SolidColorBrush bg)
        {
            buffer = color;
            slider.Value = 0;
            ColorButton.Background = bg;
            slider.IsEnabled = false;
            RedLabel.Content = RedLabel.Name.Substring(0, RedLabel.Name.Length - 5) + ": 0";
        }

        private void Uncheck(ref byte buffer, ref Slider slider, ref SolidColorBrush bg, Label label)
        {
            slider.IsEnabled = true;
            slider.Value = buffer;
            ColorButton.Background = bg;
            RedLabel.Content = RedLabel.Name.Substring(0, label.Name.Length - 5) + ": " + redBuffer;
        }

        private void ChangeValue(ref object sender, ref Label label, ref byte color)
        {
            int N = (int)((Slider)sender).Value;
            label.Content = "Red: " + N;
            color = (byte)N;
            bg.Color = Color.FromArgb(255, red, green, blue);
            ColorButton.Background = bg;
        }

        //*********************************************************

        private void RedCheck_Checked(object sender, RoutedEventArgs e)
        {
            bg.Color = Color.FromArgb(255, 0, green, blue);
            ClearValue(ref red, ref redBuffer, ref RedSlider, ref bg);
        }

        private void RedCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            bg.Color = Color.FromArgb(255, redBuffer, green, blue);
            Uncheck(ref redBuffer, ref RedSlider, ref bg);
        }

        private void GreenCheck_Checked(object sender, RoutedEventArgs e)
        {
            bg.Color = Color.FromArgb(255, 0, green, blue);
            ClearValue(ref green, ref greenBuffer, ref GreenSlider, ref bg);
        }

        private void GreenCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            bg.Color = Color.FromArgb(255, red, greenBuffer, blue);
            Uncheck(ref greenBuffer, ref GreenSlider, ref bg);
        }

        private void BlueCheck_Checked(object sender, RoutedEventArgs e)
        {

            bg.Color = Color.FromArgb(255, red, green, 0);
            ClearValue(ref blue, ref blueBuffer, ref BlueSlider, ref bg);
        }
        private void BlueCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            bg.Color = Color.FromArgb(255, red, green, blueBuffer);
            Uncheck(ref blueBuffer, ref BlueSlider, ref bg);
        }

        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeValue(ref sender, ref RedLabel, ref red);
        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeValue(ref sender, ref GreenLabel, ref green);
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeValue(ref sender, ref BlueLabel, ref blue);
        }
    }
}
