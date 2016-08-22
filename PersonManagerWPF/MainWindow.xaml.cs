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
using DataLogicLayer;
using DataLogicLayer.Entities;

namespace PersonManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IPersonManager _pm = new DLLFacade().GetPersonManager();
        public MainWindow()
        {
            //Dont touch components until after InitializeComponent is called.
            InitializeComponent();
            LstPersons.ItemsSource = _pm.GetPersons();


        }

        private void LstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = LstPersons.SelectedItem as Person;
            if (person != null)
            {
                TxtName.Text = person.Name;
                TxtEmail.Text = person.Email;
            }
        }
    }
}
