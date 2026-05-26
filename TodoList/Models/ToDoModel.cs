using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoList.Models
{
    class ToDoModel : INotifyPropertyChanged
    { 
        private bool _isChecked;
        private string _taskText;

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;


        [JsonProperty(PropertyName = "isChecked")]
        public bool IsChecked
        {
            get { return _isChecked; }
            set 
            {
                if (_isChecked == value) return;
                
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));    
            }
        }


        [JsonProperty(PropertyName = "taskText")]
        public string TaskText
        {
            get { return _taskText; }
            set 
            {
                if (_taskText == value) return;

                _taskText = value;
                OnPropertyChanged(nameof(TaskText));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
