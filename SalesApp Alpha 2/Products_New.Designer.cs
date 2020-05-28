namespace SalesApp_Alpha_2
{
    partial class Products_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products_New));
            this.BTT_Ok = new System.Windows.Forms.Button();
            this.LPANEL_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.UI_ProductsPropertiesInput = new SalesApp_Alpha_2.UI_ProductsProperties();
            this.LPANEL_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTT_Ok
            // 
            resources.ApplyResources(this.BTT_Ok, "BTT_Ok");
            this.BTT_Ok.Name = "BTT_Ok";
            this.BTT_Ok.UseVisualStyleBackColor = true;
            this.BTT_Ok.Click += new System.EventHandler(this.BTT_Ok_Click);
            // 
            // LPANEL_Buttons
            // 
            resources.ApplyResources(this.LPANEL_Buttons, "LPANEL_Buttons");
            this.LPANEL_Buttons.Controls.Add(this.BTT_Ok);
            this.LPANEL_Buttons.Name = "LPANEL_Buttons";
            // 
            // UI_ProductsPropertiesInput
            // 
            resources.ApplyResources(this.UI_ProductsPropertiesInput, "UI_ProductsPropertiesInput");
            this.UI_ProductsPropertiesInput.Name = "UI_ProductsPropertiesInput";
            this.UI_ProductsPropertiesInput.PropertyID = false;
            // 
            // Products_New
            // 
            this.AcceptButton = this.BTT_Ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UI_ProductsPropertiesInput);
            this.Controls.Add(this.LPANEL_Buttons);
            this.Name = "Products_New";
            this.LPANEL_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTT_Ok;
        private System.Windows.Forms.FlowLayoutPanel LPANEL_Buttons;
        private UI_ProductsProperties UI_ProductsPropertiesInput;
    }
}