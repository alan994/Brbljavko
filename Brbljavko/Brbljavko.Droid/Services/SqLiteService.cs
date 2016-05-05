using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Brbljavko.Droid.Services;
using Brbljavko.Interfaces;
using SQLite;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(SqLiteService))]
namespace Brbljavko.Droid.Services
{
    public class SqLiteService:ISqLiteService
    {
        public SQLiteConnection GetConnection()
        {
            //var sqliteFilename = "Brbljavko.db3";
            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Brbljavko.db3");

            return
                new SQLite.SQLiteConnection(
                    Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        "Brbljavko.db3"));

            //return conn;
        }
    }
}