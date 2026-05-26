using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoList.Models;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // JSON file path
        private readonly string PATH_TO_SAVED_TASKS = $"{Environment.CurrentDirectory}//SavingTasks.json";

        private Services.FileIOService _fileIOService;
        private BindingList<ToDoModel> _taskModelsData;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initializing service
            _fileIOService = new Services.FileIOService(PATH_TO_SAVED_TASKS);

            try
            {
                // Reading saved tasks
                _taskModelsData = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _fileIOService.ResetSavingFile();
                Close();
            }

            // Binding exist tasks
            dgTodoList.ItemsSource = _taskModelsData;

            // Binding 
            _taskModelsData.ListChanged += _taskModelsData_ListChanged;
        }

        private void _taskModelsData_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (sender == null) return;

            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.Reset)
            {
                try
                {
                    // Save tasks
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _taskModelsData.Clear();
        }
    }
}