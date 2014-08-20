using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAF.DataAccess;

namespace DAF.Business
{
    public class ApplicationManager : ManagerBase
    {
        public static List<SoftApplication> GetApplications()
        {
            using (var db = CreateDataContext())
            {
                return db.SoftApplications.ToList();
            }
        }

        public static SoftApplication GetApplication(long appID)
        {
            using (var db = CreateDataContext())
            {
                return db.SoftApplications
                            .Include(s => s.ApplicationDemos)
                            .Include(s => s.ApplicationDocuments)
                            .Include(s => s.Features)
                            .FirstOrDefault(s => s.ID == appID);
            }
        }

        public static void SaveApplication(SoftApplication app)
        {
            using (var db = CreateDataContext())
            {
                SoftApplication application = db.SoftApplications.FirstOrDefault(s => s.ID == app.ID) ?? new SoftApplication();
                application.ApplicationDemos.Clear();
                application.ApplicationDocuments.Clear();
                application.Features.Clear();
                foreach (long demoID in app.DemoIDs)
                {
                    application.ApplicationDemos.Add(new ApplicationDemo { DemoID = demoID });
                }
                foreach (long documentID in app.DocumentIDs)
                {
                    application.ApplicationDocuments.Add(new ApplicationDocument { DocumentID = documentID });
                }
                foreach (string feature in app.FeatureNames)
                {
                    application.Features.Add(new Feature {Title = feature});
                }
                application.Title = app.Title;
                application.ShortDescription = app.ShortDescription;
                application.LongDescription = app.LongDescription;
                if (application.ID == 0)
                {
                    db.SoftApplications.Add(application);
                }
                db.SaveChanges();
                app.ID = application.ID;
            }
        }

        public static void DeleteApplication(long id)
        {
            using (var db = CreateDataContext())
            {
                var app = db.SoftApplications.Single(s => s.ID == id);
                foreach (ApplicationDocument document in app.ApplicationDocuments.ToList())
                {
                    db.ApplicationDocuments.Remove(document);
                }
                foreach (ApplicationDemo demo in app.ApplicationDemos.ToList())
                {
                    db.ApplicationDemos.Remove(demo);
                }
                db.SoftApplications.Remove(app);
                db.SaveChanges();
            }
        }

        public static void DeleteApplicationImage(long id)
        {
            using (var db = CreateDataContext())
            {
                var app = db.SoftApplications.FirstOrDefault(s => s.ID == id);
                if (app == null) return;
                app.ImagePath = string.Empty;
                db.SaveChanges();
            }
        }

        public static void UpdateApplicationImagePath(long appID, string fileName)
        {
            using (var db = CreateDataContext())
            {
                var app = db.SoftApplications.FirstOrDefault(s => s.ID == appID);
                if (app == null) return;
                app.ImagePath = fileName;
                db.SaveChanges();
            }
        }
    }
}
