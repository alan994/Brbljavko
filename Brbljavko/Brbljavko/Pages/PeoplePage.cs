using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Views;
using Xamarin.Forms;

namespace Brbljavko.Pages
{
    public class PeoplePage:ContentPage
    {
        public PeoplePage()
        {
            Title = "People";

            Content=new PeopleView();
        }
    }
}
