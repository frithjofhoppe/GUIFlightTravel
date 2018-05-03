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
    /// Interaction logic for HotelList.xaml
    /// </summary>
    public partial class HotelList : UserControl
    {

        private UIElementCollection childrens;
        private MainWindow parent;
        
        public HotelList(MainWindow parent)
        {
            InitializeComponent();
            HotelListGrid.CanUserAddRows = false;
            HotelListGrid.IsReadOnly = true;
            HotelListGrid.CanUserSortColumns = true;
            HotelListGrid.SelectionMode = DataGridSelectionMode.Single;
            HotelListGrid.AutoGenerateColumns = false;
            HotelListGrid.ItemsSource = Infrastructure.Hotel.Lesen_Alle();
            this.parent = parent;
        }

        private void HotelListGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Infrastructure.DB.Hotel selectedHotel = ((Infrastructure.DB.Hotel)((DataGrid)sender).SelectedItem);
            this.childrens = ListGrid.Children;
            ListGrid.Children.Clear();
            ListGrid.Children.Add(new Hotel(selectedHotel, parent));
        }

       
    }
}
