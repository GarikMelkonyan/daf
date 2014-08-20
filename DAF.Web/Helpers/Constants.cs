using System;
using System.Web;

namespace DAF.Web.Helpers
{
    public class Constants
    {
        static Constants()
        {
            BodyImagesFolderPath = "~/BodyImages/";
            BodyImagesFolderPhisicalPath = HttpContext.Current.Server.MapPath("~/BodyImages") + "\\";
        }

        #region Request Items
        public const string RQ_Page = "page";
        public const string RQ_NewID = "f_new";
        public const string RQ_Language = "language";
        public const string RQ_ERROR_ID = "erid";
        public const string RQ_MESSAGE_ID = "mid";
        public const string RQ_TEXT_CONTENT_ID = "tce";
        public const string RQ_ITEM_ID = "ii";
        public const string RQ_VOTE_ID = "vid";
        public const string RQ_COMMAND_ADD = "Add";
        public const string RQ_VIDEO_ID = "vid";
        public const string RQ_URL_REFERRER = "rurl";
        public const string RQ_PARTNER_ID = "pi";
        public const string RQ_Estate = "estate";
        public const string RQ_RealEstates = "real_estate";
        public const string RQ_PageIndex = "pind";
        public const string RQ_ApplicationID = "appID";
        public const string RQ_Application = "app";
        #endregion

        #region Session Items
        public const string SS_UserName = "_UserName_";
        public const string SS_CULTURE = "__Culture__";
        public const string SS_CULTURE_NAME = "CultureName";
        public const string SS_Captcha = "captcha";
        public const string SS_Current_User_Email = "__Email__";
        public const string SS_Current_User = "CurrentUser";
        public const string SS_Estates = "estates";
        public const string SS_SearchCriteria = "criteria";
        #endregion

        #region ViewState Items

        public const string VS_QuestionSended = "_qsended_";

        #endregion

        #region Cache Items
        public const string CC_Features = "features";
        public const string CC_TextContents = "TextContents";
        #endregion

        #region Route Items
        public const string RN_Application_View = "application-view";
        #endregion

        #region Other Items
        public const string LanguageID = "LanguageID";
        public const string ROLE_ADMINISTRATOR = "Admin";
        public const string DateFormat = "dd.MM.yyyy";
        public static readonly string BodyImagesFolderPhisicalPath;
        public static readonly string BodyImagesFolderPath;
        

        public const string DefaultImageURL = @"~/images/ImageNA.png";

        public const string CK_VOTE = "_ckv_";
        public const string CommandAdd = "Add";
        public const string CommandEdit = "Edit";
        public const string CommandDelete = "Delete";

        public static string NewsImagesFolderPath
        {
            get { return @"~\NewsImages\"; }
        }

        public static string NewsImagesFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\NewsImages") + "\\"; }
        }

        public static string UncheckedImagesFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\UncheckedImages") + "\\"; }
        }

        public static string DocumentsFolderPath
        {
            get { return @"~\Documents\"; }
        }

        public static string DocumentsFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\Documents") + "\\"; }
        }

        public static string DemosFolderPath
        {
            get { return @"~\Demos\"; }
        }

        public static string DemosFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\Demos") + "\\"; }
        }

        public static string FeatureImagesFolderPath
        {
            get { return @"~\FeatureImages\"; }
        }

        public static string FeatureImagesFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\FeatureImages") + "\\"; }
        }
        
        public static string ImagesFolderPath
        {
            get { return @"~\EstateImages\"; }
        }

        public static string ApplicationImagesFolderPath
        {
            get { return @"~\ApplicationImages\"; }
        }

        public static string ApplicationImagesFolderPhisicalPath
        {
            get { return HttpContext.Current.Server.MapPath(@"~\ApplicationImages") + "\\"; }
        }
        
        public const string YouTubePath = "http://www.youtube.com/v/";
        public const string InfoMail = @"info@garikmelkonyan.com";
        #endregion
    }
}