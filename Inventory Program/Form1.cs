using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Program___C968___Seth_Meyer
{
    public partial class Form1 : Form
    {

        Product product = new Product();
        public Form1()
        {
            InitializeComponent();
            InitializePartsAndProducts();
            RefreshGrid();
        }

        public void MainScreenLoader(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        public static void InitializePartsAndProducts()
        {
            Inventory.Parts.Add(new Inhouse(00001, "Emitter", 25.00m, 34, 2, 54, 1977));
            Inventory.Parts.Add(new Inhouse(00002, "Switch", 12.00m, 23, 2, 50, 1978));
            Inventory.Parts.Add(new Inhouse(00003, "Body", 50.00m, 45, 2, 100, 1979));
            Inventory.Parts.Add(new Inhouse(00004, "Pommel", 6.00m, 75, 2, 100, 1980));

            Inventory.Parts.Add(new Outsourced(90001, "Kyber Crystal - Blue", 42.00m, 10, 2, 100, "Ilum"));
            Inventory.Parts.Add(new Outsourced(90002, "Kyber Crystal - Green", 42.00m, 12, 2, 100, "Ilum"));
            Inventory.Parts.Add(new Outsourced(90003, "Kyber Crystal - Red", 42.00m, 66, 2, 100, "Ilum"));

            Inventory.Products.Add(new Product(1, "Blue Lightsaber", 200.00m, 42, 0, 100));
            Inventory.Products.Add(new Product(2, "Red Lightsaber", 200.00m, 66, 0, 100));

            Inventory.LookupProduct(1).AddAssociatedPart(Inventory.LookupPart(00001));
            Inventory.LookupProduct(1).AddAssociatedPart(Inventory.LookupPart(00002));
            Inventory.LookupProduct(1).AddAssociatedPart(Inventory.LookupPart(00003));
            Inventory.LookupProduct(1).AddAssociatedPart(Inventory.LookupPart(00004));
            Inventory.LookupProduct(1).AddAssociatedPart(Inventory.LookupPart(90001));

            Inventory.LookupProduct(2).AddAssociatedPart(Inventory.LookupPart(00001));
            Inventory.LookupProduct(2).AddAssociatedPart(Inventory.LookupPart(00002));
            Inventory.LookupProduct(2).AddAssociatedPart(Inventory.LookupPart(00003));
            Inventory.LookupProduct(2).AddAssociatedPart(Inventory.LookupPart(00004));
            Inventory.LookupProduct(2).AddAssociatedPart(Inventory.LookupPart(90003));
        }

        public void RefreshGrid()
        {
            dataGridView1.DataSource = Inventory.Parts;
            dataGridView1.ClearSelection();

            dataGridView2.DataSource = Inventory.Products;
            dataGridView2.ClearSelection();
        }

        private void addButton1_Click(object sender, EventArgs e)
        {
            AddPartForm addPartFrom = new AddPartForm();
            addPartFrom.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifyButton1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.DataBoundItem.GetType() == typeof(Inhouse))
            {
                Inhouse inhousePart = (Inhouse)dataGridView1.CurrentRow.DataBoundItem;
                new ModifyPartForm(inhousePart).ShowDialog();
            }
            else if (dataGridView1.CurrentRow.DataBoundItem.GetType() == typeof(Outsourced))
            {
                Outsourced outsourcedPart = (Outsourced)dataGridView1.CurrentRow.DataBoundItem;
                new ModifyPartForm(outsourcedPart).ShowDialog();
            }
        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void modifyButton2_Click(object sender, EventArgs e)
        {
            Product product = (Product)dataGridView2.CurrentRow.DataBoundItem;
            new ModifyProductForm(product).ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchBox1.TextLength < 0)
            {
                return;
            }
            else
            {
                try
                {
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        Part part = (Part)row.DataBoundItem;
                        Part userEntry = Inventory.LookupPart(Convert.ToInt32(searchBox1.Text));

                        if (userEntry.PartID == part?.PartID)
                        {
                            row.Selected = true;
                            dataGridView1.CurrentCell = row.Cells[0];
                            return;
                        } 
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }

                catch
                {

                }
            }
        }

        private void searchButton_KeyDown(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Enter)
            {
                MessageBox.Show("It works!");  // It does not work.
            }
        }

        /*private void buttonTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It was pressed.");
        }*/

        private void searchButton2_Click(object sender, EventArgs e)
        {
            if (searchBox2.TextLength < 0)
            {
                return;
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        Product product = (Product)row.DataBoundItem;
                        Product userEntry = Inventory.LookupProduct(Convert.ToInt32(searchBox2.Text));

                        if (userEntry.ProductID == product?.ProductID)
                        {
                            row.Selected = true;
                            dataGridView2.CurrentCell = row.Cells[0];
                            return;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }

                catch
                {

                }
            }
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you wish to delete this item?", "Delete?", MessageBoxButtons.OKCancel);
            {
                if (confirm == DialogResult.OK)
                {
                    var rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    product.RemoveAssociatedPart(rowIndex);
                }
                else return;
            }
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you wish to delete this item?", "Delete?", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                Product product = (Product)dataGridView2.CurrentRow.DataBoundItem;
                if(product.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("Cannot delete a product with associated parts. Please remove assoicated parts prior to removing a product.");
                }
                else
                {
                    var rowIndex = dataGridView2.CurrentCell.RowIndex;
                    dataGridView2.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private void searchBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
