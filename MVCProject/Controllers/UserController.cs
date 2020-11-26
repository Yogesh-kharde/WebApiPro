using MVCProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<mvctblUserModel> userList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User").Result;
            userList = response.Content.ReadAsAsync<IEnumerable<mvctblUserModel>>().Result;
            return View(userList);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new mvctblUserModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvctblUserModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(mvctblUserModel user)
        {
            if (user.UserId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", user).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("User/"+user.UserId,user).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("User/"+ id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}