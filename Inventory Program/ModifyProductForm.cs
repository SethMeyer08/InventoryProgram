﻿using System;
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
    public partial class ModifyProductForm : Form
    {
        public ModifyProductForm(Product product)
        {

            InitializeComponent();

            IDBox.Text = Convert.ToString(product.ProductID);
            NameBox.Text = product.Name;
            InventoryBox.Text = Convert.ToString(product.InStock);
            PriceBox.Text = Convert.ToString(product.Price);
            MinBox.Text = Convert.ToString(product.Min);
            MaxBox.Text = Convert.ToString(product.Max);

            dataGridView1.DataSource = Inventory.Parts;
            dataGridView2.DataSource = product.AssociatedParts;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.TextLength < 0)
            {
                return;
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Part part = (Part)row.DataBoundItem;
                        Part userEntry = Inventory.LookupPart(Convert.ToInt32(searchTextBox.Text));

                        if (userEntry.PartID == part.PartID)
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
                catch { }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(IDBox.Text);
            int partID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            Product product = Inventory.LookupProduct(productID);
            Part part = Inventory.LookupPart(partID);
            Inventory.UpdateProduct(productID, product);
            product.AddAssociatedPart(part);
            dataGridView2.DataSource = product.AssociatedParts;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you wish to delete this item?", "Delete?", MessageBoxButtons.OKCancel);
            {
                if (confirm == DialogResult.OK)
                {
                    var rowIndex = dataGridView2.CurrentCell.RowIndex;
                    dataGridView2.Rows.RemoveAt(rowIndex);
                }
                else return;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(IDBox.Text) || String.IsNullOrWhiteSpace(NameBox.Text) || String.IsNullOrWhiteSpace(PriceBox.Text) || String.IsNullOrWhiteSpace(InventoryBox.Text) || String.IsNullOrWhiteSpace(MinBox.Text) || String.IsNullOrWhiteSpace(MaxBox.Text))
            {
                MessageBox.Show("Fields cannot be empty");
                return;
            }
            // verify integer fields are of the appropriate type
            if (int.Parse(IDBox.Text).GetType() != typeof(int) || int.Parse(InventoryBox.Text).GetType() != typeof(int) || int.Parse(MinBox.Text).GetType() != typeof(int) || int.Parse(MaxBox.Text).GetType() != typeof(int))
            {
                MessageBox.Show("Ensure fields that require integers contain integers");
                return;
            }
            // verify decimal field is of the appropriate type
            if (decimal.Parse(PriceBox.Text).GetType() != typeof(decimal))
            {
                MessageBox.Show("Ensure Price field entry is in decimal format. Example: 0.00");
                return;
            }
            // verify inventory level does not exceed max
            if (int.Parse(InventoryBox.Text) > int.Parse(MaxBox.Text))
            {
                MessageBox.Show("Inventory stock level cannot exceed Maximum permitted stock level");
                return;
            }
            // verify that minimum level does not exceed max
            if (int.Parse(MinBox.Text) > int.Parse(MaxBox.Text))
            {
                MessageBox.Show("Minimum permitted stock level cannot exceed Maximum permitted stock level");
                return;
            }
            else
            {
                // throw exception
                try
                {
                    Product product = new Product(int.Parse(IDBox.Text), NameBox.Text, decimal.Parse(PriceBox.Text), int.Parse(InventoryBox.Text), int.Parse(MinBox.Text), int.Parse(MaxBox.Text));
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            Part associatedPart = (Part)row.DataBoundItem;
                            product.AssociatedParts.Add(associatedPart);
                        }
                    }
                    catch { }
                    Inventory.UpdateProduct(int.Parse(IDBox.Text), product);
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                    throw;
                }
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
