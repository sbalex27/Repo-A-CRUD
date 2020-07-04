namespace SalesApp_Alpha_2
{
    partial class Home
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Strip_Principal = new System.Windows.Forms.MenuStrip();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProductoDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablaDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.Strip_Principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // Strip_Principal
            // 
            this.Strip_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem,
            this.comprasToolStripMenuItem});
            this.Strip_Principal.Location = new System.Drawing.Point(0, 0);
            this.Strip_Principal.Name = "Strip_Principal";
            this.Strip_Principal.Size = new System.Drawing.Size(800, 24);
            this.Strip_Principal.TabIndex = 0;
            this.Strip_Principal.Text = "Menu";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarProductoToolStripMenuItem,
            this.modificarProductoDeInventarioToolStripMenuItem,
            this.verTablaDeProductosToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // ingresarProductoToolStripMenuItem
            // 
            this.ingresarProductoToolStripMenuItem.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_producto_16__1_;
            this.ingresarProductoToolStripMenuItem.Name = "ingresarProductoToolStripMenuItem";
            this.ingresarProductoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ingresarProductoToolStripMenuItem.Text = "Ingreso a Inventario";
            this.ingresarProductoToolStripMenuItem.Click += new System.EventHandler(this.ingresarProductoToolStripMenuItem_Click);
            // 
            // modificarProductoDeInventarioToolStripMenuItem
            // 
            this.modificarProductoDeInventarioToolStripMenuItem.Name = "modificarProductoDeInventarioToolStripMenuItem";
            this.modificarProductoDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.modificarProductoDeInventarioToolStripMenuItem.Text = "Modificar Producto";
            this.modificarProductoDeInventarioToolStripMenuItem.Click += new System.EventHandler(this.modificarProductoDeInventarioToolStripMenuItem_Click);
            // 
            // verTablaDeProductosToolStripMenuItem
            // 
            this.verTablaDeProductosToolStripMenuItem.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_lista_con_viñetas_16;
            this.verTablaDeProductosToolStripMenuItem.Name = "verTablaDeProductosToolStripMenuItem";
            this.verTablaDeProductosToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.verTablaDeProductosToolStripMenuItem.Text = "Lista de Inventario";
            this.verTablaDeProductosToolStripMenuItem.Click += new System.EventHandler(this.verTablaDeProductosToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCompraToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // nuevaCompraToolStripMenuItem
            // 
            this.nuevaCompraToolStripMenuItem.Name = "nuevaCompraToolStripMenuItem";
            this.nuevaCompraToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.nuevaCompraToolStripMenuItem.Text = "Nueva Compra";
            this.nuevaCompraToolStripMenuItem.Click += new System.EventHandler(this.nuevaCompraToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Strip_Principal);
            this.MainMenuStrip = this.Strip_Principal;
            this.Name = "Home";
            this.Text = "Index";
            this.Strip_Principal.ResumeLayout(false);
            this.Strip_Principal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Strip_Principal;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablaDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProductoDeInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCompraToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

