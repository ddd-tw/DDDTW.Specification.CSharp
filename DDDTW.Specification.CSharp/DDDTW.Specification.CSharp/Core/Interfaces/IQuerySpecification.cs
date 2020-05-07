using System;
using System.Linq.Expressions;

namespace DDDTW.Specification.CSharp.Core.Interfaces
{
    public interface IQuerySpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> AsExpression();

        Func<TEntity, bool> AsFunc();
    }
}