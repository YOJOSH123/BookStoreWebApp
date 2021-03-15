using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorFirst { get; set; }
        public string AuthorLast { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
