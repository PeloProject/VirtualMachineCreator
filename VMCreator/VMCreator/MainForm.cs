using VMCreator.Forms;
using VMCreator.Utility;
using VMCreator.Vagrant;

namespace VMCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            var response = CommandExecutor.Execute("Vagrant -v");
            if (string.IsNullOrEmpty(response))
            {
                return;
            }

            InitializeComponent();

            // VmAppComboBox Initialize
            VmAppComboBox.Items.Add("Hyper-V");
            VmAppComboBox.SelectedIndex = 0;
            IniFileReader.ReadIniFile(VmAppComboBox.Text);

            // Box Initialize
            var boxInfos = Vagrant.Vagrant.InitializeBoxInfo();
            foreach (var boxInfo in boxInfos)
            {
                if (!IniFileReader.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }
                BoxListComboBox.Items.Add(boxInfo.Name);
            }
            if (0 < boxInfos.Count)
            {
                BoxListComboBox.SelectedIndex = 0;
            }

            //https://app.vagrantup.com/almalinux/boxes/9/versions/9.3.20231118/providers/hyperv/amd64/vagrant.box
            //https://app.vagrantup.com/almalinux/boxes/8/versions/8.9.20231219/providers/virtualbox/amd64/vagrant.box
            //Refresh();
        }


        /// <summary>
        /// VMの作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            var command = $"Vagrant up";
            // VM作成はVagrantfileがあるフォルダで実行する必要がある為pathを生成
            var boxFolder = $"C:\\Users\\shinji\\.vagrant.d\\boxes\\{BoxListComboBox.SelectedItem.ToString()}\\0\\{IniFileReader.AppInfo.Provider}"
            var response = CommandExecutor.Execute(command, false, boxFolder);
            OutputTextBox.Text += response;
        }

        /// <summary>
        /// VMの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestroyButton_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ModalDialogForm();
            modalDialogForm.SetMessage("Virtual Machine の作成");
            modalDialogForm.ShowDialog();
            modalDialogForm.Dispose();

            var command = $"Vagrant destroy {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command, true);
            OutputTextBox.Text += response;
        }

        /// <summary>
        /// Vagrantfileの作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeButton_Click(object sender, EventArgs e)
        {
            //var modalDialogForm = new ModalDialogForm();
            //modalDialogForm.SetMessage("Virtual Machine の作成");
            //modalDialogForm.ShowDialog();
            //modalDialogForm.Dispose();

            var command = $"Vagrant init {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command, true);
            OutputTextBox.Text += response;
        }
    }
}
