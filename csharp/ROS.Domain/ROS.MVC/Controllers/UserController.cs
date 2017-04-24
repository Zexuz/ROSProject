using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.Configuration;
using ROS.Domain;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using ROS.MVC.PocoClasses;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin)
        {
            userLogin.Email = userLogin.Email.Trim().ToLower();
            var userService = new UserService(new UserContext());
            var authUser = userService.GetAll()
                .SingleOrDefault(user =>
                    user.Email == userLogin.Email &&
                    user.Password == userLogin.Password
                );


            if (authUser == null)
            {
                return View("Login");
            }

            new SessionContext().SetAuthenticationToken(authUser.Id.ToString(), false, authUser);
            return RedirectToAction("Join", "Entries");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Users");
        }



        // GET: Users/Create
        public ActionResult Create()
        {
//            ViewBag.AddressContactId = new SelectList(db.AddressContacts, "Id", "NextOfKin");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you wzant to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.Users.User, User>());
                var user = Mapper.Map<User>(createUserViewModel.User);

                Mapper.Initialize(cfg => cfg.CreateMap<PocoClasses.AddressContacts.AddressContact, AddressContact>());
                var addressContact = Mapper.Map<AddressContact>(createUserViewModel.AddressContact);

                var address = new AddressContactService(new AddressContactContext()).Add(addressContact);
                user.AddressContactId = address.Id;
                new UserService(new UserContext()).Add(user);
                return RedirectToAction("Index");
            }

            return View(createUserViewModel);
        }

        // GET: Users/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id != int.Parse(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            User user = GetAllUsers().Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressContactId = new SelectList(new AddressContactService(new AddressContactContext()).GetAll(), "Id", "NextOfKin",
                user.AddressContactId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(
            [Bind(Include = "Id,AddressContactId,Email,Password,FirstName,LastName,DateOfBirth")] User user)
        {
            if (user.Id != int.Parse(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
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