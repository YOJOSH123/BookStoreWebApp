using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CheckedIn { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
