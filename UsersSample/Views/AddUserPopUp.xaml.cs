using System;
using System.Collections.Generic;
using UsersSample.Models.User;
using Xamarin.Forms;

namespace UsersSample.Views
{
    public partial class AddUserPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        Action<User> action;
        public AddUserPopUp(Action<User> action)
        {
            this.action = action;
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(eFirstName.Text))
            {
                Alert("Debe agregar el Nombre", eFirstName);
                return;
            }
            if (string.IsNullOrEmpty(eLastName.Text))
            {
                Alert("Debe agregar el Apellido", eLastName);
                return;
            }
            if (string.IsNullOrEmpty(ePhone.Text))
            {
                Alert("Debe agregar el Teléfono", ePhone);
                return;
            }
            action?.Invoke(new User() {
                FirstName = eFirstName.Text,
                LastName = eLastName.Text,
                Phone = ePhone.Text
            });
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        void Alert(string message,Entry entry)
        {
            DisplayAlert("Aviso", message, "Ok");
            entry.Focus();
        }
    }
}
