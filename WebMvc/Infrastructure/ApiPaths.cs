using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Event
        {
            public static string GetAllEventItems(string baseUri,int page,int take, int? location, int? type)
            { 
                var filterQs = string.Empty;
                if (location.HasValue||type.HasValue)
                {
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/location/{locationQs}";
                }
            
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}EventTypes";
            }

            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}EventLocations";
            }
        }
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            //Delete basket
            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
        public static class Order
        {
            public static string GetOrder(string baseuri, string orderId)
            {
                return $"{baseuri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }

    }
}
