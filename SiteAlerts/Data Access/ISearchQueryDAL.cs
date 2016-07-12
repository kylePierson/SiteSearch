using SiteAlerts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAlerts.Data_Access
{
    interface ISearchQueryDAL
    {
        List<SearchQuery> GetAllSearchQueries(int userID);
        void AddSearchQuery(SearchQuery newSearchQuery);
        void RemoveSearchQuery(int searchQueryID);
    }
}
