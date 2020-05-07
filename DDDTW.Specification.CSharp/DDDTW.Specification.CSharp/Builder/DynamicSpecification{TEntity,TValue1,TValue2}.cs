using DDDTW.Specification.CSharp.Builder.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public abstract class DynamicSpecification<TEntity, TValue1, TValue2> : QuerySpecification<TEntity>, IDynamicSpecification<TEntity, TValue1, TValue2>
        where TEntity : class
    {
        #region Constructors

        protected DynamicSpecification()
        {
        }

        protected DynamicSpecification(TValue1 value1, TValue2 value2)
        {
            Set(value1, value2);
        }

        #endregion Constructors

        #region Properties

        public TValue1 Value1 { get; private set; }

        public TValue2 Value2 { get; private set; }

        #endregion Properties

        public IDynamicSpecification<TEntity, TValue1, TValue2> Set(TValue1 value1, TValue2 value2)
        {
            Value1 = value1;
            Value2 = value2;
            return this;
        }
    }
}