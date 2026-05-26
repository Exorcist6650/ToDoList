using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoList.Models;

namespace TodoList.Services
{
    /// <summary>
    /// Service to load and save user tasks
    /// </summary>
    class FileIOService
    {
        private readonly string PATH_TO_SAVED;

        public FileIOService(string path)
        {
            PATH_TO_SAVED = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            // File existing checking and creating when it's not
            var fileExists = File.Exists(PATH_TO_SAVED);
            if (!fileExists)
            {
                File.CreateText(PATH_TO_SAVED).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (StreamReader reader = File.OpenText(PATH_TO_SAVED))
            {
                var fileText = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
                return result ?? new BindingList<ToDoModel>();
            }

        }

        public void SaveData(object taskModelsData)
        {
            using (StreamWriter writer = File.CreateText(PATH_TO_SAVED))
            {
                string output = JsonConvert.SerializeObject(taskModelsData);
                writer.Write(output);
            }
        }

        public void ResetSavingFile()
        {
            File.Delete(PATH_TO_SAVED);
            File.Create(PATH_TO_SAVED);
        }
    }
}