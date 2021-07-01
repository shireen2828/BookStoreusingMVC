﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interaces
{
    public interface IBooksRepository
    {
        List<BooksModel> GetBooks();
        BooksModel Addbooks(BooksModel books);
    }
}