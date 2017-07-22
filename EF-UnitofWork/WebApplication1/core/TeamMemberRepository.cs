using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.core
{
    public class TeamMemberRepository : IRepository<TeamMember, Guid>, IDisposable
    {
        private AppDbContext db;
        public TeamMemberRepository(AppDbContext db)
        {
            this.db = db;
        }
        public List<TeamMember> SelectAll()
        {
            return db.TeamMembers.ToList();
        }
        public TeamMember SelectByID(Guid id)
        {
            return db.TeamMembers.Where(c => c.ProjectID == id)
            .SingleOrDefault();
        }
        public void Insert(TeamMember obj)
        {
            db.TeamMembers.Add(obj);
        }
        public void Update(TeamMember obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            TeamMember obj = db.TeamMembers
            .Where(c => c.ProjectID == id)
            .SingleOrDefault();
            db.Entry(obj).State = EntityState.Deleted;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
  
}