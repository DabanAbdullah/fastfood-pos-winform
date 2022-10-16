namespace fastfoodnew
{
    partial class mainform
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelnav = new System.Windows.Forms.Panel();
            this.setting = new System.Windows.Forms.Button();
            this.users = new System.Windows.Forms.Button();
            this.role = new System.Windows.Forms.Button();
            this.div = new System.Windows.Forms.Button();
            this.food = new System.Windows.Forms.Button();
            this.category = new System.Windows.Forms.Button();
            this.expense = new System.Windows.Forms.Button();
            this.sale = new System.Windows.Forms.Button();
            this.dashboard = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panelnav);
            this.panel1.Controls.Add(this.setting);
            this.panel1.Controls.Add(this.users);
            this.panel1.Controls.Add(this.role);
            this.panel1.Controls.Add(this.div);
            this.panel1.Controls.Add(this.food);
            this.panel1.Controls.Add(this.category);
            this.panel1.Controls.Add(this.expense);
            this.panel1.Controls.Add(this.sale);
            this.panel1.Controls.Add(this.dashboard);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(909, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(42, 577);
            this.panel1.TabIndex = 0;
            // 
            // panelnav
            // 
            this.panelnav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panelnav.Location = new System.Drawing.Point(183, 144);
            this.panelnav.Name = "panelnav";
            this.panelnav.Size = new System.Drawing.Size(3, 290);
            this.panelnav.TabIndex = 1;
            // 
            // setting
            // 
            this.setting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.setting.Image = global::fastfoodnew.Properties.Resources.settings;
            this.setting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.setting.Location = new System.Drawing.Point(0, 535);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(42, 42);
            this.setting.TabIndex = 1;
            this.setting.Text = "ڕێکخستنەکان";
            this.setting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.btndashboard_Click);
            this.setting.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.setting.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.setting.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // users
            // 
            this.users.Cursor = System.Windows.Forms.Cursors.Hand;
            this.users.Dock = System.Windows.Forms.DockStyle.Top;
            this.users.FlatAppearance.BorderSize = 0;
            this.users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.users.Image = global::fastfoodnew.Properties.Resources.add_user_group_man_man_25px;
            this.users.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.users.Location = new System.Drawing.Point(0, 444);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(42, 42);
            this.users.TabIndex = 1;
            this.users.Text = "بەکار‌هێنەران";
            this.users.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.users.UseVisualStyleBackColor = true;
            this.users.Click += new System.EventHandler(this.btndashboard_Click);
            this.users.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.users.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.users.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // role
            // 
            this.role.Cursor = System.Windows.Forms.Cursors.Hand;
            this.role.Dock = System.Windows.Forms.DockStyle.Top;
            this.role.FlatAppearance.BorderSize = 0;
            this.role.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.role.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.role.Image = global::fastfoodnew.Properties.Resources.admin_settings_male_25px;
            this.role.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.role.Location = new System.Drawing.Point(0, 402);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(42, 42);
            this.role.TabIndex = 1;
            this.role.Text = "ڕۆڵ";
            this.role.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.role.UseVisualStyleBackColor = true;
            this.role.Click += new System.EventHandler(this.btndashboard_Click);
            this.role.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.role.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.role.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // div
            // 
            this.div.Cursor = System.Windows.Forms.Cursors.Hand;
            this.div.Dock = System.Windows.Forms.DockStyle.Top;
            this.div.FlatAppearance.BorderSize = 0;
            this.div.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.div.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.div.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.div.Image = global::fastfoodnew.Properties.Resources.shipped_25px;
            this.div.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.div.Location = new System.Drawing.Point(0, 360);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(42, 42);
            this.div.TabIndex = 1;
            this.div.Text = "دیلیڤەری";
            this.div.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.div.UseVisualStyleBackColor = true;
            this.div.Click += new System.EventHandler(this.btndashboard_Click);
            this.div.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.div.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.div.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // food
            // 
            this.food.Cursor = System.Windows.Forms.Cursors.Hand;
            this.food.Dock = System.Windows.Forms.DockStyle.Top;
            this.food.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.food.FlatAppearance.BorderSize = 0;
            this.food.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.food.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.food.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.food.Image = global::fastfoodnew.Properties.Resources.pot_of_food_25px;
            this.food.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.food.Location = new System.Drawing.Point(0, 318);
            this.food.Name = "food";
            this.food.Size = new System.Drawing.Size(42, 42);
            this.food.TabIndex = 1;
            this.food.Text = "خواردن";
            this.food.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.food.UseVisualStyleBackColor = true;
            this.food.Click += new System.EventHandler(this.btndashboard_Click);
            this.food.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.food.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.food.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // category
            // 
            this.category.Cursor = System.Windows.Forms.Cursors.Hand;
            this.category.Dock = System.Windows.Forms.DockStyle.Top;
            this.category.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.category.FlatAppearance.BorderSize = 0;
            this.category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.category.Image = global::fastfoodnew.Properties.Resources.sorting_25px;
            this.category.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.category.Location = new System.Drawing.Point(0, 276);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(42, 42);
            this.category.TabIndex = 1;
            this.category.Text = "جۆر";
            this.category.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.category.UseVisualStyleBackColor = true;
            this.category.Click += new System.EventHandler(this.btndashboard_Click);
            this.category.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.category.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.category.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // expense
            // 
            this.expense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expense.Dock = System.Windows.Forms.DockStyle.Top;
            this.expense.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.expense.FlatAppearance.BorderSize = 0;
            this.expense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expense.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.expense.Image = global::fastfoodnew.Properties.Resources.general_ledger_25px;
            this.expense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.expense.Location = new System.Drawing.Point(0, 234);
            this.expense.Name = "expense";
            this.expense.Size = new System.Drawing.Size(42, 42);
            this.expense.TabIndex = 1;
            this.expense.Text = "خەرجی";
            this.expense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.expense.UseVisualStyleBackColor = true;
            this.expense.Click += new System.EventHandler(this.btndashboard_Click);
            this.expense.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.expense.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.expense.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // sale
            // 
            this.sale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sale.Dock = System.Windows.Forms.DockStyle.Top;
            this.sale.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.sale.FlatAppearance.BorderSize = 0;
            this.sale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sale.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.sale.Image = global::fastfoodnew.Properties.Resources.receipt_25px;
            this.sale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sale.Location = new System.Drawing.Point(0, 192);
            this.sale.Name = "sale";
            this.sale.Size = new System.Drawing.Size(42, 42);
            this.sale.TabIndex = 1;
            this.sale.Text = "فرۆشتن";
            this.sale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sale.UseVisualStyleBackColor = true;
            this.sale.Click += new System.EventHandler(this.btndashboard_Click);
            this.sale.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.sale.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.sale.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // dashboard
            // 
            this.dashboard.ContextMenuStrip = this.contextMenuStrip1;
            this.dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboard.FlatAppearance.BorderColor = System.Drawing.Color.LightGreen;
            this.dashboard.FlatAppearance.BorderSize = 0;
            this.dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.dashboard.Image = global::fastfoodnew.Properties.Resources.google_home_25px;
            this.dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dashboard.Location = new System.Drawing.Point(0, 150);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(42, 42);
            this.dashboard.TabIndex = 1;
            this.dashboard.Text = "داشبۆرد";
            this.dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard.UseVisualStyleBackColor = true;
            this.dashboard.Click += new System.EventHandler(this.btndashboard_Click);
            this.dashboard.Leave += new System.EventHandler(this.btndashboard_Leave);
            this.dashboard.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            this.dashboard.MouseHover += new System.EventHandler(this.dashboard_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(91, 36);
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.menu1.Font = new System.Drawing.Font("Unikurd Jino", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(169)))));
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(90, 32);
            this.menu1.Text = "a";
            this.menu1.MouseLeave += new System.EventHandler(this.menu1_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(42, 150);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(42, 25);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::fastfoodnew.Properties.Resources.menu_25px;
            this.pictureBox2.Location = new System.Drawing.Point(5, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 25);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Unikurd Jino", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(169)))));
            this.label2.Location = new System.Drawing.Point(66, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "دەرچوون";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Unikurd Jino", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(169)))));
            this.label1.Location = new System.Drawing.Point(0, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "دابان صالاح الدین";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::fastfoodnew.Properties.Resources.Untitled_11;
            this.pictureBox1.Location = new System.Drawing.Point(66, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // radDock1
            // 
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            this.radDock1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.Size = new System.Drawing.Size(909, 577);
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabIndex = 1;
            this.radDock1.TabStop = false;
            this.radDock1.ThemeName = "VisualStudio2012Dark";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.ThemeName = "VisualStudio2012Dark";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainform";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mainform_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dashboard;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button food;
        private System.Windows.Forms.Button category;
        private System.Windows.Forms.Button expense;
        private System.Windows.Forms.Button sale;
        private System.Windows.Forms.Button div;
        private System.Windows.Forms.Button role;
        private System.Windows.Forms.Panel panelnav;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu1;
        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Timer timer1;
    }
}