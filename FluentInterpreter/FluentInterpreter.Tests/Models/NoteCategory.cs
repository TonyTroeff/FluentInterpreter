namespace FluentInterpreter.Tests.Models
{
	public class NoteCategory
	{
		public int NoteId { get; set; }
		public Note Note { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}