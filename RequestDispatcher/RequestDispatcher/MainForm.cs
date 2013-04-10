using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RequestDispatcher.RdMath;
using RequestDispatcher.Components;
using RequestDispatcher.Storage;
using Finisar.SQLite;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace RequestDispatcher
{
    public partial class MainForm : Form
    {
        public SQLiteStorage storage;
        TaskGenerator generator;
        Dispatcher dispatcher = new QueueDispatcher();
        Thread backThread;
        List<Chart> charts = new List<Chart>();
        static int inc = 0;
        
        public MainForm()
        {
            InitializeComponent();
            string dbPath = Application.StartupPath + "\\data.db";
            storage = new SQLiteStorage(dbPath);
        }

        private void buttonStartClick(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            NormalDistribution distribution = new NormalDistribution(1, 1);
            generator = new TaskGenerator(distribution);
            
            backThread = new Thread(run);
            backThread.IsBackground = true;
            
            for (int i = 0; i < 2; i++)
            {
                TaskHandler h = new TaskHandler("#" + (int)i, 1, 1);
                Chart c = createChart();
                charts.Add(c);
                dispatcher.addHandler(h, c);
            }
            
            backThread.Start();
            btnCancel.Enabled = true;
            timer.Enabled = true;
        }

        private void createDataGrid()
        {
            DataGridView rdDataGridView = new DataGridView();
            RdDataGridViewCellColumn column;

            rdDataGridView.ColumnHeadersHeight = 28;
            rdDataGridView.RowHeadersVisible = false;
            rdDataGridView.Dock = DockStyle.Top;
            rdDataGridView.RowTemplate.ContextMenuStrip = handlerContextMenuGrid;
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

        public void run()
        {
            visualization();
            int iterations = (int) countIteration.Value;
            //for (int i = 0; i < iterations; i++)
            while (true)
            {
                List<Task> tasks = generator.generate();
                foreach (Task task in tasks)
                {
                    dispatcher.resolve(task);
                }
                Thread.Sleep(100);
            }
        }

        private void visualization()
        {
            int chartWidth = 530;
            //int chartTop;
            
            int perLine = charts.Count / 2;
            
            //chartWidth = Width / perLine - 20;


            foreach (Chart chart in charts)
            { 
                int index = charts.IndexOf(chart);
                this.BeginInvoke(
                    new Action(delegate() 
                        {
                            chart.Height = 300;// Height - panelTop.Height - 20;
                            chart.Width = chartWidth;// Width / charts.Count - (5 * charts.Count);
                            if (index < 2)
                            {
                                chart.Location = new Point(chartWidth * index + (5 * index), this.panelTop.Height + 5);
                            }
                            this.Controls.Add(chart);
                        }
                ));
                //this.Controls.Add(chart);
            }
        }

        private void itemAddHandlerClick(object sender, EventArgs e)
        {
            HandlerForm handlerForm = new HandlerForm();
            handlerForm.Text = "Новый обработчик";
            handlerForm.Tag = "new";
            
            handlerForm.FormClosed += new FormClosedEventHandler(HandlerDialogClose);
            handlerForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["Series1"].BorderWidth = 3;
            for (int i = 0; i < 50; i++)
            {
                chart1.Series[0].Points.Add(i * 1.5 / (i * 0.5));
            }
        }

        public void HandlerDialogClose(object sender, FormClosedEventArgs e)
        {
            string i = "";
            int c = 0;
            int m = 0;
            HandlerForm handlerForm = (HandlerForm)sender;
            foreach (Control control in handlerForm.Controls)
            {
                switch (control.Name)
                {
                    case "boxIdentity":
                        TextBox ctrl = (TextBox)control;
                        i = ctrl.Text;
                        break;
                    case "boxCpu":
                    case "boxMemory":
                        break;

                }
            }
            handlerGrid.Rows.Add(i, c, m);
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            backThread.Abort();
            btnCancel.Enabled = false;
            btnStart.Enabled = true;
        }

        private void timerTick(object sender, EventArgs e)
        {
            for (int i = 0; i < charts.Count; i++)
            {
                int y = dispatcher.getHandlerStatistic(i);
                charts[i].Series["CPU"].Points.Add(y);
            }
            MainForm.inc++;
        }

        private Chart createChart()
        {
            Chart chart = new Chart();
            ChartArea ca = new ChartArea();
            Legend legend = new Legend();
            Series series = new Series();

            ca.Name = "ChartArea1";
            chart.ChartAreas.Add(ca);
            legend.Name = "Legend1";
            chart.Legends.Add(legend);
            //this.chart1.Name = "chart1";
            series.ChartArea = "ChartArea1";
            series.Legend = "Legend1";
            series.Name = "CPU";
            chart.Series.Add(series);
            chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["Series1"].BorderWidth = 3;
            return chart;
        }
    }   
}
