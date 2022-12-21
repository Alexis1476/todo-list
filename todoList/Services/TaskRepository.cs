using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoList.Models;
using static Android.Util.EventLogTags;
using static Java.Util.Jar.Attributes;

namespace todoList.Services
{
    public class TaskRepository : Repository
    {
        public string _statusMessage;
        public TaskRepository() {
            Connection.CreateTableAsync<Models.Task>();
        }
        public async void Insert(string name, string description, bool isForToday)
        {
            var result = 0;
            try
            {
                result = await Connection.InsertAsync(new Models.Task { Name = name, Description = description, IsForToday = isForToday });
                _statusMessage = $"{result} tâche ajouté : {name}";

            }
            catch (Exception ex)
            {
                _statusMessage = $"Ajout de tâche {name}.\n Erreur : {ex.Message} ";
            }
        }
        public async Task<List<Models.Task>> MyDay()
        {
            try
            {
                return await Connection.QueryAsync<Models.Task>("SELECT * FROM tasks WHERE IsForToday = ?", true);
            }
            catch (Exception ex)
            {
                _statusMessage = $"Impossible d'obtenir toutes les tâches.\n Erreur : {ex.Message} ";
                return new List<Models.Task>();
            }
        }
        public async Task<List<Models.Task>> All()
        {
            try
            {
                return await Connection.Table<Models.Task>().ToListAsync();
            }
            catch (Exception ex)
            {
                _statusMessage = $"Impossible d'obtenir toutes les tâches.\n Erreur : {ex.Message} ";
                return new List<Models.Task>();
            }
        }
    }
}