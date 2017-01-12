using System.Collections.Generic;

namespace CVS.Novologix.TransactionSearch.Models
{
	public class PagingTableResult<T>
	{
		public List<T> Items { get; set; }
		public long TotalCount { get; set; }
	}
}