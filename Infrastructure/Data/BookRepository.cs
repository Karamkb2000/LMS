using Domain;

namespace Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _context.Books.Find(book.BookId);
            if (existingBook == null) return;
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.IsBorrowed = book.IsBorrowed;
            existingBook.BorrowedDate = book.BorrowedDate;
            existingBook.BorrowedBy = book.BorrowedBy;
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book? GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
    }
}