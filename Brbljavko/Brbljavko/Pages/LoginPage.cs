using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Helpers;
using Xamarin.Forms;

namespace Brbljavko.Pages
{
    public class LoginPage:ContentPage
    {
        private Entry _nicknameEntry;

        public LoginPage()
        {
            var grid = new Grid()
            {
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)}
                }
            };

            _nicknameEntry = new Entry()
            {
                Placeholder = "Nickname",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            grid.Children.Add(_nicknameEntry, 0, 1);

            var button = new Button()
            {
                Text = "Login",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += Button_Clicked;
            grid.Children.Add(button, 0, 2);

            Content = grid;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_nicknameEntry.Text))
            {
                await DisplayAlert("Ooops...", "We need you to enter your nickname", "OK");
                return;
            }

            Settings.Nickname = _nicknameEntry.Text;
            App.DataService.Nickname = _nicknameEntry.Text;

            //if (Device.Idiom.Equals(TargetIdiom.Phone))
            //{
            //    Navigation.InsertPageBefore(new TabbedPage() { Children = { new ChatPage(), new PeoplePage() } }, this);
            //}
            //else if (Device.Idiom.Equals(TargetIdiom.Tablet))
            //{
                Navigation.InsertPageBefore(new TabletChatPage(), this);
            //}

            await Navigation.PopAsync();
        }
    }
}
