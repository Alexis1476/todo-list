using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace todoList
{
    [Activity(Label = "Activity2", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Activity2 : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity2);

            LinearLayout _main = FindViewById<LinearLayout>(Resource.Id.main);

            // Initialisation des boutons
            Button _btnMyDay = new Button(this)
            {
                Text = Intent.GetStringExtra("NameButton"),
                Id = 1,
            };
            _main.AddView(_btnMyDay);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(GetType().FullName, "OnDestroy");
        }
        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(GetType().FullName, "OnResume");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}