using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using todoList.Models;

namespace todoList
{
    public class TaskAdapter : BaseAdapter<Task>
    {
        List<Task> items;
        Activity context;
        public TaskAdapter(Activity context, List<Task> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Task this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
            view.FindViewById<TextView>(Resource.Id.title).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.description).Text = item.Description;
            return view;
        }
    }
}