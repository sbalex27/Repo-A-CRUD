namespace SalesApp_Alpha_2
{
    partial class Products
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
            this.GridView_Products = new System.Windows.Forms.DataGridView();
            this.Panel_Details = new System.Windows.Forms.Panel();
            this.BTT_Vender = new System.Windows.Forms.Button();
            this.BTT_Eliminar = new System.Windows.Forms.Button();
            this.BTT_Modificar = new System.Windows.Forms.Button();
            this.BTT_Nuevo = new System.Windows.Forms.Button();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inBox_Buscar = new SalesApp_Alpha_2.InBox();
            this.uiProductProperties = new SalesApp_Alpha_2.UiProductProperties();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Products)).BeginInit();
            this.Panel_Details.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView_Products
            // 
            this.GridView_Products.AllowUserToAddRows = false;
            this.GridView_Products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView_Products.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridView_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView_Products.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView_Products.Location = new System.Drawing.Point(12, 12);
            this.GridView_Products.MultiSelect = false;
            this.GridView_Products.Name = "GridView_Products";
            this.GridView_Products.ReadOnly = true;
            this.GridView_Products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_Products.Size = new System.Drawing.Size(606, 408);
            this.GridView_Products.TabIndex = 0;
            this.GridView_Products.SelectionChanged += new System.EventHandler(this.GridView_Products_SelectionChanged);
            // 
            // Panel_Details
            // 
            this.Panel_Details.Controls.Add(this.uiProductProperties);
            this.Panel_Details.Controls.Add(this.BTT_Vender);
            this.Panel_Details.Controls.Add(this.BTT_Eliminar);
            this.Panel_Details.Controls.Add(this.BTT_Modificar);
            this.Panel_Details.Controls.Add(this.BTT_Nuevo);
            this.Panel_Details.Controls.Add(this.LBL_Title);
            this.Panel_Details.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Details.Location = new System.Drawing.Point(630, 0);
            this.Panel_Details.Name = "Panel_Details";
            this.Panel_Details.Padding = new System.Windows.Forms.Padding(6);
            this.Panel_Details.Size = new System.Drawing.Size(275, 480);
            this.Panel_Details.TabIndex = 2;
            // 
            // BTT_Vender
            // 
            this.BTT_Vender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTT_Vender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTT_Vender.Location = new System.Drawing.Point(9, 416);
            this.BTT_Vender.Name = "BTT_Vender";
            this.BTT_Vender.Size = new System.Drawing.Size(92, 23);
            this.BTT_Vender.TabIndex = 9;
            this.BTT_Vender.Text = "&Vender";
            this.BTT_Vender.UseVisualStyleBackColor = true;
            this.BTT_Vender.Click += new System.EventHandler(this.BTT_Vender_Click);
            // 
            // BTT_Eliminar
            // 
            this.BTT_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTT_Eliminar.Location = new System.Drawing.Point(107, 445);
            this.BTT_Eliminar.Name = "BTT_Eliminar";
            this.BTT_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.BTT_Eliminar.TabIndex = 7;
            this.BTT_Eliminar.Text = "&Eliminar";
            this.BTT_Eliminar.UseVisualStyleBackColor = true;
            this.BTT_Eliminar.Click += new System.EventHandler(this.BTT_Eliminar_Click);
            // 
            // BTT_Modificar
            // 
            this.BTT_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTT_Modificar.Location = new System.Drawing.Point(188, 445);
            this.BTT_Modificar.Name = "BTT_Modificar";
            this.BTT_Modificar.Size = new System.Drawing.Size(78, 23);
            this.BTT_Modificar.TabIndex = 6;
            this.BTT_Modificar.Text = "&Modificar";
            this.BTT_Modificar.UseVisualStyleBackColor = true;
            this.BTT_Modificar.Click += new System.EventHandler(this.BTT_Modificar_Click);
            // 
            // BTT_Nuevo
            // 
            this.BTT_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTT_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTT_Nuevo.Location = new System.Drawing.Point(9, 445);
            this.BTT_Nuevo.Name = "BTT_Nuevo";
            this.BTT_Nuevo.Size = new System.Drawing.Size(92, 23);
            this.BTT_Nuevo.TabIndex = 8;
            this.BTT_Nuevo.Text = "Crear &Nuevo";
            this.BTT_Nuevo.UseVisualStyleBackColor = true;
            this.BTT_Nuevo.Click += new System.EventHandler(this.BTT_Nuevo_Click);
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBL_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.Location = new System.Drawing.Point(6, 6);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.LBL_Title.Size = new System.Drawing.Size(140, 21);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "ProductString";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GridView_Products);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(630, 432);
            this.panel1.TabIndex = 1;
            // 
            // inBox_Buscar
            // 
            this.inBox_Buscar.AutoSize = true;
            this.inBox_Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.inBox_Buscar.InputText = "";
            this.inBox_Buscar.Location = new System.Drawing.Point(0, 0);
            this.inBox_Buscar.MinimumSize = new System.Drawing.Size(200, 48);
            this.inBox_Buscar.Name = "inBox_Buscar";
            this.inBox_Buscar.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.inBox_Buscar.Picture = global::SalesApp_Alpha_2.Properties.Resources._16px_Product;
            this.inBox_Buscar.Size = new System.Drawing.Size(630, 48);
            this.inBox_Buscar.TabIndex = 0;
            this.inBox_Buscar.Title = "Buscar";
            this.inBox_Buscar.TextChange += new SalesApp_Alpha_2.InBox.TextChangeEventHandler(this.inBox_Buscar_TextChange);
            // 
            // uiProductProperties
            // 
            this.uiProductProperties.AutoSize = true;
            this.uiProductProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiProductProperties.EnablePrimaryKey = false;
            this.uiProductProperties.Location = new System.Drawing.Point(6, 27);
            this.uiProductProperties.MinimumSize = new System.Drawing.Size(150, 150);
            this.uiProductProperties.Name = "uiProductProperties";
            this.uiProductProperties.ShowPrimaryKey = true;
            this.uiProductProperties.Size = new System.Drawing.Size(263, 196);
            this.uiProductProperties.TabIndex = 10;
            // 
            // Products
            // 
            this.AcceptButton = this.BTT_Modificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inBox_Buscar);
            this.Controls.Add(this.Panel_Details);
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_Products)).EndInit();
            this.Panel_Details.ResumeLayout(false);
            this.Panel_Details.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView GridView_Products;
        private System.Windows.Forms.Panel Panel_Details;
        private System.Windows.Forms.Button BTT_Nuevo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTT_Eliminar;
        private System.Windows.Forms.Button BTT_Modificar;
        private InBox inBox_Buscar;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Button BTT_Vender;
        private UiProductProperties uiProductProperties;
    }
}