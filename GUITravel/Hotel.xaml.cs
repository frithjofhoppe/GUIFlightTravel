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
using System.Text.RegularExpressions;

namespace GUITravel
{
    /// <summary>
    /// Interaction logic for Hotel.xaml
    /// </summary>
    public partial class Hotel : UserControl
    {
        public Hotel()
        {
            InitializeComponent();
        }

        private bool IsNameValid(String name)
        {
            if(Regex.IsMatch(name, @"^[a-zA-Zäöü]{2,}$"))
            {
                return true;
            }
            return false;
        }

        private bool IsLocationValid(String name)
        {
            if(Regex.IsMatch(name, @"^[a-zA-Zäöü\-]{3,}$"))
            {
                return true;
            }
            return false;
        }

        private bool AreStarsValid(String name)
        {
            if (Regex.IsMatch(name, @"^[1-7]$"))
            {
                return true;
            }
            return false;
        }

        private bool IsManageValid(String name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Zäöü]{2,}\s[a-zA-Zäöü]{2,}$"))
            {
                return true;
            }
            return false;
        }

        private bool IsCountOfRoomsValid(String name)
        {
            if (Regex.IsMatch(name, @"^[2-1000]$"))
            {
                return true;
            }
            return false;
        }

        private bool IsDailyPriceValid(String text)
        {
            if(Regex.IsMatch(text, @"^\d{1,}\.+\d*$"))
            {
                return true;
            }
            return false;
        }

        private bool IsTelephonenumberValid(String text)
        {
            if(Regex.IsMatch(text, @"\d{3}\d{3}\d{4}$"))
            {
                return true;
            }
            return false;
        }

        private bool IsURLValid(String text)
        {
            if (Regex.IsMatch(text, @"http[s]+\:\/\/[a-zA-Zäöü]{1,}\.[a-zA-Z]{2,3}"))
            {
                return true;
            }
            return false;
        }

        private void RegexMatcher(Func<string, bool> matcher, String content, Control item)
        {
            if (matcher(content))
            {
                item.Background = Brushes.Green;
            }
            else
            {
                item.Background = Brushes.Red;
            }
        }

       

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void TBName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsNameValid, TBName.Text, TBName);
        }

        private void TBOrt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsLocationValid, TBOrt.Text, TBOrt);
        }

        private void TBSterne_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(AreStarsValid, TBSterne.Text, TBSterne);
        }

        private void TBManager_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsManageValid, TBManager.Text, TBManager);
        }

        private void TBAnzahlZimmer_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsCountOfRoomsValid, TBAnzahlZimmer.Text, TBAnzahlZimmer);
        }

        private void TBTagespreis_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsDailyPriceValid, TBTagespreis.Text, TBTagespreis);
        }

        private void TBTelefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexMatcher(IsTelephonenumberValid, TBTelefon.Text, TBTelefon);
        }

        private void TBWeb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
