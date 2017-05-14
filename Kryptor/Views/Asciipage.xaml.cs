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
using Microsoft.Graphics.Canvas.Effects;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kryptor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ASCIIPage : Page
    {
        public ASCIIPage()
        {
            this.InitializeComponent();
        }


        StringBuilder output = new StringBuilder();
        StringBuilder binStr = new StringBuilder();
        StringBuilder tempString2 = new StringBuilder();
        string tempString;
        int tempInt;
        string input;
        int charDec;
        string charBin;
        int numBlocks;

        private void AlphanumericUpdated(object sender, KeyRoutedEventArgs e)
        {
            input = textTextBox.Text;
            output.Clear();
            tempString2.Clear();
            foreach (char c in input)
            {
                charDec = Convert.ToInt32(c);
                charBin = Convert.ToString(charDec, 2);

                tempInt = 8 - charBin.Length;
                tempString = tempString2.ToString();
                output.Clear();
                for (int i = tempInt; i > 0; i--)
                {
                    tempString2.Append("0");
                }
                tempString2.Append(charBin);
                output.Append(tempString2);
            }

            asciiTextBox.Text = output.ToString();
        }

        private void AsciiUpdated(object sender, KeyRoutedEventArgs e)
        {
            output.Clear();
            input = asciiTextBox.Text;
            charDec = 0;

            if (input.Length != 0)
            {
                bool isBinary = true;
                foreach (char c in input)
                {
                    if (c != '0' && c != '1')
                        isBinary = false;
                }
                if (isBinary)
                {
                    input.ToCharArray();
                    if (input.Length % 8 == 0)
                    {
                        numBlocks = input.Length / 8;
                        for (int j = 0; j < numBlocks; j++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                binStr.Append(input[l + (8 * j)].ToString());
                            }
                            for (int k = 0; k < 8; k++)
                            {
                                if (binStr.ToString()[8 - k - 1] != '0')
                                    charDec += (int)Math.Pow(2, k);
                            }

                            output.Append((char)charDec);
                            binStr.Clear();
                            charDec = 0;
                            textTextBox.Text = output.ToString();
                        }
                    }
                    else
                    {
                        textTextBox.Text = "";
                    }
                }
            }
            else
            {
                textTextBox.Text = "";
            }
        }
    }
}
