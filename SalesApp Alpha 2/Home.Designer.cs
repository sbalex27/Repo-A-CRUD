﻿namespace SalesApp_Alpha_2
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
            this.BTT_Test = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.uiProductProperties1 = new SalesApp_Alpha_2.UiProductProperties();
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
            this.ingresarProductoToolStripMenuItem.Image = global::SalesApp_Alpha_2.Properties.Resources._16px_AddProduct;
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
            this.verTablaDeProductosToolStripMenuItem.Image = global::SalesApp_Alpha_2.Properties.Resources._16px_List;
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
            // BTT_Test
            // 
            this.BTT_Test.Location = new System.Drawing.Point(422, 290);
            this.BTT_Test.Name = "BTT_Test";
            this.BTT_Test.Size = new System.Drawing.Size(75, 23);
            this.BTT_Test.TabIndex = 1;
            this.BTT_Test.Text = "Validar";
            this.BTT_Test.UseVisualStyleBackColor = true;
            this.BTT_Test.Click += new System.EventHandler(this.BTT_Test_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Restablecer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiProductProperties1
            // 
            this.uiProductProperties1.AutoSize = true;
            this.uiProductProperties1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uiProductProperties1.EnablePrimaryKey = true;
            this.uiProductProperties1.Location = new System.Drawing.Point(341, 88);
            this.uiProductProperties1.MinimumSize = new System.Drawing.Size(150, 150);
            this.uiProductProperties1.Name = "uiProductProperties1";
            this.uiProductProperties1.ShowPrimaryKey = true;
            this.uiProductProperties1.Size = new System.Drawing.Size(156, 196);
            this.uiProductProperties1.TabIndex = 6;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiProductProperties1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTT_Test);
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
        private System.Windows.Forms.Button BTT_Test;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private UiProductProperties uiProductProperties1;
    }
}

