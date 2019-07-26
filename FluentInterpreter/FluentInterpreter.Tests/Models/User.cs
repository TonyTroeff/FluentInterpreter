#region

using System.Collections.Generic;

#endregion

namespace FluentInterpreter.Tests.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public Profile? Profile { get; set; }
        public int Age { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}