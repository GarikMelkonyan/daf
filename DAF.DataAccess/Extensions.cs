using System;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace DAF.DataAccess
{
	public static class ObjectQueryExtensions
	{
        public static DbQuery<T> Include<T>(this DbQuery<T> src, Expression<Func<T, object>> fetch)
        {
            if (fetch.Parameters.Count > 1)
                throw new ArgumentException("CreateFetchingStrategyDescription support only one parameter in a dynamic expression!");
            int dot = fetch.Body.ToString().IndexOf(".") + 1;
            string afterFirstDot = fetch.Body.ToString().Remove(0, dot);
            return src.Include(afterFirstDot.Replace(".First()", ""));
        }
	}
}
