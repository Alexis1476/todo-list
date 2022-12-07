using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using todoList.Services;
using todoList.Models;
using System.Collections;
using System.Linq;

namespace todoList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button _addtask;
        ListView _tasksList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Recuperer les éléments de l'interface
            _addtask = FindViewById<Button>(Resource.Id.add_task);
            _tasksList = FindViewById<ListView>(Resource.Id.container);

            _addtask.Click += (object sender, System.EventArgs e) => {
                //
            };
            DisplayTasks();
        }
        async void DisplayTasks()
        {
            TaskRepository tr = new TaskRepository();
            List<Task> tasks = await tr.All();
            _tasksList.Adapter = new TaskAdapter(this, tasks);
        }
        async void DisplayFormAddTask(object sender, System.EventArgs e)
        {
            //
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}