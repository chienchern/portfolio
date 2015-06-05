namespace DesktopClient.View
{
    partial class MainWindow
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
            this.groupBoxTop = new System.Windows.Forms.GroupBox();
            this.buttonThrowException = new System.Windows.Forms.Button();
            this.buttonNewOrder = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.groupBoxTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTop
            // 
            this.groupBoxTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTop.Controls.Add(this.buttonThrowException);
            this.groupBoxTop.Controls.Add(this.buttonNewOrder);
            this.groupBoxTop.Location = new System.Drawing.Point(13, 3);
            this.groupBoxTop.Name = "groupBoxTop";
            this.groupBoxTop.Size = new System.Drawing.Size(887, 53);
            this.groupBoxTop.TabIndex = 0;
            this.groupBoxTop.TabStop = false;
            // 
            // buttonThrowException
            // 
            this.buttonThrowException.Location = new System.Drawing.Point(114, 17);
            this.buttonThrowException.Name = "buttonThrowException";
            this.buttonThrowException.Size = new System.Drawing.Size(132, 29);
            this.buttonThrowException.TabIndex = 1;
            this.buttonThrowException.Text = "Throw Exception";
            this.buttonThrowException.UseVisualStyleBackColor = true;
            this.buttonThrowException.Click += new System.EventHandler(this.OnButtonThrowExceptionClick);
            // 
            // buttonNewOrder
            // 
            this.buttonNewOrder.Location = new System.Drawing.Point(8, 17);
            this.buttonNewOrder.Name = "buttonNewOrder";
            this.buttonNewOrder.Size = new System.Drawing.Size(90, 29);
            this.buttonNewOrder.TabIndex = 0;
            this.buttonNewOrder.Text = "New Order";
            this.buttonNewOrder.UseVisualStyleBackColor = true;
            this.buttonNewOrder.Click += new System.EventHandler(this.OnButtonNewOrderClick);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(13, 70);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowTemplate.Height = 24;
            this.dataGridViewOrders.Size = new System.Drawing.Size(887, 398);
            this.dataGridViewOrders.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 482);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.groupBoxTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Desktop Client";
            this.groupBoxTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTop;
        private System.Windows.Forms.Button buttonNewOrder;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonThrowException;
    }
}

