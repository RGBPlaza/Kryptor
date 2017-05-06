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
            NavFrame.Navigate(typeof(Dec2Binpage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = false;
        }

        private void Dec2BinBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavFrame.Navigate(typeof(Dec2Binpage));
            SettingsBtn.IsSelected = false;
            PageTextBlock.Text = "Decimal / Binary";
        }

        private void QuadraticBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavFrame.Navigate(typeof(Quadraticpage));
            SettingsBtn.IsSelected = false;
            PageTextBlock.Text = "Quadratic Calculator";
        }

        private void SettingsBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavFrame.Navigate(typeof(Settingspage));
            Dec2BinBtn.IsSelected = false;
            QuadraticBtn.IsSelected = false;
            AsciiBtn.IsSelected = false;
            CesarBtn.IsSelected = false;

            PageTextBlock.Text = "About + Settings";
        }

        private void AsciiBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavFrame.Navigate(typeof(Asciipage));
            SettingsBtn.IsSelected = false;
            PageTextBlock.Text = "Text / ASCII";
        }

        private void CesarBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavFrame.Navigate(typeof(Cesarpage));
            SettingsBtn.IsSelected = false;
            PageTextBlock.Text = "Caesar Cypher";
        }
    }
}
