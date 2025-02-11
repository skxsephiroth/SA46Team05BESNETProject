﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA46Team05BESNETProject
{
    public partial class CrystalReportForm : Form
    {
        public CrystalReportForm()
        {
            InitializeComponent();
        }

        private void CrystalReportForm_Load(object sender, EventArgs e)
        {
            SA46Team05BESNETProjectDataSet ds = new SA46Team05BESNETProjectDataSet();
            SA46Team05BESNETProjectDataSetTableAdapters.TransactionsTableAdapter ta = new SA46Team05BESNETProjectDataSetTableAdapters.TransactionsTableAdapter();
            ta.Fill(ds.Transactions);

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;

        }
    }
}
