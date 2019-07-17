using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEntity<TEntityId>
    {
        TEntityId Id { get; set; }
    }

    public interface IEntity : IEntity<int>
    {
    }
}
