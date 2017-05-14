using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kryptor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuadraticPage : Page
    {
        public QuadraticPage()
        {
            this.InitializeComponent();
        }

        double a;
        double b;
        double c;
        decimal output1;
        decimal output2;

        private void ValueUpdated(object sender, KeyRoutedEventArgs e)
        {
            if (double.TryParse(aTextBox.Text, out a) && double.TryParse(bTextBox.Text, out b) && double.TryParse(cTextBox.Text, out c))
            {
                try
                {
                    output1 = (decimal)((b + (double)Math.Sqrt((double)Math.Pow(b, 2) - (4 * a * c))) / (2 * a));
                    output2 = (decimal)((b - (double)Math.Sqrt((double)Math.Pow(b, 2) - (4 * a * c))) / (2 * a));

                    outputBlock.Text = string.Format("X = {0}, {1}", output1.ToString(), output2.ToString());
                }
                catch { outputBlock.Text = "X = ?, ?"; };
            }
            else
            {
                outputBlock.Text = "X = ?, ?";
            }
        }
    }
}
