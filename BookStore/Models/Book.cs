using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public short YearOfRelease { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
