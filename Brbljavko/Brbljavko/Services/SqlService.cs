using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brbljavko.Interfaces;
using Brbljavko.Models;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace Brbljavko.Services
{
    public class SqlService
    {
        private SQLiteConnection _database;
        public SqlService()
        {
            _database = DependencyService.Get<ISqLiteService>().GetConnection();

            _database.CreateTable<Message>();
            _database.CreateTable<Person>();
        }

        public void DoSomething()
        {
            //_database.Query()
        }
    }
}
