namespace KPRA_RIMS
{
    partial class Add_Business_Type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Business_Type));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LB12 = new System.Windows.Forms.Label();
            this.BusinessName = new MetroFramework.Controls.MetroTextBox();
            this.Description = new MetroFramework.Controls.MetroTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(154)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LB12);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 46);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(719, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(763, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LB12
            // 
            this.LB12.AutoSize = true;
            this.LB12.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB12.ForeColor = System.Drawing.Color.White;
            this.LB12.Location = new System.Drawing.Point(47, 5);
            this.LB12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB12.Name = "LB12";
            this.LB12.Size = new System.Drawing.Size(206, 32);
            this.LB12.TabIndex = 48;
            this.LB12.Text = "Business Type";
            // 
            // BusinessName
            // 
            // 
            // 
            // 
            this.BusinessName.CustomButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessName.CustomButton.Image = null;
            this.BusinessName.CustomButton.Location = new System.Drawing.Point(608, 2);
            this.BusinessName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BusinessName.CustomButton.Name = "";
            this.BusinessName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.BusinessName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.BusinessName.CustomButton.TabIndex = 1;
            this.BusinessName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.BusinessName.CustomButton.UseSelectable = true;
            this.BusinessName.CustomButton.Visible = false;
            this.BusinessName.Lines = new string[0];
            this.BusinessName.Location = new System.Drawing.Point(52, 70);
            this.BusinessName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BusinessName.MaxLength = 32767;
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.PasswordChar = '\0';
            this.BusinessName.PromptText = "Business Type Name";
            this.BusinessName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BusinessName.SelectedText = "";
            this.BusinessName.SelectionLength = 0;
            this.BusinessName.SelectionStart = 0;
            this.BusinessName.ShortcutsEnabled = true;
            this.BusinessName.Size = new System.Drawing.Size(638, 32);
            this.BusinessName.TabIndex = 0;
            this.BusinessName.UseSelectable = true;
            this.BusinessName.WaterMark = "Business Type Name";
            this.BusinessName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.BusinessName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Description
            // 
            // 
            // 
            // 
            this.Description.CustomButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.CustomButton.Image = null;
            this.Description.CustomButton.Location = new System.Drawing.Point(608, 2);
            this.Description.CustomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Description.CustomButton.Name = "";
            this.Description.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.Description.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Description.CustomButton.TabIndex = 1;
            this.Description.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Description.CustomButton.UseSelectable = true;
            this.Description.CustomButton.Visible = false;
            this.Description.Lines = new string[0];
            this.Description.Location = new System.Drawing.Point(52, 108);
            this.Description.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Description.MaxLength = 32767;
            this.Description.Name = "Description";
            this.Description.PasswordChar = '\0';
            this.Description.PromptText = "Description";
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Description.SelectedText = "";
            this.Description.SelectionLength = 0;
            this.Description.SelectionStart = 0;
            this.Description.ShortcutsEnabled = true;
            this.Description.Size = new System.Drawing.Size(638, 32);
            this.Description.TabIndex = 1;
            this.Description.UseSelectable = true;
            this.Description.WaterMark = "Description";
            this.Description.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Description.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(172)))), ((int)(((byte)(52)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(482, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(172)))), ((int)(((byte)(52)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(267, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "List";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(52, 186);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Add_Business_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BusinessName);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add_Business_Type";
            this.Padding = new System.Windows.Forms.Padding(25, 64, 25, 21);
            this.TransparencyKey = System.Drawing.Color.DodgerBlue;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB12;
        private MetroFramework.Controls.MetroTextBox BusinessName;
        private MetroFramework.Controls.MetroTextBox Description;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;





    }
}

