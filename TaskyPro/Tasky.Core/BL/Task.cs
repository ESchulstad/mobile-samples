using System;
using Tasky.BL.Contracts;
using Tasky.DL.SQLite;

namespace Tasky.BL
{
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class Task : IBusinessEntity
	{
		public Task ()
		{
		}

		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		//public DateTime? DueDate { get; set; }
		public bool Done { get; set; }
	}
}

