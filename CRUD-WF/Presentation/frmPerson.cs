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
        public int? id;
        Person oPerson = null;
        public frmPerson(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id!=null)
            {
                Update();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private new void Update()
        {
            using (DBPersonEntities db = new DBPersonEntities())
            {
                oPerson = db.People.Find(id);
                
                txtDNI.Text= oPerson.Id.ToString();
                txtFirstName.Text = oPerson.FirstName;
                txtLastName.Text = oPerson.LastName;
                dtpDateOfBirth.Value = oPerson.DateOfBirth;
                txtAge.Text = oPerson.Age;
                txtAdress.Text = oPerson.Address;
                txtCity.Text = oPerson.City;
            }
        }
        private void Save()
        {
            //using EF
            using (DBPersonEntities db = new DBPersonEntities())
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
                
                if (id==null) oPerson = new Person();

                //Save in the tPerson
                if (id ==null) db.People.Add(oPerson);
                else db.Entry(oPerson).State = System.Data.Entity.EntityState.Modified;
               
                db.SaveChanges();
            }

            MessageBox.Show("Save Successfull");
            this.Close();
        }
    }
}
