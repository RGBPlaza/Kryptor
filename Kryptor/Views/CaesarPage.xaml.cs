using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text;
using Windows.UI.Composition;
using Microsoft.Graphics.Canvas.Effects;
using Windows.UI.Core;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kryptor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class CaesarPage : Page
    {
        static int charNo;
        static int newCharNo;
        static int boxNo;
        static int dist;
        static string outString;
        static StringBuilder output = new StringBuilder();

        public static string Caesar(string s, double offset)
        {
            output.Clear();
            foreach (char c in s)
            {
                if (c != ' ')
                {
                    charNo = (int)c;
                    newCharNo = charNo + (int)offset;

                    if (newCharNo < 65 && charNo >= 65)
                    {
                        dist = 65 - newCharNo;
                        charNo = 90 - dist;
                    }
                    else if (newCharNo > 90 && charNo <= 90)
                    {
                        dist = newCharNo - 90;
                        charNo = 65 + dist;
                    }
                    else if (newCharNo > 122 && charNo <= 122)
                    {
                        dist = newCharNo - 122;
                        charNo = 97 + dist;
                    }
                    else if (newCharNo < 97 && charNo >= 97)
                    {
                        dist = 97 - newCharNo;
                        charNo = 122 - dist;
                    }
                    else
                    {
                        charNo = newCharNo;
                    }

                    output.Append((char)charNo);
                    outString = output.ToString();
                }
            }
            return outString;
        }

        public CaesarPage()
        {
            this.InitializeComponent();
        }

        private void EnTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            deTextBox.Text = Caesar(enTextBox.Text, (offsetSlider.Value * -1));
            boxNo = 0;
        }

        private void DeTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            enTextBox.Text = Caesar(deTextBox.Text, offsetSlider.Value);
            boxNo = 1;
        }

        private void OffsetSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (boxNo == 0 && enTextBox.Text != "")
            {
                deTextBox.Text = Caesar(enTextBox.Text, (offsetSlider.Value * -1));
            }
            else if (boxNo == 1 && deTextBox.Text != "")
            {
                enTextBox.Text = Caesar(deTextBox.Text, offsetSlider.Value);
            }
        }
    }
}
