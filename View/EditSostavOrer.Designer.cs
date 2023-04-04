namespace Service_PK.View
{
    partial class EditSostavOrer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSostavOrer));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialButton19 = new MaterialSkin.Controls.MaterialButton();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            materialListView1 = new MaterialSkin.Controls.MaterialListView();
            columnHeader1 = new ColumnHeader();
            tabPage2 = new TabPage();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            materialListView2 = new MaterialSkin.Controls.MaterialListView();
            columnHeader2 = new ColumnHeader();
            imageList1 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(441, 330);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialButton19);
            tabPage1.Controls.Add(materialComboBox1);
            tabPage1.Controls.Add(materialListView1);
            tabPage1.ImageKey = "pngwing.com (11).png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(433, 287);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Комплектующие";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialButton19
            // 
            materialButton19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialButton19.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton19.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton19.Depth = 0;
            materialButton19.HighEmphasis = true;
            materialButton19.Icon = null;
            materialButton19.Location = new Point(326, 247);
            materialButton19.Margin = new Padding(4, 6, 4, 6);
            materialButton19.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton19.Name = "materialButton19";
            materialButton19.NoAccentTextColor = Color.Empty;
            materialButton19.Size = new Size(100, 36);
            materialButton19.TabIndex = 11;
            materialButton19.Text = "Добавить";
            materialButton19.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton19.UseAccentColor = false;
            materialButton19.UseVisualStyleBackColor = true;
            materialButton19.Click += materialButton19_Click;
            // 
            // materialComboBox1
            // 
            materialComboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Location = new Point(3, 242);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(201, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 10;
            // 
            // materialListView1
            // 
            materialListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialListView1.AutoSizeTable = false;
            materialListView1.BackColor = Color.FromArgb(255, 255, 255);
            materialListView1.BorderStyle = BorderStyle.None;
            materialListView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            materialListView1.Depth = 0;
            materialListView1.FullRowSelect = true;
            materialListView1.Location = new Point(0, 0);
            materialListView1.MinimumSize = new Size(200, 100);
            materialListView1.MouseLocation = new Point(-1, -1);
            materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            materialListView1.Name = "materialListView1";
            materialListView1.OwnerDraw = true;
            materialListView1.Size = new Size(433, 238);
            materialListView1.TabIndex = 9;
            materialListView1.UseCompatibleStateImageBehavior = false;
            materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Комплектующие";
            columnHeader1.Width = 150;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialButton1);
            tabPage2.Controls.Add(materialComboBox2);
            tabPage2.Controls.Add(materialListView2);
            tabPage2.ImageKey = "pngwing.com (7).png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(433, 287);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Услуги";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialButton1
            // 
            materialButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(326, 238);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(100, 36);
            materialButton1.TabIndex = 14;
            materialButton1.Text = "Добавить";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialComboBox2
            // 
            materialComboBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            materialComboBox2.AutoResize = false;
            materialComboBox2.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox2.Depth = 0;
            materialComboBox2.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox2.DropDownHeight = 174;
            materialComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox2.DropDownWidth = 121;
            materialComboBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox2.FormattingEnabled = true;
            materialComboBox2.IntegralHeight = false;
            materialComboBox2.ItemHeight = 43;
            materialComboBox2.Location = new Point(3, 233);
            materialComboBox2.MaxDropDownItems = 4;
            materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox2.Name = "materialComboBox2";
            materialComboBox2.Size = new Size(247, 49);
            materialComboBox2.StartIndex = 0;
            materialComboBox2.TabIndex = 13;
            // 
            // materialListView2
            // 
            materialListView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialListView2.AutoSizeTable = false;
            materialListView2.BackColor = Color.FromArgb(255, 255, 255);
            materialListView2.BorderStyle = BorderStyle.None;
            materialListView2.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            materialListView2.Depth = 0;
            materialListView2.FullRowSelect = true;
            materialListView2.Location = new Point(0, -2);
            materialListView2.MinimumSize = new Size(200, 100);
            materialListView2.MouseLocation = new Point(-1, -1);
            materialListView2.MouseState = MaterialSkin.MouseState.OUT;
            materialListView2.Name = "materialListView2";
            materialListView2.OwnerDraw = true;
            materialListView2.Size = new Size(433, 231);
            materialListView2.TabIndex = 12;
            materialListView2.UseCompatibleStateImageBehavior = false;
            materialListView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Услуги";
            columnHeader2.Width = 150;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "pngwing.com (5).png");
            imageList1.Images.SetKeyName(1, "pngwing.com (7).png");
            imageList1.Images.SetKeyName(2, "pngwing.com (11).png");
            // 
            // EditSostavOrer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 397);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "EditSostavOrer";
            Text = "Редактирование состава заказа";
            FormClosed += EditSostavOrer_FormClosed;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialButton materialButton19;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private ColumnHeader columnHeader1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private MaterialSkin.Controls.MaterialListView materialListView2;
        private ColumnHeader columnHeader2;
        private ImageList imageList1;
    }
}