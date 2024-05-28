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
            OutputTextBox = new RichTextBox();
            BoxListComboBox = new ComboBox();
            tabControl1 = new TabControl();
            tabPageControl = new TabPage();
            InitializeButton = new Button();
            DestroyButton = new Button();
            label1 = new Label();
            VmAppComboBox = new ComboBox();
            tabPageSettings = new TabPage();
            tabControl1.SuspendLayout();
            tabPageControl.SuspendLayout();
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
            // OutputTextBox
            // 
            OutputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputTextBox.Location = new Point(12, 262);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(608, 131);
            OutputTextBox.TabIndex = 1;
            OutputTextBox.Text = "";
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
            tabControl1.Font = new Font("Yu Gothic UI Light", 9F);
            tabControl1.Location = new Point(11, 10);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(609, 246);
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
            tabPageControl.Size = new Size(601, 218);
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
            tabPageSettings.Location = new Point(4, 24);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(601, 218);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "設定";
            tabPageSettings.UseVisualStyleBackColor = true;
            tabPageSettings.UseWaitCursor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 405);
            Controls.Add(tabControl1);
            Controls.Add(OutputTextBox);
            Name = "MainForm";
            Text = "VMCreator";
            tabControl1.ResumeLayout(false);
            tabPageControl.ResumeLayout(false);
            tabPageControl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button CreateButton;
        private RichTextBox OutputTextBox;
        private ComboBox BoxListComboBox;
        private TabControl tabControl1;
        private TabPage tabPageControl;
        private TabPage tabPageSettings;
        private ComboBox VmAppComboBox;
        private Label label1;
        private Button DestroyButton;
        private Button InitializeButton;
    }
}
