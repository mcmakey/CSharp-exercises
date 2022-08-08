using LibraryService.Models;
using LibraryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public interface ILibraryRepositoryService : IRepository<Book>
    {
        IList<Book> GetByTitle(string title);

        IList<Book> GetByAuthor(string author);

        IList<Book> GetByCategory(string category);
    }
}
