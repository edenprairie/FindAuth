﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CVS.Novologix.TransactionSearch.DomainModel;
using CVS.Novologix.TransactionSearch.SearchProvider;

namespace CVS.Novologix.TransactionSearch.Controllers
{
	[RoutePrefix("Search")]
	public class SearchController : Controller
	{
		readonly ISearchProvider _searchProvider = new ElasticsearchProvider();

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[Route("Search")]
		public JsonResult Search(string term)
{
			return Json(_searchProvider.QueryString<StateProvince>(term), "AuthList", JsonRequestBehavior.AllowGet);
		}
    
		[Route("GetAuth")]
		public JsonResult GetAuth(string authSearchText, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
		{
			try
			{
				var data = _searchProvider.GetAllAuth(authSearchText, jtStartIndex, jtPageSize, jtSorting);
                return Json(new { Result = "OK", Records = data.Items, TotalRecordCount = data.TotalCount });
			}
			catch (Exception ex)
			{
				return Json(new { Result = "ERROR", Message = ex.Message });
			}
		}

        [Route("GetAuthByDate")]
        public JsonResult GetAuthByDate(string authSearchText, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int day = System.Convert.ToInt32(authSearchText); 
                var data = _searchProvider.GetAuthByDate(day, jtStartIndex, jtPageSize, jtSorting);
                return Json(new { Result = "OK", Records = data.Items, TotalRecordCount = data.TotalCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



        [Route("CreateAddressForStateProvince")]
		public JsonResult CreateAddressForStateProvince(Address address, string stateprovinceid)
		{
			try
			{
				address.StateProvinceID = Convert.ToInt32(stateprovinceid);
				_searchProvider.AddUpdateDocument(address);
				return Json(new { Result = "OK", Record = address });
			}
			catch (Exception ex)
			{
				return Json(new { Result = "ERROR", Message = ex.Message });
			}
		}

		[Route("UpdateAddressForStateProvince")]
		public JsonResult UpdateAddressForStateProvince(Address address)
		{
			try
			{
				_searchProvider.UpdateAddresses(address.StateProvinceID, new List<Address> { address });
				return Json(new { Result = "OK", Records = address });
			}
			catch (Exception ex)
			{
				return Json(new { Result = "ERROR", Message = ex.Message });
			}
		}

		[HttpPost]
		[Route("DeleteAddress")]
		public ActionResult DeleteAddress(int addressId, int stateprovinceid)
		{
			_searchProvider.DeleteAddress(addressId, stateprovinceid);
			return Json(new { Result = "OK"});
		}
	}
}