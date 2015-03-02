using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Registration.DAL;
using Registration.Models;
using Registration.ViewModels;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _db = new UserContext();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var indexFormView = new IndexFormView();
            EntityFormBind(indexFormView);
            return View(indexFormView);
        }

        public ActionResult Subscript()
        {
            var indexFormView = new IndexFormView();
            EntityFormBind(indexFormView);
            return View(indexFormView);
        }

        public ActionResult Registration(UserSignUpModel model)
        {
            if (model.Services != null)
            {
                ViewBag.ServicesList =
                    _db.Services.Where(l => model.Services.Contains(l.ServiceId)).Select(l => l.Name).ToList();
            }
            if (model.Location != null)
            {
                Location singleOrDefault = _db.Locations.SingleOrDefault(l => l.LocationId == model.Location);
                if (singleOrDefault != null)
                    ViewBag.Location = singleOrDefault.LocationName;
            }
            Session["UserSignUpModel"] = model;
            return PartialView("_Summary", model);
        }


        public ActionResult Confirm()
        {
            var msg = new MyMessage();
            var model = Session["UserSignUpModel"] as UserSignUpModel;
            if (model == null)
            {
                msg.msg = "Fatal Error.";
                msg.status = "Error";
                msg.url = Url.Action("Error", "Home");
                Response.StatusCode = 500;
                return Json(msg);
            }
            try
            {
                SaveFromEntity(model);
                msg.msg = "Thank you for your registration";
                msg.status = "Success";
                msg.url = Url.Action("Success", "Home");
            }
            catch (Exception e)
            {
                msg.msg = e.Message;
                msg.status = "Error";
                msg.url = Url.Action("Error", "Home");
                Response.StatusCode = 500;
            }
            Session["UserSignUpModel"] = null;
            return Json(msg);
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Success()
        {
            return View();
        }

        private void SaveFromEntity(UserSignUpModel model)
        {
            var newUser = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                Country = model.Country,
                OrganisationName = model.OrganisationName,
                OrganisationContact = model.OrganisationContact,
                OrganisationAddress=model.OrganisationAddress,
                PriFirstName = model.PriFirstName,
                PriLastName = model.PriLastName,
                PriEmail = model.PriEmail,
                SecFirstName = model.SecFirstName,
                SecLastName = model.SecLastName,
                SecEmail = model.SecEmail,
                Rate = model.Rate,
                ServiceSource = model.ServiceSource,
                EmployeesNo = model.EmployeesNo,
                Comments = model.Comments,
                NewsLetters = !string.IsNullOrEmpty(model.NewsLetters),
                LocationId = model.Location
            };

            if (model.Services != null && _db.Services.Any(l => model.Services.Contains(l.ServiceId)))
            {
                List<Service> services = _db.Services.Where(l => model.Services.Contains(l.ServiceId)).ToList();
                newUser.Services = services;
            }
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }


        private void EntityFormBind(IndexFormView indexFormView)
        {
            var serviceslist = new List<SelectListItem>
            {
                new SelectListItem {Value = ""},
            };
            serviceslist.AddRange(_db.Services.Select(l => new SelectListItem
            {
                Value = l.ServiceId.ToString(),
                Text = l.Name
            }).ToList());

            var locationsList = new List<SelectListItem>
            {
                new SelectListItem {Value = ""},
            };

            locationsList.AddRange(_db.Locations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = l.LocationName
            }).ToList());
            indexFormView.Services = serviceslist;
            indexFormView.Locations = locationsList;
        }
    }
}