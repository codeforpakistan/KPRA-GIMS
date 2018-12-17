namespace KPRA_RIMS
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LB12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProductCode = new MetroFramework.Controls.MetroTextBox();
            this.CostPrice = new MetroFramework.Controls.MetroTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.Description = new MetroFramework.Controls.MetroTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SalePrice = new MetroFramework.Controls.MetroTextBox();
            this.ProductName = new MetroFramework.Controls.MetroTextBox();
            this.LB5 = new MaterialSkin.Controls.MaterialLabel();
            this.LB3 = new MaterialSkin.Controls.MaterialLabel();
            this.LB2 = new MaterialSkin.Controls.MaterialLabel();
            this.LB1 = new MaterialSkin.Controls.MaterialLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(154)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.LB12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-4, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 64);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(729, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 66;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // LB12
            // 
            this.LB12.AutoSize = true;
            this.LB12.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB12.ForeColor = System.Drawing.Color.White;
            this.LB12.Location = new System.Drawing.Point(32, 18);
            this.LB12.Name = "LB12";
            this.LB12.Size = new System.Drawing.Size(248, 32);
            this.LB12.TabIndex = 59;
            this.LB12.Text = "Add New Product";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(767, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ProductCode
            // 
            // 
            // 
            // 
            this.ProductCode.CustomButton.Image = null;
            this.ProductCode.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.ProductCode.CustomButton.Name = "";
            this.ProductCode.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ProductCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ProductCode.CustomButton.TabIndex = 1;
            this.ProductCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ProductCode.CustomButton.UseSelectable = true;
            this.ProductCode.CustomButton.Visible = false;
            this.ProductCode.Lines = new string[0];
            this.ProductCode.Location = new System.Drawing.Point(292, 133);
            this.ProductCode.MaxLength = 32767;
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.PasswordChar = '\0';
            this.ProductCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ProductCode.SelectedText = "";
            this.ProductCode.SelectionLength = 0;
            this.ProductCode.SelectionStart = 0;
            this.ProductCode.ShortcutsEnabled = true;
            this.ProductCode.Size = new System.Drawing.Size(317, 30);
            this.ProductCode.TabIndex = 1;
            this.ProductCode.UseSelectable = true;
            this.ProductCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ProductCode.WaterMarkFont = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CostPrice
            // 
            // 
            // 
            // 
            this.CostPrice.CustomButton.Image = null;
            this.CostPrice.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.CostPrice.CustomButton.Name = "";
            this.CostPrice.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.CostPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CostPrice.CustomButton.TabIndex = 1;
            this.CostPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CostPrice.CustomButton.UseSelectable = true;
            this.CostPrice.CustomButton.Visible = false;
            this.CostPrice.Lines = new string[0];
            this.CostPrice.Location = new System.Drawing.Point(292, 215);
            this.CostPrice.MaxLength = 32767;
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.PasswordChar = '\0';
            this.CostPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CostPrice.SelectedText = "";
            this.CostPrice.SelectionLength = 0;
            this.CostPrice.SelectionStart = 0;
            this.CostPrice.ShortcutsEnabled = true;
            this.CostPrice.Size = new System.Drawing.Size(317, 30);
            this.CostPrice.TabIndex = 3;
            this.CostPrice.UseSelectable = true;
            this.CostPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CostPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CostPrice_KeyPress);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(151, 219);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(79, 19);
            this.materialLabel4.TabIndex = 61;
            this.materialLabel4.Text = "Cost Price";
            // 
            // Description
            // 
            // 
            // 
            // 
            this.Description.CustomButton.Image = null;
            this.Description.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.Description.CustomButton.Name = "";
            this.Description.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.Description.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Description.CustomButton.TabIndex = 1;
            this.Description.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Description.CustomButton.UseSelectable = true;
            this.Description.CustomButton.Visible = false;
            this.Description.Lines = new string[0];
            this.Description.Location = new System.Drawing.Point(292, 302);
            this.Description.MaxLength = 32767;
            this.Description.Name = "Description";
            this.Description.PasswordChar = '\0';
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Description.SelectedText = "";
            this.Description.SelectionLength = 0;
            this.Description.SelectionStart = 0;
            this.Description.ShortcutsEnabled = true;
            this.Description.Size = new System.Drawing.Size(317, 30);
            this.Description.TabIndex = 5;
            this.Description.UseSelectable = true;
            this.Description.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Description.WaterMarkFont = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(151, 306);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(86, 19);
            this.materialLabel2.TabIndex = 60;
            this.materialLabel2.Text = "Description";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(292, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(317, 29);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Catagory";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SalePrice
            // 
            // 
            // 
            // 
            this.SalePrice.CustomButton.Image = null;
            this.SalePrice.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.SalePrice.CustomButton.Name = "";
            this.SalePrice.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.SalePrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SalePrice.CustomButton.TabIndex = 1;
            this.SalePrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SalePrice.CustomButton.UseSelectable = true;
            this.SalePrice.CustomButton.Visible = false;
            this.SalePrice.Lines = new string[0];
            this.SalePrice.Location = new System.Drawing.Point(292, 260);
            this.SalePrice.MaxLength = 32767;
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.PasswordChar = '\0';
            this.SalePrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SalePrice.SelectedText = "";
            this.SalePrice.SelectionLength = 0;
            this.SalePrice.SelectionStart = 0;
            this.SalePrice.ShortcutsEnabled = true;
            this.SalePrice.Size = new System.Drawing.Size(317, 30);
            this.SalePrice.TabIndex = 4;
            this.SalePrice.UseSelectable = true;
            this.SalePrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SalePrice.WaterMarkFont = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalePrice_KeyPress);
            // 
            // ProductName
            // 
            // 
            // 
            // 
            this.ProductName.CustomButton.Image = null;
            this.ProductName.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.ProductName.CustomButton.Name = "";
            this.ProductName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ProductName.CustomButton.TabIndex = 1;
            this.ProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ProductName.CustomButton.UseSelectable = true;
            this.ProductName.CustomButton.Visible = false;
            this.ProductName.Lines = new string[0];
            this.ProductName.Location = new System.Drawing.Point(292, 176);
            this.ProductName.MaxLength = 32767;
            this.ProductName.Name = "ProductName";
            this.ProductName.PasswordChar = '\0';
            this.ProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ProductName.SelectedText = "";
            this.ProductName.SelectionLength = 0;
            this.ProductName.SelectionStart = 0;
            this.ProductName.ShortcutsEnabled = true;
            this.ProductName.Size = new System.Drawing.Size(317, 30);
            this.ProductName.TabIndex = 2;
            this.ProductName.UseSelectable = true;
            this.ProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LB5
            // 
            this.LB5.AutoSize = true;
            this.LB5.BackColor = System.Drawing.Color.Transparent;
            this.LB5.Depth = 0;
            this.LB5.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB5.Location = new System.Drawing.Point(151, 264);
            this.LB5.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB5.Name = "LB5";
            this.LB5.Size = new System.Drawing.Size(76, 19);
            this.LB5.TabIndex = 58;
            this.LB5.Text = "Sale Price";
            // 
            // LB3
            // 
            this.LB3.AutoSize = true;
            this.LB3.BackColor = System.Drawing.Color.Transparent;
            this.LB3.Depth = 0;
            this.LB3.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB3.Location = new System.Drawing.Point(151, 180);
            this.LB3.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB3.Name = "LB3";
            this.LB3.Size = new System.Drawing.Size(105, 19);
            this.LB3.TabIndex = 57;
            this.LB3.Text = "Product Name";
            // 
            // LB2
            // 
            this.LB2.AutoSize = true;
            this.LB2.BackColor = System.Drawing.Color.Transparent;
            this.LB2.Depth = 0;
            this.LB2.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB2.Location = new System.Drawing.Point(151, 144);
            this.LB2.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB2.Name = "LB2";
            this.LB2.Size = new System.Drawing.Size(104, 19);
            this.LB2.TabIndex = 56;
            this.LB2.Text = "Product  Code";
            // 
            // LB1
            // 
            this.LB1.AutoSize = true;
            this.LB1.BackColor = System.Drawing.Color.Transparent;
            this.LB1.Depth = 0;
            this.LB1.Font = new System.Drawing.Font("Roboto", 11F);
            this.LB1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LB1.Location = new System.Drawing.Point(151, 101);
            this.LB1.MouseState = MaterialSkin.MouseState.HOVER;
            this.LB1.Name = "LB1";
            this.LB1.Size = new System.Drawing.Size(69, 19);
            this.LB1.TabIndex = 55;
            this.LB1.Text = "Category";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(123, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 44);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(172)))), ((int)(((byte)(52)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(467, 355);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 44);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(172)))), ((int)(((byte)(52)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(295, 355);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 44);
            this.button5.TabIndex = 7;
            this.button5.Text = "List";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 437);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ProductCode);
            this.Controls.Add(this.CostPrice);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SalePrice);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.LB5);
            this.Controls.Add(this.LB3);
            this.Controls.Add(this.LB2);
            this.Controls.Add(this.LB1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddProduct";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB12;
        private MetroFramework.Controls.MetroTextBox ProductCode;
        private MetroFramework.Controls.MetroTextBox CostPrice;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MetroFramework.Controls.MetroTextBox Description;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroTextBox SalePrice;
        private MetroFramework.Controls.MetroTextBox ProductName;
        private MaterialSkin.Controls.MaterialLabel LB5;
        private MaterialSkin.Controls.MaterialLabel LB3;
        private MaterialSkin.Controls.MaterialLabel LB2;
        private MaterialSkin.Controls.MaterialLabel LB1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;





    }
}

