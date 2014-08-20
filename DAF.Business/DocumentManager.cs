using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAF.DataAccess;

namespace DAF.Business
{
    public class DocumentManager : ManagerBase
    {
        public static List<Document> GetDocuments()
        {
            using (var db = CreateDataContext())
            {
                return db.Documents.ToList();
            }
        }

        public static IDocumentDemo GetDocument(long documentID)
        {
            using (var db = CreateDataContext())
            {
                return db.Documents.FirstOrDefault(s => s.ID == documentID);
            }
        }

        public static void SaveDocument(IDocumentDemo document)
        {
            using (var db = CreateDataContext())
            {
                var doc = db.Documents.FirstOrDefault(s => s.ID == document.ID) ?? new Document();
                doc.Title = document.Title;
                doc.DocumentPath = document.Path;
                if (doc.ID == 0)
                {
                    db.Documents.Add(doc);
                }
                db.SaveChanges();
            }
        }

        public static string DeleteDocument(long id)
        {
            using (var db = CreateDataContext())
            {
                var doc = db.Documents.FirstOrDefault(s => s.ID == id);
                if (doc == null) return string.Empty;
                db.Documents.Remove(doc);
                db.SaveChanges();
                return doc.DocumentPath;
            }
        }

        public static List<Document> GetDocuments(long appID)
        {
            using (var db = CreateDataContext())
            {
                return db.ApplicationDocuments.Where(s => s.ApplicationID == appID).Select(s => s.Document).ToList();
            }
        }
    }
}
