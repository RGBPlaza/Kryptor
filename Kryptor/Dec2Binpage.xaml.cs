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

namespace Kryptor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dec2Binpage : Page
    {
        Int64 dec;
        Int64 bin;
        string output;

        public Dec2Binpage()
        {
            this.InitializeComponent();
            Loaded += (s, e) => { SetBlur(ActualWidth, ActualHeight); };
            Window.Current.SizeChanged += (s, e) => { SetBlur(e.Size.Width, e.Size.Height); };
        }

        private void SetBlur(double width, double height)
        {
            GaussianBlurEffect blurEffect = new GaussianBlurEffect()
            {
                Name = "Blur",
                BlurAmount = 5.0f, // You can place your blur amount here.
                BorderMode = EffectBorderMode.Hard,
                Optimization = EffectOptimization.Balanced,
                Source = new CompositionEffectSourceParameter("source")
            };

            var menuVisual = ElementCompositionPreview.GetElementVisual(this as UIElement);
            var compositor = menuVisual.Compositor;

            var blurEffectFactory = compositor.CreateEffectFactory(blurEffect);

            var effectBrush = blurEffectFactory.CreateBrush();
            effectBrush.SetSourceParameter("source", compositor.CreateHostBackdropBrush());

            SpriteVisual visual = compositor.CreateSpriteVisual();
            visual.Brush = effectBrush;
            visual.Size = new System.Numerics.Vector2((float)width, (float)height);

            ElementCompositionPreview.SetElementChildVisual(BackgroundHolder, visual);
        }

        private void decTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            binTextBox.Text = "";
            bool isDecNum = Int64.TryParse(decTextBox.Text, out dec);
            if(isDecNum == true)
            {
                output = Convert.ToString(dec, 2);
                binTextBox.Text = output.ToString();
            }
        }

        private void binTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            decTextBox.Text = "";
            bool isBinNum = Int64.TryParse(binTextBox.Text, out bin);
            if (isBinNum == true)
            {
                int binLength = bin.ToString().Length;
                var dec = 0;
                for (int i = 0; i < binLength; i++)
                {
                    if (bin.ToString()[binLength - i - 1] != '0')
                        dec += (int)Math.Pow(2, i);
                }
                output = dec.ToString();
                decTextBox.Text = output.ToString();
            }
        }
    }
}
