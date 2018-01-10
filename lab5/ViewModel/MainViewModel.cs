using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace lab5
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Unit selectedUnit;
        IFileService fileService;
        IDialogService dialogService;
        public ObservableCollection<Unit> Units { get; set; }

        private MyCommand openCommand;
        public MyCommand OpenCommand => openCommand ??
                  (openCommand = new MyCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var units = fileService.Open(dialogService.FilePath);
                              Units.Clear();
                              foreach (var p in units)
                              {
                                  Units.Add(p);
                              }

                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));

        private MyCommand saveCommand;
        public MyCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new MyCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Units.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private MyCommand addCommand;
        public MyCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new MyCommand(obj =>
                  {
                      Unit unit = new Unit("Default",0,0,0);
                      Units.Insert(0, unit);
                      SelectedUnit = unit;
                  }));
            }
        }
        private MyCommand removeCommand;
        public MyCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new MyCommand(obj =>
                    {
                       Unit unit = obj as Unit;
                        if (unit != null)
                        {
                            Units.Remove(unit);
                        }

                    },
                    (obj) => Units.Count > 0));
            }
        }
        public Unit SelectedUnit
        {
            get { return selectedUnit; }
            set
            {
                selectedUnit = value;
                OnPropertyChanged("SelectedUnit");
            }
        }

        public MainViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Units = new ObservableCollection<Unit>{
                new Unit("Sworder", 100.3, 30, 100),
                new Unit("Archer", 30, 50, 80),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
