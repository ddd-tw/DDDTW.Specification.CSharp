using DDDTW.Specification.CSharp.Builder.Interfaces;

namespace DDDTW.Specification.CSharp.Builder
{
    public abstract class DynamicSpecification<TEntity, TValue1, TValue2, TValue3, TValue4> : DynamicSpecification<TEntity, TValue1, TValue2, TValue3>, IDynamicSpecification<TEntity, TValue1, TValue2, TValue3, TValue4>
        where TEntity : class
    {
        #region Constructors

        protected DynamicSpecification()
        {
        }

        protected DynamicSpecification(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
            : base(value1, value2, value3)
        {
            Value4 = value4;
        }

        #endregion Constructors

        public TValue4 Value4 { get; private set; }

        public IDynamicSpecification<TEntity, TValue1, TValue2, TValue3, TValue4> Set(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
        {
            Set(value1, value2, value3);
            Value4 = value4;
            return this;
        }
    }
}