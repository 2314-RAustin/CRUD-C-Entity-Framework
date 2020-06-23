using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobertoCRUD.Models;

namespace RobertoCRUD.Presentational
{
    public partial class Form1 : Form
    {
        private int? id;
        private datos_users _dataUser = null;

        public Form1(int? id=null)
        {
            InitializeComponent();

            this.id = id;

            if (id != null)
            {
                loadData();
            }
        }

        private void loadData()
        {
            using (var db = new CrudEntities())
            {
                _dataUser = db.datos_users.Find(id);
                txtName.Text = _dataUser.nombre;
                txtEmail.Text = _dataUser.correo;
                dtpBirth.Value = _dataUser.fecha_nacimiento;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new CrudEntities())
            {
                if (id == null)
                {
                    _dataUser = new datos_users();    
                }

                _dataUser.nombre = txtName.Text;
                _dataUser.correo = txtEmail.Text;
                _dataUser.fecha_nacimiento = dtpBirth.Value;

                if (id == null)
                {
                    db.datos_users.Add(_dataUser);
                }
                else
                {
                    db.Entry(_dataUser).State = System.Data.Entity.EntityState.Modified;
                }
                
                db.SaveChanges();

                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
