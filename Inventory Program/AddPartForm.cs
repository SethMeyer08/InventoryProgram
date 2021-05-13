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
    public partial class AddPartForm : Form
    {
        public AddPartForm()
        {
            InitializeComponent();
            inHouseRadio.Checked = true;
        }

        private void inHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            MachineOrCompanyLabel.Text = "Machine ID";
        }

        private void outsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            MachineOrCompanyLabel.Text = "Company Name";
        }

        private void AddPartSaveButton_Click(object sender, EventArgs e)
        {
            if (inHouseRadio.Checked)
            {
                inHouseRadio.Checked = true;
                Inhouse inhousePart = new Inhouse(int.Parse(AddPartIDBox.Text), AddPartNameBox.Text, decimal.Parse(AddPartPriceBox.Text), int.Parse(AddPartInventoryBox.Text),
                    int.Parse(AddPartMinBox.Text), int.Parse(AddPartMaxBox.Text), int.Parse(AddPartMachOrCompBox.Text));
                if (String.IsNullOrWhiteSpace(AddPartNameBox.Text))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                if (int.Parse(AddPartIDBox.Text) != inhousePart.PartID)
                {
                    MessageBox.Show("Cannot alter Product's ID.");
                    return;
                }
                if (int.Parse(AddPartInventoryBox.Text) > int.Parse(AddPartMaxBox.Text))
                {
                    MessageBox.Show("Stock level cannot exceed Maximum stock level.");
                    return;
                }
                if (int.Parse(AddPartMinBox.Text) > int.Parse(AddPartMaxBox.Text))
                {
                    MessageBox.Show("Minimum stock level cannot exceed Maximum stock level.");
                }
                else
                {
                    Inventory.AddPart(inhousePart);
                }
            }
            else
            {
                outsourcedRadio.Checked = true;
                Outsourced outsourcedPart = new Outsourced(int.Parse(AddPartIDBox.Text), AddPartNameBox.Text, decimal.Parse(AddPartPriceBox.Text), int.Parse(AddPartInventoryBox.Text),
                    int.Parse(AddPartMinBox.Text), int.Parse(AddPartMaxBox.Text), AddPartMachOrCompBox.Text);
                if (String.IsNullOrWhiteSpace(AddPartNameBox.Text))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                if (int.Parse(AddPartIDBox.Text) != outsourcedPart.PartID)
                {
                    MessageBox.Show("Cannot alter Product's ID.");
                    return;
                }
                if (int.Parse(AddPartInventoryBox.Text) > int.Parse(AddPartMaxBox.Text))
                {
                    MessageBox.Show("Stock level cannot exceed Maximum stock level.");
                    return;
                }
                if (int.Parse(AddPartMinBox.Text) > int.Parse(AddPartMaxBox.Text))
                {
                    MessageBox.Show("Minimum stock level cannot exceed Maximum stock level.");
                    return;
                }
                else
                {
                    Inventory.AddPart(outsourcedPart);
                }
            }

            Close();
        }

        private void AddPartCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
