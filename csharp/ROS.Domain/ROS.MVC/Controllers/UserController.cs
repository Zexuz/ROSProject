using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.ViewModel;

namespace ROS.MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var users = GetAllUsers();
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = GetAllUsers().Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
//            ViewBag.AddressContactId = new SelectList(db.AddressContacts, "Id", "NextOfKin");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                new UserService(new UserContext()).Add(createUserViewModel.User);
                new AddressContactService().AddToDb(createUserViewModel.AddressContact);
                return RedirectToAction("Index");
            }

            return View(createUserViewModel);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = GetAllUsers().Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
//            ViewBag.AddressContactId = new SelectList(db.AddressContacts, "Id", "NextOfKin", user.AddressContactId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,AddressContactId,Email,Password,FirstName,LastName,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                new UserService(new UserContext()).Edit(user);
                return RedirectToAction("Index");
            }
//            ViewBag.AddressContactId = new SelectList(db.AddressContacts, "Id", "NextOfKin", user.AddressContactId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = GetAllUsers().Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = GetAllUsers().Find(u => u.Id == id);
            new UserService(new UserContext()).Remove(user);
            return RedirectToAction("Index");
        }

        private List<User> GetAllUsers()
        {
            using (var context = new UserContext())
            {
                var service = new UserService(context);
                var users = service.GetAll();
                return users.ToList();
            }
        }
    }
}