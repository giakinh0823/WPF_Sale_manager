using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> List();
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
        Member FindById(int id);
        Member FindByEmailAndPassword(string email,string password);
    }
}
