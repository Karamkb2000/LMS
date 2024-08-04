namespace Domain
{
    public interface IMemberRepository
    {
        void AddMember(Member? member);
        void UpdateMember(Member member);
        void DeleteMember(int memberId);
        Member? GetMemberById(int memberId);
        List<Member?> GetAllMembers();
    }
}
