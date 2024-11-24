using Microsoft.VisualBasic.ApplicationServices;
using VMCreator.Forms;
using VMCreator.Utility;
using VMCreator.Vagrant;

namespace VMCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            if (!IsInstallVagrant())
            {
                return;
            }

            InitializeComponent();
            InitializeProviderList();
            LoadAppSettings(VmAppComboBox.Text);
            InitializeBoxList();
            InitializeVagrantRootPath();
            InitializeDiscoverBoxInfoList();
            Console.WriteLine("\nSeccessed Initialize!!\n");
            Console.WriteLine("=============================");
            Console.WriteLine("===== Welcome VMCreator =====");
            Console.WriteLine("=============================");

            //Refresh();
        }

        #region Initialize

        private bool IsInstallVagrant()
        {
            Console.WriteLine("===== Is Vagrant Installed =====");
            var response = CommandExecutor.Execute("Vagrant -v");
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Is not Install Vagrant. Close Application");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 全てのプロパティを再度更新
        /// </summary>
        private void ReloadAllProperty()
        {
            LoadAppSettings(VmAppComboBox.Text);
            InitializeBoxList();
            InitializeVagrantRootPath();
            InitializeDiscoverBoxInfoList();
        }

        private void InitializeDiscoverBoxInfoList()
        {
            // ListViewコントロールのプロパティを設定
            listViewBoxInfo.FullRowSelect = true;
            listViewBoxInfo.GridLines = true;
            listViewBoxInfo.Sorting = SortOrder.Ascending;
            listViewBoxInfo.View = View.Details;

            var columnHeaderName = new ColumnHeader();
            var columnHeaderURL = new ColumnHeader();
            columnHeaderName.Text = "Name";
            columnHeaderURL.Text = "URL";
            columnHeaderURL.Width = 300;
            ColumnHeader[] colHeaderRegValue = { columnHeaderName, columnHeaderURL };
            listViewBoxInfo.Columns.AddRange(colHeaderRegValue);

            listViewBoxInfo.Items.Clear();
            // ListViewコントロールにデータを追加します。
            string[] item1 = { "almalinux/9", "--box-version 9.4.20240805" };
            listViewBoxInfo.Items.Add(new ListViewItem(item1));
            string[] item2 = { "almalinux/8", "--box-version 8.10.20240821" };
            listViewBoxInfo.Items.Add(new ListViewItem(item2));
        }

        /// <summary>
        /// アプリケーション設定の読み込み
        /// </summary>
        private void LoadAppSettings(string provider)
        {
            AppSettings.ReadIniFile(provider);
        }

        /// <summary>
        /// Vagrantのプロバイダーリストを初期化
        /// </summary>
        private void InitializeProviderList()
        {
            // VmAppComboBox Initialize
            VmAppComboBox.Items.Add("Hyper-V");
            VmAppComboBox.Items.Add("VirtualBox");
            VmAppComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// ボックスリストの初期化
        /// </summary>
        private void InitializeBoxList()
        {
            Console.WriteLine("\n===== Initalize Box list =====");
            var boxInfos = Vagrant.Vagrant.GetBoxInfo();

            // ListViewコントロールのプロパティを設定
            listViewHaveBoxInfos.FullRowSelect = true;
            listViewHaveBoxInfos.GridLines = true;
            listViewHaveBoxInfos.Sorting = SortOrder.Ascending;
            listViewHaveBoxInfos.View = View.Details;

            var columnHeaderName = new ColumnHeader();
            var columnHeaderURL = new ColumnHeader();
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 300;
            columnHeaderURL.Text = "Version";
            columnHeaderURL.Width = 300;
            ColumnHeader[] colHeaderRegValue = { columnHeaderName, columnHeaderURL };
            listViewHaveBoxInfos.Columns.AddRange(colHeaderRegValue);
            listViewHaveBoxInfos.Items.Clear();

            BoxListComboBox.Items.Clear();
            foreach (var boxInfo in boxInfos)
            {
                if (!AppSettings.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }
                // コンボボックスの設定
                BoxListComboBox.Items.Add(boxInfo.Name);

                // 所持リスト設定
                string[] item1 = { boxInfo.Name, boxInfo.Version };
                listViewHaveBoxInfos.Items.Add(new ListViewItem(item1));

            }
            if (0 < boxInfos.Count)
            {
                BoxListComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Vagrantのルートパスの取得
        /// </summary>
        private void InitializeVagrantRootPath()
        {
            Console.WriteLine("\n===== Initalize Vagrant Box Root Path =====");
            Console.WriteLine("Check Environment VAGRANT_HOME");
            var command = $"echo %VAGRANT_HOME%";
            var response = CommandExecutor.Execute(command);
            if (response.Equals("%VAGRANT_HOME%"))
            {
                TextBox_BoxRootPath.Text = response;
            }
            else
            {
                Console.WriteLine("Not Exists Environment VAGRANT_HOME");
                Console.WriteLine("Check Environment UserName");
                command = $"echo %username%";
                response = CommandExecutor.Execute(command);
                response = response.Replace("\r\n", "");
                TextBox_BoxRootPath.Text = $"C:\\Users\\{response}\\.vagrant.d";
            }
            label_CurrentBoxRootPath.Text = TextBox_BoxRootPath.Text;
            Console.WriteLine($"Vagrant RootPath : {label_CurrentBoxRootPath.Text}");
        }
        #endregion

        /// <summary>
        /// VMの作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Create Vagrant Start =====");
            var provider = AppSettings.AppInfo.Provider;
            var command = $"Vagrant up --provider={provider}\n";
            // VM作成はVagrantfileがあるフォルダで実行する必要がある為pathを生成
            var boxFolder = $"{label_CurrentBoxRootPath.Text}\\boxes\\{BoxListComboBox.SelectedItem}\\0\\{provider}";

            Console.WriteLine($"ExecuteCommand : {command}");

            CommandExecutor.Execute(command, boxFolder);

            Console.WriteLine("===== Create Vagrant Finished =====");
        }

        /// <summary>
        /// VMの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestroyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Destory Vagrant Start =====");
            var modalDialogForm = new ModalDialogForm();
            modalDialogForm.SetMessage("Virtual Machine の作成");
            modalDialogForm.ShowDialog();
            modalDialogForm.Dispose();

            var provider = AppSettings.AppInfo.Provider;

            // VM作成はVagrantfileがあるフォルダで実行する必要がある為pathを生成
            var boxFolder = $"{label_CurrentBoxRootPath.Text}\\boxes\\{BoxListComboBox.SelectedItem}\\0\\{provider}";

            var command = $"Vagrant destroy -f";
            CommandExecutor.Execute(command, boxFolder);

            Console.WriteLine("===== Destory Vagrant Finished =====");
        }

        /// <summary>
        /// Vagrantfileの作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Initialize Vagrant Start =====");

            var command = $"Vagrant init {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command);

            Console.WriteLine("===== Initialize Vagrant Finished =====");
        }

        /// <summary>
        /// Boxのルートパスを環境変数に反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ApplyBoxRootPath_Click(object sender, EventArgs e)
        {
            var command = $"SET VAGRANT_HOME={TextBox_BoxRootPath.Text}";
            var response = CommandExecutor.Execute(command);
            label_CurrentBoxRootPath.Text = TextBox_BoxRootPath.Text;
        }

        private void listViewBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            var item = listView.SelectedItems;
            if (0 < item.Count)
            {
                var boxInfo = item[0].SubItems[1];
                labelSelectedBoxName.Text = boxInfo.Text;
            }
        }

        private void buttonCreateBox_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Vagrant Box Add Start =====");

            var command = $"Vagrant box add {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command);

            Console.WriteLine("===== Vagrant Box Add Finished =====");
        }

        private void VmAppComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadAllProperty();
        }
    }
}
