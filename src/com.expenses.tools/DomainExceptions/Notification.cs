using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.expenses.tools.DomainExceptions
{
    public class Notification
    {
		public string Key { get; }
		public string Message { get; }

		public Notification(string key, string message)
		{
			Key = key;
			Message = message;
		}

		public Notification(string message)
		{			
			Message = message;
		}
	}
}
