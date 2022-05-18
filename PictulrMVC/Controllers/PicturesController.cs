using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Pictuler.Services;
using Pictulr.Data;

namespace PictulrMVC.Controllers
{

    public class PicturesController : Controller
    {
        string rootLocation { get; set; }
        string filePath { get; set; }
        public PicturesController()
        {
            //rootLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            rootLocation = Path.GetDirectoryName(HostingEnvironment.ApplicationPhysicalPath);
            //filePath = Path.Combine(rootLocation, "Assets/SeedContent/");
            filePath = Path.Combine(rootLocation, "Assets\\SeedContent\\");
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pictures
        public ActionResult Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                string[] LocalPics = Directory.GetFiles(filePath);
                List<Picture> modelPictures = new List<Picture>();

                foreach (var item in LocalPics)
                {
                    var foundImage = ctx.Pictures.FirstOrDefault(x => x.ImageLocation == item);
                    if (foundImage == null)
                    {
                        modelPictures.Add(new Picture { ImageLocation = item });
                    }

                }

                //var pictures = db.Pictures.Include(p => p.Node).Include(p => p.Subject);
                return View(modelPictures);
            }
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(List<Picture> listPictures)
        {
            if (!ModelState.IsValid) return View(listPictures);

            var service = new PictureService();

            if (service.CreatePicture(listPictures))
            {
                TempData["SaveResult"] = "Success!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Image(s) could not be created.");

            return View(listPictures);
        }

        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            ViewBag.NodeNameId = new SelectList(db.Nodes, "NodeId", "NodeNameId");
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureId,OwnerId,SubjectName,PictureTitle,NodeNameId,ImageLocation,Base64EncodedImage,CreatedUtc,RecievedUtc,OptionalMetadata")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NodeNameId = new SelectList(db.Nodes, "NodeId", "NodeNameId", picture.NodeNameId);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", picture.SubjectName);
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.NodeNameId = new SelectList(db.Nodes, "NodeId", "NodeNameId", picture.NodeNameId);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", picture.SubjectName);
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureId,OwnerId,SubjectName,PictureTitle,NodeNameId,ImageLocation,Base64EncodedImage,CreatedUtc,RecievedUtc,OptionalMetadata")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NodeNameId = new SelectList(db.Nodes, "NodeId", "NodeNameId", picture.NodeNameId);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", picture.SubjectName);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
