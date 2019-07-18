using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TEntityId"></typeparam>
    public class Entity<TEntityId> : IEntity<TEntityId>
    {
        public TEntityId Id { get; set; }

        public override int GetHashCode()
        {
            if (Id == null) return 0;
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this != obj) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (this.Id.ToString() != ((Entity<TEntityId>)obj).Id.ToString()) return false;
            return true;
        }
    }

    /// <summary>
    /// 实体基类，Id为int类型
    /// </summary>
    public class Entity : Entity<int>, IEntity
    {

    }
}
