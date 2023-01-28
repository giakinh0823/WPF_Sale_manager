using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Add(Member member)
        {
            throw new NotImplementedException();
        }

        public void Delete(Member member)
        {
            throw new NotImplementedException();
        }

        public Member FindByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Member FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
