using DDDTW.Specification.CSharp.Builder.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public abstract class DynamicSpecification<TEntity, TValue> : QuerySpecification<TEntity>, IDynamicSpecification<TEntity, TValue>
        where TEntity : class
    {
        #region Constructors

        protected DynamicSpecification()
        {
        }

        protected DynamicSpecification(TValue value)
        {
            Set(value);
        }

        #endregion Constructors

        public TValue Value { get; private set; }

        public IDynamicSpecification<TEntity, TValue> Set(TValue value)
        {
            Value = value;
            return this;
        }
    }
}