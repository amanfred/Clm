using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clm.Extensions
{
	public static class ReflectionExtension
	{
		public static string GetPropertyValue<T>(this T item, string propertyName)
		{
			try
			{
				return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
			}
			catch(Exception e)
			{
				return null;
			}
		}
	}
}
