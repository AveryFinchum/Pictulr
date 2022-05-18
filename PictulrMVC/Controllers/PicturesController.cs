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
            return RedirectToAction("Create");
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
            using (var ctx = new ApplicationDbContext())
            {
                string[] LocalPics = Directory.GetFiles(filePath);
                List<Picture> modelPictures = new List<Picture>();

                foreach (var item in LocalPics)
                {
                    //C: \Users\avfin\Documents\Coding\ElevenFifty\Assignments\elevennoteMVC\PictulrMVC\PictulrMVC\Assets\SeedContent\
                    //var splitPath = item.Split();

                    string toBeSearched = "PictulrMVC\\PictulrMVC";
                    string directory = item.Substring(item.IndexOf(toBeSearched) + toBeSearched.Length);

                    var foundImage = ctx.Pictures.FirstOrDefault(x => x.ImageLocation == directory);
                    if (foundImage == null)
                    {
                        modelPictures.Add(new Picture { 
                            ImageLocation = "~" + directory,
                            PictureTitle = "",
                            SubjectName = "",
                            NodeName = "seedData"
                            
                        });
                    }

                }

                //var pictures = db.Pictures.Include(p => p.Node).Include(p => p.Subject);
                return View(modelPictures.ToArray());
            }
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Picture> model)
        {
            bool sendAgain = false;
            var sendList = model.Where(x => x.AddImage).ToArray();

            foreach (var item in sendList)
            {
                if (item.PictureTitle == "") sendAgain = true;
                if (item.SubjectName == "") sendAgain = true;
            }

            if (sendAgain) return View(sendList.ToArray());

            var service = new PictureService();


            if (service.CreatePicture(model))
            {
                TempData["SaveResult"] = "Success!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Image(s) could not be created.");

            return View(model);

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
