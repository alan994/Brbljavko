using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Views;
using Xamarin.Forms;

namespace Brbljavko.Pages
{
    public class TabletChatPage:ContentPage
    {
        public TabletChatPage()
        {
            var grid = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition() {Width = new GridLength(50, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(50, GridUnitType.Star)}
                }
            };

            grid.Children.Add(new ChatView("Algebra"), 0, 0);
            grid.Children.Add(new ChatView("Zebra"), 1, 0);

            Content = grid;
        }
    }
}
