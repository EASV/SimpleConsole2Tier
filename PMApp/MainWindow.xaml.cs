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

namespace PMApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPersonManager manager = 
            new DLLFacade().GetPersonManager();
        public MainWindow()
        {
            
            InitializeComponent();

            LstPersons.ItemsSource = manager.GetPersons();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Window1();
            if (dialog.ShowDialog() == true)
            {
                Console.WriteLine(dialog.Person);
            }
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
