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
            components = new System.ComponentModel.Container();
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
            tabPageCreateBox = new TabPage();
            labelSelectedBoxName = new Label();
            labelBaseBoxName = new Label();
            labelCreateBoxName = new Label();
            listViewBoxInfo = new ListView();
            textBoxCreateBoxName = new TextBox();
            buttonCreateBox = new Button();
            tabPageBoxManager = new TabPage();
            listViewHaveBoxInfos = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            テストToolStripMenuItem = new ToolStripMenuItem();
            tabPageVMInfo = new TabPage();
            listViewVmInfo = new ListView();
            tabControl1.SuspendLayout();
            tabPageControl.SuspendLayout();
            tabPageSettings.SuspendLayout();
            tabPageCreateBox.SuspendLayout();
            tabPageBoxManager.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabPageVMInfo.SuspendLayout();
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
            tabControl1.Controls.Add(tabPageVMInfo);
            tabControl1.Controls.Add(tabPageControl);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPageCreateBox);
            tabControl1.Controls.Add(tabPageBoxManager);
            tabControl1.Font = new Font("Yu Gothic UI Light", 9F);
            tabControl1.Location = new Point(11, 10);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(609, 383);
            tabControl1.TabIndex = 4;
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
            VmAppComboBox.SelectedIndexChanged += VmAppComboBox_SelectedIndexChanged;
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
            // tabPageCreateBox
            // 
            tabPageCreateBox.Controls.Add(labelSelectedBoxName);
            tabPageCreateBox.Controls.Add(labelBaseBoxName);
            tabPageCreateBox.Controls.Add(labelCreateBoxName);
            tabPageCreateBox.Controls.Add(listViewBoxInfo);
            tabPageCreateBox.Controls.Add(textBoxCreateBoxName);
            tabPageCreateBox.Controls.Add(buttonCreateBox);
            tabPageCreateBox.Location = new Point(4, 24);
            tabPageCreateBox.Name = "tabPageCreateBox";
            tabPageCreateBox.Padding = new Padding(3);
            tabPageCreateBox.Size = new Size(601, 355);
            tabPageCreateBox.TabIndex = 2;
            tabPageCreateBox.Text = "Box作成";
            tabPageCreateBox.UseVisualStyleBackColor = true;
            tabPageCreateBox.UseWaitCursor = true;
            // 
            // labelSelectedBoxName
            // 
            labelSelectedBoxName.AutoSize = true;
            labelSelectedBoxName.Font = new Font("Yu Gothic UI Light", 11F);
            labelSelectedBoxName.Location = new Point(109, 44);
            labelSelectedBoxName.Name = "labelSelectedBoxName";
            labelSelectedBoxName.Size = new Size(44, 20);
            labelSelectedBoxName.TabIndex = 5;
            labelSelectedBoxName.Text = "None";
            labelSelectedBoxName.UseWaitCursor = true;
            // 
            // labelBaseBoxName
            // 
            labelBaseBoxName.AutoSize = true;
            labelBaseBoxName.Font = new Font("Yu Gothic UI Light", 11F);
            labelBaseBoxName.Location = new Point(6, 44);
            labelBaseBoxName.Name = "labelBaseBoxName";
            labelBaseBoxName.Size = new Size(106, 20);
            labelBaseBoxName.TabIndex = 4;
            labelBaseBoxName.Text = "ベースのBox名：";
            labelBaseBoxName.UseWaitCursor = true;
            // 
            // labelCreateBoxName
            // 
            labelCreateBoxName.AutoSize = true;
            labelCreateBoxName.Font = new Font("Yu Gothic UI Light", 11F);
            labelCreateBoxName.Location = new Point(3, 15);
            labelCreateBoxName.Name = "labelCreateBoxName";
            labelCreateBoxName.Size = new Size(114, 20);
            labelCreateBoxName.TabIndex = 3;
            labelCreateBoxName.Text = "作成するBox名：";
            labelCreateBoxName.UseWaitCursor = true;
            // 
            // listViewBoxInfo
            // 
            listViewBoxInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewBoxInfo.Location = new Point(17, 95);
            listViewBoxInfo.Name = "listViewBoxInfo";
            listViewBoxInfo.Size = new Size(564, 254);
            listViewBoxInfo.TabIndex = 2;
            listViewBoxInfo.UseCompatibleStateImageBehavior = false;
            listViewBoxInfo.UseWaitCursor = true;
            listViewBoxInfo.SelectedIndexChanged += listViewBoxInfo_SelectedIndexChanged;
            // 
            // textBoxCreateBoxName
            // 
            textBoxCreateBoxName.Location = new Point(123, 15);
            textBoxCreateBoxName.Name = "textBoxCreateBoxName";
            textBoxCreateBoxName.Size = new Size(425, 23);
            textBoxCreateBoxName.TabIndex = 1;
            textBoxCreateBoxName.UseWaitCursor = true;
            // 
            // buttonCreateBox
            // 
            buttonCreateBox.Location = new Point(240, 66);
            buttonCreateBox.Name = "buttonCreateBox";
            buttonCreateBox.Size = new Size(75, 23);
            buttonCreateBox.TabIndex = 0;
            buttonCreateBox.Text = "Boxの作成";
            buttonCreateBox.UseVisualStyleBackColor = true;
            buttonCreateBox.UseWaitCursor = true;
            buttonCreateBox.Click += buttonCreateBox_Click;
            // 
            // tabPageBoxManager
            // 
            tabPageBoxManager.Controls.Add(listViewHaveBoxInfos);
            tabPageBoxManager.Location = new Point(4, 24);
            tabPageBoxManager.Name = "tabPageBoxManager";
            tabPageBoxManager.Size = new Size(601, 355);
            tabPageBoxManager.TabIndex = 3;
            tabPageBoxManager.Text = "Box管理";
            tabPageBoxManager.UseVisualStyleBackColor = true;
            tabPageBoxManager.UseWaitCursor = true;
            // 
            // listViewHaveBoxInfos
            // 
            listViewHaveBoxInfos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewHaveBoxInfos.ContextMenuStrip = contextMenuStrip1;
            listViewHaveBoxInfos.Location = new Point(15, 85);
            listViewHaveBoxInfos.Name = "listViewHaveBoxInfos";
            listViewHaveBoxInfos.Size = new Size(564, 254);
            listViewHaveBoxInfos.TabIndex = 3;
            listViewHaveBoxInfos.UseCompatibleStateImageBehavior = false;
            listViewHaveBoxInfos.UseWaitCursor = true;
            listViewHaveBoxInfos.MouseClick += listViewHaveBoxInfos_MouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { テストToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(101, 26);
            // 
            // テストToolStripMenuItem
            // 
            テストToolStripMenuItem.Name = "テストToolStripMenuItem";
            テストToolStripMenuItem.Size = new Size(100, 22);
            テストToolStripMenuItem.Text = "テスト";
            テストToolStripMenuItem.Click += テストToolStripMenuItem_Click;
            // 
            // tabPageVMInfo
            // 
            tabPageVMInfo.Controls.Add(listViewVmInfo);
            tabPageVMInfo.Location = new Point(4, 24);
            tabPageVMInfo.Name = "tabPageVMInfo";
            tabPageVMInfo.Padding = new Padding(3);
            tabPageVMInfo.Size = new Size(601, 355);
            tabPageVMInfo.TabIndex = 4;
            tabPageVMInfo.Text = "VM情報";
            tabPageVMInfo.UseVisualStyleBackColor = true;
            tabPageVMInfo.UseWaitCursor = true;
            // 
            // listViewVmInfo
            // 
            listViewVmInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewVmInfo.Location = new Point(6, 6);
            listViewVmInfo.Name = "listViewVmInfo";
            listViewVmInfo.Size = new Size(589, 343);
            listViewVmInfo.TabIndex = 0;
            listViewVmInfo.UseCompatibleStateImageBehavior = false;
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
            tabPageCreateBox.ResumeLayout(false);
            tabPageCreateBox.PerformLayout();
            tabPageBoxManager.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            tabPageVMInfo.ResumeLayout(false);
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
        private TabPage tabPageCreateBox;
        private TextBox textBoxCreateBoxName;
        private Button buttonCreateBox;
        private ListView listViewBoxInfo;
        private TabPage tabPageBoxManager;
        private Label labelCreateBoxName;
        private Label labelSelectedBoxName;
        private Label labelBaseBoxName;
        private ListView listViewHaveBoxInfos;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem テストToolStripMenuItem;
        private TabPage tabPageVMInfo;
        private ListView listViewVmInfo;
    }
}
