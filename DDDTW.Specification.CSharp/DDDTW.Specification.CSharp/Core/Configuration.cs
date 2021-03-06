﻿using System.Collections.Generic;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Core
{
    public sealed class Configuration<TEntity> : IOrderedSpecification<TEntity>
        where TEntity : class
    {
        #region Constructors

        public Configuration(IQuerySpecification<TEntity> querySpecification)
        {
            OrderSpecifications = new List<IOrderSpecification<TEntity>>();
            QuerySpecification = querySpecification;
        }

        public Configuration(IOrderSpecification<TEntity> orderSpecification)
        {
            OrderSpecifications = new List<IOrderSpecification<TEntity>> { orderSpecification };
            QuerySpecification = new DummySpecification<TEntity>();
        }

        public Configuration(IQuerySpecification<TEntity> querySpecification, List<IOrderSpecification<TEntity>> orderSpecifications)
        {
            OrderSpecifications = orderSpecifications;
            QuerySpecification = querySpecification;
        }

        #endregion Constructors

        #region Properties

        public IQuerySpecification<TEntity> QuerySpecification { get; set; }

        public List<IOrderSpecification<TEntity>> OrderSpecifications { get; }

        public int? Skip { get; set; }

        public int? Take { get; set; }

        public Configuration<TEntity> Internal => this;

        #endregion Properties

        public ISpecification<TEntity> Clone()
        {
            return new Configuration<TEntity>(QuerySpecification, OrderSpecifications)
            {
                Skip = Skip,
                Take = Take
            };
        }
    }
}