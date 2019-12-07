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
            var notesDbContext = new NotesDbContext();

            notesDbContext.Database.EnsureDeleted();
            notesDbContext.Database.EnsureCreated();
        }
    }
}