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
            Console.WriteLine("\nSeccessed Initialize!!\n");
            Console.WriteLine("=============================");
            Console.WriteLine("===== Welcome VMCreator =====");
            Console.WriteLine("=============================");

            //https://app.vagrantup.com/almalinux/boxes/9/versions/9.3.20231118/providers/hyperv/amd64/vagrant.box
            //https://app.vagrantup.com/almalinux/boxes/8/versions/8.9.20231219/providers/virtualbox/amd64/vagrant.box
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
        /// �A�v���P�[�V�����ݒ�̓ǂݍ���
        /// </summary>
        private void LoadAppSettings(string provider)
        {
            AppSettings.ReadIniFile(provider);
        }

        /// <summary>
        /// Vagrant�̃v���o�C�_�[���X�g��������
        /// </summary>
        private void InitializeProviderList()
        {
            // VmAppComboBox Initialize
            VmAppComboBox.Items.Add("Hyper-V");
            VmAppComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// �{�b�N�X���X�g�̏�����
        /// </summary>
        private void InitializeBoxList()
        {
            Console.WriteLine("\n===== Initalize Box list =====");
            var boxInfos = Vagrant.Vagrant.InitializeBoxInfo();
            foreach (var boxInfo in boxInfos)
            {
                if (!AppSettings.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }
                BoxListComboBox.Items.Add(boxInfo.Name);
            }
            if (0 < boxInfos.Count)
            {
                BoxListComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Vagrant�̃��[�g�p�X�̎擾
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
        /// VM�̍쐬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            var provider = AppSettings.AppInfo.Provider;
            var command = $"Vagrant up --provider={provider}\n";
            // VM�쐬��Vagrantfile������t�H���_�Ŏ��s����K�v�������path�𐶐�
            var boxFolder = $"{label_CurrentBoxRootPath.Text}\\boxes\\{BoxListComboBox.SelectedItem}\\0\\{provider}";

            Console.WriteLine($"ExecuteCommand : {command}");

            CommandExecutor.Execute(command, boxFolder);
        }

        /// <summary>
        /// VM�̍폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestroyButton_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ModalDialogForm();
            modalDialogForm.SetMessage("Virtual Machine �̍쐬");
            modalDialogForm.ShowDialog();
            modalDialogForm.Dispose();

            var command = $"Vagrant destroy {BoxListComboBox.Text}";
            CommandExecutor.Execute(command);
        }

        /// <summary>
        /// Vagrantfile�̍쐬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeButton_Click(object sender, EventArgs e)
        {
            //var modalDialogForm = new ModalDialogForm();
            //modalDialogForm.SetMessage("Virtual Machine �̍쐬");
            //modalDialogForm.ShowDialog();
            //modalDialogForm.Dispose();

            var command = $"Vagrant init {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command);
        }

        /// <summary>
        /// Box�̃��[�g�p�X�����ϐ��ɔ��f
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ApplyBoxRootPath_Click(object sender, EventArgs e)
        {
            var command = $"SET VAGRANT_HOME={TextBox_BoxRootPath.Text}";
            var response = CommandExecutor.Execute(command);
            label_CurrentBoxRootPath.Text = TextBox_BoxRootPath.Text;
        }
    }
}
