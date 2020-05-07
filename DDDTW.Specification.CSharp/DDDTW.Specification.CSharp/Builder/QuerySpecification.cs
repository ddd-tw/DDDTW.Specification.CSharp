using System;
using System.Linq.Expressions;
using DDDTW.Specification.CSharp.Core;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public abstract class QuerySpecification<TEntity> : IQuerySpecification<TEntity>
        where TEntity : class
    {
        #region Fields

        private readonly Expression<Func<TEntity, bool>> _expression;
        private Func<TEntity, bool> _func;

        #endregion Fields

        #region Constructors

        protected QuerySpecification()
        {
        }

        protected QuerySpecification(Expression<Func<TEntity, bool>> expression)
        {
            _expression = expression;
        }

        #endregion Constructors

        public Configuration<TEntity> Internal => new Configuration<TEntity>(this);

        public virtual Expression<Func<TEntity, bool>> AsExpression()
        {
            return _expression;
        }

        public Func<TEntity, bool> AsFunc()
        {
            var expression = AsExpression();
            if (expression == null)
            {
                return null;
            }

            return _func ?? (_func = expression.Compile());
        }
    }
}