using System;
using System.Linq.Expressions;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Core
{
    internal class DummySpecification<TEntity> : IQuerySpecification<TEntity>
        where TEntity : class
    {
        public Configuration<TEntity> Internal => new Configuration<TEntity>(this);

        public Expression<Func<TEntity, bool>> AsExpression() => null;

        public Func<TEntity, bool> AsFunc() => null;
    }
}