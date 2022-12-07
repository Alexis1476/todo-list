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
using SQLite;

namespace todoList
{
    [Table("tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int IdTask { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public Task(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}