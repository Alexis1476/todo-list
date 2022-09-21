﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace todoList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        LinearLayout _mainLayout;
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
            _mainLayout = FindViewById<LinearLayout>(Resource.Id.btns_Layout);

            // Initialisation des boutons
            _btnMyDay = new Button(this)
            {
                Text= "Journée",
                Id = 1
            };
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

            // Ajouter les boutons au layout
            _mainLayout.AddView(_btnMyDay);
            _mainLayout.AddView(_btnAddTask);
            _mainLayout.AddView(_btnCategories);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}