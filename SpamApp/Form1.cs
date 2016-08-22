using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLogicLayer;
using DataLogicLayer.Entities;

namespace SpamApp
{
    public partial class Form1 : Form
    {
        readonly IPersonManager _manager =
                new DLLFacade().GetPersonManager();

        public Form1()
        {
            InitializeComponent();

            personLstBox.DataSource = 
                _manager.GetPersons();

        }

        private void ListChanged(object sender, EventArgs e)
        {
            var person = 
                personLstBox.SelectedItem as Person;

            if (person != null)
            {
                nameTxt.Text = person.Name;
            }
        }

        private void personDeleteBtn_Click(object sender, EventArgs e)
        {
            var person =
                personLstBox.SelectedItem as Person;

            if (person != null)
            {
                _manager.Delete(person);
                nameTxt.Text = "";
                personLstBox.DataSource = _manager.GetPersons();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

