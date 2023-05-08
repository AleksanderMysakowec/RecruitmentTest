using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTest.RepositoryDirectory
{
    public interface IFindOrder
    {
        public string FindOrders(string numberOrder, DateTime fromDate, DateTime toDate, string[] clientCode);
    }
}
