// using Domain;
// using Infrastructure.Data;
//
// namespace InfrastructureTest
// {
//     public class MemberRepositoryTest
//     {
//         private readonly MemberRepository _repository;
//
//         public MemberRepositoryTest()
//         {
//             _repository = new MemberRepository();
//         }
//
//         [Fact]
//         public void AddMember_ShouldAddMemberToList()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "John Doe", Email = "john@example.com" };
//
//             // Act
//             _repository.AddMember(member);
//
//             // Assert
//             var result = _repository.GetMemberById(1);
//             Assert.NotNull(result);
//             Assert.Equal("John Doe", result.Name);
//         }
//
//         [Fact]
//         public void UpdateMember_ShouldUpdateExistingMember()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "John Doe", Email = "john@example.com" };
//             _repository.AddMember(member);
//             var updatedMember = new Member { MemberId = 1, Name = "Jane Doe", Email = "jane@example.com" };
//
//             // Act
//             _repository.UpdateMember(updatedMember);
//
//             // Assert
//             var result = _repository.GetMemberById(1);
//             Assert.NotNull(result);
//             Assert.Equal("Jane Doe", result.Name);
//             Assert.Equal("jane@example.com", result.Email);
//         }
//
//         [Fact]
//         public void UpdateMember_ShouldNotUpdateIfMemberDoesNotExist()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "Non-existent Member", Email = "nonexistent@example.com" };
//
//             // Act
//             _repository.UpdateMember(member);
//
//             // Assert
//             var result = _repository.GetMemberById(1);
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void DeleteMember_ShouldRemoveMemberFromList()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "John Doe", Email = "john@example.com" };
//             _repository.AddMember(member);
//
//             // Act
//             _repository.DeleteMember(1);
//
//             // Assert
//             var result = _repository.GetMemberById(1);
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void DeleteMember_ShouldNotThrowIfMemberDoesNotExist()
//         {
//             // Act
//             _repository.DeleteMember(1);
//
//             // Assert
//             // No exception should be thrown, so no assertion is needed
//         }
//
//         [Fact]
//         public void GetMemberById_ShouldReturnCorrectMember()
//         {
//             // Arrange
//             var member = new Member { MemberId = 1, Name = "John Doe", Email = "john@example.com" };
//             _repository.AddMember(member);
//
//             // Act
//             var result = _repository.GetMemberById(1);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal("John Doe", result.Name);
//         }
//
//         [Fact]
//         public void GetMemberById_ShouldReturnNullForNonExistentMember()
//         {
//             // Act
//             var result = _repository.GetMemberById(1);
//
//             // Assert
//             Assert.Null(result);
//         }
//
//         [Fact]
//         public void GetAllMembers_ShouldReturnAllMembers()
//         {
//             // Arrange
//             var member1 = new Member { MemberId = 1, Name = "John Doe", Email = "john@example.com" };
//             var member2 = new Member { MemberId = 2, Name = "Jane Smith", Email = "jane@example.com" };
//             _repository.AddMember(member1);
//             _repository.AddMember(member2);
//
//             // Act
//             var result = _repository.GetAllMembers();
//
//             // Assert
//             Assert.Equal(2, result.Count);
//             Assert.Contains(result, m => m.MemberId == 1);
//             Assert.Contains(result, m => m.MemberId == 2);
//         }
//     }
// }
