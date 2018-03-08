using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for TextBoxWithSelection.xaml
    /// </summary>
    public partial class TextBoxWithSelection : UserControl
    {
        public TextBoxWithSelection()
        {
            InitializeComponent();
        }

        private void SelecteContent()
        {
            TBWithSelection.SelectionStart = 0;
            TBWithSelection.SelectionLength = TBWithSelection.Text.Length;
        }

        private void TBWithSelection_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelecteContent();
        }
        
        private void TBWithSelection_GotMouseCapture(object sender, MouseEventArgs e)
        {
            SelecteContent();
        }
    }
}
