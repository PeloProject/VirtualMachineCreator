namespace VMCreator
{
    partial class Form1
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
            tabPageSettings = new TabPage();
            tabControl1.SuspendLayout();
            tabPageControl.SuspendLayout();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(6, 35);
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
            OutputTextBox.Location = new Point(12, 307);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(776, 131);
            OutputTextBox.TabIndex = 1;
            OutputTextBox.Text = "";
            // 
            // BoxListComboBox
            // 
            BoxListComboBox.FormattingEnabled = true;
            BoxListComboBox.Location = new Point(6, 6);
            BoxListComboBox.Name = "BoxListComboBox";
            BoxListComboBox.Size = new Size(240, 23);
            BoxListComboBox.TabIndex = 2;
            BoxListComboBox.UseWaitCursor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageControl);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Font = new Font("Yu Gothic UI Light", 9F);
            tabControl1.Location = new Point(11, 10);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(777, 291);
            tabControl1.TabIndex = 3;
            tabControl1.UseWaitCursor = true;
            // 
            // tabPageControl
            // 
            tabPageControl.Controls.Add(BoxListComboBox);
            tabPageControl.Controls.Add(CreateButton);
            tabPageControl.Location = new Point(4, 24);
            tabPageControl.Name = "tabPageControl";
            tabPageControl.Padding = new Padding(3);
            tabPageControl.Size = new Size(769, 263);
            tabPageControl.TabIndex = 0;
            tabPageControl.Text = "VM操作";
            tabPageControl.UseVisualStyleBackColor = true;
            tabPageControl.UseWaitCursor = true;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Location = new Point(4, 24);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(769, 263);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "設定";
            tabPageSettings.UseVisualStyleBackColor = true;
            tabPageSettings.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(OutputTextBox);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPageControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button CreateButton;
        private RichTextBox OutputTextBox;
        private ComboBox BoxListComboBox;
        private TabControl tabControl1;
        private TabPage tabPageControl;
        private TabPage tabPageSettings;
    }
}
