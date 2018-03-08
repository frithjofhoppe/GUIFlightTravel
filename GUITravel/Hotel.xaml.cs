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
        bool areAllFieldsValid = false;
        int validFiels {
            set
            {
                areFieldsValid();
            }

            get
            {
                return validFiels;
            }
        }

        private EWorkingStatus workingStatus;

        public Hotel()
        {
            InitializeComponent();
        }

        private void SelecteContent(TextBox txt)
        {
            txt.SelectionStart = 0;
            txt.SelectionLength = txt.Text.Length;
        }

        private void TBWithSelection_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelecteContent(((TextBox)sender));
        }

        private void TBWithSelection_GotMouseCapture(object sender, MouseEventArgs e)
        {
            SelecteContent(((TextBox)sender));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TBName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsNameValid, TBName.Text, TBName);
        }

        private void TBOrt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsLocationValid, TBOrt.Text, TBOrt);
        }

        private void TBSterne_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.AreStarsValid, TBSterne.Text, TBSterne);
        }

        private void TBManager_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsManageValid, TBManager.Text, TBManager);
        }

        private void TBAnzahlZimmer_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsCountOfRoomsValid, TBAnzahlZimmer.Text, TBAnzahlZimmer);
        }

        private void TBTagespreis_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsDailyPriceValid, TBTagespreis.Text, TBTagespreis);
        }

        private void TBTelefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsTelephonenumberValid, TBTelefon.Text, TBTelefon);
        }

        private void TBWeb_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsURLValid, TBWeb.Text, TBWeb);
        }

        private void areFieldsValid()
        {
            if(RegexLib.RegexMatcher(RegexLib.IsNameValid, TBName.Text, TBName) &&
               RegexLib.RegexMatcher(RegexLib.IsLocationValid, TBOrt.Text, TBOrt) &&
               RegexLib.RegexMatcher(RegexLib.AreStarsValid, TBSterne.Text, TBSterne) &&
               RegexLib.RegexMatcher(RegexLib.IsManageValid, TBManager.Text, TBManager) &&
               RegexLib.RegexMatcher(RegexLib.IsCountOfRoomsValid, TBAnzahlZimmer.Text, TBAnzahlZimmer) &&
               RegexLib.RegexMatcher(RegexLib.IsDailyPriceValid, TBTagespreis.Text, TBTagespreis) &&
               RegexLib.RegexMatcher(RegexLib.IsTelephonenumberValid, TBTelefon.Text, TBTelefon) &&
               RegexLib.RegexMatcher(RegexLib.IsURLValid, TBWeb.Text, TBWeb))
            {
                areAllFieldsValid = true;
            }
            else
            {
                areAllFieldsValid = false;
            }
        }

        private void clearAllFiels()
        {
            TBAnzahlZimmer.Clear();
            TBEmail.Clear();
            TBManager.Clear();
            TBName.Clear();
            TBOrt.Clear();
            TBSterne.Clear();
            TBTagespreis.Clear();
            TBTelefon.Clear();
            TBWeb.Clear();
        }
        private void neu_Click(object sender, RoutedEventArgs e)
        {
            workingStatus = EWorkingStatus.CREATE;
            clearAllFiels();
        }

        private void TBEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsEmailValid, TBEmail.Text, TBEmail);
        }
    }
}
