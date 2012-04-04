using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Tasky.BL;

namespace TaskyAndroid.Screens {
	//TODO: implement proper lifecycle methods
	[Activity (Label = "TaskDetailsScreen")]			
	public class TaskDetailsScreen : Activity {
		protected Task task = new Task();
		protected Button cancelDeleteButton = null;
		protected EditText notesTextEdit = null;
		protected EditText nameTextEdit = null;
		protected Button saveButton = null;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			int taskID = Intent.GetIntExtra("TaskID", 0);
			if(taskID > 0) {
				task = Tasky.BL.Managers.TaskManager.GetTask(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			saveButton = FindViewById<Button>(Resource.Id.btnSave);
			
			// find all our controls
			cancelDeleteButton = FindViewById<Button>(Resource.Id.btnCancelDelete);
			
			
			// set the cancel delete based on whether or not it's an existing task
			if(cancelDeleteButton != null)
			{ cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete"); }
			
			// name
			if(nameTextEdit != null) { nameTextEdit.Text = task.Name; }
			
			// notes
			if(notesTextEdit != null) { notesTextEdit.Text = task.Notes; }
			
			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
		}

		protected void Save()
		{
			task.Name = nameTextEdit.Text;
			task.Notes = notesTextEdit.Text;
			Tasky.BL.Managers.TaskManager.SaveTask(task);
			Finish();
		}
		
		protected void CancelDelete()
		{
			if(task.ID != 0) {
				Tasky.BL.Managers.TaskManager.DeleteTask(task.ID);
			}
			Finish();
		}
	}
}