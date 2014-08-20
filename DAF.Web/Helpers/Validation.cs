using System;
using System.IO;

namespace DAF.Web.Helpers
{
	public static class Validation
	{
		public static bool IsNumber(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return false;
			}
			long i;
			return Int64.TryParse(o.ToString(), out i);
		}

		public static bool IsNumeric(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return false;
			}
			double d;
			return Double.TryParse(o.ToString(), out d);
		}

		public static bool IsDateTime(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return false;
			}
			DateTime d;
			return DateTime.TryParse(o.ToString(), out d);
		}

		public static bool IsImage(string FileName)
		{
			if (Path.GetExtension(FileName) == ".jpg" || Path.GetExtension(FileName) == ".bmp" || Path.GetExtension(FileName) == ".gif")
			{
				return true;
			}
			return false;
		}

		public static bool IsRequestParamValid(string param)
		{
			return (!string.IsNullOrEmpty(param) && IsNumber(param));
		}

		internal static bool IsRequestParamValid(string param, out int intParam)
		{
			if (string.IsNullOrEmpty(param))
			{
				intParam = 0;
				return false;
			}
			return int.TryParse(param, out intParam);
		}

		public static int ValidateRequestParam(string param)
		{
			int intParam;
			if(!string.IsNullOrEmpty(param) && int.TryParse(param, out intParam))
			{
				return intParam;
			}
			return 0;
		}
	}
}