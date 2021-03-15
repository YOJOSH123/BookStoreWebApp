using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookStoreAdminfunctions
    {
        public static void AddBook(Book book)
        {
            try
            {
                using (var db = new SE407_BookStoreContext())
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }catch(Exception e)
            {
            }
        }

        public static void DeleteBook(int id)
        {
            try
            {
                using (var db = new SE407_BookStoreContext())
                {
                    var bookToDelete = db.Books.Find(id);
                    db.Books.Remove(bookToDelete);
                    db.SaveChanges();
                }
            }catch(Exception e)
            {
            }
        }

        public static void EditBook(Book book)
        {
            try
            {
                using(var db = new SE407_BookStoreContext())
                {
                    db.Books.Update(book);
                    db.SaveChanges();
                }
            }catch(Exception e) { }
        }
    }
}
