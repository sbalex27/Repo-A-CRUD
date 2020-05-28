namespace SalesApp_Alpha_2
{
    partial class NewPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPurchase));
            this.Panel_Search = new System.Windows.Forms.Panel();
            this.InputBox_Search = new SalesApp_Alpha_2.InputBox_Text();
            this.ListBox_SearchResults = new System.Windows.Forms.ListBox();
            this.ProductProperties_Selected = new SalesApp_Alpha_2.UI_ProductsProperties();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTT_AddToList = new System.Windows.Forms.Button();
            this.GridView_Products = new System.Windows.Forms.DataGridView();
            this.Panel_Search.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Search
            // 
            this.Panel_Search.Controls.Add(this.ListBox_SearchResults);
            this.Panel_Search.Controls.Add(this.ProductProperties_Selected);
            this.Panel_Search.Controls.Add(this.InputBox_Search);
            this.Panel_Search.Controls.Add(this.flowLayoutPanel1);
            this.Panel_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Search.Location = new System.Drawing.Point(0, 0);
            this.Panel_Search.Name = "Panel_Search";
            this.Panel_Search.Size = new System.Drawing.Size(200, 450);
            this.Panel_Search.TabIndex = 0;
            // 
            // InputBox_Search
            // 
            this.InputBox_Search.AutoSize = true;
            this.InputBox_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.InputBox_Search.InputEnabled = true;
            this.InputBox_Search.InputValue = "";
            this.InputBox_Search.Location = new System.Drawing.Point(0, 0);
            this.InputBox_Search.MinimumSize = new System.Drawing.Size(150, 0);
            this.InputBox_Search.Name = "InputBox_Search";
            this.InputBox_Search.Padding = new System.Windows.Forms.Padding(3);
            this.InputBox_Search.Picture = ((System.Drawing.Image)(resources.GetObject("InputBox_Search.Picture")));
            this.InputBox_Search.Size = new System.Drawing.Size(200, 42);
            this.InputBox_Search.TabIndex = 0;
            this.InputBox_Search.Title = "MyTitle";
            this.InputBox_Search.VisualError = false;
            this.InputBox_Search.InputChanged += new SalesApp_Alpha_2.InputBoxEventHandler(this.InputBox_Search_InputChanged);
            // 
            // ListBox_SearchResults
            // 
            this.ListBox_SearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_SearchResults.FormattingEnabled = true;
            this.ListBox_SearchResults.Location = new System.Drawing.Point(0, 42);
            this.ListBox_SearchResults.Name = "ListBox_SearchResults";
            this.ListBox_SearchResults.Size = new System.Drawing.Size(200, 192);
            this.ListBox_SearchResults.TabIndex = 1;
            this.ListBox_SearchResults.SelectedIndexChanged += new System.EventHandler(this.ListBox_SearchResults_SelectedIndexChanged);
            // 
            // ProductProperties_Selected
            // 
            this.ProductProperties_Selected.AutoScroll = true;
            this.ProductProperties_Selected.AutoSize = true;
            this.ProductProperties_Selected.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProductProperties_Selected.Location = new System.Drawing.Point(0, 234);
            this.ProductProperties_Selected.MaximumSize = new System.Drawing.Size(0, 400);
            this.ProductProperties_Selected.MinimumSize = new System.Drawing.Size(200, 0);
            this.ProductProperties_Selected.Name = "ProductProperties_Selected";
            this.ProductProperties_Selected.Padding = new System.Windows.Forms.Padding(3);
            this.ProductProperties_Selected.PropertyID = false;
            this.ProductProperties_Selected.Size = new System.Drawing.Size(200, 187);
            this.ProductProperties_Selected.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.BTT_AddToList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 421);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 29);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // BTT_AddToList
            // 
            this.BTT_AddToList.Location = new System.Drawing.Point(3, 3);
            this.BTT_AddToList.Name = "BTT_AddToList";
            this.BTT_AddToList.Size = new System.Drawing.Size(110, 23);
            this.BTT_AddToList.TabIndex = 0;
            this.BTT_AddToList.Text = "Agregar a la lista";
            this.BTT_AddToList.UseVisualStyleBackColor = true;
            this.BTT_AddToList.Click += new System.EventHandler(this.BTT_AddToList_Click);
            // 
            // GridView_Products
            // 
            this.GridView_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView_Products.Location = new System.Drawing.Point(254, 65);
            this.GridView_Products.Name = "GridView_Products";
            this.GridView_Products.Size = new System.Drawing.Size(465, 293);
            this.GridView_Products.TabIndex = 1;
            // 
            // NewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridView_Products);
            this.Controls.Add(this.Panel_Search);
            this.Name = "NewPurchase";
            this.Text = "NewPurchase";
            this.Panel_Search.ResumeLayout(false);
            this.Panel_Search.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Products)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Search;
        private System.Windows.Forms.ListBox ListBox_SearchResults;
        private UI_ProductsProperties ProductProperties_Selected;
        private InputBox_Text InputBox_Search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BTT_AddToList;
        private System.Windows.Forms.DataGridView GridView_Products;
    }
}