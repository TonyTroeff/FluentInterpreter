#region

using NUnit.Framework;

#endregion

namespace FluentInterpreter.Tests
{
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