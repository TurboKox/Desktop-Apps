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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //*********************************************************

        private void RedCheck_Checked(object sender, RoutedEventArgs e)
        {
            ClearValue(ref redBuffer, ref red, ref RedSlider, ref bg, ref RedLabel);
        }

        private void RedCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            Uncheck(ref redBuffer, ref red, ref RedSlider, ref bg, ref RedLabel);
        }

        private void GreenCheck_Checked(object sender, RoutedEventArgs e)
        {
            ClearValue(ref greenBuffer, ref green, ref GreenSlider, ref bg, ref GreenLabel);
        }

        private void GreenCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            Uncheck(ref greenBuffer, ref green, ref GreenSlider, ref bg, ref GreenLabel);
        }

        private void BlueCheck_Checked(object sender, RoutedEventArgs e)
        {
            ClearValue(ref blueBuffer, ref blue, ref BlueSlider, ref bg, ref BlueLabel);
        }
        private void BlueCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            Uncheck(ref blueBuffer, ref blue, ref BlueSlider, ref bg, ref BlueLabel);
        }

        //*********************************************************

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

        //*********************************************************

        private void ClearValue(ref byte buffer, ref byte color, ref Slider slider, ref SolidColorBrush bg, ref Label label)
        {
            buffer = color;
            color = 0;
            bg.Color = Color.FromArgb(255, red, green, blue);
            slider.Value = 0;
            ColorButton.Background = bg;
            slider.IsEnabled = false;
            label.Content = label.Name.Substring(0, label.Name.Length - 5) + ": 0";
        }

        private void Uncheck(ref byte buffer, ref byte color, ref Slider slider, ref SolidColorBrush bg, ref Label label)
        {
            slider.IsEnabled = true;
            slider.Value = buffer;
            color = buffer;
            bg.Color = Color.FromArgb(255, red, green, blue);
            ColorButton.Background = bg;
            label.Content = label.Name.Substring(0, label.Name.Length - 5) + ": " + redBuffer;
        }

        private void ChangeValue(ref object sender, ref Label label, ref byte color)
        {
            int N = (int)((Slider)sender).Value;
            label.Content = label.Name.Substring(0, label.Name.Length - 5) + ": " + N;
            color = (byte)N;
            bg.Color = Color.FromArgb(255, red, green, blue);
            ColorButton.Background = bg;
        }

        //*********************************************************

        private byte red, green, blue, redBuffer, greenBuffer, blueBuffer;
        private SolidColorBrush bg = new SolidColorBrush();
    }
}
