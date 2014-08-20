namespace DAF.Web.Helpers
{
	public enum Errors
	{
		InvalidParameters=1,
		ApplicationNotFound,
		UnknownError,
	};

	public enum PageNames
	{
		Default,
		Contacts,
		ErrorPage,
		Login,
		TextContentEdit,
	    FeatureDetail,
	    FeaturesManagement,
	    ApplicationsManagement,
	    ApplicationDetails
	};

	public enum FolderNames
	{
		Admin = 1,
		Account,
	};

	public enum ImageTypes {  jpg = 1, JPG , JPEG, jpeg, PNG, png, gif, GIF, BMP, bmp };
}