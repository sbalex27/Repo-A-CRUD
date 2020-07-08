namespace SalesApp_Alpha_2
{
    partial class InputBox_Combo
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
            this.Panel_Input = new System.Windows.Forms.Panel();
            this.CB_Input = new System.Windows.Forms.ComboBox();
            this.Pic_16px = new System.Windows.Forms.PictureBox();
            this.Panel_Header = new System.Windows.Forms.Panel();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.Panel_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_16px)).BeginInit();
            this.Panel_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Input
            // 
            this.Panel_Input.AutoSize = true;
            this.Panel_Input.Controls.Add(this.CB_Input);
            this.Panel_Input.Controls.Add(this.Pic_16px);
            this.Panel_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Input.Location = new System.Drawing.Point(3, 19);
            this.Panel_Input.Name = "Panel_Input";
            this.Panel_Input.Size = new System.Drawing.Size(194, 21);
            this.Panel_Input.TabIndex = 3;
            // 
            // CB_Input
            // 
            this.CB_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Input.FormattingEnabled = true;
            this.CB_Input.Location = new System.Drawing.Point(26, 0);
            this.CB_Input.Margin = new System.Windows.Forms.Padding(0);
            this.CB_Input.Name = "CB_Input";
            this.CB_Input.Size = new System.Drawing.Size(168, 21);
            this.CB_Input.TabIndex = 2;
            this.CB_Input.SelectedIndexChanged += new System.EventHandler(this.CB_Input_SelectedIndexChanged);
            this.CB_Input.Enter += new System.EventHandler(this.CB_Input_Enter);
            // 
            // Pic_16px
            // 
            this.Pic_16px.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pic_16px.Image = global::SalesApp_Alpha_2.Properties.Resources._16px_Image;
            this.Pic_16px.Location = new System.Drawing.Point(0, 0);
            this.Pic_16px.Margin = new System.Windows.Forms.Padding(0);
            this.Pic_16px.Name = "Pic_16px";
            this.Pic_16px.Size = new System.Drawing.Size(20, 21);
            this.Pic_16px.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pic_16px.TabIndex = 1;
            this.Pic_16px.TabStop = false;
            // 
            // Panel_Header
            // 
            this.Panel_Header.AutoSize = true;
            this.Panel_Header.Controls.Add(this.LBL_Title);
            this.Panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Header.Location = new System.Drawing.Point(3, 3);
            this.Panel_Header.Name = "Panel_Header";
            this.Panel_Header.Size = new System.Drawing.Size(194, 16);
            this.Panel_Header.TabIndex = 2;
            // 
            // LBL_Title
            // 
            this.LBL_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBL_Title.Location = new System.Drawing.Point(0, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LBL_Title.Size = new System.Drawing.Size(194, 16);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "MyTitle";
            // 
            // InputBox_Combo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Panel_Input);
            this.Controls.Add(this.Panel_Header);
            this.MinimumSize = new System.Drawing.Size(150, 0);
            this.Name = "InputBox_Combo";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(200, 43);
            this.Panel_Input.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_16px)).EndInit();
            this.Panel_Header.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Input;
        private System.Windows.Forms.PictureBox Pic_16px;
        private System.Windows.Forms.Panel Panel_Header;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.ComboBox CB_Input;
    }
}
