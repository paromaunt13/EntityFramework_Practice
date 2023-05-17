using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDatabaseSecond
{
    public partial class Form1 : Form
    {
        private CarContainer carsDB;
        public Form1()
        {
            InitializeComponent();
            carsDB = new CarContainer();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CarContainer carsDB = new CarContainer();
            carsDB.Cars.Add(new Car { CarBrand = "BMW", CarModel = "X5", CarPrice = 45000 });
            carsDB.Cars.Add(new Car { CarBrand = "Volvo", CarModel = "C40", CarPrice = 40000 });
            carsDB.Cars.Add(new Car { CarBrand = "Toyota", CarModel = "Camry", CarPrice = 35000 });
            carsDB.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carsDB.Cars.Load();
            dataGridView1.DataSource = carsDB.Cars.Local.ToBindingList();
        }

        
    }
}
