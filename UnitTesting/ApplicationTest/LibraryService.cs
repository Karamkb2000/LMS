//
// using Application;
// using Domain;
// using Moq;
//
//
// namespace ApplicationTest
// {
//     public class LibraryServiceTests
//     {
//         private readonly Mock<IBookRepository> _mockBookRepo;
//         private readonly Mock<IMemberRepository> _mockMemberRepo;
//         
//         private readonly LibraryService _service;
//
//         public LibraryServiceTests()
//         {
//             _mockBookRepo = new Mock<IBookRepository>();
//             _mockMemberRepo = new Mock<IMemberRepository>();
//             _service = new LibraryService(_mockBookRepo.Object, _mockMemberRepo.Object);
//         }
//         
//
//
//         [Fact]
//         public void GetBorrowedBooks_ShouldReturnEmptyList_WhenExceptionIsThrown()
//         {
//             // Arrange
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Throws(new Exception("Test exception"));
//
//             // Act
//             var result = _service.GetBorrowedBooks();
//
//             // Assert
//             Assert.Empty(result);
//         }
//
//         [Fact]
//         public void ViewBooks_ShouldReturnEmptyList_WhenExceptionIsThrown()
//         {
//             // Arrange
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Throws(new Exception("Test exception"));
//
//             // Act
//             var result = _service.ViewBooks();
//
//             // Assert
//             Assert.Empty(result);
//         }
//
//         [Fact]
//         public void ViewMembers_ShouldReturnEmptyList_WhenExceptionIsThrown()
//         {
//             // Arrange
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Throws(new Exception("Test exception"));
//
//             // Act
//             var result = _service.ViewMembers();
//
//             // Assert
//             Assert.Empty(result);
//         }
//
//         [Fact]
//         public void AddBook_ShouldThrowArgumentNullException_WhenBookIsNull()
//         {
//             // Arrange
//             Book? book = null;
//
//             // Act & Assert
//             var exception = Assert.Throws<ArgumentNullException>(() => _service.AddBook(book));
//             Assert.Equal("book", exception.ParamName);
//         }
//
//         [Fact]
//         public void AddBook_ShouldThrowArgumentException_WhenBookPropertiesAreInvalid()
//         {
//             // Arrange
//             var book = new Book { BookId = 0, Title = "", Author = "" };
//
//             // Act
//             var exception = Assert.Throws<ArgumentException>(() => _service.AddBook(book));
//
//             // Assert
//             Assert.Equal("Book ID, Title, and Author cannot be null or empty.", exception.Message);
//         }
//
//         [Fact]
//         public void AddBook_ShouldThrowInvalidOperationException_WhenBookAlreadyExists()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test", Author = "Author" };
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Returns(new List<Book?> { book });
//
//             // Act & Assert
//             Assert.Throws<InvalidOperationException>(() => _service.AddBook(book));
//         }
//
//         [Fact]
//         public void AddBook_ShouldAddBook_WhenBookIsValid()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test", Author = "Author" };
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Returns(new List<Book?>());
//
//             // Act
//             _service.AddBook(book);
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.AddBook(It.IsAny<Book>()), Times.Once);
//         }
//
//         [Fact]
//         public void UpdateBook_ShouldThrowArgumentNullException_WhenBookIsNull()
//         {
//             // Arrange
//             Book book = null;
//
//             // Act & Assert
//             Assert.Throws<ArgumentNullException>(() => _service.UpdateBook(book));
//         }
//
//         [Fact]
//         public void UpdateBook_ShouldUpdateBook_WhenBookIsValid()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Updated Title", Author = "Updated Author" };
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Returns(new List<Book>
//             {
//                 new Book
//                 {
//                     BookId = 1, Title = "Original Title", Author = "Original Author" 
//                     
//                 }});
//
//             // Act
//             _service.UpdateBook(book);
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Once);
//         }
//
//         [Fact]
//         public void DeleteBook_ShouldThrowArgumentException_WhenBookIDIsInvalid()
//         {
//             // Arrange
//             int bookId = 0;
//
//             // Act & Assert
//             Assert.Throws<ArgumentException>(() => _service.DeleteBook(bookId));
//         }
//
//         [Fact]
//         public void DeleteBook_ShouldDeleteBook_WhenBookIDIsValid()
//         {
//             // Arrange
//             int bookId = 1;
//             var existingBooks = new List<Book>
//             {
//                 new Book { BookId = 1, Title = "Test Book", Author = "Test Author" },
//                 new Book { BookId = 2, Title = "Another Book", Author = "Another Author" }
//             };
//
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Returns(existingBooks);
//
//             // Act
//             _service.DeleteBook(bookId);
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.DeleteBook(It.IsAny<int>()), Times.Once);
//         }
//         
//         
//         [Fact]
//         public void ReturnBook_BookIsNull_ThrowsKeyNotFoundException()
//         {
//             // Arrange
//             var bookRepositoryMock = new Mock<IBookRepository>();
//             var memberRepositoryMock = new Mock<IMemberRepository>();
//             var libraryService = new LibraryService(bookRepositoryMock.Object, memberRepositoryMock.Object);
//
//             int bookId = 1;
//
//             // Mock GetBookById to return null
//             bookRepositoryMock.Setup(repo => repo.GetBookById(bookId)).Returns((Book?)null);
//
//             // Act & Assert
//             var exception = Assert.Throws<KeyNotFoundException>(() => libraryService.ReturnBook(bookId));
//
//             // Verify that the correct exception message is thrown
//             Assert.Equal($"No book found with ID {bookId}.", exception.Message);
//         }
//
//
//         [Fact]
//         public void BorrowBook_ShouldThrowArgumentException_WhenBookIDIsInvalid()
//         {
//             // Arrange
//             int bookId = 0;
//             int memberId = 1;
//
//             // Act & Assert
//             Assert.Throws<ArgumentException>(() => _service.BorrowBook(bookId, memberId));
//         }
//
//         [Fact]
//         public void BorrowBook_ShouldThrowArgumentException_WhenMemberIDIsInvalid()
//         {
//             // Arrange
//             int bookId = 1;
//             int memberId = 0;
//
//             // Act & Assert
//             Assert.Throws<ArgumentException>(() => _service.BorrowBook(bookId, memberId));
//         }
//
//         [Fact]
//         public void BorrowBook_ShouldThrowInvalidOperationException_WhenBookIsAlreadyBorrowed()
//         {
//             // Arrange
//             int bookId = 1;
//             int memberId = 1;
//             var book = new Book { BookId = bookId, Title = "Test Book", Author = "Author", IsBorrowed = true };
//
//             _mockBookRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
//             _mockMemberRepo.Setup(repo => repo.GetMemberById(memberId)).Returns(new Member { MemberId = memberId, Name = "Test Member", Email = "test@example.com" });
//
//             // Act & Assert
//             Assert.Throws<InvalidOperationException>(() => _service.BorrowBook(bookId, memberId));
//         }
//
//         [Fact]
//         public void BorrowBook_ShouldBorrowBook_WhenValid()
//         {
//             // Arrange
//             int bookId = 1;
//             int memberId = 1;
//             var book = new Book { BookId = bookId, Title = "Test Book", Author = "Author", IsBorrowed = false };
//             var member = new Member { MemberId = memberId, Name = "Test Member", Email = "test@example.com" };
//
//             _mockBookRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
//             _mockMemberRepo.Setup(repo => repo.GetMemberById(memberId)).Returns(member);
//
//             // Act
//             _service.BorrowBook(bookId, memberId);
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.UpdateBook(It.Is<Book>(b => b.BookId == bookId && b.IsBorrowed)), Times.Once);
//         }
//
//         [Fact]
//         public void ReturnBook_ShouldThrowArgumentException_WhenBookIDIsInvalid()
//         {
//             // Arrange
//             int bookId = 0;
//
//             // Act & Assert
//             Assert.Throws<ArgumentException>(() => _service.ReturnBook(bookId));
//         }
//
//         [Fact]
//         public void ReturnBook_ShouldThrowInvalidOperationException_WhenBookIsNotBorrowed()
//         {
//             // Arrange
//             int bookId = 1;
//             var book = new Book { BookId = bookId, Title = "Test Book", Author = "Author", IsBorrowed = false };
//
//             _mockBookRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
//
//             // Act & Assert
//             Assert.Throws<InvalidOperationException>(() => _service.ReturnBook(bookId));
//         }
//
//         [Fact]
//         public void ReturnBook_ShouldReturnBook_WhenValid()
//         {
//             // Arrange
//             int bookId = 1;
//             var book = new Book { BookId = bookId, Title = "Test Book", Author = "Author", IsBorrowed = true };
//
//             _mockBookRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
//
//             // Act
//             _service.ReturnBook(bookId);
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.UpdateBook(It.Is<Book>(b => b.BookId == bookId && !b.IsBorrowed)), Times.Once);
//         }
//         
//         
//         [Fact]
//         public void GetBorrowedBooks_ReturnsOnlyBorrowedBooks()
//         {
//             // Arrange
//             var bookRepositoryMock = new Mock<IBookRepository>();
//             var memberRepositoryMock = new Mock<IMemberRepository>();
//             var libraryService = new LibraryService(bookRepositoryMock.Object, memberRepositoryMock.Object);
//
//             // Set up a list of books where some are borrowed and some are not
//             var books = new List<Book?>
//             {
//                 new Book { BookId = 1, Title = "Book 1", IsBorrowed = true },
//                 new Book { BookId = 2, Title = "Book 2", IsBorrowed = false },
//                 new Book { BookId = 3, Title = "Book 3", IsBorrowed = true },
//                 new Book { BookId = 4, Title = "Book 4", IsBorrowed = false }
//             };
//
//             // Mock GetAllBooks to return the list of books
//             bookRepositoryMock.Setup(repo => repo.GetAllBooks()).Returns(books);
//
//             // Act
//             var borrowedBooks = libraryService.GetBorrowedBooks();
//
//             // Assert
//             Assert.Equal(2, borrowedBooks.Count);
//             Assert.All(borrowedBooks, book => Assert.True(book?.IsBorrowed));
//             Assert.Contains(borrowedBooks, book => book?.BookId == 1);
//             Assert.Contains(borrowedBooks, book => book?.BookId == 3);
//         }
//
//
//         [Fact]
//         public void AddMember_ShouldThrowArgumentNullException_WhenMemberIsNull()
//         {
//             // Arrange
//             Member? member = null;
//
//             // Act & Assert
//             Assert.Throws<ArgumentNullException>(() => _service.AddMember(member));
//         }
//
//         [Fact]
//         public void AddMember_ShouldThrowArgumentException_WhenMemberPropertiesAreInvalid()
//         {
//             // Arrange
//             var invalidMember = new Member { MemberId = 0, Name = "", Email = "" };
//
//             // Act & Assert
//             var exception = Assert.Throws<ArgumentException>(() => _service.AddMember(invalidMember));
//             Assert.Equal("Member ID, Name, and Email cannot be null or empty.", exception.Message);
//         }
//
//         [Fact]
//         public void AddMember_ShouldThrowInvalidOperationException_WhenMemberAlreadyExists()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" };
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(new List<Member> { member });
//
//             // Act & Assert
//             Assert.Throws<InvalidOperationException>(() => _service.AddMember(member));
//         }
//
//         [Fact]
//         public void AddMember_ShouldAddMember_WhenMemberIsValid()
//         {
//             // Arrange
//             var newMember = new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" };
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(new List<Member>());
//
//             // Act
//             _service.AddMember(newMember);
//
//             // Assert
//             _mockMemberRepo.Verify(repo => repo.AddMember(It.IsAny<Member>()), Times.Once);
//         }
//
//         [Fact]
//         public void UpdateMember_ShouldThrowArgumentNullException_WhenMemberIsNull()
//         {
//             // Arrange
//             Member member = null;
//
//             // Act & Assert
//             Assert.Throws<ArgumentNullException>(() => _service.UpdateMember(member));
//         }
//
//         [Fact]
//         public void UpdateMember_ShouldUpdateMember_WhenMemberIsValid()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "Updated Name", Email = "updated@example.com" };
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(new List<Member>
//             {
//                 new Member { MemberId = 1, Name = "Original Name", Email = "original@example.com" }
//             });
//
//             // Act
//             _service.UpdateMember(member);
//
//             // Assert
//             _mockMemberRepo.Verify(repo => repo.UpdateMember(It.IsAny<Member>()), Times.Once);
//         }
//
//         [Fact]
//         public void DeleteMember_ShouldThrowArgumentException_WhenMemberIDIsInvalid()
//         {
//             // Arrange
//             int memberId = 0;
//
//             // Act & Assert
//             Assert.Throws<ArgumentException>(() => _service.DeleteMember(memberId));
//         }
//
//         [Fact]
//         public void DeleteMember_ShouldDeleteMember_WhenMemberIDIsValid()
//         {
//             // Arrange
//             int memberId = 1;
//             var existingMembers = new List<Member>
//             {
//                 new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" },
//                 new Member { MemberId = 2, Name = "Another Member", Email = "another@example.com" }
//             };
//
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(existingMembers);
//
//             // Act
//             _service.DeleteMember(memberId);
//
//             // Assert
//             _mockMemberRepo.Verify(repo => repo.DeleteMember(It.IsAny<int>()), Times.Once);
//         }
//         
//
//         [Fact]
//         public void ViewMembers_ShouldReturnMembers()
//         {
//             // Arrange
//             var members = new List<Member?>
//             {
//                 new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" }
//             };
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(members);
//
//             // Act
//             var result = _service.ViewMembers();
//
//             // Assert
//             Assert.Equal(members, result);
//         }
//         
//         
//         [Fact]
//         public void SaveData_ShouldSaveBooksAndMembersSuccessfully()
//         {
//             // Arrange
//             var sampleBooks = new List<Book?>
//             {
//                 new Book { BookId = 1, Title = "Book 1", Author = "Author 1" }
//             };
//
//             var sampleMembers = new List<Member?>
//             {
//                 new Member { MemberId = 1, Name = "Member 1", Email = "member1@example.com" }
//             };
//
//             _mockBookRepo.Setup(repo => repo.GetAllBooks()).Returns(sampleBooks);
//             _mockMemberRepo.Setup(repo => repo.GetAllMembers()).Returns(sampleMembers);
//
//             // Act
//
//
//             // Assert
//             _mockBookRepo.Verify(repo => repo.GetAllBooks(), Times.Once);
//             _mockMemberRepo.Verify(repo => repo.GetAllMembers(), Times.Once);
//         }
//         
//     }
// }
