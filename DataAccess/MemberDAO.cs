using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        private MemberDAO() {
        }

        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }

            }
        }

        public void Add(Member member)
        {
            try
            {
                Member p = FindOne(item => item.MemberId.Equals(member.MemberId));
                if (p == null)
                {
                    using (var saleManagement = new SaleManagerContext())
                    {
                        saleManagement.Members.Add(member);
                        saleManagement.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The member is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Member member)
        {
            try
            {
                Member p = FindOne(item => item.MemberId.Equals(member.MemberId));
                if (p != null)
                {
                    using (var saleManagerContext = new SaleManagerContext())
                    {
                        saleManagerContext.Members.Remove(member);
                        saleManagerContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Member FindOne(Expression<Func<Member, bool>> predicate)
        {
            Member member = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    member = saleManagerContext.Members.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return member;
        }

        public IEnumerable<Member> FindAll(Expression<Func<Member, bool>> predicate)
        {
            List<Member> members = new List<Member>();
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    members = saleManagerContext.Members.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public IEnumerable<Member> List()
        {
            List<Member> members = new List<Member>();
            try
            {
                using (var SaleManagerContext = new SaleManagerContext())
                {
                    members = SaleManagerContext.Members.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return members;
        }

        public void Update(Member member)
        {
            try
            {
                Member p = FindOne(item => item.MemberId.Equals(member.MemberId));
                if (p != null)
                {
                    using (var saleManager = new SaleManagerContext())
                    {
                        saleManager.Entry<Member>(member).State = EntityState.Modified;
                        saleManager.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
