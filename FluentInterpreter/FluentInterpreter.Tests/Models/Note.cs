#region

using System;
using System.Collections.Generic;

#endregion

namespace FluentInterpreter.Tests.Models
{
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