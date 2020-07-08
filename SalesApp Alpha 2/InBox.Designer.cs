namespace SalesApp_Alpha_2
{
    partial class InBox
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
            this.Panel_Header = new System.Windows.Forms.Panel();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.Panel_Picture = new System.Windows.Forms.Panel();
            this.Panel_Body = new System.Windows.Forms.Panel();
            this.TXT_Input = new System.Windows.Forms.TextBox();
            this.Picture_16px = new System.Windows.Forms.PictureBox();
            this.Panel_Header.SuspendLayout();
            this.Panel_Picture.SuspendLayout();
            this.Panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_16px)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Header
            // 
            this.Panel_Header.Controls.Add(this.LBL_Title);
            this.Panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Header.Location = new System.Drawing.Point(31, 0);
            this.Panel_Header.Name = "Panel_Header";
            this.Panel_Header.Size = new System.Drawing.Size(230, 16);
            this.Panel_Header.TabIndex = 3;
            // 
            // LBL_Title
            // 
            this.LBL_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Title.Location = new System.Drawing.Point(0, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LBL_Title.Size = new System.Drawing.Size(230, 16);
            this.LBL_Title.TabIndex = 6;
            this.LBL_Title.Text = "Title";
            // 
            // Panel_Picture
            // 
            this.Panel_Picture.Controls.Add(this.Picture_16px);
            this.Panel_Picture.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Picture.Location = new System.Drawing.Point(0, 0);
            this.Panel_Picture.Name = "Panel_Picture";
            this.Panel_Picture.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.Panel_Picture.Size = new System.Drawing.Size(31, 127);
            this.Panel_Picture.TabIndex = 8;
            // 
            // Panel_Body
            // 
            this.Panel_Body.Controls.Add(this.TXT_Input);
            this.Panel_Body.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Body.Location = new System.Drawing.Point(31, 16);
            this.Panel_Body.Name = "Panel_Body";
            this.Panel_Body.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.Panel_Body.Size = new System.Drawing.Size(230, 20);
            this.Panel_Body.TabIndex = 11;
            // 
            // TXT_Input
            // 
            this.TXT_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TXT_Input.Location = new System.Drawing.Point(6, 0);
            this.TXT_Input.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.TXT_Input.MinimumSize = new System.Drawing.Size(200, 20);
            this.TXT_Input.Name = "TXT_Input";
            this.TXT_Input.Size = new System.Drawing.Size(224, 20);
            this.TXT_Input.TabIndex = 8;
            this.TXT_Input.TextChanged += new System.EventHandler(this.TXT_Input_TextChanged);
            // 
            // Picture_16px
            // 
            this.Picture_16px.Dock = System.Windows.Forms.DockStyle.Top;
            this.Picture_16px.Image = global::SalesApp_Alpha_2.Properties.Resources._16px_Image;
            this.Picture_16px.Location = new System.Drawing.Point(0, 16);
            this.Picture_16px.Name = "Picture_16px";
            this.Picture_16px.Size = new System.Drawing.Size(31, 20);
            this.Picture_16px.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture_16px.TabIndex = 5;
            this.Picture_16px.TabStop = false;
            // 
            // InBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Panel_Body);
            this.Controls.Add(this.Panel_Header);
            this.Controls.Add(this.Panel_Picture);
            this.Name = "InBox";
            this.Size = new System.Drawing.Size(261, 127);
            this.Panel_Header.ResumeLayout(false);
            this.Panel_Picture.ResumeLayout(false);
            this.Panel_Body.ResumeLayout(false);
            this.Panel_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_16px)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Header;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.PictureBox Picture_16px;
        private System.Windows.Forms.Panel Panel_Picture;
        private System.Windows.Forms.Panel Panel_Body;
        private System.Windows.Forms.TextBox TXT_Input;
    }
}
