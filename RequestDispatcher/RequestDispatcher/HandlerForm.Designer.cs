namespace RequestDispatcher
{
    partial class HandlerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.boxIdentity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxMemory = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.boxCpu = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddHandler = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCpu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Идентификатор";
            // 
            // boxIdentity
            // 
            this.boxIdentity.Location = new System.Drawing.Point(105, 12);
            this.boxIdentity.Name = "boxIdentity";
            this.boxIdentity.Size = new System.Drawing.Size(183, 20);
            this.boxIdentity.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxMemory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.boxCpu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Характиристики";
            // 
            // boxMemory
            // 
            this.boxMemory.Location = new System.Drawing.Point(200, 28);
            this.boxMemory.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.boxMemory.Name = "boxMemory";
            this.boxMemory.Size = new System.Drawing.Size(58, 20);
            this.boxMemory.TabIndex = 3;
            this.boxMemory.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Память";
            // 
            // boxCpu
            // 
            this.boxCpu.Location = new System.Drawing.Point(79, 26);
            this.boxCpu.Name = "boxCpu";
            this.boxCpu.Size = new System.Drawing.Size(58, 20);
            this.boxCpu.TabIndex = 1;
            this.boxCpu.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Процессор";
            // 
            // btnAddHandler
            // 
            this.btnAddHandler.Location = new System.Drawing.Point(213, 116);
            this.btnAddHandler.Name = "btnAddHandler";
            this.btnAddHandler.Size = new System.Drawing.Size(75, 23);
            this.btnAddHandler.TabIndex = 3;
            this.btnAddHandler.Text = "Сохранить";
            this.btnAddHandler.UseVisualStyleBackColor = true;
            this.btnAddHandler.Click += new System.EventHandler(this.btnAddHandlerClick);
            // 
            // HandlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 151);
            this.Controls.Add(this.btnAddHandler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.boxIdentity);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HandlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый обработчик";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCpu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown boxMemory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown boxCpu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddHandler;
        private System.Windows.Forms.TextBox boxIdentity;
    }
}