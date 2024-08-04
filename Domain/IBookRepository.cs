namespace Domain
{
    public interface IBookRepository
    {
        void AddBook(Book? book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        Book? GetBookById(int bookId);
        List<Book?> GetAllBooks();
    }
}
