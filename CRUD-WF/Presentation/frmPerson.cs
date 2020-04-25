using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_WF.Models;

namespace CRUD_WF.Presentation
{
    public partial class frmPerson : Form
    {
        public frmPerson()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a entity
            Person oPerson = new Person();
            //Acess to data
            oPerson.Id = int.Parse(this.txtDNI.Text);
            oPerson.FirstName = txtFirstName.Text;
            oPerson.LastName = txtLastName.Text;
            oPerson.DateOfBirth = dtpDateOfBirth.Value;
            oPerson.Age = txtAge.Text;
            oPerson.Address = txtAdress.Text;
            oPerson.City = txtCity.Text;

            //using EF
            using (DBPersonEntities1 db = new DBPersonEntities1())
            {
                //Save in the tPerson
                db.People.Add(oPerson);
                db.SaveChanges();

            }

            MessageBox.Show("Save Suscesfull");
            this.Close();
        }
    }
}
