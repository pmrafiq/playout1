using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TAS.Client.Common;
using TAS.Client.Config.Model;

namespace TAS.Client.Config
{
    public class ArchiveDirectoriesViewmodel: OkCancelViewmodelBase<ArchiveDirectories>
    {
       
        public ArchiveDirectoriesViewmodel(ArchiveDirectories directories) : base(directories, typeof(ArchiveDirectoriesView), "Archive directories")
        {
            Directories = new ObservableCollection<ArchiveDirectory>(Model.Directories);
            _createCommands();
        }

        public ICommand CommandAdd { get; private set; }
        public ICommand CommandDelete { get; private set; }

        private void _createCommands()
        {
            CommandAdd = new UiCommand(_add);
            CommandDelete = new UiCommand(_delete, _canDelete);
        }

        private void _delete(object obj)
        {
            SelectedDirectory.Delete();
            Directories.Remove(SelectedDirectory);
            SelectedDirectory = null;
        }

        private bool _canDelete(object obj)
        {
            return SelectedDirectory != null;
        }

        private void _add(object obj)
        {
            var newDir = new ArchiveDirectory();
            Directories.Add(newDir);
            Model.Directories.Add(newDir);
            SelectedDirectory = newDir;
        }

        public ObservableCollection<ArchiveDirectory> Directories { get; }

        ArchiveDirectory _selectedDirectory;

        public ArchiveDirectory SelectedDirectory
        {
            get => _selectedDirectory;
            set
            {
                if (_selectedDirectory == value)
                    return;
                _selectedDirectory = value;
                NotifyPropertyChanged();
            }
        }
        
        protected override void OnDispose()
        {
        }
        
        public override bool IsModified { get { return Model.Directories.Any(d => d.IsModified || d.IsDeleted | d.IsNew); } }

        protected override void Update(object parameter = null)
        {
            Model.Save();
        }

    }
}
