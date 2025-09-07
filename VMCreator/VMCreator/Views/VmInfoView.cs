using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCreator.Vagrant;
using VMCreator.Utility;

namespace VMCreator.Views
{
    internal class VmInfoView
    {
        /// <summary>
        /// VM情報リストビュー
        /// </summary>
        ListView ListViewVmInfo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="listViewVmInfo"></param>
        public VmInfoView(ListView listViewVmInfo)
        {
            ListViewVmInfo = listViewVmInfo;
            Initialize();
        }

        void Initialize()
        {
            Console.WriteLine("\n===== Initalize VMInfo Start =====");

            ListViewVmInfo.FullRowSelect = true;
            ListViewVmInfo.GridLines = true;
            ListViewVmInfo.Sorting = SortOrder.Ascending;
            ListViewVmInfo.View = View.Details;

            // カラムヘッダーの設定（id       name    provider state  directory）
            ListViewVmInfo.Columns.Clear();
            var columnHeaderId = new ColumnHeader();
            columnHeaderId.Text = "ID";
            columnHeaderId.Width = 60;

            var columnHeaderName = new ColumnHeader();
            columnHeaderName.Text = "名前";
            columnHeaderName.Width = 60;

            var columnHeaderProvider = new ColumnHeader();
            columnHeaderProvider.Text = "プロバイダー";
            columnHeaderProvider.Width = 60;

            var columnHeaderState = new ColumnHeader();
            columnHeaderState.Text = "状態";
            columnHeaderState.Width = 50;

            var columnHeaderDirectory = new ColumnHeader();
            columnHeaderDirectory.Text = "ディレクトリ";
            columnHeaderDirectory.Width = 300;

            ColumnHeader[] colHeaderRegValue = { columnHeaderId, columnHeaderName, columnHeaderProvider, columnHeaderState, columnHeaderDirectory };
            ListViewVmInfo.Columns.AddRange(colHeaderRegValue);

            ReloadVmInfo();

            InitializeContextMenu();
            Console.WriteLine("\n===== Initalize VMInfo Finish =====");
        }

        // 右クリックメニュー初期化
        void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ListViewVmInfo.ContextMenuStrip = contextMenu;

            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "起動", menuItemStartVm_Click);
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "再起動", menuItemReloadVm_Click);
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "停止", menuItemHaltVm_Click);
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "一時停止", menuItemSuspendVm_Click);
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "再開", menuItemResumeVm_Click);
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "削除", menuItemDeleteVm_Click);

            // スナップショットメニュー
            var menuItemSnapshotVm = new ToolStripMenuItem("スナップショット");

            // エクスプローラ表示メニュー
            Utility.Utility.AddContextMenuItem(ListViewVmInfo.ContextMenuStrip, "エクスプローラで表示", menuItemExplorerShow_Click);
        }


        /// <summary>
        /// ListViewのアイテム設定
        /// </summary>
        void ReloadVmInfo()
        {
            Console.WriteLine("\nReload Vagrant Virtural Mathine Info");
            var vmInfos = Vagrant.Vagrant.GetVMInfo();
            ListViewVmInfo.Items.Clear();
            foreach (var vmInfo in vmInfos)
            {
                var listViewItem = new ListViewItem(vmInfo[0]); // ID
                listViewItem.SubItems.Add(vmInfo[1]); // Name
                listViewItem.SubItems.Add(vmInfo[2]); // Provider
                listViewItem.SubItems.Add(vmInfo[3]); // State
                listViewItem.SubItems.Add(vmInfo[4]); // Directory
                ListViewVmInfo.Items.Add(listViewItem);
            }
        }

        private void menuItemStartVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;
            Vagrant.Vagrant.StartVM(vmId);
            ReloadVmInfo();
        }

        private void menuItemReloadVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;
            Vagrant.Vagrant.ReloadVM(vmId);
            ReloadVmInfo();
        }

        private void menuItemSuspendVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;
            Vagrant.Vagrant.SuspendVM(vmId);
            ReloadVmInfo();
        }

        private void menuItemResumeVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;
            Vagrant.Vagrant.ResumeVM(vmId);
            ReloadVmInfo();
        }

        /// <summary>
        /// 停止イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemHaltVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;
            Vagrant.Vagrant.HaltVM(vmId);
            ReloadVmInfo();
        }

        /// <summary>
        /// 削除イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemDeleteVm_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmId = item.Text;

            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show($"VM({item.SubItems[1].Text})を削除しますか？",
                "削除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Vagrant.Vagrant.DestoryVM(vmId);
            }
        }

        /// <summary>
        /// エクスプローラ表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemExplorerShow_Click(object? sender, EventArgs e)
        {
            ListViewItem item = ListViewVmInfo.SelectedItems[0];
            string vmDirectory = item.SubItems[4].Text;
            vmDirectory = vmDirectory.Replace("/", "\\");
            System.Diagnostics.Process.Start("explorer.exe", vmDirectory);
        }
    }
}
