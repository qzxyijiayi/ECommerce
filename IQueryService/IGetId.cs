using System;
using System.Collections.Generic;
using System.Text;

namespace IQueryService
{
    public interface IGetId
    {
        int GetId(EntityType entityType);
    }
}
