using Domain;


namespace Application
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class LibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public LibraryService(IBookRepository bookRepository, IMemberRepository memberRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;

            // Load data when the service is initialized
            // Data is automatically loaded from the database
        }

        public OperationResult AddBook(Book? book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null.");
                }
                
                // Check if book already exists
                if (_bookRepository.GetBookById(book.BookId) != null)
                {
                    return new OperationResult { Success = false, Message = $"A book with ID {book.BookId} already exists." };
                }

                if (book.BorrowedBy.HasValue)
                {
                    Member? member = _memberRepository.GetMemberById(book.BorrowedBy.Value);
                    if (member == null && book.IsBorrowed)
                    {
                        return new OperationResult { Success = false, Message = $"No member found with ID {book.BorrowedBy}." };
                    }
                }

                _bookRepository.AddBook(book);
                return new OperationResult { Success = true, Message = "Book added successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error adding book: {ex.Message}" };
            }
        }

        public OperationResult UpdateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null.");
                }

                Book? existingBook = _bookRepository.GetBookById(book.BookId);
                if (existingBook == null)
                {
                    return new OperationResult { Success = false, Message = $"No book found with ID {book.BookId}." };
                }

                if (book.BorrowedBy.HasValue)
                {
                    Member? member = _memberRepository.GetMemberById(book.BorrowedBy.Value);
                    if (member == null && book.IsBorrowed)
                    {
                        return new OperationResult { Success = false, Message = $"No member found with ID {book.BorrowedBy}." };
                    }
                }

                _bookRepository.UpdateBook(book);
                return new OperationResult { Success = true, Message = "Book updated successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error updating book: {ex.Message}" };
            }
        }

        public OperationResult DeleteBook(int bookId)
        {
            try
            {
                if (bookId <= 0)
                {
                    throw new ArgumentException("Book ID must be greater than zero.");
                }

                Book? book = _bookRepository.GetBookById(bookId);
                if (book == null)
                {
                    return new OperationResult { Success = false, Message = $"No book found with ID {bookId}." };
                }

                _bookRepository.DeleteBook(bookId);
                return new OperationResult { Success = true, Message = "Book deleted successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error deleting book: {ex.Message}" };
            }
        }

        public List<Book?> ViewBooks()
        {
            try
            {
                return _bookRepository.GetAllBooks();
            }
            catch (Exception ex)
            {
                // Print error message
                Console.WriteLine($"Error viewing books: {ex.Message}");
                return new List<Book?>();
            }
        }

        public OperationResult AddMember(Member? member)
        {
            try
            {
                if (member == null)
                {
                    throw new ArgumentNullException(nameof(member), "Member cannot be null.");
                }

                if (_memberRepository.GetMemberById(member.MemberId) != null)
                {
                    return new OperationResult { Success = false, Message = $"A member with ID {member.MemberId} already exists." };
                }

                _memberRepository.AddMember(member);
                return new OperationResult { Success = true, Message = "Member added successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error adding member: {ex.Message}" };
            }
        }

        public OperationResult UpdateMember(Member member)
        {
            try
            {
                if (member == null)
                {
                    throw new ArgumentNullException(nameof(member), "Member cannot be null.");
                }

                Member? existingMember = _memberRepository.GetMemberById(member.MemberId);
                if (existingMember == null)
                {
                    return new OperationResult { Success = false, Message = $"No member found with ID {member.MemberId}." };
                }

                _memberRepository.UpdateMember(member);
                return new OperationResult { Success = true, Message = "Member updated successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error updating member: {ex.Message}" };
            }
        }

        public OperationResult DeleteMember(int memberId)
        {
            try
            {
                if (memberId <= 0)
                {
                    throw new ArgumentException("Member ID must be greater than zero.");
                }

                Member? member = _memberRepository.GetMemberById(memberId);
                if (member == null)
                {
                    return new OperationResult { Success = false, Message = $"No member found with ID {memberId}." };
                }

                _memberRepository.DeleteMember(memberId);
                return new OperationResult { Success = true, Message = "Member deleted successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error deleting member: {ex.Message}" };
            }
        }

        public List<Member?> ViewMembers()
        {
            try
            {
                return _memberRepository.GetAllMembers();
            }
            catch (Exception ex)
            {
                // Print error message
                Console.WriteLine($"Error viewing members: {ex.Message}");
                return new List<Member?>();
            }
        }

        public OperationResult BorrowBook(int bookId, int memberId)
        {
            try
            {
                if (bookId <= 0 || memberId <= 0)
                {
                    throw new ArgumentException("Book ID and Member ID must be greater than zero.");
                }

                Book? book = _bookRepository.GetBookById(bookId);
                if (book == null)
                {
                    return new OperationResult { Success = false, Message = $"No book found with ID {bookId}." };
                }

                if (book.IsBorrowed)
                {
                    return new OperationResult { Success = false, Message = "The book is already borrowed." };
                }

                book.IsBorrowed = true;
                book.BorrowedDate = DateTime.Now;
                book.BorrowedBy = memberId;
                _bookRepository.UpdateBook(book);

                return new OperationResult { Success = true, Message = "Book borrowed successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error borrowing book: {ex.Message}" };
            }
        }

        public OperationResult ReturnBook(int bookId)
        {
            try
            {
                if (bookId <= 0)
                {
                    throw new ArgumentException("Book ID must be greater than zero.");
                }

                Book? book = _bookRepository.GetBookById(bookId);
                if (book == null)
                {
                    return new OperationResult { Success = false, Message = $"No book found with ID {bookId}." };
                }

                if (!book.IsBorrowed)
                {
                    return new OperationResult { Success = false, Message = "The book is not currently borrowed." };
                }

                book.IsBorrowed = false;
                book.BorrowedDate = null;
                book.BorrowedBy = null;
                _bookRepository.UpdateBook(book);

                return new OperationResult { Success = true, Message = "Book returned successfully." };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = $"Error returning book: {ex.Message}" };
            }
        }

        public List<Book?> GetBorrowedBooks()
        {
            try
            {
                return _bookRepository.GetAllBooks().Where(book => book != null && book.IsBorrowed).ToList();
            }
            catch (Exception ex)
            {
                // Print error message
                Console.WriteLine($"Error getting borrowed books: {ex.Message}");
                return new List<Book?>();
            }
        }
    }
}
