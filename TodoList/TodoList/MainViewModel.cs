using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Todo.Core.Repository;
using Todo.Core;
using TodoList.Core;
using System.Collections.ObjectModel;

namespace TodoList
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<TodoModel> _todoList;
        public ObservableCollection<TodoModel> TodoList { get => _todoList; set { _todoList = value; OnPropertyChanged("TodoList"); } }
        private TodoRepository TodoRepository { get; set; }

        private string _name;
        private string _description;

        public string Name { get => _name; set { _name = value; OnPropertyChanged("Name"); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged("Description"); } }

        private TodoModel _selectedTodo;

        public TodoModel SelectedTodo { get => _selectedTodo; set { _selectedTodo = value; OnPropertyChanged("SelectedTodo"); } }

        public MainViewModel() 
        {
            TodoRepository = new TodoRepositoryImpl();
            TodoList= new ObservableCollection<TodoModel>(TodoRepository.Read());
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new RelayCommand(obj =>
                  {
                      TodoRepository.Save(TodoList.ToList());
                      _todoList = new ObservableCollection<TodoModel>(TodoRepository.Read());
                  }));
            }
        }
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      TodoRepository.Create(new TodoModel()
                      {
                          
                      });
                      TodoList = new ObservableCollection<TodoModel>(TodoRepository.Read());
                  }));
            }
        }
        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                  (_deleteCommand = new RelayCommand(obj =>
                  {
                      TodoRepository.Delete(SelectedTodo.Id);
                      TodoList = new ObservableCollection<TodoModel>(TodoRepository.Read());
                  }));
            }
        }

    }
}
