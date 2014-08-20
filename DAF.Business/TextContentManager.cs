using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DAF.DataAccess;

namespace DAF.Business
{
    public class TextContentManager : ManagerBase
    {
        public static TextContent GetTextContent(string controlName)
        {
            using (var db = CreateDataContext())
            {
                try
                {
                    return db.TextContents.FirstOrDefault(s => s.ControlName == controlName);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static bool UpdateTextContent(TextContent textContent, bool addIfNotExist = true)
        {
            using (var db = CreateDataContext())
            {
                try
                {
                    TextContent contentInDB = db.TextContents.FirstOrDefault(s => s.ControlName == textContent.ControlName);
                    if (contentInDB == null)
                    {
                        if (!addIfNotExist) return true;
                        db.TextContents.Add(textContent);
                    }
                    else
                    {
                        contentInDB.Content = textContent.Content;
                        contentInDB.Title = textContent.Title;
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //todo: log
                    return false;
                }
            }
        }

    }
}
