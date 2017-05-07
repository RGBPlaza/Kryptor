using Microsoft.Graphics.Canvas.Effects;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Kryptor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
            NavFrame.Navigate(typeof(Dec2Binpage));
            Window.Current.SizeChanged += OnSizeAllocated;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetBlur(ActualWidth, ActualHeight);
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

            SpriteVisual HamburgerBlurVisual = compositor.CreateSpriteVisual();
            HamburgerBlurVisual.Brush = effectBrush;
            HamburgerBlurVisual.Size = new System.Numerics.Vector2((float)width, (float)height);

            SpriteVisual AppBarBlurVisual = compositor.CreateSpriteVisual();
            AppBarBlurVisual.Brush = effectBrush;
            AppBarBlurVisual.Size = new System.Numerics.Vector2((float)width, (float)height);

            ElementCompositionPreview.SetElementChildVisual(BackgroundHolder, HamburgerBlurVisual);
            ElementCompositionPreview.SetElementChildVisual(AppBarBackgroundHolder, AppBarBlurVisual);
        }

        private void OnSizeAllocated(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SetBlur(e.Size.Width, e.Size.Height);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void Dec2BinBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (PageTextBlock.Text != "DECIMAL / BINARY")
            {
                NavFrame.Navigate(typeof(Dec2Binpage));
                SettingsBtn.IsSelected = false;
                PageTextBlock.Text = "DECIMAL / BINARY";
            }
        }

        private void QuadraticBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (PageTextBlock.Text != "QUADRATIC CALCULATOR")
            {
                NavFrame.Navigate(typeof(Quadraticpage));
                SettingsBtn.IsSelected = false;
                PageTextBlock.Text = "QUADRATIC CALCULATOR";
            }
        }

        private void SettingsBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (PageTextBlock.Text != "ABOUT + SETTINGS")
            {
                NavFrame.Navigate(typeof(Settingspage));
                Dec2BinBtn.IsSelected = false;
                QuadraticBtn.IsSelected = false;
                AsciiBtn.IsSelected = false;
                CesarBtn.IsSelected = false;

                PageTextBlock.Text = "ABOUT + SETTINGS";
            }
        }

        private void AsciiBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (PageTextBlock.Text != "TEXT / UNICODE")
            {
                NavFrame.Navigate(typeof(Asciipage));
                SettingsBtn.IsSelected = false;
                PageTextBlock.Text = "TEXT / UNICODE";
            }
        }

        private void CesarBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (PageTextBlock.Text != "CAESAR CIPHER")
            {
                NavFrame.Navigate(typeof(Cesarpage));
                SettingsBtn.IsSelected = false;
                PageTextBlock.Text = "CAESAR CIPHER";
            }
        }

        private void UpperListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = false;
        }
    }
}
