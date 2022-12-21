/// ETML
/// Date : 21/12/2022
/// Auteur : Alexis Rojas
/// Description : Class qui gère la disposition des éléments de la ListView qui affiche les tâches
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using todoList.Models;

namespace todoList
{
    /// <summary>
    /// Adapter pour la listview des tâches
    /// </summary>
    public class TaskAdapter : BaseAdapter<Task>
    {
        /// <summary>
        /// Liste des tâches (Models.Task)
        /// </summary>
        List<Task> _tasks;
        /// <summary>
        /// Activité
        /// </summary>
        Activity _context;
        /// <summary>
        /// Constructeur de l'adapter
        /// </summary>
        /// <param name="context">Activité</param>
        /// <param name="items">Liste de tâches</param>
        public TaskAdapter(Activity context, List<Task> items) : base()
        {
            _context = context;
            _tasks = items;
        }
        /// <summary>
        /// Retourne l'ID d'une tâche à une position donnée
        /// </summary>
        /// <param name="position">Index</param>
        /// <returns>Models.Task</returns>
        public override long GetItemId(int position)
        {
            return position;
        }
        /// <summary>
        /// Retourne une tâche à une position donnée
        /// </summary>
        /// <param name="position">Index</param>
        /// <returns>Models.Task</returns>
        public override Task this[int position]
        {
            get { return _tasks[position]; }
        }
        /// <summary>
        /// Retourne la taille de la liste de tâches
        /// </summary>
        public override int Count
        {
            get { return _tasks.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _tasks[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = _context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);
            view.FindViewById<TextView>(Resource.Id.title).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.description).Text = item.Description;
            // Si la tâche est pour aujourd'hui
            view.FindViewById<TextView>(Resource.Id.for_today).Text = item.IsForToday ? "Aujourd'hui" : "";
            
            return view;
        }
    }
}