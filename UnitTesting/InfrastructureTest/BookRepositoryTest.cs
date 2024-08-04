// using Domain;
// using Infrastructure.Data;
//
// namespace InfrastructureTest
// {
//     public class BookRepositoryTest
//     {
//         private readonly BookRepository _repository;
//
//         public BookRepositoryTest()
//         {
//             _repository = new BookRepository();
//         }
//
//         [Fact]
//         public void AddBook_ShouldAddBookToList()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test Book", Author = "Author" };
//
//             // Act
//             _repository.AddBook(book);
//
//             // Assert
//             var result = _repository.GetBookById(1);
//             Assert.NotNull(result);
//             Assert.Equal("Test Book", result.Title);
//         }
//
//         [Fact]
//         public void UpdateBook_ShouldUpdateExistingBook()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test Book", Author = "Author" };
//             _repository.AddBook(book);
//             var updatedBook = new Book { BookId = 1, Title = "Updated Title", Author = "Updated Author" };
//
//             // Act
//             _repository.UpdateBook(updatedBook);
//
//             // Assert
//             var result = _repository.GetBookById(1);
//             Assert.NotNull(result);
//             Assert.Equal("Updated Title", result.Title);
//             Assert.Equal("Updated Author", result.Author);
//         }
//
//         [Fact]
//         public void UpdateBook_ShouldNotUpdateIfBookDoesNotExist()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Non-existent Book", Author = "Author" };
//
//             // Act
//             _repository.UpdateBook(book);
//
//             // Assert
//             var result = _repository.GetBookById(1);
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void DeleteBook_ShouldRemoveBookFromList()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test Book", Author = "Author" };
//             _repository.AddBook(book);
//
//             // Act
//             _repository.DeleteBook(1);
//
//             // Assert
//             var result = _repository.GetBookById(1);
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void DeleteBook_ShouldNotThrowIfBookDoesNotExist()
//         {
//             // Act
//             _repository.DeleteBook(1);
//
//             // Assert
//             // No exception should be thrown, so no assertion is needed
//         }
//
//         [Fact]
//         public void GetBookById_ShouldReturnCorrectBook()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test Book", Author = "Author" };
//             _repository.AddBook(book);
//
//             // Act
//             var result = _repository.GetBookById(1);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal("Test Book", result.Title);
//         }
//
//         [Fact]
//         public void GetBookById_ShouldReturnNullForNonExistentBook()
//         {
//             // Act
//             var result = _repository.GetBookById(1);
//
//             // Assert
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void GetAllBooks_ShouldReturnAllBooks()
//         {
//             // Arrange
//             var book1 = new Book { BookId = 1, Title = "Book 1", Author = "Author 1" };
//             var book2 = new Book { BookId = 2, Title = "Book 2", Author = "Author 2" };
//             _repository.AddBook(book1);
//             _repository.AddBook(book2);
//
//             // Act
//             var result = _repository.GetAllBooks();
//
//             // Assert
//             Assert.Equal(2, result.Count);
//             Assert.Contains(result, b => b.BookId == 1);
//             Assert.Contains(result, b => b.BookId == 2);
//         }
//     }
// }
