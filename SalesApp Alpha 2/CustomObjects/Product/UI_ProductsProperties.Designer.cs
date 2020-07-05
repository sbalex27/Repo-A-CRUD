namespace SalesApp_Alpha_2
{
    partial class UI_ProductsProperties
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_ProductsProperties));
            this.Box_Price = new SalesApp_Alpha_2.InputBox_Numeric();
            this.Box_Quantity = new SalesApp_Alpha_2.InputBox_Numeric();
            this.Box_Trademark = new SalesApp_Alpha_2.InputBox_Combo();
            this.Box_Description = new SalesApp_Alpha_2.InputBox_Text();
            this.Box_ID = new SalesApp_Alpha_2.InputBox_Text();
            this.SuspendLayout();
            // 
            // inputBox_Numeric_Price
            // 
            this.Box_Price.AutoSize = true;
            this.Box_Price.DecimalPlaces = 2;
            this.Box_Price.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box_Price.InputEnabled = true;
            this.Box_Price.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Box_Price.Location = new System.Drawing.Point(3, 184);
            this.Box_Price.MinimumSize = new System.Drawing.Size(100, 0);
            this.Box_Price.Name = "inputBox_Numeric_Price";
            this.Box_Price.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.Box_Price.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_etiqueta_de_precio_usd_16;
            this.Box_Price.Size = new System.Drawing.Size(244, 45);
            this.Box_Price.TabIndex = 3;
            this.Box_Price.Title = "Precio";
            this.Box_Price.VisualError = false;
            // 
            // inputBox_Numeric_Quantity
            // 
            this.Box_Quantity.AutoSize = true;
            this.Box_Quantity.DecimalPlaces = 0;
            this.Box_Quantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box_Quantity.InputEnabled = true;
            this.Box_Quantity.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Box_Quantity.Location = new System.Drawing.Point(3, 139);
            this.Box_Quantity.MinimumSize = new System.Drawing.Size(100, 0);
            this.Box_Quantity.Name = "inputBox_Numeric_Quantity";
            this.Box_Quantity.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.Box_Quantity.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_lista_con_viñetas_16;
            this.Box_Quantity.Size = new System.Drawing.Size(244, 45);
            this.Box_Quantity.TabIndex = 2;
            this.Box_Quantity.Title = "Cantidad";
            this.Box_Quantity.VisualError = false;
            // 
            // inputBox_Combo_TradeMark
            // 
            this.Box_Trademark.AutoSize = true;
            this.Box_Trademark.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box_Trademark.InputDataSource = null;
            this.Box_Trademark.InputEnabled = true;
            this.Box_Trademark.InputValue = "";
            this.Box_Trademark.Location = new System.Drawing.Point(3, 93);
            this.Box_Trademark.MinimumSize = new System.Drawing.Size(150, 0);
            this.Box_Trademark.Name = "inputBox_Combo_TradeMark";
            this.Box_Trademark.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.Box_Trademark.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_marca_16;
            this.Box_Trademark.Size = new System.Drawing.Size(244, 46);
            this.Box_Trademark.TabIndex = 1;
            this.Box_Trademark.Title = "Marca";
            this.Box_Trademark.VisualError = false;
            this.Box_Trademark.Load += new System.EventHandler(this.inputBox_Combo_TradeMark_Load);
            // 
            // inputBox_Text_Description
            // 
            this.Box_Description.AutoSize = true;
            this.Box_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box_Description.InputEnabled = true;
            this.Box_Description.InputValue = "";
            this.Box_Description.Location = new System.Drawing.Point(3, 48);
            this.Box_Description.MinimumSize = new System.Drawing.Size(150, 0);
            this.Box_Description.Name = "inputBox_Text_Description";
            this.Box_Description.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.Box_Description.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_producto_16;
            this.Box_Description.Size = new System.Drawing.Size(244, 45);
            this.Box_Description.TabIndex = 0;
            this.Box_Description.Title = "Descripción";
            this.Box_Description.VisualError = false;
            // 
            // inputBox_Text_ID
            // 
            this.Box_ID.AutoSize = true;
            this.Box_ID.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box_ID.InputEnabled = false;
            this.Box_ID.InputValue = "";
            this.Box_ID.Location = new System.Drawing.Point(3, 3);
            this.Box_ID.MinimumSize = new System.Drawing.Size(150, 0);
            this.Box_ID.Name = "inputBox_Text_ID";
            this.Box_ID.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.Box_ID.Picture = ((System.Drawing.Image)(resources.GetObject("inputBox_Text_ID.Picture")));
            this.Box_ID.Size = new System.Drawing.Size(244, 45);
            this.Box_ID.TabIndex = 4;
            this.Box_ID.Title = "ID";
            this.Box_ID.VisualError = false;
            // 
            // UI_ProductsProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.Box_Price);
            this.Controls.Add(this.Box_Quantity);
            this.Controls.Add(this.Box_Trademark);
            this.Controls.Add(this.Box_Description);
            this.Controls.Add(this.Box_ID);
            this.MaximumSize = new System.Drawing.Size(0, 400);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "UI_ProductsProperties";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(250, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public InputBox_Text Box_Description;
        public InputBox_Combo Box_Trademark;
        public InputBox_Numeric Box_Quantity;
        public InputBox_Numeric Box_Price;
        public InputBox_Text Box_ID;
    }
}
