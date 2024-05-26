using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMCreator.Forms
{
    public partial class ModalDialogForm : Form
    {
        public ModalDialogForm()
        {
            InitializeComponent();
            
        }
        
        /// <summary>
        /// メッセージの設定
        /// </summary>
        /// <param name="msg"></param>
        public void SetMessage(string msg)
        {
            var msgArray = msg.Split("\n");

            List<string> line = VerticalCenteringMsgList(MessageTextBox, msgArray.Count());

            for (int i = 0; i < msgArray.Count(); i++)
            {
                line.Add(msgArray[i]);
            }

            MessageTextBox.Lines = line.ToArray();
            var lineNum = MessageTextBox.Lines.Count();
        }

        /// <summary>
        /// 垂直方向のセンタリング用の改行文字配列を返します。
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="msgLineCount"></param>
        /// <returns></returns>
        private List<string> VerticalCenteringMsgList(System.Windows.Forms.TextBox textbox, int msgLineCount)
        {
            const int lineSpace = 4;
            var fontSize = textbox.Font.Size;
            var textBoxSize = textbox.Size;
            var showLines = (int)(textBoxSize.Height / (fontSize + lineSpace));

            List<string> lines = new List<string>();
            if (msgLineCount < showLines)
            {
                int addLine = (showLines / 2 - msgLineCount) - 1;
                for (int i = 0; i < addLine; i++)
                {
                    lines.Add("\n");
                }
            }

            return lines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // モーダルダイアログを閉じます
            Close();
        }
    }
}
