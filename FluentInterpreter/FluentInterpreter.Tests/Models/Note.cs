namespace FluentInterpreter.Tests.Models
{
	public class Note
	{
		public int Id { get; set; }
		public string Text { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}