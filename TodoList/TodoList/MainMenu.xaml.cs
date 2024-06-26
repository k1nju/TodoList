﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Todo.Core;
using Todo.Core.Repository;
using TodoList.Services;

namespace TodoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        MainViewModel vm = new MainViewModel();
        public MainMenu()
        {
            DataContext = vm;
            InitializeComponent();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    TodoRepository rep = new TodoRepositoryImpl();
        //    try
        //    {
        //        _todoDataList = new BindingList<TodoModel>(rep.Read());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        Close();
        //    }

        //    dgTodoList.ItemsSource = _todoDataList;
        //    _todoDataList.ListChanged += _todoDataList_ListChanged;
        //}

        //private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
        //    {
        //        try
        //        {
        //            _fileService.SaveData(sender);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            Close();
        //        }
        //    }
        //}
    }
}
