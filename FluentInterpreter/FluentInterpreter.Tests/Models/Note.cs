namespace FluentInterpreter.Tests.Models
{
	using System;
	using System.Collections.Generic;

	public class Note
	{
		public int Id { get; set; }
		public string Text { get; set; }

		public DateTime? Created { get; set; }
		
		public int UserId { get; set; }
		public User User { get; set; }

		public ICollection<NoteCategory> Categories { get; set; }
	}
}