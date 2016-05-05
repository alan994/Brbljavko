using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Models;
using Brbljavko.Services;
using Xamarin.Forms;

namespace Brbljavko.Views
{
    public class ChatView:ContentView
    {
        private string _nickname;
        private Entry _entry;
        public ChatView(string nickname)
        {
            _nickname = nickname;

            var grid = new Grid()
            {
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(50, GridUnitType.Absolute)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(70, GridUnitType.Absolute)}
                }
            };

            var dataTemplate = new DataTemplate(typeof (TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, nameof(Message.Text));
            dataTemplate.SetBinding(TextCell.DetailProperty, nameof(Message.SenderName));

            var list = new ListView()
            {
                ItemTemplate = dataTemplate,
                BindingContext = App.DataService.Messages,
                ItemsSource = App.DataService.Messages,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Fuchsia
            };
            grid.Children.Add(list, 0, 2, 0, 1);

            _entry = new Entry()
            {
                Placeholder = "Your message"
            };
            grid.Children.Add(_entry, 0, 1);

            var button = new Button()
            {
                Text = "Send"
            };
            button.Clicked += Button_Clicked;
            grid.Children.Add(button, 1, 1);

            Content = grid;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.DataService.Messages.Add(new Message()
            {
                SenderName = _nickname,
                Text = _entry.Text,
                SentAt = DateTime.Now
            });
        }
    }
}
