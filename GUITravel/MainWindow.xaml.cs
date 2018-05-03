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

namespace GUITravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Travel";
        }


        private void btnHotel_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Hotel";
            this.showPlace.Children.Clear();
            this.showPlace.Children.Add(new Hotel());
        }

        private void btnKunde_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Kunde";
            this.showPlace.Children.Clear();
            this.showPlace.Children.Add(new Kunde());
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "List";
            this.showPlace.Children.Clear();
            this.showPlace.Children.Add(new HotelList(this));
        }
    }
}
