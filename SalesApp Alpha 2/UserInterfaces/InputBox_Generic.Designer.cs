namespace SalesApp_Alpha_2.UserInterfaces
{
    partial class InputBox_Generic<T>
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
            this.Label_Title = new System.Windows.Forms.Label();
            this.Picture_Icon = new System.Windows.Forms.PictureBox();
            this.Panel_Input = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_Title.Location = new System.Drawing.Point(0, 1);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.Label_Title.Size = new System.Drawing.Size(150, 15);
            this.Label_Title.TabIndex = 0;
            this.Label_Title.Text = "Title";
            // 
            // Picture_Icon
            // 
            this.Picture_Icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.Picture_Icon.Image = global::SalesApp_Alpha_2.Properties.Resources._16px_Image;
            this.Picture_Icon.Location = new System.Drawing.Point(0, 16);
            this.Picture_Icon.Name = "Picture_Icon";
            this.Picture_Icon.Size = new System.Drawing.Size(32, 134);
            this.Picture_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture_Icon.TabIndex = 1;
            this.Picture_Icon.TabStop = false;
            // 
            // Panel_Input
            // 
            this.Panel_Input.AutoSize = true;
            this.Panel_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Input.Location = new System.Drawing.Point(32, 16);
            this.Panel_Input.Name = "Panel_Input";
            this.Panel_Input.Size = new System.Drawing.Size(118, 134);
            this.Panel_Input.TabIndex = 2;
            // 
            // InputBox_Generic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.Panel_Input);
            this.Controls.Add(this.Picture_Icon);
            this.Controls.Add(this.Label_Title);
            this.Name = "InputBox_Generic";
            this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 3);
            this.Size = new System.Drawing.Size(150, 153);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.InputBox_Generic_Validating);
            this.Validated += new System.EventHandler(this.InputBox_Generic_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.PictureBox Picture_Icon;
        private System.Windows.Forms.Panel Panel_Input;
    }
}
