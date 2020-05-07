using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Builder.Interfaces
{
    public interface IDynamicSpecification<TEntity, out TValue1, out TValue2> : IQuerySpecification<TEntity>
        where TEntity : class
    {
        TValue1 Value1 { get; }

        TValue2 Value2 { get; }
    }
}