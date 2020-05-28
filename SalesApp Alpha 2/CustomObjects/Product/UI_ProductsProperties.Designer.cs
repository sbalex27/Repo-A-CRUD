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
            this.inputBox_Numeric_Price = new SalesApp_Alpha_2.InputBox_Numeric();
            this.inputBox_Numeric_Quantity = new SalesApp_Alpha_2.InputBox_Numeric();
            this.inputBox_Combo_TradeMark = new SalesApp_Alpha_2.InputBox_Combo();
            this.inputBox_Text_Description = new SalesApp_Alpha_2.InputBox_Text();
            this.inputBox_Text_ID = new SalesApp_Alpha_2.InputBox_Text();
            this.SuspendLayout();
            // 
            // inputBox_Numeric_Price
            // 
            this.inputBox_Numeric_Price.AutoSize = true;
            this.inputBox_Numeric_Price.DecimalPlaces = 2;
            this.inputBox_Numeric_Price.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputBox_Numeric_Price.InputEnabled = true;
            this.inputBox_Numeric_Price.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inputBox_Numeric_Price.Location = new System.Drawing.Point(3, 184);
            this.inputBox_Numeric_Price.MinimumSize = new System.Drawing.Size(100, 0);
            this.inputBox_Numeric_Price.Name = "inputBox_Numeric_Price";
            this.inputBox_Numeric_Price.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.inputBox_Numeric_Price.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_etiqueta_de_precio_usd_16;
            this.inputBox_Numeric_Price.Size = new System.Drawing.Size(244, 45);
            this.inputBox_Numeric_Price.TabIndex = 3;
            this.inputBox_Numeric_Price.Title = "Precio";
            this.inputBox_Numeric_Price.VisualError = false;
            // 
            // inputBox_Numeric_Quantity
            // 
            this.inputBox_Numeric_Quantity.AutoSize = true;
            this.inputBox_Numeric_Quantity.DecimalPlaces = 0;
            this.inputBox_Numeric_Quantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputBox_Numeric_Quantity.InputEnabled = true;
            this.inputBox_Numeric_Quantity.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inputBox_Numeric_Quantity.Location = new System.Drawing.Point(3, 139);
            this.inputBox_Numeric_Quantity.MinimumSize = new System.Drawing.Size(100, 0);
            this.inputBox_Numeric_Quantity.Name = "inputBox_Numeric_Quantity";
            this.inputBox_Numeric_Quantity.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.inputBox_Numeric_Quantity.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_lista_con_viñetas_16;
            this.inputBox_Numeric_Quantity.Size = new System.Drawing.Size(244, 45);
            this.inputBox_Numeric_Quantity.TabIndex = 2;
            this.inputBox_Numeric_Quantity.Title = "Cantidad";
            this.inputBox_Numeric_Quantity.VisualError = false;
            // 
            // inputBox_Combo_TradeMark
            // 
            this.inputBox_Combo_TradeMark.AutoSize = true;
            this.inputBox_Combo_TradeMark.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputBox_Combo_TradeMark.InputDataSource = null;
            this.inputBox_Combo_TradeMark.InputEnabled = true;
            this.inputBox_Combo_TradeMark.InputValue = "";
            this.inputBox_Combo_TradeMark.Location = new System.Drawing.Point(3, 93);
            this.inputBox_Combo_TradeMark.MinimumSize = new System.Drawing.Size(150, 0);
            this.inputBox_Combo_TradeMark.Name = "inputBox_Combo_TradeMark";
            this.inputBox_Combo_TradeMark.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.inputBox_Combo_TradeMark.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_marca_16;
            this.inputBox_Combo_TradeMark.Size = new System.Drawing.Size(244, 46);
            this.inputBox_Combo_TradeMark.TabIndex = 1;
            this.inputBox_Combo_TradeMark.Title = "Marca";
            this.inputBox_Combo_TradeMark.VisualError = false;
            this.inputBox_Combo_TradeMark.Load += new System.EventHandler(this.inputBox_Combo_TradeMark_Load);
            // 
            // inputBox_Text_Description
            // 
            this.inputBox_Text_Description.AutoSize = true;
            this.inputBox_Text_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputBox_Text_Description.InputEnabled = true;
            this.inputBox_Text_Description.InputValue = "";
            this.inputBox_Text_Description.Location = new System.Drawing.Point(3, 48);
            this.inputBox_Text_Description.MinimumSize = new System.Drawing.Size(150, 0);
            this.inputBox_Text_Description.Name = "inputBox_Text_Description";
            this.inputBox_Text_Description.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.inputBox_Text_Description.Picture = global::SalesApp_Alpha_2.Properties.Resources.icons8_producto_16;
            this.inputBox_Text_Description.Size = new System.Drawing.Size(244, 45);
            this.inputBox_Text_Description.TabIndex = 0;
            this.inputBox_Text_Description.Title = "Descripción";
            this.inputBox_Text_Description.VisualError = false;
            // 
            // inputBox_Text_ID
            // 
            this.inputBox_Text_ID.AutoSize = true;
            this.inputBox_Text_ID.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputBox_Text_ID.InputEnabled = false;
            this.inputBox_Text_ID.InputValue = "";
            this.inputBox_Text_ID.Location = new System.Drawing.Point(3, 3);
            this.inputBox_Text_ID.MinimumSize = new System.Drawing.Size(150, 0);
            this.inputBox_Text_ID.Name = "inputBox_Text_ID";
            this.inputBox_Text_ID.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.inputBox_Text_ID.Picture = ((System.Drawing.Image)(resources.GetObject("inputBox_Text_ID.Picture")));
            this.inputBox_Text_ID.Size = new System.Drawing.Size(244, 45);
            this.inputBox_Text_ID.TabIndex = 4;
            this.inputBox_Text_ID.Title = "ID";
            this.inputBox_Text_ID.VisualError = false;
            // 
            // UI_ProductsProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.inputBox_Numeric_Price);
            this.Controls.Add(this.inputBox_Numeric_Quantity);
            this.Controls.Add(this.inputBox_Combo_TradeMark);
            this.Controls.Add(this.inputBox_Text_Description);
            this.Controls.Add(this.inputBox_Text_ID);
            this.MaximumSize = new System.Drawing.Size(0, 400);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "UI_ProductsProperties";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(250, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public InputBox_Text inputBox_Text_Description;
        public InputBox_Combo inputBox_Combo_TradeMark;
        public InputBox_Numeric inputBox_Numeric_Quantity;
        public InputBox_Numeric inputBox_Numeric_Price;
        public InputBox_Text inputBox_Text_ID;
    }
}
