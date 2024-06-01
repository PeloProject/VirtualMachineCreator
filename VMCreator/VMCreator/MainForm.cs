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

            //BoxPath Initialize
            var command = $"echo %VAGRANT_HOME%";
            response = CommandExecutor.Execute(command, true);
            if(response.Equals("%VAGRANT_HOME%"))
            {
                TextBox_BoxRootPath.Text = response;
            }
            else
            {
                command = $"echo %username%";
                response = CommandExecutor.Execute(command, true);
                response = response.Replace("\r\n", "");
                TextBox_BoxRootPath.Text = $"C:\\Users\\{response}\\.vagrant.d";
            }
            label_CurrentBoxRootPath.Text = TextBox_BoxRootPath.Text;

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
            var provider = IniFileReader.AppInfo.Provider;
            var command = $"Vagrant up --provider={provider}\n";
            // VM作成はVagrantfileがあるフォルダで実行する必要がある為pathを生成
            var boxFolder = $"{label_CurrentBoxRootPath.Text}\\boxes\\{BoxListComboBox.SelectedItem}\\0\\{provider}";

            OutputTextBox.Text += $"ExecuteCommand : {command}";

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

        /// <summary>
        /// Boxのルートパスを環境変数に反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ApplyBoxRootPath_Click(object sender, EventArgs e)
        {
            var command = $"SET VAGRANT_HOME={TextBox_BoxRootPath.Text}";
            var response = CommandExecutor.Execute(command, true);
            OutputTextBox.Text += response;
            label_CurrentBoxRootPath.Text = TextBox_BoxRootPath.Text;
        }
    }
}
