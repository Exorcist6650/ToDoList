using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    class ToDoModel : INotifyPropertyChanged
    {
        private bool _isChecked;
        private string _taskText;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsChecked
        {
            get { return _isChecked; }
            set 
            {
                if (_isChecked == value) return;
                
                _isChecked = value;
                OnPropertyChanged();    
            }
        }


        public string TaskText
        {
            get { return _taskText; }
            set 
            {
                if (_taskText == value) return;

                _taskText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
