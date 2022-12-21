/// ETML
/// Date : 21/12/2022
/// Auteur : Alexis Rojas
/// Description : Class ORM de la table tasks
using SQLite;

namespace todoList.Models
{
    [Table("tasks")]
    public class Task
    {
        /// <summary>
        /// Id de la tâche
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int IdTask { get; set; }
        /// <summary>
        /// Nom de la tache
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Description de la tâche
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// Indique si la tâche est pour aujourd'hui
        /// </summary>
        [MaxLength(1)]
        public bool IsForToday { get; set; }
    }
}