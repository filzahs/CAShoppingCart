using CAShoppingCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private ShopContext shopContext;

        public LoginController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public IActionResult Index()
        {
            //when you land on this page, will check for any existing session

            //check if there is a cookie called session Id,
            //and validate against db
            if (Request.Cookies["SessionId"] != null) {
                Guid sessionId = Guid.Parse(Request.Cookies["sessionId"]);
                Session session = shopContext.Sessions.FirstOrDefault(x =>
                x.Id == sessionId);

                //if there is a sessionId, but I cannot find it in my db,
                //means someone trying to fake a session
                //so not a valid login, so log out to clear that sessionId
                if (session == null) 
                {
                    return RedirectToAction("Index", "Logout");
                }

                return RedirectToAction("Index", "Search");
            }

                return View();
        }

        public IActionResult Login(IFormCollection form)
        {
            string username = form["username"];
            string password = form["password"];

            //search whether these two values above are in our db
            User newUser = shopContext.Users.FirstOrDefault(x =>
            x.Username == username && x.Password == password);

            //if cannot find in db
            if(newUser == null)
            {
                //how do i add an alert to say user invalid?
                return RedirectToAction("Index", "Login");
            }

            //if found in db, create new session
            Session session = new Session()
            {
                User = newUser
            };

            //add new row to session table in db
            shopContext.Sessions.Add(session);
            shopContext.SaveChanges();

            //create new cookie
            Response.Cookies.Append("SessionId", session.Id.ToString());
            Response.Cookies.Append("Username", newUser.Username); //just to display the username

            return RedirectToAction("Index", "Search");
        }

        public IActionResult NewUser()
        {
            return View();
        }

        //make sure your parameters are the same as the name values in the form
        public IActionResult Register(string username, string password, string email, string name)
        {
            shopContext.Users.Add(new User
            {
                Username = username,
                Password = password,
                Email = email,
                Name = name
            });
            shopContext.SaveChanges();

            return RedirectToAction("SignupSuccess", "Login");
        }

        //maybe can create another constructor for empty email

        public IActionResult SignupSuccess()
        {
            return View();
        }

        public IActionResult CheckUsername([FromBody] User username)
        {
            //list all users
            List<User> userList = shopContext.Users.Where(x =>
            x.Id != null).ToList();

            //if there are currently users,
            //compare if username alr exists
            if(userList != null)
            {
                foreach (User item in userList)
                {
                    if(item.Username == username.Username)
                    {
                        return Json(new { isOkay = false });
                    }
                }
            }

            //if no users/username doesnt exist, return true json obj
            return Json(new { isOkay = true });

        }

    }
}
