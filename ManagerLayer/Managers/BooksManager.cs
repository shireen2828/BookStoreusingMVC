using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class BooksManager : IBooksManager
    {
        private readonly IBooksRepository booksRepository;
        public BooksManager(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public List<BooksModel> GetBooks()
        {
            return this.booksRepository.GetBooks();
        }
        public BooksModel Addbooks(BooksModel books)
        {
            return this.booksRepository.Addbooks(books);
        }
    }
}
