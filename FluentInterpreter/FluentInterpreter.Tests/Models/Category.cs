#region

using System.Collections.Generic;

#endregion

namespace FluentInterpreter.Tests.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<NoteCategory> Notes { get; set; }
    }
}