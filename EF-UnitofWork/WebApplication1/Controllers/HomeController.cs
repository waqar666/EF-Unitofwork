using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.core;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project, List<TeamMember> members)
        {
            ProjectUnit unit = new ProjectUnit();
            project.ProjectID = Guid.NewGuid();
            unit.ProjectRepository.Insert(project);
            foreach (var item in members)
            {
                item.ProjectID = project.ProjectID;
                unit.TeamRepository.Insert(item);
            }
            unit.CreateProject();
            ViewBag.Message = "Project created successfully!";
            return View("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}