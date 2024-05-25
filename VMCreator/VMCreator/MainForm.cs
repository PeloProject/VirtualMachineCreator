using VMCreator.Utility;
using VMCreator.Vagrant;

namespace VMCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            var response = CommandExecutor.Execute("Vagrant -v");
            if( string.IsNullOrEmpty(response) )
            {
                return;
            }

            

            InitializeComponent();

            // VmAppComboBox Initialize
            VmAppComboBox.Items.Add("Hyper-V");
            VmAppComboBox.SelectedIndex = 0;
            IniFileReader.ReadIniFile(VmAppComboBox.Text);

            // 
            var boxInfos = Vagrant.Vagrant.InitializeBoxInfo();
            foreach( var boxInfo in boxInfos )
            {
                if(!IniFileReader.AppInfo.Provider.Equals(boxInfo.Provider))
                {
                    continue;
                }
                BoxListComboBox.Items.Add(boxInfo.Name);
            }

            //https://app.vagrantup.com/almalinux/boxes/9/versions/9.3.20231118/providers/hyperv/amd64/vagrant.box
            //https://app.vagrantup.com/almalinux/boxes/8/versions/8.9.20231219/providers/virtualbox/amd64/vagrant.box
            //Refresh();
        }


        /// <summary>
        /// VM�̍쐬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            var response = CommandExecutor.Execute("Vagrant -v");
            OutputTextBox.Text += response;
        }
    }
}
