using BusinessObject.Model;
using DataAccess.Model;
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
            MemberDAO.Instance.Add(member);
        }

        public void Delete(Member member)
        {
            MemberDAO.Instance.Delete(member);
        }

        public IEnumerable<Member> FindAllBy(MemberFilter filter)
        {
            if (filter != null)
            {
                return MemberDAO.Instance.FindAll(member => (filter.MemberId == null || member.MemberId.Equals(filter.MemberId)) &&
                                                              (filter.Email == null || member.Email.ToLower().Contains(filter.Email.ToLower())) &&
                                                              (filter.CompanyName == null || member.CompanyName.ToLower().Contains(filter.CompanyName.ToLower())) &&
                                                              (filter.City == null || member.City.ToLower().Contains(filter.City.ToLower())) &&
                                                              (filter.Country == null || member.Country.ToLower().Contains(filter.Country.ToLower())));
            }
            return List();
        }

        public Member FindByEmailAndPassword(string email, string password)
        {
            return MemberDAO.Instance.FindOne(member => member.Email== email && member.Password == password);
        }

        public Member FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Member FindByEmail(string email)
        {
            return MemberDAO.Instance.FindOne(member => member.Email == email);
        }

        public IEnumerable<Member> List()
        {
            return MemberDAO.Instance.List();
        }

        public void Update(Member member)
        {
            MemberDAO.Instance.Update(member);
        }
    }
}
