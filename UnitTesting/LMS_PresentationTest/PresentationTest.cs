// using Application;
// using Domain;
// using LMS;
// using Microsoft.VisualStudio.TestPlatform.TestHost;
// using Moq;
//
// namespace LMS_PresentationTest
// {
//     public class ProgramTest
//     {
//         private readonly Mock<IBookRepository> _mockBookRepository;
//         private readonly Mock<IMemberRepository> _mockMemberRepository;
//         private readonly LibraryService _libraryService;
//         private readonly Program _program;
//
//         public ProgramTest()
//         {
//             _mockBookRepository = new Mock<IBookRepository>();
//             _mockMemberRepository = new Mock<IMemberRepository>();
//             _libraryService = new LibraryService(_mockBookRepository.Object, _mockMemberRepository.Object);
//             _program = new Program(_libraryService);
//         }
//
//         [Fact]
//         public void Run_ShouldInvokeLoadData()
//         {
//             // Arrange
//             _mockBookRepository.Setup(repo => repo.GetAllBooks()).Returns(new List<Book?>());
//             _mockMemberRepository.Setup(repo => repo.GetAllMembers()).Returns(new List<Member?>());
//
//             // Act
//             _program.Run();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.GetAllBooks(), Times.Once);
//             _mockMemberRepository.Verify(repo => repo.GetAllMembers(), Times.Once);
//         }
//
//         [Fact]
//         public void ManageBooks_ShouldAddBook()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Test Book", Author = "Test Author" };
//
//             // Act
//             _program.AddBook();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.AddBook(It.IsAny<Book?>()), Times.Once);
//         }
//
//         [Fact]
//         public void ManageBooks_ShouldViewBooks()
//         {
//             // Arrange
//             var books = new List<Book?> { new Book { BookId = 1, Title = "Test Book", Author = "Test Author" } };
//             _mockBookRepository.Setup(repo => repo.GetAllBooks()).Returns(books);
//
//             // Act
//             _program.ViewBooks();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.GetAllBooks(), Times.Once);
//         }
//
//         [Fact]
//         public void ManageBooks_ShouldUpdateBook()
//         {
//             // Arrange
//             var book = new Book { BookId = 1, Title = "Updated Book", Author = "Updated Author" };
//
//             // Act
//             _program.UpdateBook();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Once);
//         }
//
//         [Fact]
//         public void ManageBooks_ShouldDeleteBook()
//         {
//             // Arrange
//             var bookId = 1;
//
//             // Act
//             _program.DeleteBook();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.DeleteBook(bookId), Times.Once);
//         }
//
//         [Fact]
//         public void ManageMembers_ShouldAddMember()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" };
//
//             // Act
//             _program.AddMember();
//
//             // Assert
//             _mockMemberRepository.Verify(repo => repo.AddMember(It.IsAny<Member?>()), Times.Once);
//         }
//
//         [Fact]
//         public void ManageMembers_ShouldViewMembers()
//         {
//             // Arrange
//             var members = new List<Member?> { new Member { MemberId = 1, Name = "Test Member", Email = "test@example.com" } };
//             _mockMemberRepository.Setup(repo => repo.GetAllMembers()).Returns(members);
//
//             // Act
//             _program.ViewMembers();
//
//             // Assert
//             _mockMemberRepository.Verify(repo => repo.GetAllMembers(), Times.Once);
//         }
//
//         [Fact]
//         public void ManageMembers_ShouldUpdateMember()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "Updated Member", Email = "updated@example.com" };
//
//             // Act
//             _program.UpdateMember();
//
//             // Assert
//             _mockMemberRepository.Verify(repo => repo.UpdateMember(It.IsAny<Member>()), Times.Once);
//         }
//
//         [Fact]
//         public void ManageMembers_ShouldDeleteMember()
//         {
//             // Arrange
//             var memberId = 1;
//
//             // Act
//             _program.DeleteMember();
//
//             // Assert
//             _mockMemberRepository.Verify(repo => repo.DeleteMember(memberId), Times.Once);
//         }
//
//         [Fact]
//         public void BorrowBook_ShouldInvokeBorrowBook()
//         {
//             // Arrange
//             var bookId = 1;
//             var memberId = 1;
//             _mockBookRepository.Setup(repo => repo.GetBookById(bookId)).Returns(new Book { BookId = bookId });
//             _mockMemberRepository.Setup(repo => repo.GetMemberById(memberId)).Returns(new Member { MemberId = memberId });
//
//             // Act
//             _program.BorrowBook();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.GetBookById(bookId), Times.Once);
//             _mockMemberRepository.Verify(repo => repo.GetMemberById(memberId), Times.Once);
//         }
//
//         [Fact]
//         public void ReturnBook_ShouldInvokeReturnBook()
//         {
//             // Arrange
//             var bookId = 1;
//             _mockBookRepository.Setup(repo => repo.GetBookById(bookId)).Returns(new Book { BookId = bookId });
//
//             // Act
//             _program.ReturnBook();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.GetBookById(bookId), Times.Once);
//         }
//
//         [Fact]
//         public void ViewBorrowedBooks_ShouldInvokeGetBorrowedBooks()
//         {
//             // Arrange
//             var borrowedBooks = new List<Book?> { new Book { BookId = 1, Title = "Borrowed Book", Author = "Author" } };
//             _mockBookRepository.Setup(repo => repo.GetAllBooks()).Returns(borrowedBooks);
//
//             // Act
//             _program.ViewBorrowedBooks();
//
//             // Assert
//             _mockBookRepository.Verify(repo => repo.GetAllBooks(), Times.Once);
//         }
//     }
// }
