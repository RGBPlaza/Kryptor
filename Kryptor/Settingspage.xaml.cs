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
    public sealed partial class Settingspage : Page
    {
        public Settingspage()
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
    }
}
