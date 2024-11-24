namespace VMCreator.Forms
{
    partial class ModalDialogForm
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
            panel1 = new Panel();
            button1 = new Button();
            MessageTextBox = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Location = new Point(12, 265);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 44);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(220, 10);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.BackColor = SystemColors.Control;
            MessageTextBox.BorderStyle = BorderStyle.None;
            MessageTextBox.Font = new Font("Yu Gothic UI", 11F);
            MessageTextBox.Location = new Point(12, 12);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.ReadOnly = true;
            MessageTextBox.Size = new Size(516, 239);
            MessageTextBox.TabIndex = 1;
            MessageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ModalDialogForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(540, 321);
            ControlBox = false;
            Controls.Add(MessageTextBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ModalDialogForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox MessageTextBox;
        private Button button1;
    }
}