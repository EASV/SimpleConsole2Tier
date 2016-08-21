using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLogicLayer;
using DataLogicLayer.Entities;
using DataLogicLayer.Managers;

namespace PersonManagerWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var pm = new DLLFacade().GetPersonManager();

           /* var bindingList = new BindingList<Person>(pm.GetPersons());
            var source = new BindingSource(bindingList, null);
            personDataGrid.DataSource = source;
            */
            personLst.DataSource = pm.GetPersons();
        }
        
        private void personLst_SelectedValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(personLst.SelectedItem);
            var person = personLst.SelectedItem as Person;

            if(person == null) return;
            
            nameTxt.Text = person.Name;
            emailTxt.Text = person.Email;
            
        }
    }
}
