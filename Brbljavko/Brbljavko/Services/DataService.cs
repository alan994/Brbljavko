using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Models;
using Microsoft.AspNet.SignalR.Client;
using SQLite;
using Xamarin.Forms;

namespace Brbljavko.Services
{
    public class DataService
    {
        private SqlService _sqlService;
        public string Nickname { get; set; }

        private List<Person> _persons;

        public List<Person> Persons
        {
            get { return _persons;}
            set
            {
                if (_persons != value)
                {
                    _persons = value;
                }
            }
        }

        private ObservableCollection<Message> _messages;

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                }
            }
        }

        private readonly HubConnection _hubConnection;
        private IHubProxy _hubProxy;
        public ConnectionState SignalRConnectionState { get { return _hubConnection.State; } }

        public DataService()
        {
            _sqlService=new SqlService();

            _persons = new List<Person>();
            _messages = new ObservableCollection<Message>();
            _hubConnection = new HubConnection(@"http://algebrasignalr.azurewebsites.net/");
            _hubProxy = _hubConnection.CreateHubProxy("ChatHub");

            _hubConnection.Closed += _hubConnection_Closed;

            _hubConnection.StateChanged += _hubConnection_StateChanged;

            ConnectToSignalRHub();
        }

        void _hubConnection_StateChanged(StateChange obj)
        {
            MessagingCenter.Send(this, "SignalRConnectionStateChanged", obj.NewState);
        }

        private async void _hubConnection_Closed()
        {
            while (true)
            {
                var result = await ConnectToSignalRHub();
                if (result.Equals(false))
                {
                    continue;
                }
                break;
            }
        }

        private async Task<bool> ConnectToSignalRHub()
        {
            try
            {
                await _hubConnection.Start();
            }
            catch (Exception ex)
            {
                return false;
            }

            _hubProxy.On<string, string>("broadcastMessage", (name, message) =>
            {
                Messages.Add(new Message()
                {
                    Text = message,
                    SentAt = DateTime.Now,
                    SenderName = name
                });
            });

            return true;
        }

        public void SendMessage(Message message)
        {
            
        }

        public List<Person> RefreshPersons()
        {
            //TODO: This is stupid
            return _persons;
        } 


    }
}
