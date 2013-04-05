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
            }
            // createDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NormalDistribution distribution = new NormalDistribution(1, 0.1);
            for (int i = 0; i < 100; i++)
            {
                //int countTasks = (int) (distribution.DistributionValue(i) * 10);
                double countTasks = distribution.Random();
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
            TabControl tabControl = (TabControl)sender;

            // Get the item from the collection.
            TabPage _tabPage = tabControl.TabPages[e.Index];

            _tabPage.BorderStyle = BorderStyle.None;


            ///////////////////////////

            SolidBrush fillBrush = new SolidBrush(Color.DarkGray);

            //draw rectangle behind the tabs
            Rectangle lastTabRect = tabControl.GetTabRect(tabControl.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            //background.Location = new Point(lastTabRect.Left, lastTabRect.Bottom);
            background.Location = new Point(tabControl.Left, lastTabRect.Bottom);

            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            // background.Size = new Size(tabControl1.Bottom - background.Left, lastTabRect.Height + 1);
            background.Size = new Size(lastTabRect.Width, tabControl.Height);
            e.Graphics.FillRectangle(fillBrush, background);


            ///////////////////////////




            Brush backBrush = new SolidBrush(Color.DarkGray);
            g.FillRectangle(backBrush, e.Bounds);
            backBrush.Dispose();

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl.GetTabRect(e.Index);

            //MessageBox.Show(Convert.ToString(_tabBounds.Top));
            int newLeft = _tabBounds.Left - 8;
            int newTop = _tabBounds.Top;
            _tabBounds.Location = new Point(-100, newTop);
            _tabBounds.Size = new Size(120, 40);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                //g.FillRectangle(Brushes.WhiteSmoke, _tabBounds);
                g.FillRectangle(Brushes.Green, _tabBounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                g.FillRectangle(Brushes.Red, _tabBounds);
                //e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));

        }

        private void mainMenuLabelMouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.White;
        }

        private void mainMenuLabelMouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Transparent;
        }

        private void mainMenuLabelClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            mainMenuTabControl.TabIndex = 1;
        }
    }   
}
