using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequestDispatcher.RdMath;
using RequestDispatcher.Components;

namespace RequestDispatcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            for (int i = 1; i < 6; i++)
            {
                String identifier = "Обработчик " + Convert.ToString(i);
                dataGridView1.Rows.Add(identifier, 2.7, 2048);
            }
            createDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NormalDistribution distribution = new NormalDistribution(1, 0.1);
            for (int i = 0; i < 50; i++)
            {
                //int countTasks = (int) (distribution.DistributionValue(i) * 10);
                double countTasks = distribution.Value(i);
                chart1.Series[0].Points.AddXY(i, countTasks);
            }
        }

        private void createDataGrid()
        {
            DataGridView rdDataGridView = new DataGridView();
            RdDataGridViewCellColumn column;

            rdDataGridView.ColumnHeadersHeight = 28;
            rdDataGridView.RowHeadersVisible = false;
            rdDataGridView.Dock = DockStyle.Top;
            rdDataGridView.RowTemplate.ContextMenuStrip = contextMenuStrip1;
            rdDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            rdDataGridView.BackgroundColor = Color.GhostWhite;

            
            rdDataGridView.RowTemplate.DefaultCellStyle.Padding = new Padding(5);
            rdDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            

            column = new RdDataGridViewCellColumn();
            column.HeaderText = "Идентификатор";
            rdDataGridView.Columns.Add(column);


            rdDataGridView.Rows.Add("");


            rdDataGridView.Rows[0].Height = 28;
            //tabControl1.TabPages[0].Controls.Add(rdDataGridView);
            this.Controls.Add(rdDataGridView);
        }

        private void tabControlDrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.DimGray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }   
}
