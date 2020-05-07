using DDDTW.Specification.CSharp.Builder.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public abstract class DynamicSpecification<TEntity, TValue1, TValue2, TValue3> : DynamicSpecification<TEntity, TValue1, TValue2>, IDynamicSpecification<TEntity, TValue1, TValue2, TValue3>
        where TEntity : class
    {
        #region Constructors

        protected DynamicSpecification()
        {
        }

        protected DynamicSpecification(TValue1 value1, TValue2 value2, TValue3 value3)
            : base(value1, value2)
        {
            Value3 = value3;
        }

        #endregion Constructors

        public TValue3 Value3 { get; private set; }

        public IDynamicSpecification<TEntity, TValue1, TValue2, TValue3> Set(TValue1 value1, TValue2 value2, TValue3 value3)
        {
            Set(value1, value2);
            Value3 = value3;
            return this;
        }
    }
}