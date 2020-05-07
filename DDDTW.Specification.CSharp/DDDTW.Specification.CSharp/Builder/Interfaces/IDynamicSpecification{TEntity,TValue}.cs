using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Builder.Interfaces
{
    public interface IDynamicSpecification<TEntity, out TValue> : ISpecification<TEntity>
        where TEntity : class
    {
        TValue Value { get; }
    }
}