using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace todoList.Services
{
    public abstract class Repository
    {
        readonly static string DB_PATH = Path.Combine(FileSystem.AppDataDirectory, "dbtodo1.db3");

        protected SQLiteAsyncConnection Connection { get { return new SQLiteAsyncConnection(DB_PATH); } }
    }
}