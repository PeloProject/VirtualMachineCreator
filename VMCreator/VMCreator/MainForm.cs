using Microsoft.VisualBasic.ApplicationServices;
using VMCreator.Forms;
using VMCreator.Utility;
using VMCreator.Vagrant;

namespace VMCreator
{
    public partial class MainForm : Form
    {
        bool IsInitializeFinished = false;
        public MainForm()
        {
            if (!IsInstallVagrant())
            {
                return;
            }

            InitializeComponent();
            InitializeProviderList();
            LoadAppSettings(VmAppComboBox.Text);
            InitializeVagrantRootPath();
            InitializeBoxList();
            InitializeDiscoverBoxInfoList();
            Console.WriteLine("\nSeccessed Initialize!!\n");
            Console.WriteLine("=============================");
            Console.WriteLine("===== Welcome VMCreator =====");
            Console.WriteLine("=============================");

            IsInitializeFinished = true;

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
        /// �S�Ẵv���p�e�B���ēx�X�V
        /// </summary>
        private void ReloadAllProperty()
        {
            if (!IsInitializeFinished) { return; }
            LoadAppSettings(VmAppComboBox.Text);
            InitializeVagrantRootPath();
            InitializeBoxList();
            InitializeDiscoverBoxInfoList();
        }

        private void InitializeDiscoverBoxInfoList()
        {
            // ListView�R���g���[���̃v���p�e�B��ݒ�
            listViewBoxInfo.FullRowSelect = true;
            listViewBoxInfo.GridLines = true;
            listViewBoxInfo.Sorting = SortOrder.Ascending;
            listViewBoxInfo.View = View.Details;

            listViewBoxInfo.Columns.Clear();
            var columnHeaderName = new ColumnHeader();
            var columnHeaderURL = new ColumnHeader();
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 300;
            columnHeaderURL.Text = "Version";
            columnHeaderURL.Width = 300;
            ColumnHeader[] colHeaderRegValue = { columnHeaderName, columnHeaderURL };
            listViewBoxInfo.Columns.AddRange(colHeaderRegValue);

            listViewBoxInfo.Items.Clear();
            // ListView�R���g���[���Ƀf�[�^��ǉ����܂��B
            string[] item1 = { "almalinux/9", "9.5.20241203" };
            listViewBoxInfo.Items.Add(new ListViewItem(item1));
            //string[] item2 = { "almalinux/8", "8.10.20240821" };
            //listViewBoxInfo.Items.Add(new ListViewItem(item2));
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
            VmAppComboBox.Items.Add("VirtualBox");
            VmAppComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// �{�b�N�X���X�g�̏�����
        /// </summary>
        private void InitializeBoxList()
        {
            Console.WriteLine("\n===== Initalize Box list =====");
            var boxInfos = Vagrant.VagrantBox.GetBoxInfo();

            // ListView�R���g���[���̃v���p�e�B��ݒ�
            listViewHaveBoxInfos.FullRowSelect = true;
            listViewHaveBoxInfos.GridLines = true;
            listViewHaveBoxInfos.Sorting = SortOrder.Ascending;
            listViewHaveBoxInfos.View = View.Details;

            var columnHeaderName = new ColumnHeader();
            var columnHeaderURL = new ColumnHeader();
            var columnHeaderVagrantfilePath = new ColumnHeader();
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 300;
            columnHeaderURL.Text = "Version";
            columnHeaderURL.Width = 300;
            columnHeaderVagrantfilePath.Text = "VagrantfilePath";
            columnHeaderVagrantfilePath.Width = 300;
            ColumnHeader[] colHeaderRegValue = { columnHeaderName, columnHeaderURL, columnHeaderVagrantfilePath };
            listViewHaveBoxInfos.Columns.AddRange(colHeaderRegValue);
            listViewHaveBoxInfos.Items.Clear();

            BoxListComboBox.Items.Clear();
            foreach (var boxInfo in boxInfos)
            {
                if (!AppSettings.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }
                // �R���{�{�b�N�X�̐ݒ�
                BoxListComboBox.Items.Add(boxInfo.Name);

                // �������X�g�ݒ�
                string[] item1 = { boxInfo.Name, boxInfo.Version, boxInfo.VagrantfilePath };
                listViewHaveBoxInfos.Items.Add(new ListViewItem(item1));

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

            TextBox_BoxRootPath.Text = VagrantBox.InitializeBoxWorkingDirectory();
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
            Console.WriteLine("===== Create Vagrant Start =====");
            var provider = AppSettings.AppInfo.Provider;
            var command = $"Vagrant up --provider={provider}\n";

            Console.WriteLine($"ExecuteCommand : {command}");

            // VM�쐬��Vagrantfile������t�H���_�Ŏ��s����K�v�������path�𐶐�
            CommandExecutor.Execute(command, GetBoxWorkingDirectory(provider));

            Console.WriteLine("===== Create Vagrant Finished =====");
        }

        /// <summary>
        /// VM�̍폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestroyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Destory Vagrant Start =====");

            var provider = AppSettings.AppInfo.Provider;
            var command = $"Vagrant destroy -f";

            ShowModalDialog("Virtual Machine ���폜���܂��B");

            // VM�쐬��Vagrantfile������t�H���_�Ŏ��s����K�v�������path�𐶐�
            //CommandExecutor.Execute(command, GetBoxWorkingDirectory(provider));

            Console.WriteLine("===== Destory Vagrant Finished =====");
        }

        /// <summary>
        /// Vagrantfile�̍쐬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===== Initialize Vagrant Start =====");

            var command = $"Vagrant init {BoxListComboBox.Text}";
            var response = CommandExecutor.Execute(command, GetBoxRootPath());

            Console.WriteLine("===== Initialize Vagrant Finished =====");
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

        /// <summary>
        /// �{�b�N�X���X�g�I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            var item = listView.SelectedItems;
            if (0 < item.Count)
            {
                var boxInfo = item[0].SubItems[0];
                labelSelectedBoxName.Text = boxInfo.Text;
            }
        }

        /// <summary>
        /// �{�b�N�X�̍쐬�{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateBox_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBoxCreateBoxName.Text))
            //{
            //    ShowModalDialog("�쐬����Box�������͂���Ă��܂���B");
            //    return;
            //}

            Console.WriteLine("===== Vagrant Box Add Start =====");
            var baseBoxName = listViewBoxInfo.SelectedItems[0].SubItems[0].Text;
            var baseBoxVersion = $"--box-version {listViewBoxInfo.SelectedItems[0].SubItems[1].Text}";
            var provider = $"--provider {AppSettings.AppInfo.Provider}";

            var command = $"Vagrant box add {baseBoxName} {baseBoxVersion} {provider}";

            Console.WriteLine($"ExecuteCommand : {command}");
            var response = CommandExecutor.Execute(command, GetBoxWorkingDirectory());

            Console.WriteLine("===== Vagrant Box Add Finished =====");

            ShowModalDialog($"Box:({baseBoxName} {baseBoxVersion})���쐬����܂����B");
        }

        private void VmAppComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadAllProperty();
        }

        private string GetBoxRootPath()
        {
            return label_CurrentBoxRootPath.Text;
        }
        private string GetBoxWorkingDirectory()
        {
            var provider = AppSettings.AppInfo.Provider;
            return GetBoxWorkingDirectory(provider);
        }
        private string GetBoxWorkingDirectory(string provider)
        {
            return $"{label_CurrentBoxRootPath.Text}\\boxes\\{BoxListComboBox.SelectedItem}\\0\\{provider}";
        }

        private void ShowModalDialog(string message)
        {
            var modalDialogForm = new ModalDialogForm();
            modalDialogForm.SetMessage(message);
            modalDialogForm.ShowDialog();
            modalDialogForm.Dispose();
        }

        private void listViewHaveBoxInfos_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void �e�X�gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            string message = item.Text + " ��������܂���";
            MessageBox.Show(this, message, "���j���[", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
