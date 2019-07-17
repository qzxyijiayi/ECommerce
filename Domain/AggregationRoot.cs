﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 聚合根基类
    /// </summary>
    /// <typeparam name="TAggregationRootId"></typeparam>
    public abstract class AggregationRoot<TAggregationRootId> : Entity<TAggregationRootId>, IAggregationRoot<TAggregationRootId>
    {
        public TAggregationRootId AggregationRootId { get; protected set; }
        public new TAggregationRootId Id { get; set; }

        protected AggregationRoot(TAggregationRootId id)
        {
            AggregationRootId = id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this != obj) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (this.AggregationRootId.ToString() != ((AggregationRoot<TAggregationRootId>)obj).AggregationRootId.ToString()) return false;
            return true;
        }

    }

    /// <summary>
    /// 聚合根基类，AggregationRootId为int类型
    /// </summary>
    public abstract class AggregationRoot : AggregationRoot<int>, IAggregationRoot
    {
        public new int Id { get; set; }

        protected AggregationRoot(int id) : base(id) { }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this != obj) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (this.AggregationRootId != ((AggregationRoot)obj).AggregationRootId) return false;
            return true;
        }

    }
}
