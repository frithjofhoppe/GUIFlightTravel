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
using Infrastructure.DB;


namespace GUITravel
{
    /// <summary>
    /// Interaction logic for Hotel.xaml
    /// </summary>
    public partial class Hotel : UserControl
    {
        bool areAllFieldsValid = false;
        bool hasParent = false;

        private EWorkingStatus workingStatus;
        private EValidation validateionState;
        private Infrastructure.DB.Hotel currentHotel;
        private MainWindow parent;



        public Hotel()
        {
            InitializeComponent();
            validateionState = EValidation.INVALID;
            TBLand.ItemsSource = Infrastructure.Land.Lesen_Alle();
            TBLand.DisplayMemberPath = "Name";
            TBLand.SelectedValuePath = "LandID";
        }

        public Hotel(Infrastructure.DB.Hotel hotel, MainWindow parent)
        {
            InitializeComponent();
            TBLand.ItemsSource = Infrastructure.Land.Lesen_Alle();
            TBLand.DisplayMemberPath = "Name";
            TBLand.SelectedValuePath = "LandID";
            currentHotel = hotel;
            LoadEntity(hotel);
            workingStatus = EWorkingStatus.MODIFY;
            this.parent = parent;
            this.hasParent = true;
            this.parent.Title = hotel.Name;
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            long id;
            if (!String.IsNullOrEmpty(TBSearch.Text) && long.TryParse(TBSearch.Text, out id))
            {
                this.currentHotel = Infrastructure.Hotel.Lesen_HotelID(id);
                if (this.currentHotel != null)
                {
                    LoadEntity(this.currentHotel);
                    workingStatus = EWorkingStatus.MODIFY;
                }else
                {
                    MessageBox.Show("Das Hotel mit der eingegebenen Id konnte nicht gefunden werden","Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateionState == EValidation.VALID)
            {
                if (workingStatus == EWorkingStatus.CREATE)
                {
                    Infrastructure.DB.Hotel hotel = new Infrastructure.DB.Hotel();

                    UpdateEntity(hotel);
              
                    long hotelId = Infrastructure.Hotel.Erstellen(hotel);
                    this.currentHotel = Infrastructure.Hotel.Lesen_HotelID(hotelId);
                    MessageBox.Show("Der Eintrag wurde erstellt", "Abgeschlossen", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (workingStatus == EWorkingStatus.MODIFY)
                {
                    UpdateEntity(this.currentHotel);
                    Infrastructure.Hotel.Aktualisieren(this.currentHotel);
                    MessageBox.Show("Ihre Änderungen wurde übernommen", "Änderungen", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Überprüfen sie ihre Angaben", "Invalid", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UpdateEntity(Infrastructure.DB.Hotel hotel)
        {
            hotel.Email = TBEmail.Text;
            hotel.Manager = TBManager.Text;
            hotel.Name = TBName.Text;
            hotel.Ort = TBOrt.Text;
            hotel.Telefon = TBTelefon.Text;
            hotel.Web = TBWeb.Text;
            hotel.Sterne = byte.Parse(TBSterne.Text);
            hotel.TagesPreis = decimal.Parse(TBTagespreis.Text);
            hotel.AnzahlZimmer = short.Parse(TBAnzahlZimmer.Text);
            hotel.Land = long.Parse(TBLand.SelectedValue.ToString());
        }
       

        private void TBName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsNameValid, TBName.Text, TBName);
            areFieldsValid();
        }

        private void TBOrt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsLocationValid, TBOrt.Text, TBOrt);
            areFieldsValid();
        }

        private void TBSterne_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.AreStarsValid, TBSterne.Text, TBSterne);
            areFieldsValid();
        }

        private void TBManager_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsManageValid, TBManager.Text, TBManager);
            areFieldsValid();
        }

        private void TBAnzahlZimmer_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsCountOfRoomsValid, TBAnzahlZimmer.Text, TBAnzahlZimmer);
            areFieldsValid();
        }

        private void TBTagespreis_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsDailyPriceValid, TBTagespreis.Text, TBTagespreis);
            areFieldsValid();
        }

        private void TBTelefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsTelephonenumberValid, TBTelefon.Text, TBTelefon);
            areFieldsValid();
        }

        private void TBWeb_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsURLValid, TBWeb.Text, TBWeb);
            areFieldsValid();
        }

        private void areFieldsValid()
        {
            if (RegexLib.RegexMatcher(RegexLib.IsNameValid, TBName.Text, TBName) &&
               RegexLib.RegexMatcher(RegexLib.IsLocationValid, TBOrt.Text, TBOrt) &&
               RegexLib.RegexMatcher(RegexLib.AreStarsValid, TBSterne.Text, TBSterne) &&
               RegexLib.RegexMatcher(RegexLib.IsManageValid, TBManager.Text, TBManager) &&
               RegexLib.RegexMatcher(RegexLib.IsCountOfRoomsValid, TBAnzahlZimmer.Text, TBAnzahlZimmer) &&
               RegexLib.RegexMatcher(RegexLib.IsDailyPriceValid, TBTagespreis.Text, TBTagespreis) &&
               RegexLib.RegexMatcher(RegexLib.IsTelephonenumberValid, TBTelefon.Text, TBTelefon) &&
               RegexLib.RegexMatcher(RegexLib.IsURLValid, TBWeb.Text, TBWeb))
            {
                validateionState = EValidation.VALID;
            }
            else
            {
                validateionState = EValidation.INVALID;
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
            TBLand.SelectedItem = null;
        }
        private void neu_Click(object sender, RoutedEventArgs e)
        {
            workingStatus = EWorkingStatus.CREATE;
            clearAllFiels();
            this.currentHotel = null;
        }

        private void TBEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegexLib.RegexMatcher(RegexLib.IsEmailValid, TBEmail.Text, TBEmail);
            areFieldsValid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (hasParent)
            {
                this.parent.Title = "List";
                this.parent.showPlace.Children.Clear();
                this.parent.showPlace.Children.Add(new HotelList(parent));
            }
            else
            {
                workingStatus = EWorkingStatus.CANCEL;
                clearAllFiels();
                MessageBox.Show("Der Vorgang wurde abgebrochen", "Abbrechen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(this.currentHotel != null && this.currentHotel.HotelID > 0)
            {
                MessageBoxResult mbr = MessageBox.Show("Wollen sie das Hotel '" + this.currentHotel.Name + "' wirklich löschen?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(mbr == MessageBoxResult.Yes)
                {
                    Infrastructure.Hotel.Loeschen(this.currentHotel);
                    clearAllFiels();
                }
            }
        }

        private void LoadEntity(Infrastructure.DB.Hotel hotel)
        {
            if(this.currentHotel.HotelID > 0)
            {
                Land land = Infrastructure.Land.Lesen_LandID(hotel.Land);
                IMGLand.Source = Infrastructure.Land.byteArrayToImage(land.Flagge);
                TBName.Text = hotel.Name;
                TBManager.Text = hotel.Manager;
                TBOrt.Text = hotel.Ort;
                TBSterne.Text = hotel.Sterne.ToString();
                TBTagespreis.Text = hotel.TagesPreis.ToString();
                TBTelefon.Text = hotel.Telefon;
                TBWeb.Text = hotel.Web;
                TBAnzahlZimmer.Text = hotel.AnzahlZimmer.ToString();
                TBEmail.Text = hotel.Email;
                TBLand.SelectedValue = hotel.Land;
            }
        }
    }
}
