using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone4_TaskListRevisted.Models;

namespace Capstone4_TaskListRevisted.Controllers
{
    public class TasksController : Controller
    {
        // GET: TasksController
        public ActionResult Index()
        {
            TasksListDbContext tasksListDbContext = new TasksListDbContext();
            return View(tasksListDbContext.Tasks.ToList());
        }

        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TasksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks tasks)
        {
            try
            {

                TasksListDbContext tasksListDbContext = new TasksListDbContext();
                tasks.UserId = tasksListDbContext.AspNetUsers.FirstOrDefault().Id;
                
                //Add the task to the table 
                tasksListDbContext.Tasks.Add(tasks);

                //Committ the changes
                int results = tasksListDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            TasksListDbContext tasksListDbContext = new TasksListDbContext();
            
            return View(tasksListDbContext.Tasks.Where(t => t.Id == id).FirstOrDefault());
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tasks tasks)
        {
            try
            {
                TasksListDbContext tasksListDbContext = new TasksListDbContext();
                //Remove task from table
                tasksListDbContext.Tasks.Remove(tasks);
                int results = tasksListDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
