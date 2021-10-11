using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class Pos : Form
    {
        public Pos()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        Bitmap bitmap;

        private void Change()
        {
            double tax, q, c;
            tax = 3.9;

            if (dataGridView1.Rows.Count > 0)
            {
                q = ((CostofItem() * tax) / 100) + CostofItem();
                c = Convert.ToInt32(lblCost.Text);
                lblChange.Text = String.Format("(0:c2)", c * q);

            }
        }

        public double CostofItem()
        {
            double sum = 0;
            int num = 0;

            for (num = 0; num < dataGridView1.Rows.Count; num++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[num].Cells[2].Value);
            }

            return sum;
        }

        private void AddCost()
        {
            Double tax, q;
            tax = 3.9;

            if (dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format("(R4.9)", ((((CostofItem() * tax) / 100))));
                q = ((CostofItem() * tax) / 100);
                lblTotal.Text = String.Format("R50", (CostofItem() + q));
                Convert.ToString(q * CostofItem());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lblChange.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                lblCost.Text = "0";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button press = (Button)sender;

            if (lblCost.Text == "0")
            {
                lblCost.Text = "";
                lblCost.Text = press.Text;
            }
            else if (press.Text == ("."))
            {
                if (!lblCost.Text.Contains("."))
                {
                    lblCost.Text = lblCost.Text + press.Text;
                }
            }
            else
            {
                lblCost.Text = lblCost.Text + press.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblCost.Text = "0";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                Change();

                MessageBox.Show("Payment Successful");
            }
            else 
            {
                lblChange.Text = "";
                lblCost.Text = "0";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();

            if (radioCash.Checked == true)
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCost.Text = "0";
            }
        }

        private void btnPap_Click(object sender, EventArgs e)
        {
            Double costOfItem = 7.00;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Pap"))
                { 
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Pap", "1", costOfItem);
            AddCost();
        }

        private void btnSteak_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Steak"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Steak", "1", costOfItem);
            AddCost();
        }

        private void btnWors_Click(object sender, EventArgs e)
        {
            Double costOfItem = 23;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Wors"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Wors", "1", costOfItem);
            AddCost();
        }

        private void btnGravy_Click(object sender, EventArgs e)
        {
            Double costOfItem = 5.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Gravy"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Gravy", "1", costOfItem);
            AddCost();
        }

        private void btnChakalaka_Click(object sender, EventArgs e)
        {
            Double costOfItem = 5.00;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Chakalaka"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Chakalaka", "1", costOfItem);
            AddCost();
        }

        private void btnMogodu_Click(object sender, EventArgs e)
        {
            Double costOfItem = 40.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mogodu"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Mogodu", "1", costOfItem);
            AddCost();
        }

        private void btnChips_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Chips"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Chips", "1", costOfItem);
            AddCost();
        }

        private void btnSkopo_Click(object sender, EventArgs e)
        {
            Double costOfItem = 50;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Skopo"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Skopo", "1", costOfItem);
            AddCost();
        }

        private void btnDumpling_Click(object sender, EventArgs e)
        {
            Double costOfItem = 15.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Dumpling"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Dumpling", "1", costOfItem);
            AddCost();
        }

        private void btnHeineken_Click(object sender, EventArgs e)
        {
            Double costOfItem = 23.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Heineken"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Heineken", "1", costOfItem);
            AddCost();
        }

        private void btnCorona_Click(object sender, EventArgs e)
        {
            Double costOfItem = 25.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Corona"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Corona", "1", costOfItem);
            AddCost();
        }

        private void btnFlyingFish_Click(object sender, EventArgs e)
        {
            Double costOfItem = 23.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Flying Fish"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Flying Fish", "1", costOfItem);
            AddCost();
        }

        private void btnBlackLabel_Click(object sender, EventArgs e)
        {
            Double costOfItem = 19.00;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Black Label"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Black Label", "1", costOfItem);
            AddCost();
        }

        private void btnSvannah_Click(object sender, EventArgs e)
        {
            Double costOfItem = 25.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Savannah"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Savannah", "1", costOfItem);
            AddCost();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Brutal Fruit"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Brutal Fruit", "1", costOfItem);
            AddCost();
        }

        private void btnStella_Click(object sender, EventArgs e)
        {
            Double costOfItem = 25;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Stella"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Stella", "1", costOfItem);
            AddCost();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Water"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Water", "1", costOfItem);
            AddCost();
        }

        private void btnHennessy_Click(object sender, EventArgs e)
        {
            Double costOfItem = 800.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Hennnessy"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Hennessy", "1", costOfItem);
            AddCost();
        }

        private void btnJagermeister_Click(object sender, EventArgs e)
        {
            Double costOfItem = 450.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Jagermeister"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Jagermeister", "1", costOfItem);
            AddCost();
        }

        private void btnGordon_Click(object sender, EventArgs e)
        {
            Double costOfItem = 260.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Gordon"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Gordon", "1", costOfItem);
            AddCost();
        }

        private void btnRussianBear_Click(object sender, EventArgs e)
        {
            Double costOfItem = 180.0;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Russian Bear"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Russian Bear", "1", costOfItem);
            AddCost();
        }
    }
}
