using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAF.DataAccess;

namespace DAF.Business
{
    public class FeaturesManager : ManagerBase
    {
        public static List<Feature> GetFeatures(long? appID)
        {
            using (var db = CreateDataContext())
            {
                return appID.HasValue ? 
                    db.Features.Where(s => s.ApplicationID == appID).ToList() : 
                    db.Features.Where(s => s.ApplicationID == null).ToList();
            }
        }

        public static bool SaveFeature(Feature feature)
        {
            using (var db = CreateDataContext())
            {
                var featureInDB = db.Features.FirstOrDefault(s => s.ID == feature.ID) ?? new Feature();
                featureInDB.ApplicationID = feature.ApplicationID;
                featureInDB.Description = feature.Description;
                featureInDB.Title = feature.Title;
                if (featureInDB.ID == 0)
                {
                    db.Features.Add(featureInDB);
                }
                try
                {
                    db.SaveChanges();
                    feature.ID = featureInDB.ID;
                    return true;
                }
                catch (Exception ex)
                {
                    //todo: log
                    return false;
                }
            }
        }

        public static Feature GetFeature(int id)
        {
            using (var db = CreateDataContext())
            {
                return db.Features.FirstOrDefault(s => s.ID == id);
            }
        }

        public static void UpdateFeatureImage(long id, string imageName)
        {
            using (var db = CreateDataContext())
            {
                var feature = db.Features.Single(s => s.ID == id);
                feature.ImageName = imageName;
                db.SaveChanges();
            }
        }

        public static bool DeleteFeature(long id)
        {
            using (var db = CreateDataContext())
            {
                var feature = db.Features.Single(s => s.ID == id);
                db.Features.Remove(feature);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    //todo: log
                    return false;
                }
            }
        }
    }
}
