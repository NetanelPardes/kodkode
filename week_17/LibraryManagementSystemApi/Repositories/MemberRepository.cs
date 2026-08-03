using LibraryManagementSystemApi.Data;
using LibraryManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryDbContext _context;

        public MemberRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }
        public async Task<Member> CreateAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }
        public async Task<bool> UpdateAsync(int id, Member member)
        {
            var exist = await _context.Members.FindAsync(id);
            if (exist == null)
            {
                return false;
            }
            exist.FullName = member.FullName;
            exist.Email = member.Email;
            exist.MembershipNumber = member.MembershipNumber;
            exist.JoinedDate = member.JoinedDate;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _context.Members.FindAsync(id);
            if (exist == null)
            {
                return false;
            }
            _context.Members.Remove(exist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
