using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace DAF.Web.Helpers
{
	public class RequestParameters : NameValueCollection
	{
		public RequestParameters()
		{
		}

		public RequestParameters(NameValueCollection RequestStringParameters)
			: base(RequestStringParameters)
		{ }

		public RequestParameters(string RequestStringParameters)
		{
			if (RequestStringParameters != String.Empty)
			{
				foreach (string str in RequestStringParameters.Split('&'))
				{
					int index = str.IndexOf('=');
					if (index == -1)
					{
						this[str] = String.Empty;
					}
					else
					{
						this[str.Substring(0, index)] = str.Substring(index + 1);
					}
				}
			}

		}

		public override string ToString()
		{
			if (Count == 0)
			{
				return string.Empty;
			}
			StringBuilder sb = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();

			for (bool isNotFirstElement = false; enumerator.MoveNext(); isNotFirstElement = true)
			{
				if (isNotFirstElement)
				{
					sb.Append("&");
				}
				sb.Append(enumerator.Current.ToString());
				sb.Append("=");
				sb.Append(this[enumerator.Current.ToString()]);
			}
			return sb.ToString();
		}

		public void Union(RequestParameters p)
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = p.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string str = enumerator.Current.ToString();
					this[str] = p[str];
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}





	}

	public class URL
	{
		public string Host { get; set; }
		public RequestParameters Parameters { get; set; }

		public URL(string url)
		{
			if (url == null)
			{
				url = string.Empty;
			}
			int index = url.IndexOf('?');
			if (index >= 0)
			{
				Host = url.Substring(0, index);
				Parameters = new RequestParameters(url.Substring(index + 1));
			}
			else
			{
				Host = url;
				Parameters = new RequestParameters();
			}
		}

		public URL(PageNames pageName, FolderNames folderName)
			: this(string.Format("/{0}/{1}", folderName, pageName))
		{ }
		
		public URL(PageNames pageName)
			: this(string.Format("~/{0}", pageName))
		{ }

		public override string ToString()
		{
			string host = Host;
			if (Parameters.Count > 0)
			{
				host = host + "?" + Parameters;
			}
			return host;
		}

		public void Redirect()
		{
			HttpContext.Current.Response.Redirect(this.ToString());
		}
	}
}