/// ETML
/// Date : 21/12/2022
/// Auteur : Alexis Rojas
/// Description : Class qui gère la connexion à la base de données
using SQLite;
using System.IO;
using Xamarin.Essentials;

namespace todoList.Services
{
    /// <summary>
    /// Gère la connexion à la base de données
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// Chemin de la base de données
        /// </summary>
        readonly static string DB_PATH = Path.Combine(FileSystem.AppDataDirectory, "dbTodo2.db3");
        /// <summary>
        /// Retourne une nouvelle connexion SQLite
        /// </summary>
        protected SQLiteAsyncConnection Connection { get { return new SQLiteAsyncConnection(DB_PATH); } }
    }
}