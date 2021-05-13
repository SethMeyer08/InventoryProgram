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
    public partial class ModifyPartForm : Form

    {
        public ModifyPartForm()
        {
            InitializeComponent();
        }

        public ModifyPartForm(Inhouse inhouse)
        {
            InitializeComponent();

            ModIDBox.Text = Convert.ToString(inhouse.PartID);
            ModNameBox.Text = inhouse.Name;
            ModInventoryBox.Text = Convert.ToString(inhouse.InStock);
            ModPriceBox.Text = Convert.ToString(inhouse.Price);
            ModMinBox.Text = Convert.ToString(inhouse.Min);
            ModMaxBox.Text = Convert.ToString(inhouse.Max);
            ModMachineIDBox.Text = Convert.ToString(inhouse.MachineID);
            MachineOrCompanyLabel.Text = "Machine ID";
            radioInhouse.Checked = true;
        }

        public ModifyPartForm(Outsourced outsourced)
        {
            InitializeComponent();

            ModIDBox.Text = Convert.ToString(outsourced.PartID);
            ModNameBox.Text = outsourced.Name;
            ModInventoryBox.Text = Convert.ToString(outsourced.InStock);
            ModPriceBox.Text = Convert.ToString(outsourced.Price);
            ModMinBox.Text = Convert.ToString(outsourced.Min);
            ModMaxBox.Text = Convert.ToString(outsourced.Max);
            ModMachineIDBox.Text = Convert.ToString(outsourced.CompanyName);
            MachineOrCompanyLabel.Text = "Company Name";
            radioOutsourced.Checked = true;
        }

        private void RadioInhouse_CheckedChanged(object sender, EventArgs e)
        {
            MachineOrCompanyLabel.Text = "Machine ID";
        }

        private void RadioOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            MachineOrCompanyLabel.Text = "Company Name";
        }

        private void ModSaveButton_Click(object sender, EventArgs e)
        {
            if (radioInhouse.Checked)
            {
                radioInhouse.Checked = true;

                if (String.IsNullOrWhiteSpace(ModIDBox.Text) || String.IsNullOrWhiteSpace(ModNameBox.Text) || String.IsNullOrWhiteSpace(ModPriceBox.Text)
                    || String.IsNullOrWhiteSpace(ModInventoryBox.Text) || String.IsNullOrWhiteSpace(ModMinBox.Text) || String.IsNullOrWhiteSpace(ModMaxBox.Text))
                {
                    MessageBox.Show("Fields cannot be empty.");
                    return;
                }

                if (int.Parse(ModIDBox.Text).GetType() != typeof(int) || int.Parse(ModInventoryBox.Text).GetType() != typeof(int)
                    || int.Parse(ModMinBox.Text).GetType() != typeof(int) || int.Parse(ModMaxBox.Text).GetType() != typeof(int))
                {
                    MessageBox.Show("These fields require integers.");
                    return;
                }

                if (decimal.Parse(ModPriceBox.Text).GetType() != typeof(decimal))
                {
                    MessageBox.Show("Your price must be a decimal. Example: 15.00");
                    return;
                }

                if (int.Parse(ModInventoryBox.Text) > int.Parse(ModMaxBox.Text))
                {
                    MessageBox.Show("Your Inventory cannot exceed the Maximumu.");
                    return;
                }

                if (int.Parse(ModMinBox.Text) > int.Parse(ModMaxBox.Text))
                {
                    MessageBox.Show("The Minimum cannot exceed the Maximum.");
                    return;
                }
                else
                {
                    try
                    {
                        Inhouse inhousePart = new Inhouse(int.Parse(ModIDBox.Text), ModNameBox.Text, decimal.Parse(ModPriceBox.Text), int.Parse(ModInventoryBox.Text),
                            int.Parse(ModMinBox.Text), int.Parse(ModMaxBox.Text), int.Parse(ModMachineIDBox.Text));
                        Inventory.UpdatePart(int.Parse(ModIDBox.Text), inhousePart);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error.");
                        //throw;
                    }
                    this.Close();
                }

            }
            else
            {
                radioOutsourced.Checked = true;

                if (String.IsNullOrWhiteSpace(ModIDBox.Text) || String.IsNullOrWhiteSpace(ModNameBox.Text) || String.IsNullOrWhiteSpace(ModPriceBox.Text)
                    || String.IsNullOrWhiteSpace(ModInventoryBox.Text) || String.IsNullOrWhiteSpace(ModMinBox.Text) || String.IsNullOrWhiteSpace(ModMaxBox.Text))
                {
                    MessageBox.Show("Fields cannot be empty.");
                    return;
                }

                if (int.Parse(ModIDBox.Text).GetType() != typeof(int) || int.Parse(ModInventoryBox.Text).GetType() != typeof(int)
                    || int.Parse(ModMinBox.Text).GetType() != typeof(int) || int.Parse(ModMaxBox.Text).GetType() != typeof(int))
                {
                    MessageBox.Show("These fields require integers.");
                    return;
                }

                if (decimal.Parse(ModPriceBox.Text).GetType() != typeof(decimal))
                {
                    MessageBox.Show("Your price must be a decimal. Example: 15.00");
                    return;
                }

                if (int.Parse(ModInventoryBox.Text) > int.Parse(ModMaxBox.Text))
                {
                    MessageBox.Show("Your Inventory cannot exceed the Maximum.");
                    return;
                }

                if (int.Parse(ModMinBox.Text) > int.Parse(ModMaxBox.Text))
                {
                    MessageBox.Show("The Minimum cannot exceed the Maximum.");
                    return;
                }
                else
                {
                    try
                    {
                        Outsourced outsourcedPart = new Outsourced(int.Parse(ModIDBox.Text), ModNameBox.Text, decimal.Parse(ModPriceBox.Text), int.Parse(ModInventoryBox.Text),
                            int.Parse(ModMinBox.Text), int.Parse(ModMaxBox.Text), ModMachineIDBox.Text);
                        Inventory.UpdatePart(int.Parse(ModIDBox.Text), outsourcedPart);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error.");
                        throw;
                    }
                    this.Close();
                }
            }
        }

        private void ModCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModMachineIDBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
