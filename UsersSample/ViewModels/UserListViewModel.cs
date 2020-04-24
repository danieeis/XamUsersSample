using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UsersSample.Models.User;
using UsersSample.Services;
using UsersSample.Views;
using Xamarin.Forms;

namespace UsersSample.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        RouteUser routeUser;
        ObservableCollection<User> _users;
        bool _isLoading;
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

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
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
            IsLoading = true;
            var result = await routeUser.GetUsers();
            if (result.Success)
            {
                Users = new ObservableCollection<User>(result.Value.Result);
                IsLoading = false;
            }
        }

        void AddItem()
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new AddUserPopUp((item) => {
                item.Links = Users.FirstOrDefault().Links;
                Users.Add(item);
            }));
        }

        public ICommand AddItemCommand
        {
            get
            {
                return new Command(AddItem);
            }
        }
    }
}
