using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryService.Services.Impl
{
    public class LibraryRepository : ILibraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _dbContext;

        public LibraryRepository(ILibraryDatabaseContextService dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Book> GetByTitle(string title)
        {
            return _dbContext.Books.Where(book => book.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public IList<Book> GetByAuthor(string authorName)
        {
            return _dbContext.Books.Where(book =>
                book.Authors.Where(author =>
                    author.Name.ToLower().Contains(authorName.ToLower())).Count() > 0).ToList();
        }

        public IList<Book> GetByCategory(string category)
        {
            return _dbContext.Books.Where(book =>
                book.Category.ToLower().Contains(category.ToLower())).ToList();
        }

        //

        public int Delete(Book item)
        {
            _dbContext.Books.Remove(item);

            return _dbContext.Books.Count();
        }

        public int Update(Book item)
        {
            var book = _dbContext.Books.First(b => b.Id == item.Id);

            book.Title = item.Title;
            book.Category = item.Category;
            book.Authors = item.Authors;
            book.AgeLimit = item.AgeLimit;
            book.Lang = item.Lang;
            book.Pages = item.Pages;
            book.Pages = item.PublicationDate;

            return _dbContext.Books.Count();
        }

        //

        public int? Add(Book item)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}