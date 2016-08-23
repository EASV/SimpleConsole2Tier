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
using System.Windows.Shapes;
using DataLogicLayer.Entities;

namespace PMApp
{
    /// <summary>
    /// Interaction logic for AddPersonDialog.xaml
    /// </summary>
    public partial class AddPersonDialog : Window
    {
        public AddPersonDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person = new Person
            {
                Name = TxtName.Text,
                Email = TxtEmail.Text
            };

            DialogResult = true;
        }

        public Person Person { get; set; }
    }
}
