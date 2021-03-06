﻿using System.Collections.Generic;
using System.Linq;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public static class LinqExtensions
    {
        #region Where

        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query : query.Where(expression);
        }

        public static IEnumerable<TEntity> Where<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection : collection.Where(func);
        }

        #endregion Where

        #region Any

        public static bool Any<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.Any() : query.Any(expression);
        }

        public static bool Any<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.Any() : collection.Any(func);
        }

        #endregion Any

        #region All

        public static bool All<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null || query.All(expression);
        }

        public static bool All<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null || collection.All(func);
        }

        #endregion All

        #region Count

        public static int Count<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.Count() : query.Count(expression);
        }

        public static int Count<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.Count() : collection.Count(func);
        }

        #endregion Count

        #region First

        public static TEntity First<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.First() : query.First(expression);
        }

        public static TEntity First<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.First() : collection.First(func);
        }

        #endregion First

        #region FirstOrDefault

        public static TEntity FirstOrDefault<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.FirstOrDefault() : query.FirstOrDefault(expression);
        }

        public static TEntity FirstOrDefault<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.FirstOrDefault() : collection.FirstOrDefault(func);
        }

        #endregion FirstOrDefault

        #region Single

        public static TEntity Single<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.Single() : query.Single(expression);
        }

        public static TEntity Single<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.Single() : collection.Single(func);
        }

        #endregion Single

        #region SingleOrDefault

        public static TEntity SingleOrDefault<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var expression = specification.Internal.QuerySpecification.AsExpression();
            return expression == null ? query.SingleOrDefault() : query.SingleOrDefault(expression);
        }

        public static TEntity SingleOrDefault<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var func = specification.Internal.QuerySpecification.AsFunc();
            return func == null ? collection.SingleOrDefault() : collection.SingleOrDefault(func);
        }

        #endregion SingleOrDefault
    }
}