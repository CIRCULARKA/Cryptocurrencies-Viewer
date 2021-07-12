using System;
using System.Web;

namespace CurrencyViewer
{
	public class ApiException : Exception
	{
		public ApiException(string msg = "") : base(msg) { }
	}
}
