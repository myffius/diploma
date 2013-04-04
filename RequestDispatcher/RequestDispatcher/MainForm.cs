using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequestDispatcher.RdMath;

namespace RequestDispatcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NormalDistribution distribution = new NormalDistribution(1, 0.1);
            for (int i = 0; i < 50; i++)
            {
                //int countTasks = (int) (distribution.DistributionValue(i) * 10);
                double countTasks = distribution.DistributionValue(i);
                chart1.Series[0].Points.AddXY(i, countTasks);
            }
        }
    }
}
