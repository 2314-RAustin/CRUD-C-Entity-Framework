using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobertoCRUD.Models;

namespace RobertoCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            using (var db = new CrudEntities())
            {
                var list = from d in db.datos_users
                           select d;
                dataGridView1.DataSource = list.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentational.Form1 F1 = new Presentational.Form1();
            F1.ShowDialog();

            refreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                Presentational.Form1 F1 = new Presentational.Form1(id);
                F1.ShowDialog();

                refreshData();
            }

        }

        private int? getId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if (id != null)
            {
                using (CrudEntities db = new CrudEntities())
                {
                    datos_users dataUsers = db.datos_users.Find(id);
                    db.datos_users.Remove(dataUsers);
                }
                
                refreshData();
            }
        }
    }
}
