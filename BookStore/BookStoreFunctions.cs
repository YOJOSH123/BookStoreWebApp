using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookStoreFunctions
    {
        public static Book GetBookById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.Find(id);
            }
        }

        public static List<Book> GetBookByTitle(string title)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Join(db.Authors,
                    m => m.Author.AuthorId,
                    t => t.AuthorId,
                    (m, t) => new
                    {
                        BookId = m.BookId,
                        Title = m.BookTitle,
                        ReleaseYear = m.YearOfRelease,
                        GenreId = m.GenreId,
                        AuthorId = m.AuthorId,
                    }).Where(w => w.Title == title)
                    .Select(m => new Book
                    {
                        BookId = m.BookId,
                        BookTitle = m.Title,
                        YearOfRelease = m.ReleaseYear,
                        GenreId = m.GenreId,
                        AuthorId = m.AuthorId
                    }).ToList();
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.ToList();
            }
        }

        public static List<Book> GetMoviesByAuthorLastName(String author)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Join(db.Authors,
                    m => m.Author.AuthorId,
                    t => t.AuthorId,
                    (m, t) => new
                    {
                        BookId = m.BookId,
                        BookTitle = m.BookTitle,
                        YearOfRelease = m.YearOfRelease,
                        GenreId = m.GenreId,
                        AuhtorId = m.AuthorId,
                        AuhtorLast = m.Author.AuthorLast,
                    }).Where(w => w.AuhtorLast == author)
                    .Select(m => new Book
                    {
                        BookId = m.BookId,
                        BookTitle = m.BookTitle,
                        YearOfRelease = m.YearOfRelease,
                        GenreId = m.GenreId,
                        AuthorId = m.AuhtorId
                    }).ToList();
            }
        }

        public static List<Book> GetAllBooksFull()
        {
            using (var db = new SE407_BookStoreContext())
            {
                var books = db.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .ToList();

                return books;
            }
        }

        public static Book GetFullBookById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var book = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Where(b => b.BookId == id)
                    .FirstOrDefault();

                return book;
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Genres.ToList();
            }
        }

        public static List<Author> GetAllAuthors()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Authors.ToList();
            }
        }
    }
}
