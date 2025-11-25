using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Inventory.CustomExeptionClass;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {

        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;
        public frmAddProduct()
        {
            InitializeComponent();

            showProductList = new BindingSource();
            gridViewProductList.DataSource = showProductList;



        }

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new StringFormatException(name);
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
                throw new NumberFormatException(qty);
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
                throw new CurrencyFormatException(price);
            return Convert.ToDouble(price);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = { "Beverages", "Bread", "Canned", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        
           
       {
            try
            {
                string name = Product_Name(txtProductName.Text);
                int qty = Quantity(txtQuantity.Text);
                double price = SellingPrice(txtSellPrice.Text);

                var product = new { Name = name, Quantity = qty, Price = price };
                showProductList.Add(product);

                MessageBox.Show("Product added successfully!");
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show("String Error: " + ex.Message);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show("Number Error: " + ex.Message);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show("Currency Error: " + ex.Message);
            }
            finally
            {
                txtProductName.Clear();
                txtQuantity.Clear();
                txtSellPrice.Clear();
                txtProductName.Focus();
            }
        }
    }
}
        
    
