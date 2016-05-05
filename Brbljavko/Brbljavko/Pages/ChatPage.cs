using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Views;
using Xamarin.Forms;

namespace Brbljavko.Pages
{
    public class ChatPage:ContentPage
    {
        public ChatPage()
        {
            Title = "Chat";

            Content=new ChatView("Mirko");
        }
    }
}
