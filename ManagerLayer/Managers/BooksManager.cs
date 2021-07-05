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

        public bool UploadImage(int BookId, string addImage)
        {
            return this.booksRepository.UploadImage(BookId, addImage);
        }
        public BooksModel Addbooks(BooksModel books)
        {
            return this.booksRepository.Addbooks(books);
        }
    }
}
