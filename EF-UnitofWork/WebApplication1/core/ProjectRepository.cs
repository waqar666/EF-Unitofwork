﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.core
{
    public class ProjectRepository : IRepository<Project, Guid>, IDisposable
    {
        private AppDbContext db;
        public ProjectRepository(AppDbContext db)
        {
            this.db = db;
        }
        public List<Project> SelectAll()
        {
            return db.Projects.ToList();
        }
        public Project SelectByID(Guid id)
        {
            return db.Projects.Where(c => c.ProjectID == id)
            .SingleOrDefault();
        }
        public void Insert(Project obj)
        {
            db.Projects.Add(obj);
        }
        public void Update(Project obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Project obj = db.Projects
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