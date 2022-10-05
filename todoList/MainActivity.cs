using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;

namespace todoList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        LinearLayout _footer;
        Button _btnMyDay;
        Button _btnAddTask;
        Button _btnCategories;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get layout
            _footer = FindViewById<LinearLayout>(Resource.Id.btns_layout);

            // Initialisation des boutons
            _btnMyDay = new Button(this)
            {
                Text= "Journée",
                Id = 1,
            };
            _btnMyDay.Click += _btnMyDay_Click;
            _btnAddTask = new Button(this)
            {
                Text = "Ajouter",
                Id = 2
            };
            _btnCategories = new Button(this)
            {
                Text = "Categories",
                Id = 3
            };
            ListView tasksList = FindViewById<ListView>(Resource.Id.listView1);
            List <TableItem> items = new List<TableItem> { new TableItem("Tache 1","Category 1"), new TableItem("Tache 2","Category 1")};

            tasksList.Adapter = new HomeScreenAdapter(this, items);
            // Ajouter les boutons au layout
            _footer.AddView(_btnMyDay);
            _footer.AddView(_btnAddTask);
            _footer.AddView(_btnCategories);
        }

        private void _btnMyDay_Click(object sender, System.EventArgs e)
        {
            var activity2 = new Intent(this, typeof(Activity2));
            activity2.PutExtra("NameButton", "Nom reçu de main activity");
            StartActivity(activity2);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}