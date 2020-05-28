namespace SalesApp_Alpha_2
{
    partial class InputBox_Text
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
            this.Panel_Input = new System.Windows.Forms.Panel();
            this.TXT_Input = new System.Windows.Forms.TextBox();
            this.Pic_16px = new System.Windows.Forms.PictureBox();
            this.Panel_Header.SuspendLayout();
            this.Panel_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_16px)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Header
            // 
            this.Panel_Header.AutoSize = true;
            this.Panel_Header.Controls.Add(this.LBL_Title);
            this.Panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Header.Location = new System.Drawing.Point(3, 3);
            this.Panel_Header.Name = "Panel_Header";
            this.Panel_Header.Size = new System.Drawing.Size(194, 16);
            this.Panel_Header.TabIndex = 0;
            // 
            // LBL_Title
            // 
            this.LBL_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.LBL_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LBL_Title.Location = new System.Drawing.Point(0, 0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LBL_Title.Size = new System.Drawing.Size(194, 16);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "MyTitle";
            // 
            // Panel_Input
            // 
            this.Panel_Input.AutoSize = true;
            this.Panel_Input.Controls.Add(this.TXT_Input);
            this.Panel_Input.Controls.Add(this.Pic_16px);
            this.Panel_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Input.Location = new System.Drawing.Point(3, 19);
            this.Panel_Input.Name = "Panel_Input";
            this.Panel_Input.Size = new System.Drawing.Size(194, 20);
            this.Panel_Input.TabIndex = 1;
            // 
            // TXT_Input
            // 
            this.TXT_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_Input.Location = new System.Drawing.Point(26, 0);
            this.TXT_Input.Margin = new System.Windows.Forms.Padding(0);
            this.TXT_Input.Name = "TXT_Input";
            this.TXT_Input.Size = new System.Drawing.Size(168, 20);
            this.TXT_Input.TabIndex = 2;
            this.TXT_Input.TextChanged += new System.EventHandler(this.TXT_Input_TextChanged);
            this.TXT_Input.Enter += new System.EventHandler(this.TXT_Input_Enter);
            // 
            // Pic_16px
            // 
            this.Pic_16px.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pic_16px.Image = global::SalesApp_Alpha_2.Properties.Resources.icons8_archivo_de_imagen_16;
            this.Pic_16px.Location = new System.Drawing.Point(0, 0);
            this.Pic_16px.Margin = new System.Windows.Forms.Padding(0);
            this.Pic_16px.Name = "Pic_16px";
            this.Pic_16px.Size = new System.Drawing.Size(20, 20);
            this.Pic_16px.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pic_16px.TabIndex = 1;
            this.Pic_16px.TabStop = false;
            // 
            // InputBox_Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Panel_Input);
            this.Controls.Add(this.Panel_Header);
            this.MinimumSize = new System.Drawing.Size(150, 0);
            this.Name = "InputBox_Text";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(200, 42);
            this.Panel_Header.ResumeLayout(false);
            this.Panel_Input.ResumeLayout(false);
            this.Panel_Input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_16px)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel Panel_Header;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Panel Panel_Input;
        private System.Windows.Forms.PictureBox Pic_16px;

        #endregion

        private System.Windows.Forms.TextBox TXT_Input;
    }
}
