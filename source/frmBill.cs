using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Keyboard
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            bill.ItemDataTable items = new bill.ItemDataTable();
           var data= items.NewRow();
            data[0] = 1;
            data[1] = "keyboard";
            data[2] = "computer item";
            data[3] = 200.0;
            data[4] = DateTime.Now;
            items.Rows.Add(data);
            items.WriteXml(@"E:\dev\source\bill.xml");

        }
    }
}
