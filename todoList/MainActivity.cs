/// ETML
/// Date : 21/12/2022
/// Auteur : Alexis Rojas
/// Description : Class qui gère l'activité principale "main_activity"
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;
using System.Threading;
using todoList.Models;
using todoList.Services;

namespace todoList
{
    /// <summary>
    /// Activité principale
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        /// <summary>
        /// Boouton pour afficher toutes les tâches
        /// </summary>
        Button _allTasks;
        /// <summary>
        /// Bouton pour ajouter une tâche
        /// </summary>
        Button _addtask;
        /// <summary>
        /// Listview qui affiche la liste des tâches
        /// </summary>
        ListView _tasksList;
        /// <summary>
        /// Bouton pour voir les tâches du jour
        /// </summary>
        Button _myDay;
        /// <summary>
        /// Permet d'effectuer des actions sur la table "tasks"
        /// </summary>
        TaskRepository _taskRepository;
        /// <summary>
        /// Initialise les éléments de l'activité
        /// </summary>
        /// <param name="savedInstanceState">Bundle</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Initialise le task repository
            _taskRepository = new TaskRepository();

            // Recuperer les éléments de l'interface
            _allTasks = FindViewById<Button>(Resource.Id.all_tasks);
            _addtask = FindViewById<Button>(Resource.Id.add_task);
            _tasksList = FindViewById<ListView>(Resource.Id.container);
            _myDay = FindViewById<Button>(Resource.Id.myDay);

            // Ajouter les méthodes évenèmentielles
            _allTasks.Click += (object sender, System.EventArgs e) => DisplayAllTasks();
            _addtask.Click += DisplayFormAddTask;
            _myDay.Click += DisplayMyDayTasks;

            // Afficher les tâches de la base de données
            DisplayAllTasks();
        }
        /// <summary>
        /// Affiche les tâches du jour
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        async void DisplayMyDayTasks(object sender, System.EventArgs e)
        {       
            ChangeTasks(await _taskRepository.MyDay());
        }
        /// <summary>
        /// Change la source des données de la listView qui affiche les tâches
        /// </summary>
        /// <param name="tasks">Liste de tâches</param>
        void ChangeTasks(List<Task> tasks)
        {
            _tasksList.Adapter = new TaskAdapter(this, tasks);
        }
        /// <summary>
        /// Affiche la liste de toutes les tâches
        /// </summary>
        async void DisplayAllTasks()
        {
            ChangeTasks(await _taskRepository.All());
        }
        /// <summary>
        /// Affiche le formulaire d'ajout d'une tâche (sous forme de popoup)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        void DisplayFormAddTask(object sender, System.EventArgs e)
        {
            // Récupère le layout contenant le formulaire d'ajout d'une tâche
            var taskCreateForm = LayoutInflater.Inflate(Resource.Layout.task_create, null);

            var popUp = new Android.App.AlertDialog.Builder(this);
            popUp.SetView(taskCreateForm);
            // Action pour le bouton confirmer
            popUp.SetPositiveButton("Confirmer", (object sender, DialogClickEventArgs e) =>
            {
                _tasksList = FindViewById<ListView>(Resource.Id.container);

                var dialog = (Android.App.AlertDialog)sender;
                var taskName = (EditText)dialog.FindViewById(Resource.Id.title);
                var taskDesc = (EditText)dialog.FindViewById(Resource.Id.description);
                var taskDay = (CheckBox)dialog.FindViewById(Resource.Id.is_for_today);

                _taskRepository.Insert(taskName.Text, taskDesc.Text, taskDay.Checked);
                Thread.Sleep(100); // Thread sleep pour enregistrer avant d'afficher les tâches
                DisplayAllTasks();
                dialog.Hide();
            });
            // Action pour le bouton Annuler
            popUp.SetNegativeButton("Annuler", (object sender, DialogClickEventArgs e) =>
            {
                var dialog = (Android.App.AlertDialog)sender;
                dialog.Hide();
            });
            var builder = popUp.Create();
            popUp.Show();
        }
        /// <summary>
        /// OnRequestPermissionsResult default function
        /// </summary>
        /// <param name="requestCode">Int</param>
        /// <param name="permissions">String[]</param>
        /// <param name="grantResults">[GeneratedEnum]</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}