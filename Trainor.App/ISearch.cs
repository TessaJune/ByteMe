using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public interface ISearch
    {
        IEnumerable<ResourceDto> SearchByKeyword(string keyword);
        IEnumerable<ResourceDto> SearchByFilter(string filter);
    }
}