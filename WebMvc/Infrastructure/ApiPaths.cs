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

    }
}
