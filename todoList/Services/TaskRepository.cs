﻿using Android.App;
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

namespace todoList.Services
{
    public class TaskRepository : Repository
    {
        public string _statusMessage;
        public TaskRepository() {
            Connection.CreateTableAsync<Models.Task>();
        }
        public async void Insert(string name, string description)
        {
            var result = 0;
            try
            {
                result = await Connection.InsertAsync(new Models.Task { Name = name, Description = description });
                _statusMessage = $"{result} tâche ajouté : {name}";

            }
            catch (Exception ex)
            {
                _statusMessage = $"Ajout de tâche {name}.\n Erreur : {ex.Message} ";
            }
        }
    }
}