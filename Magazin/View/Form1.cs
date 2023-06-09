using Magazin.Controller;
using Magazin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Type = Magazin.Models.Type;

namespace Magazin.View
{
    public partial class Form1 : Form
    {
        ProductLogic productController = new ProductLogic();
        TypeLogic typeController = new TypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Product product)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = product.Id.ToString();
            textBox5.Text = product.Marka;
            textBox2.Text = product.Srok.ToString();
            textBox3.Text = product.Price.ToString();
            textBox4.Text = product.Opisanie;
            comboBox1.Text = product.Types.Name;
        }
        private void ClearSreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
        }

        private void Magazin_Load(object sender, EventArgs e)
        {
            List<Type> allTypes = typeController.GetAllTypes();
            comboBox1.DataSource = allTypes;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            button5_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Product> allproducts = productController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allproducts)
            {
                listBox1.Items.Add($"{item.Id}. Marka: {item.Marka}, Opisanie: {item.Opisanie}, Price: {item.Price}, Srok: {item.Srok} Type:{item.Types.Name}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.White;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Product findedProduct = productController.Get(findId);
            if (findedProduct == null)
            {
                MessageBox.Show("Няма такъв запис в БД!/n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;

            }
            LoadRecord(findedProduct);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете  Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);

            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                Product findedProduct = productController.Get(findId);
                if (findedProduct == null)
                {
                    MessageBox.Show("Няма такъв запис в БД!/ n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedProduct);
            } 
            else

            {
                Product updateProduct = new Product();
                updateProduct.Marka = textBox2.Text;
                updateProduct.Opisanie = textBox4.Text;
                updateProduct.Srok = int.Parse(textBox2.Text);
                updateProduct.Price = double.Parse(textBox3.Text);
                updateProduct.TypesId = (int)comboBox1.SelectedValue;
                productController.Update(findId, updateProduct);
            }
            button5_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете id за търсене!");
                textBox1.BackColor = Color.Red; textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Product findedProduct = productController.Get(findId);
            if (findedProduct == null)
            {
                MessageBox.Show("Няма такъв запис в БД!/n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red; textBox1.Focus();
                return;

            }
            LoadRecord(findedProduct);
            DialogResult answer = MessageBox.Show("Наистина ли искате  да изтриете запис №" + findId + "?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)

            {
                productController.Delete(findId);
            }
            button5_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text)||textBox2.Text =="")
            {
                MessageBox.Show("Въведете данни!");
                textBox2.Focus();
                return;
            }
            Product newProduct = new Product();
            newProduct.Marka = (textBox5.Text);
            newProduct.Price=double.Parse(textBox3.Text);
            newProduct.Srok = int.Parse(textBox2.Text);
            newProduct.Opisanie= (textBox4.Text);
            newProduct.TypesId = (int)comboBox1.SelectedValue;
            productController.Create(newProduct);
            MessageBox.Show("Записът е успешно добавен!");
            ClearSreen();
            button5_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
