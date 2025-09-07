using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCreator.Utility;

namespace VMCreator.Views
{
    internal class BoxInfoView
    {

        /// <summary>
        /// VM情報リストビュー
        /// </summary>
        ListView ListViewBoxInfo;

        ComboBox ComboBoxBoxName;

        public BoxInfoView(ListView listViewBoxInfo, ComboBox comboBoxBoxName)
        {
            ListViewBoxInfo = listViewBoxInfo;
            ComboBoxBoxName = comboBoxBoxName;
            Initalize();
        }

        private void Initalize()
        {
            Console.WriteLine("===== Initalize BoxInfoView Start =====");
            // ListViewのプロパティ設定
            ListViewBoxInfo.View = View.Details;
            ListViewBoxInfo.FullRowSelect = true;
            ListViewBoxInfo.GridLines = true;
            ListViewBoxInfo.MultiSelect = false;
            ListViewBoxInfo.Sorting = SortOrder.Ascending;

            // カラムヘッダー設定
            var columnHeaderName = new ColumnHeader();
            columnHeaderName.Text = "名前";
            columnHeaderName.Width = 200;
            var columnHeaderVersion = new ColumnHeader();
            columnHeaderVersion.Text = "バージョン";
            columnHeaderVersion.Width = 100;
            var columnHeaderDirectory = new ColumnHeader();
            columnHeaderDirectory.Text = "ディレクトリ";
            columnHeaderDirectory.Width = 300;
            ColumnHeader[] colHeaderRegValue = { columnHeaderName, columnHeaderVersion, columnHeaderDirectory };
            ListViewBoxInfo.Columns.AddRange(colHeaderRegValue);
            ReloadBoxInfo();
            InitlizeContextMenu();
            Console.WriteLine("===== Initalize BoxInfoView Finish =====");
        }

        private void InitlizeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            Utility.Utility.AddContextMenuItem(contextMenu, "エクスプローラ表示", menuItemExplorerShow_Click);
            ListViewBoxInfo.ContextMenuStrip = contextMenu;
        }

        public void ReloadBoxInfo()
        {
            Console.WriteLine("===== Reload BoxInfo Start =====");
            ListViewBoxInfo.Items.Clear();
            ComboBoxBoxName.Items.Clear();
            var boxInfoList = Vagrant.Vagrant.GetBoxInfo();
            foreach (var boxInfo in boxInfoList)
            {
                if (!AppSettings.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }

                // コンボボックスの設定
                ComboBoxBoxName.Items.Add(boxInfo.Name);

                var listItem = new ListViewItem(boxInfo.Name); // 名前
                listItem.SubItems.Add(boxInfo.Version); // バージョン
                listItem.SubItems.Add(boxInfo.VagrantfilePath); // ディレクトリ
                ListViewBoxInfo.Items.Add(listItem);
            }
            Console.WriteLine("===== Reload BoxInfo Finish =====");
        }

        /// <summary>
        /// エクスプローラ表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemExplorerShow_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewBoxInfo.SelectedItems[0];
            string vmDirectory = item.SubItems[2].Text;
            vmDirectory = vmDirectory.Replace("/", "\\");
            System.Diagnostics.Process.Start("explorer.exe", vmDirectory);
        }
    }
}
