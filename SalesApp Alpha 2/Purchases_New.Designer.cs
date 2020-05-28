namespace SalesApp_Alpha_2
{
    partial class Purchases_New
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
            this.DGV_ProductsLoaded = new System.Windows.Forms.DataGridView();
            this.LB_SearchResults = new System.Windows.Forms.ListBox();
            this.PANEL_AllPurchase = new System.Windows.Forms.Panel();
            this.PANEL_DockFill = new System.Windows.Forms.Panel();
            this.PANEL_DockBottom = new System.Windows.Forms.Panel();
            this.PB_Progress = new System.Windows.Forms.ProgressBar();
            this.BTT_ConfirmPurchase = new System.Windows.Forms.Button();
            this.BOX_Provider = new System.Windows.Forms.GroupBox();
            this.BOX_Select = new System.Windows.Forms.GroupBox();
            this.UI_SelectProductsProperties = new SalesApp_Alpha_2.UI_ProductsProperties();
            this.LPANEL_SelectProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.BTT_AddToList = new System.Windows.Forms.Button();
            this.BTT_New = new System.Windows.Forms.Button();
            this.IB_Text_Search = new SalesApp_Alpha_2.InputBox_Text();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductsLoaded)).BeginInit();
            this.PANEL_AllPurchase.SuspendLayout();
            this.PANEL_DockFill.SuspendLayout();
            this.PANEL_DockBottom.SuspendLayout();
            this.BOX_Select.SuspendLayout();
            this.LPANEL_SelectProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_ProductsLoaded
            // 
            this.DGV_ProductsLoaded.AllowUserToAddRows = false;
            this.DGV_ProductsLoaded.AllowUserToDeleteRows = false;
            this.DGV_ProductsLoaded.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ProductsLoaded.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_ProductsLoaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ProductsLoaded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ProductsLoaded.Location = new System.Drawing.Point(0, 6);
            this.DGV_ProductsLoaded.Name = "DGV_ProductsLoaded";
            this.DGV_ProductsLoaded.ReadOnly = true;
            this.DGV_ProductsLoaded.Size = new System.Drawing.Size(458, 373);
            this.DGV_ProductsLoaded.TabIndex = 0;
            // 
            // LB_SearchResults
            // 
            this.LB_SearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_SearchResults.FormattingEnabled = true;
            this.LB_SearchResults.Location = new System.Drawing.Point(6, 64);
            this.LB_SearchResults.Name = "LB_SearchResults";
            this.LB_SearchResults.Size = new System.Drawing.Size(244, 183);
            this.LB_SearchResults.TabIndex = 1;
            this.LB_SearchResults.SelectedIndexChanged += new System.EventHandler(this.LB_SearchResults_SelectedIndexChanged);
            // 
            // PANEL_AllPurchase
            // 
            this.PANEL_AllPurchase.Controls.Add(this.PANEL_DockFill);
            this.PANEL_AllPurchase.Controls.Add(this.PANEL_DockBottom);
            this.PANEL_AllPurchase.Controls.Add(this.BOX_Provider);
            this.PANEL_AllPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PANEL_AllPurchase.Location = new System.Drawing.Point(262, 6);
            this.PANEL_AllPurchase.Name = "PANEL_AllPurchase";
            this.PANEL_AllPurchase.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.PANEL_AllPurchase.Size = new System.Drawing.Size(464, 474);
            this.PANEL_AllPurchase.TabIndex = 1;
            // 
            // PANEL_DockFill
            // 
            this.PANEL_DockFill.Controls.Add(this.DGV_ProductsLoaded);
            this.PANEL_DockFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PANEL_DockFill.Location = new System.Drawing.Point(6, 58);
            this.PANEL_DockFill.Name = "PANEL_DockFill";
            this.PANEL_DockFill.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.PANEL_DockFill.Size = new System.Drawing.Size(458, 385);
            this.PANEL_DockFill.TabIndex = 1;
            // 
            // PANEL_DockBottom
            // 
            this.PANEL_DockBottom.AutoSize = true;
            this.PANEL_DockBottom.Controls.Add(this.PB_Progress);
            this.PANEL_DockBottom.Controls.Add(this.BTT_ConfirmPurchase);
            this.PANEL_DockBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PANEL_DockBottom.Location = new System.Drawing.Point(6, 443);
            this.PANEL_DockBottom.Name = "PANEL_DockBottom";
            this.PANEL_DockBottom.Size = new System.Drawing.Size(458, 31);
            this.PANEL_DockBottom.TabIndex = 2;
            // 
            // PB_Progress
            // 
            this.PB_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Progress.Location = new System.Drawing.Point(3, 3);
            this.PB_Progress.Name = "PB_Progress";
            this.PB_Progress.Size = new System.Drawing.Size(310, 23);
            this.PB_Progress.TabIndex = 5;
            this.PB_Progress.Visible = false;
            // 
            // BTT_ConfirmPurchase
            // 
            this.BTT_ConfirmPurchase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTT_ConfirmPurchase.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_de_acuerdo_16;
            this.BTT_ConfirmPurchase.Location = new System.Drawing.Point(319, 3);
            this.BTT_ConfirmPurchase.MinimumSize = new System.Drawing.Size(0, 25);
            this.BTT_ConfirmPurchase.Name = "BTT_ConfirmPurchase";
            this.BTT_ConfirmPurchase.Size = new System.Drawing.Size(139, 25);
            this.BTT_ConfirmPurchase.TabIndex = 4;
            this.BTT_ConfirmPurchase.Text = "Procesar Compra";
            this.BTT_ConfirmPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTT_ConfirmPurchase.UseVisualStyleBackColor = true;
            this.BTT_ConfirmPurchase.Click += new System.EventHandler(this.BTT_ConfirmPurchase_Click);
            // 
            // BOX_Provider
            // 
            this.BOX_Provider.Dock = System.Windows.Forms.DockStyle.Top;
            this.BOX_Provider.Location = new System.Drawing.Point(6, 0);
            this.BOX_Provider.Name = "BOX_Provider";
            this.BOX_Provider.Padding = new System.Windows.Forms.Padding(6);
            this.BOX_Provider.Size = new System.Drawing.Size(458, 58);
            this.BOX_Provider.TabIndex = 0;
            this.BOX_Provider.TabStop = false;
            this.BOX_Provider.Text = "Proveedor";
            // 
            // BOX_Select
            // 
            this.BOX_Select.Controls.Add(this.LB_SearchResults);
            this.BOX_Select.Controls.Add(this.UI_SelectProductsProperties);
            this.BOX_Select.Controls.Add(this.LPANEL_SelectProduct);
            this.BOX_Select.Controls.Add(this.IB_Text_Search);
            this.BOX_Select.Dock = System.Windows.Forms.DockStyle.Left;
            this.BOX_Select.Location = new System.Drawing.Point(6, 6);
            this.BOX_Select.Name = "BOX_Select";
            this.BOX_Select.Padding = new System.Windows.Forms.Padding(6);
            this.BOX_Select.Size = new System.Drawing.Size(256, 474);
            this.BOX_Select.TabIndex = 0;
            this.BOX_Select.TabStop = false;
            this.BOX_Select.Text = "Seleccionar";
            // 
            // UI_SelectProductsProperties
            // 
            this.UI_SelectProductsProperties.AutoScroll = true;
            this.UI_SelectProductsProperties.AutoSize = true;
            this.UI_SelectProductsProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UI_SelectProductsProperties.Location = new System.Drawing.Point(6, 247);
            this.UI_SelectProductsProperties.MaximumSize = new System.Drawing.Size(0, 400);
            this.UI_SelectProductsProperties.MinimumSize = new System.Drawing.Size(200, 0);
            this.UI_SelectProductsProperties.Name = "UI_SelectProductsProperties";
            this.UI_SelectProductsProperties.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.UI_SelectProductsProperties.PropertyID = false;
            this.UI_SelectProductsProperties.Size = new System.Drawing.Size(244, 190);
            this.UI_SelectProductsProperties.TabIndex = 2;
            this.UI_SelectProductsProperties.Enter += new System.EventHandler(this.UI_SelectProductsProperties_Enter);
            // 
            // LPANEL_SelectProduct
            // 
            this.LPANEL_SelectProduct.AutoSize = true;
            this.LPANEL_SelectProduct.Controls.Add(this.BTT_AddToList);
            this.LPANEL_SelectProduct.Controls.Add(this.BTT_New);
            this.LPANEL_SelectProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LPANEL_SelectProduct.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.LPANEL_SelectProduct.Location = new System.Drawing.Point(6, 437);
            this.LPANEL_SelectProduct.Name = "LPANEL_SelectProduct";
            this.LPANEL_SelectProduct.Size = new System.Drawing.Size(244, 31);
            this.LPANEL_SelectProduct.TabIndex = 3;
            // 
            // BTT_AddToList
            // 
            this.BTT_AddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTT_AddToList.AutoSize = true;
            this.BTT_AddToList.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_carrito_de_la_compra_cargado_16;
            this.BTT_AddToList.Location = new System.Drawing.Point(120, 3);
            this.BTT_AddToList.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.BTT_AddToList.Name = "BTT_AddToList";
            this.BTT_AddToList.Size = new System.Drawing.Size(124, 25);
            this.BTT_AddToList.TabIndex = 0;
            this.BTT_AddToList.Text = "&Añadir al Carrito";
            this.BTT_AddToList.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTT_AddToList.UseVisualStyleBackColor = true;
            this.BTT_AddToList.Click += new System.EventHandler(this.BTT_AddToList_Click);
            // 
            // BTT_New
            // 
            this.BTT_New.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_añadir_16;
            this.BTT_New.Location = new System.Drawing.Point(15, 3);
            this.BTT_New.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.BTT_New.Name = "BTT_New";
            this.BTT_New.Size = new System.Drawing.Size(105, 25);
            this.BTT_New.TabIndex = 1;
            this.BTT_New.Text = "Crear Nuevo";
            this.BTT_New.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTT_New.UseVisualStyleBackColor = true;
            this.BTT_New.Click += new System.EventHandler(this.BTT_New_Click);
            // 
            // IB_Text_Search
            // 
            this.IB_Text_Search.AutoSize = true;
            this.IB_Text_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.IB_Text_Search.InputEnabled = true;
            this.IB_Text_Search.InputValue = "";
            this.IB_Text_Search.Location = new System.Drawing.Point(6, 19);
            this.IB_Text_Search.MinimumSize = new System.Drawing.Size(150, 0);
            this.IB_Text_Search.Name = "IB_Text_Search";
            this.IB_Text_Search.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.IB_Text_Search.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_búsqueda_16__1_;
            this.IB_Text_Search.Size = new System.Drawing.Size(244, 45);
            this.IB_Text_Search.TabIndex = 0;
            this.IB_Text_Search.Title = "Buscar";
            this.IB_Text_Search.VisualError = false;
            this.IB_Text_Search.InputChanged += new SalesApp_Alpha_2.InputBoxEventHandler(this.IB_Text_Search_InputChanged);
            this.IB_Text_Search.Leave += new System.EventHandler(this.IB_Text_Search_Leave);
            // 
            // Purchases_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 486);
            this.Controls.Add(this.PANEL_AllPurchase);
            this.Controls.Add(this.BOX_Select);
            this.MinimumSize = new System.Drawing.Size(650, 380);
            this.Name = "Purchases_New";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Nueva Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductsLoaded)).EndInit();
            this.PANEL_AllPurchase.ResumeLayout(false);
            this.PANEL_AllPurchase.PerformLayout();
            this.PANEL_DockFill.ResumeLayout(false);
            this.PANEL_DockBottom.ResumeLayout(false);
            this.BOX_Select.ResumeLayout(false);
            this.BOX_Select.PerformLayout();
            this.LPANEL_SelectProduct.ResumeLayout(false);
            this.LPANEL_SelectProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_ProductsLoaded;
        private System.Windows.Forms.Button BTT_AddToList;
        private System.Windows.Forms.Panel PANEL_AllPurchase;
        private System.Windows.Forms.ListBox LB_SearchResults;
        private UI_ProductsProperties UI_SelectProductsProperties;
        private System.Windows.Forms.Panel PANEL_DockFill;
        private System.Windows.Forms.GroupBox BOX_Select;
        private System.Windows.Forms.GroupBox BOX_Provider;
        private InputBox_Text IB_Text_Search;
        private System.Windows.Forms.FlowLayoutPanel LPANEL_SelectProduct;
        private System.Windows.Forms.Panel PANEL_DockBottom;
        private System.Windows.Forms.Button BTT_ConfirmPurchase;
        private System.Windows.Forms.Button BTT_New;
        private System.Windows.Forms.ProgressBar PB_Progress;
    }
}