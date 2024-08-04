// using Domain;
// using Moq;
// using Newtonsoft.Json;
//
// namespace DomainTest
// {
//     public class JsonFilePersistenceTests
//     {
//         private const string BooksFilePath = @"C:\Users\Karam Bataineh\Desktop\final4\LMS\Infrastructure\Data\books.json";
//         private const string MembersFilePath = @"C:\Users\Karam Bataineh\Desktop\final4\LMS\Infrastructure\Data\members.json";
//
//         [Fact]
//         public void LoadBooks_FileExists_ReturnsBooks()
//         {
//             // Arrange
//             var books = new List<Book> { new Book { Id = 1, Title = "Test Book" } };
//             var json = JsonConvert.SerializeObject(books);
//             var fileMock = new Mock<IFileWrapper>();
//             fileMock.Setup(f => f.Exists(BooksFilePath)).Returns(true);
//             fileMock.Setup(f => f.ReadAllText(BooksFilePath)).Returns(json);
//
//             // Act
//             var result = JsonFilePersistence.LoadBooks(fileMock.Object);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Single(result);
//             Assert.Equal(books[0].Title, result[0].Title);
//         }
//
//         [Fact]
//         public void LoadBooks_FileDoesNotExist_ReturnsEmptyList()
//         {
//             // Arrange
//             var fileMock = new Mock<IFileWrapper>();
//             fileMock.Setup(f => f.Exists(BooksFilePath)).Returns(false);
//
//             // Act
//             var result = JsonFilePersistence.LoadBooks(fileMock.Object);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Empty(result);
//         }
//
//         [Fact]
//         public void SaveBooks_WritesToFile()
//         {
//             // Arrange
//             var books = new List<Book> { new Book { Id = 1, Title = "Test Book" } };
//             var json = JsonConvert.SerializeObject(books, Formatting.Indented);
//             var fileMock = new Mock<IFileWrapper>();
//
//             // Act
//             JsonFilePersistence.SaveBooks(fileMock.Object, books);
//
//             // Assert
//             fileMock.Verify(f => f.WriteAllText(BooksFilePath, json), Times.Once);
//         }
//
//         [Fact]
//         public void LoadMembers_FileExists_ReturnsMembers()
//         {
//             // Arrange
//             var members = new List<Member> { new Member { Id = 1, Name = "Test Member" } };
//             var json = JsonConvert.SerializeObject(members);
//             var fileMock = new Mock<IFileWrapper>();
//             fileMock.Setup(f => f.Exists(MembersFilePath)).Returns(true);
//             fileMock.Setup(f => f.ReadAllText(MembersFilePath)).Returns(json);
//
//             // Act
//             var result = JsonFilePersistence.LoadMembers(fileMock.Object);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Single(result);
//             Assert.Equal(members[0].Name, result[0].Name);
//         }
//
//         [Fact]
//         public void LoadMembers_FileDoesNotExist_ReturnsEmptyList()
//         {
//             // Arrange
//             var fileMock = new Mock<IFileWrapper>();
//             fileMock.Setup(f => f.Exists(MembersFilePath)).Returns(false);
//
//             // Act
//             var result = JsonFilePersistence.LoadMembers(fileMock.Object);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Empty(result);
//         }
//
//         [Fact]
//         public void SaveMembers_WritesToFile()
//         {
//             // Arrange
//             var members = new List<Member> { new Member { Id = 1, Name = "Test Member" } };
//             var json = JsonConvert.SerializeObject(members, Formatting.Indented);
//             var fileMock = new Mock<IFileWrapper>();
//
//             // Act
//             JsonFilePersistence.SaveMembers(fileMock.Object, members);
//
//             // Assert
//             fileMock.Verify(f => f.WriteAllText(MembersFilePath, json), Times.Once);
//         }
//     }
//
//     public interface IFileWrapper
//     {
//         bool Exists(string path);
//         string ReadAllText(string path);
//         void WriteAllText(string path, string contents);
//     }
//
//     public static class JsonFilePersistence
//     {
//         private const string BooksFilePath = @"C:\Users\Karam Bataineh\Desktop\final4\LMS\Infrastructure\Data\books.json";
//         private const string MembersFilePath = @"C:\Users\Karam Bataineh\Desktop\final4\LMS\Infrastructure\Data\members.json";
//
//         public static List<Book?> LoadBooks(IFileWrapper fileWrapper)
//         {
//             if (!fileWrapper.Exists(BooksFilePath))
//             {
//                 return new List<Book?>();
//             }
//
//             var json = fileWrapper.ReadAllText(BooksFilePath);
//             return JsonConvert.DeserializeObject<List<Book>>(json);
//         }
//
//         public static void SaveBooks(IFileWrapper fileWrapper, List<Book?> books)
//         {
//             var json = JsonConvert.SerializeObject(books, Formatting.Indented);
//             fileWrapper.WriteAllText(BooksFilePath, json);
//         }
//
//         public static List<Member?> LoadMembers(IFileWrapper fileWrapper)
//         {
//             if (!fileWrapper.Exists(MembersFilePath))
//             {
//                 return new List<Member?>();
//             }
//
//             var json = fileWrapper.ReadAllText(MembersFilePath);
//             return JsonConvert.DeserializeObject<List<Member>>(json);
//         }
//
//         public static void SaveMembers(IFileWrapper fileWrapper, List<Member?> members)
//         {
//             var json = JsonConvert.SerializeObject(members, Formatting.Indented);
//             fileWrapper.WriteAllText(MembersFilePath, json);
//         }
//     }
// }
