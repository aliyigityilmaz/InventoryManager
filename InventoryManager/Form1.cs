using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{
    public partial class Form1 : Form
    {
        DataTable inventoryTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = "";
            nameTextBox.Text = "";
            categoryComboBox.SelectedIndex = -1;
            priceTextBox.Text = "";
            descTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String sku = skuTextBox.Text;
            String name = nameTextBox.Text;
            String price = priceTextBox.Text;
            String desc = descTextBox.Text;
            String quantity = quantityTextBox.Text;
            String category = (string)categoryComboBox.SelectedItem;

            inventoryTable.Rows.Add(sku, name, category, price, desc, quantity);

            newButton_Click(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error0: " + err);
                throw;
            }
        }

        private void inventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuTextBox.Text = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                categoryComboBox.SelectedItem = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                priceTextBox.Text = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                descTextBox.Text = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventoryTable.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error1: " + err);
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inventoryTable.Columns.Add("SKU");
            inventoryTable.Columns.Add("Name");
            inventoryTable.Columns.Add("Category");
            inventoryTable.Columns.Add("Price");
            inventoryTable.Columns.Add("Description");
            inventoryTable.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventoryTable;
        }
    }
}
