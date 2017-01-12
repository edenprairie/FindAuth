using System.Collections.Generic;
using System.Web.Mvc;
using CVS.Novologix.TransactionSearch.DomainModel;
using CVS.Novologix.TransactionSearch.Models;

namespace CVS.Novologix.TransactionSearch.SearchProvider
{
	public interface ISearchProvider
	{
		IEnumerable<T> QueryString<T>(string term);

		void AddUpdateDocument(Address address);
		void UpdateAddresses(long stateProvinceId, List<Address> addresses);
		void DeleteAddress(int addressId, int stateprovinceid);
		List<SelectListItem> GetAllStateProvinces();
		PagingTableResult<Auth> GetAllAuth(string stateprovinceid, int jtStartIndex, int jtPageSize, string jtSorting);
        PagingTableResult<Auth> GetAuthByDate(int days, int jtStartIndex, int jtPageSize, string jtSorting);
    }
}