using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _2108___ClassExrices___3
{
    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public GoButtonConverter GoBtnConverter { get; set; } = new GoButtonConverter();
        public CancelButtonConverter CancelBtnConverter { get; set; } = new CancelButtonConverter();
        public ICommand GoCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private string myName= "";
        public string MyName { get { return myName; } set { myName = value; OnPropertyChanged("MyName"); }  }


        public ViewModel()
        {
            GoCommand = new DelegateCommand(() =>
            {
                MessageBox.Show($"Hello {MyName}!");
            },
             () =>
             {
                 return GoBtnConverter.CanExecute;
             });

            CancelCommand = new DelegateCommand(() => 
            {
            MyName = "";
            },
             () => 
            {
                return CancelBtnConverter.CanExecute;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return GetErrorForProperty(columnName);
            }

        }

        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "MyName":
                    if (MyName.Length < 3)
                        return "Too Short!";
                    else
                        return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}