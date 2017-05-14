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
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.MenuItems.Add(new NavigationMenuItem() { Tag = "Caesar", Text = "Caesar Cipher", Icon = new SymbolIcon(Symbol.Switch) });
            NavView.MenuItems.Add(new NavigationMenuItem() { Tag = "DecBin", Text = "Decimal / Binary", Icon = new SymbolIcon(Symbol.Delete) });
            NavView.MenuItems.Add(new NavigationMenuItem() { Tag = "ASCII", Text = "Text / ASCII", Icon = new SymbolIcon(Symbol.FontColor) });
            NavView.MenuItems.Add(new NavigationMenuItem() { Tag = "Quadratic", Text = "Quadratic Calculator", Icon = new SymbolIcon(Symbol.Calculator) });

            ContentFrame.Navigate(typeof(Views.CaesarPage));
            NavigationMenuItem firstItem = (NavigationMenuItem)NavView.MenuItems[0];
            firstItem.IsSelected = true;
            SelectedTag = firstItem.Tag.ToString();
            NavView.Header = firstItem.Text;

            foreach (var navItem in NavView.MenuItems)
            {
                if (navItem is NavigationMenuItem)
                {
                    (navItem as NavigationMenuItem).Invoked += Nav_Invoked;
                }
            }
        }

        private string SelectedTag;

        private void Nav_Invoked(NavigationMenuItem sender, object args)
        {
            string itemTag = sender.Tag.ToString();
            if (SelectedTag != itemTag)
            {
                switch (sender.Tag.ToString())
                {
                case "Caesar":
                    {
                        ContentFrame.Navigate(typeof(Views.CaesarPage));
                        break;
                    }
                case "DecBin":
                    {
                        ContentFrame.Navigate(typeof(Views.DecimalBinaryPage));
                        break;
                    }
                case "ASCII":
                    {
                        ContentFrame.Navigate(typeof(Views.ASCIIPage));
                        break;
                    }
                case "Quadratic":
                    {
                        ContentFrame.Navigate(typeof(Views.QuadraticPage));
                        break;
                    }
                }
                NavView.Header = sender.Text;
                SelectedTag = itemTag;
            }
        }

        private void NavView_SettingsInvoked(NavigationView sender, object args)
        {
            if (SelectedTag != "Settings")
            {
                ContentFrame.Navigate(typeof(Settingspage));
                NavView.Header = "About & Settings";
                SelectedTag = "Settings";
            }
        }

    }
}
