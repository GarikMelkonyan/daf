using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAF.DataAccess;

namespace DAF.Business
{
    public class DemoManager : ManagerBase
    {
        public static List<Demo> GetDemos()
        {
            using (var db = CreateDataContext())
            {
                return db.Demos.ToList();
            }
        }

        public static Demo GetDemo(long id)
        {
            using (var db = CreateDataContext())
            {
                return db.Demos.FirstOrDefault(s => s.ID == id);
            }
        }

        public static void SaveDemo(IDocumentDemo d)
        {
            using (var db = CreateDataContext())
            {
                var demo = db.Demos.FirstOrDefault(s => s.ID == d.ID) ?? new Demo();
                demo.Title = d.Title;
                demo.DemoPath = d.Path;
                if (demo.ID == 0)
                {
                    db.Demos.Add(demo);
                }
                db.SaveChanges();
            }
        }

        public static string DeleteDemo(long id)
        {
            using (var db = CreateDataContext())
            {
                var doc = db.Demos.FirstOrDefault(s => s.ID == id);
                if (doc == null) return string.Empty;
                db.Demos.Remove(doc);
                db.SaveChanges();
                return doc.DemoPath;
            }
        }

        public static List<Demo> GetApplicationDemos(long appID)
        {
            using (var db= CreateDataContext())
            {
                return db.ApplicationDemos.Where(s => s.ApplicationID == appID).Select(s => s.Demo).ToList();
            }
        }
    }
}
