/// ETML
/// Date : 21/12/2022
/// Auteur : Alexis Rojas
/// Description : Class qui gère les méthodes CRUD sur la table "tasks" avec son ORM
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace todoList.Services
{
    /// <summary>
    /// Contient le CRUD de la table "tasks"
    /// </summary>
    public class TaskRepository : Repository
    {
        /// <summary>
        /// Message d'état de la requête SQL
        /// </summary>
        public string _statusMessage;
        /// <summary>
        /// Constructeur par défaut qui crée la table "tasks" si elle n'existe pas
        /// </summary>
        public TaskRepository() {
            Connection.CreateTableAsync<Models.Task>();
        }
        /// <summary>
        /// Insère une nouvelle tâche dans la base de données
        /// </summary>
        /// <param name="name">Nom de la tâche</param>
        /// <param name="description">Description de la tâche</param>
        /// <param name="isForToday">True si la tâche est pour aujourd'hui; false sinon.</param>
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
        /// <summary>
        /// Retourne la liste des tâches pour la journée (Si IsForToday = true)
        /// </summary>
        /// <returns>Liste de tâches</returns>
        public async Task<List<Models.Task>> MyDay()
        {
            try
            {
                // Methode en utilisant linq
                var tasks = from task in Connection.Table<Models.Task>() where task.IsForToday.Equals(true) select task;
                return await tasks.ToListAsync();
                // En utilisant SQL query
                //return await Connection.QueryAsync<Models.Task>("SELECT * FROM tasks WHERE IsForToday = ?", true);
            }
            catch (Exception ex)
            {
                _statusMessage = $"Impossible d'obtenir toutes les tâches.\n Erreur : {ex.Message} ";
                return new List<Models.Task>();
            }
        }
        /// <summary>
        /// Retourne toutes les tâches de la base de données
        /// </summary>
        /// <returns>Toutes les tâches</returns>
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