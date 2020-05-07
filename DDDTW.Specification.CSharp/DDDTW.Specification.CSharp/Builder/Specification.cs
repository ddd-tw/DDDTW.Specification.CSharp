﻿using System;
using System.Linq;
using System.Linq.Expressions;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public class Specification<TEntity> : QuerySpecification<TEntity>
        where TEntity : class
    {
        #region Constructors

        public Specification()
        {
        }

        public Specification(Expression<Func<TEntity, bool>> expression)
            : base(expression)
        {
        }

        #endregion Constructors

        public static ISpecification<TEntity> New()
        {
            return new Specification<TEntity>();
        }

        public static ISpecification<TEntity> New(Expression<Func<TEntity, bool>> expression)
        {
            return new Specification<TEntity>(expression);
        }

        public static ISpecification<TEntity> All(params ISpecification<TEntity>[] specifications)
        {
            return specifications.Aggregate(New(), (current, specification) => current.And(specification));
        }

        public static ISpecification<TEntity> None(params ISpecification<TEntity>[] specifications)
        {
            return specifications.Aggregate(New(), (current, specification) => current.And(specification)).Not();
        }

        public static ISpecification<TEntity> Any(params ISpecification<TEntity>[] specifications)
        {
            return specifications.Aggregate(New(), (current, specification) => current.Or(specification));
        }
    }
}