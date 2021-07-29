using MVCDemoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoData.Controllers
{
    public class UserinfoController : Controller
    {
        MyDBEntities db = new MyDBEntities();
        // GET: Userinfo
        public ActionResult Index()
        {
            var data2 = db.Userinfoes.Select(s=>new UserinfoModel { ID = s.ID, Firstname = s.FName, LastName = s.LName, Address = s.Address, Email = s.Email}).ToList();
            return View(data2);
        }
        public ActionResult Create()
        {
            var data2 = db.Userinfoes.Select(s => new UserinfoModel { ID = s.ID, Firstname = s.FName, LastName = s.LName, Address = s.Address, Email = s.Email }).FirstOrDefault();
            return View(data2);
        }
        [HttpPost]
        public ActionResult Create(UserinfoModel userInfoDto)
        {
            if(ModelState.IsValid)
            {
                Userinfo data = new Userinfo()
                {
                    ID = userInfoDto.ID,
                    FName = userInfoDto.Firstname,
                    LName = userInfoDto.LastName,
                    email = userInfoDto.Email,
                    Address = userInfoDto.Address,
                   
                };

                db.Userinfoes.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfoDto);
        }

    }
}