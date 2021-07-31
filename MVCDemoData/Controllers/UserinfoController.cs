using MVCDemoData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoData.Controllers
{
    public class UserinfoController : Controller
    {
        MyDBEntities1 db = new MyDBEntities1();

       

        // GET: Userinfo
        public ActionResult Index()
        {
            var data2 = db.StudentInfoes.Select(s => new UserinfoModel { ID = s.ID, Firstname = s.FName, LastName = s.LName, Address = s.Address, Email = s.Email }).ToList();
            return View(data2);
        }
        public ActionResult Create()
        {
            var data2 = db.StudentInfoes.Select(s => new UserinfoModel { ID = s.ID, Firstname = s.FName, LastName = s.LName, Address = s.Address, Email = s.Email }).FirstOrDefault();
            return View(data2);
        }
        [HttpPost]
        public ActionResult Create(UserinfoModel userInfoDto)
        {
            if (ModelState.IsValid)
            {
                StudentInfo data = new StudentInfo()
                {
                    FName = userInfoDto.Firstname,
                    LName = userInfoDto.LastName,
                    Email = userInfoDto.Email,
                    Address = userInfoDto.Address,

                };

                db.StudentInfoes.Add(data);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfoDto);
        }
        public ActionResult Edit(int ID)
        {
            var data = db.StudentInfoes.Where(s => s.ID == ID).FirstOrDefault();
            if (data != null)
            {
                TempData["ID"] = ID;
                TempData.Keep();
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(StudentInfo userInfoDto)
        {
            Int32 ID = (int)TempData["ID"];
            var Studentinfo = db.StudentInfoes.Where(s => s.ID == ID).FirstOrDefault();
            if (Studentinfo != null)
            {
                Studentinfo.FName = userInfoDto.FName;
                Studentinfo.LName = userInfoDto.LName;
                Studentinfo.Email = userInfoDto.Email;
                Studentinfo.Address = userInfoDto.Address;

                db.Entry(Studentinfo).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}