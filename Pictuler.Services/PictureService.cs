using Pictulr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictuler.Services
{
    public class PictureService
    {
        public bool CreatePicture(List<Picture> listPictures)
        {
            var ImagesToAdd = listPictures.Where(x => x.AddImage);
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var image in ImagesToAdd)
                {
                    var foundNode = ctx.Nodes.FirstOrDefault(x => x.NodeNameId == image.NodeName);
                    if(foundNode == null)
                    {
                        //Implement logic to create node if doesnt exist
                    }
                    image.NodeNameId = foundNode.NodeId;

                    var foundSubject = ctx.Subjects.FirstOrDefault(x => x.SubjectName == image.SubjectName);
                    if (foundSubject == null)
                    {
                        //Implement logic to create Subject name if doesnt exist
                    }
                    image.SubjectId = foundSubject.SubjectId;

                    ctx.Pictures.Add(image);
                }
                ctx.SaveChanges();
            }
            return true;
        }
    }
}
