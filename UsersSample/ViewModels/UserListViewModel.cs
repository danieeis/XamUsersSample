using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UsersSample.Models.User;
using UsersSample.Services;
using Xamarin.Forms;

namespace UsersSample.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        RouteUser routeUser;
        ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    Refresh();
                }
            }
        }

        public UserListViewModel()
        {
            routeUser = new RouteUser();

            GetListUsers();
        }

        async void GetListUsers()
        {
            var result = await routeUser.GetUsers();
            if (result.Success)
            {
                Users = new ObservableCollection<User>(result.Value.Result);

            }
        }

        void AddItem()
        {

        }

        ICommand AddItemCommand
        {
            get
            {
                return new Command(AddItem);
            }
        }
    }
}
