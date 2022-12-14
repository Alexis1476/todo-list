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
using System.Threading;

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

            _addtask.Click += DisplayFormAddTask;

            DisplayTasks();
        }
        async void DisplayTasks()
        {


            TaskRepository tr = new TaskRepository();
            List<Task> tasks = await tr.All();
            _tasksList.Adapter = new TaskAdapter(this, tasks);
        }
        void DisplayFormAddTask(object sender, System.EventArgs e)
        {
            //
            var editText = LayoutInflater.Inflate(Resource.Layout.task_create, null);

            var ad = new Android.App.AlertDialog.Builder(this);
            ad.SetView(editText);
            ad.SetPositiveButton("Confirm", ConfirmButton);
            ad.SetNegativeButton("Cancel", CancelButton);
            var builder = ad.Create();
            ad.Show();
        }
        void ConfirmButton(object sender, DialogClickEventArgs e)
        {
            _tasksList = FindViewById<ListView>(Resource.Id.container);
            
            var dialog = (Android.App.AlertDialog)sender;
            var taskName = (EditText)dialog.FindViewById(Resource.Id.title);
            var taskDesc = (EditText)dialog.FindViewById(Resource.Id.description);
            TaskRepository repository = new TaskRepository();

            repository.Insert(taskName.Text, taskDesc.Text);
            Thread.Sleep(100);
            DisplayTasks();
            dialog.Hide();
        }

        /// <summary>
        /// Button to hide de popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CancelButton(object sender, DialogClickEventArgs e)
        {
            var dialog = (Android.App.AlertDialog)sender;
            dialog.Hide();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}