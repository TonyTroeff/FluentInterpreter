namespace FluentInterpreter.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class Tests
	{
		[Test]
		public void Test()
		{
			NotesDbContext notesDbContext = new NotesDbContext();

			notesDbContext.Database.EnsureDeleted();
			notesDbContext.Database.EnsureCreated();
		}
	}
}