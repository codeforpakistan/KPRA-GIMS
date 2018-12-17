namespace KPRA_RIMS
{
    partial class Update_Business_Type
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BusinessName = new MetroFramework.Controls.MetroTextBox();
            this.LB12 = new System.Windows.Forms.Label();
            this.Description = new MetroFramework.Controls.MetroTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.BusinessName);
            this.panel1.Controls.Add(this.LB12);
            this.panel1.Controls.Add(this.Description);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(10, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 274);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BusinessName
            // 
            // 
            // 
            // 
            this.BusinessName.CustomButton.Image = null;
            this.BusinessName.CustomButton.Location = new System.Drawing.Point(373, 2);
            this.BusinessName.CustomButton.Name = "";
            this.BusinessName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.BusinessName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.BusinessName.CustomButton.TabIndex = 1;
            this.BusinessName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.BusinessName.CustomButton.UseSelectable = true;
            this.BusinessName.CustomButton.Visible = false;
            this.BusinessName.Lines = new string[0];
            this.BusinessName.Location = new System.Drawing.Point(157, 104);
            this.BusinessName.MaxLength = 32767;
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.PasswordChar = '\0';
            this.BusinessName.PromptText = "Business Type Name";
            this.BusinessName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BusinessName.SelectedText = "";
            this.BusinessName.SelectionLength = 0;
            this.BusinessName.SelectionStart = 0;
            this.BusinessName.ShortcutsEnabled = true;
            this.BusinessName.Size = new System.Drawing.Size(401, 30);
            this.BusinessName.TabIndex = 0;
            this.BusinessName.UseSelectable = true;
            this.BusinessName.WaterMark = "Business Type Name";
            this.BusinessName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.BusinessName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LB12
            // 
            this.LB12.AutoSize = true;
            this.LB12.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB12.ForeColor = System.Drawing.Color.Black;
            this.LB12.Location = new System.Drawing.Point(22, 17);
            this.LB12.Name = "LB12";
            this.LB12.Size = new System.Drawing.Size(270, 37);
            this.LB12.TabIndex = 43;
            this.LB12.Text = "Update Business Type";
            // 
            // Description
            // 
            // 
            // 
            // 
            this.Description.CustomButton.Image = null;
            this.Description.CustomButton.Location = new System.Drawing.Point(373, 2);
            this.Description.CustomButton.Name = "";
            this.Description.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.Description.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Description.CustomButton.TabIndex = 1;
            this.Description.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Description.CustomButton.UseSelectable = true;
            this.Description.CustomButton.Visible = false;
            this.Description.Lines = new string[0];
            this.Description.Location = new System.Drawing.Point(157, 147);
            this.Description.MaxLength = 32767;
            this.Description.Name = "Description";
            this.Description.PasswordChar = '\0';
            this.Description.PromptText = "Description";
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Description.SelectedText = "";
            this.Description.SelectionLength = 0;
            this.Description.SelectionStart = 0;
            this.Description.ShortcutsEnabled = true;
            this.Description.Size = new System.Drawing.Size(401, 30);
            this.Description.TabIndex = 2;
            this.Description.UseSelectable = true;
            this.Description.WaterMark = "Description";
            this.Description.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Description.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(157, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(401, 38);
            this.button2.TabIndex = 40;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Update_Business_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 348);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Update_Business_Type";
            this.TransparencyKey = System.Drawing.Color.DodgerBlue;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox Description;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LB12;
        private MetroFramework.Controls.MetroTextBox BusinessName;





    }
}

