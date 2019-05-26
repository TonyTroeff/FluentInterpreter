namespace FluentInterpreter.Tests.Models
{
	using System.Collections.Generic;

	public class User
	{
		public int UserId { get; set; }

		public ICollection<Note> Notes { get; set; }
	}
}