﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRM.Models;

namespace MVC_CRM.Controllers {

  public class CustomersController : Controller {
    private WingtipCRMEntities db = new WingtipCRMEntities();

    // GET: /Customers/
    public ActionResult Index() {
      return View(db.Customers.ToList());
    }

    // GET: /Customers/Details/5
    public ActionResult Details(int id = 0) {
      Customer customer = db.Customers.Find(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // GET: /Customers/Create
    public ActionResult Create() {
      return View();
    }

    // POST: /Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer) {
      if (ModelState.IsValid) {
        db.Customers.Add(customer);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(customer);
    }

    // GET: /Customers/Edit/5
    public ActionResult Edit(int id = 0) {
      Customer customer = db.Customers.Find(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Customers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Customer customer) {
      if (ModelState.IsValid) {
        db.Entry(customer).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    // GET: /Customers/Delete/5
    public ActionResult Delete(int id = 0) {
      Customer customer = db.Customers.Find(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      Customer customer = db.Customers.Find(id);
      db.Customers.Remove(customer);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing) {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}

