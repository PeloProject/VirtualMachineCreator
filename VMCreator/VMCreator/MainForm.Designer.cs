namespace VMCreator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateButton = new Button();
            BoxListComboBox = new ComboBox();
            tabControl1 = new TabControl();
            tabPageControl = new TabPage();
            InitializeButton = new Button();
            DestroyButton = new Button();
            label1 = new Label();
            VmAppComboBox = new ComboBox();
            tabPageSettings = new TabPage();
            label_CurrentBoxRootPath = new Label();
            label3 = new Label();
            button_ApplyBoxRootPath = new Button();
            label2 = new Label();
            TextBox_BoxRootPath = new TextBox();
            tabPageBox = new TabPage();
            listViewBoxInfo = new ListView();
            textBox1 = new TextBox();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPageControl.SuspendLayout();
            tabPageSettings.SuspendLayout();
            tabPageBox.SuspendLayout();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(112, 61);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 0;
            CreateButton.Text = "VM作成";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.UseWaitCursor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // BoxListComboBox
            // 
            BoxListComboBox.FormattingEnabled = true;
            BoxListComboBox.Location = new Point(6, 32);
            BoxListComboBox.Name = "BoxListComboBox";
            BoxListComboBox.Size = new Size(240, 23);
            BoxListComboBox.TabIndex = 2;
            BoxListComboBox.UseWaitCursor = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageControl);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPageBox);
            tabControl1.Font = new Font("Yu Gothic UI Light", 9F);
            tabControl1.Location = new Point(11, 10);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(609, 383);
            tabControl1.TabIndex = 3;
            tabControl1.UseWaitCursor = true;
            // 
            // tabPageControl
            // 
            tabPageControl.Controls.Add(InitializeButton);
            tabPageControl.Controls.Add(DestroyButton);
            tabPageControl.Controls.Add(label1);
            tabPageControl.Controls.Add(VmAppComboBox);
            tabPageControl.Controls.Add(BoxListComboBox);
            tabPageControl.Controls.Add(CreateButton);
            tabPageControl.Location = new Point(4, 24);
            tabPageControl.Name = "tabPageControl";
            tabPageControl.Padding = new Padding(3);
            tabPageControl.Size = new Size(601, 355);
            tabPageControl.TabIndex = 0;
            tabPageControl.Text = "VM操作";
            tabPageControl.UseVisualStyleBackColor = true;
            tabPageControl.UseWaitCursor = true;
            // 
            // InitializeButton
            // 
            InitializeButton.Location = new Point(9, 61);
            InitializeButton.Name = "InitializeButton";
            InitializeButton.Size = new Size(97, 23);
            InitializeButton.TabIndex = 6;
            InitializeButton.Text = "設定ファイル作成";
            InitializeButton.UseVisualStyleBackColor = true;
            InitializeButton.UseWaitCursor = true;
            InitializeButton.Click += InitializeButton_Click;
            // 
            // DestroyButton
            // 
            DestroyButton.Location = new Point(193, 61);
            DestroyButton.Name = "DestroyButton";
            DestroyButton.Size = new Size(75, 23);
            DestroyButton.TabIndex = 5;
            DestroyButton.Text = "VM削除";
            DestroyButton.UseVisualStyleBackColor = true;
            DestroyButton.UseWaitCursor = true;
            DestroyButton.Click += DestroyButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Light", 11F);
            label1.Location = new Point(6, 6);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "VM APP :";
            label1.UseWaitCursor = true;
            // 
            // VmAppComboBox
            // 
            VmAppComboBox.FormattingEnabled = true;
            VmAppComboBox.Location = new Point(79, 6);
            VmAppComboBox.Name = "VmAppComboBox";
            VmAppComboBox.Size = new Size(240, 23);
            VmAppComboBox.TabIndex = 3;
            VmAppComboBox.UseWaitCursor = true;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Controls.Add(label_CurrentBoxRootPath);
            tabPageSettings.Controls.Add(label3);
            tabPageSettings.Controls.Add(button_ApplyBoxRootPath);
            tabPageSettings.Controls.Add(label2);
            tabPageSettings.Controls.Add(TextBox_BoxRootPath);
            tabPageSettings.Location = new Point(4, 24);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(601, 355);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "設定";
            tabPageSettings.UseVisualStyleBackColor = true;
            tabPageSettings.UseWaitCursor = true;
            // 
            // label_CurrentBoxRootPath
            // 
            label_CurrentBoxRootPath.AutoSize = true;
            label_CurrentBoxRootPath.Font = new Font("Yu Gothic UI Light", 11F);
            label_CurrentBoxRootPath.Location = new Point(144, 35);
            label_CurrentBoxRootPath.Name = "label_CurrentBoxRootPath";
            label_CurrentBoxRootPath.Size = new Size(0, 20);
            label_CurrentBoxRootPath.TabIndex = 4;
            label_CurrentBoxRootPath.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI Light", 11F);
            label3.Location = new Point(2, 35);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 3;
            label3.Text = "CurrentBoxRootPath：";
            label3.UseWaitCursor = true;
            // 
            // button_ApplyBoxRootPath
            // 
            button_ApplyBoxRootPath.Location = new Point(457, 6);
            button_ApplyBoxRootPath.Name = "button_ApplyBoxRootPath";
            button_ApplyBoxRootPath.Size = new Size(84, 23);
            button_ApplyBoxRootPath.TabIndex = 2;
            button_ApplyBoxRootPath.Text = "Boxパス反映";
            button_ApplyBoxRootPath.UseVisualStyleBackColor = true;
            button_ApplyBoxRootPath.UseWaitCursor = true;
            button_ApplyBoxRootPath.Click += button_ApplyBoxRootPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Light", 11F);
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 1;
            label2.Text = "BoxRootPath：";
            label2.UseWaitCursor = true;
            // 
            // TextBox_BoxRootPath
            // 
            TextBox_BoxRootPath.Location = new Point(110, 6);
            TextBox_BoxRootPath.Name = "TextBox_BoxRootPath";
            TextBox_BoxRootPath.Size = new Size(331, 23);
            TextBox_BoxRootPath.TabIndex = 0;
            TextBox_BoxRootPath.UseWaitCursor = true;
            // 
            // tabPageBox
            // 
            tabPageBox.Controls.Add(listViewBoxInfo);
            tabPageBox.Controls.Add(textBox1);
            tabPageBox.Controls.Add(button1);
            tabPageBox.Location = new Point(4, 24);
            tabPageBox.Name = "tabPageBox";
            tabPageBox.Padding = new Padding(3);
            tabPageBox.Size = new Size(601, 355);
            tabPageBox.TabIndex = 2;
            tabPageBox.Text = "Box";
            tabPageBox.UseVisualStyleBackColor = true;
            tabPageBox.UseWaitCursor = true;
            // 
            // listViewBoxInfo
            // 
            listViewBoxInfo.Location = new Point(17, 74);
            listViewBoxInfo.Name = "listViewBoxInfo";
            listViewBoxInfo.Size = new Size(531, 235);
            listViewBoxInfo.TabIndex = 2;
            listViewBoxInfo.UseCompatibleStateImageBehavior = false;
            listViewBoxInfo.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(9, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.Location = new Point(128, 8);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 405);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "VMCreator";
            tabControl1.ResumeLayout(false);
            tabPageControl.ResumeLayout(false);
            tabPageControl.PerformLayout();
            tabPageSettings.ResumeLayout(false);
            tabPageSettings.PerformLayout();
            tabPageBox.ResumeLayout(false);
            tabPageBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button CreateButton;
        private ComboBox BoxListComboBox;
        private TabControl tabControl1;
        private TabPage tabPageControl;
        private TabPage tabPageSettings;
        private ComboBox VmAppComboBox;
        private Label label1;
        private Button DestroyButton;
        private Button InitializeButton;
        private Label label2;
        private TextBox TextBox_BoxRootPath;
        private Button button_ApplyBoxRootPath;
        private Label label3;
        private Label label_CurrentBoxRootPath;
        private TabPage tabPageBox;
        private TextBox textBox1;
        private Button button1;
        private ListView listViewBoxInfo;
    }
}
