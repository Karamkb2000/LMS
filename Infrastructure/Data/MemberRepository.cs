using Domain;

namespace Infrastructure.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryDbContext _context;

        public MemberRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            var existingMember = _context.Members.Find(member.MemberId);
            if (existingMember == null) return;
            existingMember.Name = member.Name;
            existingMember.Email = member.Email;
            _context.SaveChanges();
        }

        public void DeleteMember(int memberId)
        {
            var member = _context.Members.Find(memberId);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
        }

        public Member? GetMemberById(int memberId)
        {
            return _context.Members.Find(memberId);
        }

        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }
    }
}