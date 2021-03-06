using System.Configuration;
using System.IO;
using System.Windows.Input;
using TAS.Client.Common;

namespace TAS.Client.Config
{
    public class MainWindowViewmodel: ViewModelBase
    {
        private Model.ConfigFile _configFile;

        public MainWindowViewmodel()
        {
            if (File.Exists("TVPlay.exe"))
                ConfigFile = new Model.ConfigFile(ConfigurationManager.OpenExeConfiguration("TVPlay.exe"));
            CommandIngestFoldersSetup = new UiCommand(_ingestFoldersSetup, _canShowDialog);
            CommandConfigFileEdit = new UiCommand(_configFileEdit, _canShowDialog);
            CommandConfigFileSelect = new UiCommand(_configFileSelect, _canShowDialog);
            CommandPlayoutServersSetup = new UiCommand(_serversSetup, _canShowDialog);
            CommandEnginesSetup = new UiCommand(_enginesSetup, _canShowDialog);
        }

        public ICommand CommandIngestFoldersSetup { get; }
        public ICommand CommandConfigFileEdit { get; }
        public ICommand CommandConfigFileSelect { get; }
        public ICommand CommandPlayoutServersSetup { get; }
        public ICommand CommandEnginesSetup { get; }

        public Model.ConfigFile ConfigFile
        {
            get => _configFile;
            set => SetField(ref _configFile, value);
        }

        protected override void OnDispose() { }

        private bool _canShowDialog(object o)
        {
            return _configFile != null;
        }
        
        private void _enginesSetup(object obj)
        {
            using (var vm = new EnginesViewmodel(ConfigFile.AppSettings.DatabaseType, ConfigFile.Configuration.ConnectionStrings.ConnectionStrings))
            {
                vm.ShowDialog();
            }
        }
        
        private void _serversSetup(object obj)
        {
            using (var vm = new PlayoutServersViewmodel(ConfigFile.AppSettings.DatabaseType, ConfigFile.Configuration.ConnectionStrings.ConnectionStrings))
            {
                vm.ShowDialog();
            }
        }
                
        private void _configFileSelect(object obj)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog() { Filter = "Executables (*.exe)|*.exe" };
            if (dlg.ShowDialog() == true)
                ConfigFile = new Model.ConfigFile(ConfigurationManager.OpenExeConfiguration(dlg.FileName));
        }

        private void _configFileEdit(object obj)
        {
            ConfigFileViewmodel vm = new ConfigFileViewmodel(_configFile);
            vm.ShowDialog();
        }

        private void _ingestFoldersSetup(object obj)
        {
            IngestDirectoriesViewmodel vm = new IngestDirectoriesViewmodel(_configFile.AppSettings.IngestFolders);
            vm.ShowDialog();
        }

    }
}
