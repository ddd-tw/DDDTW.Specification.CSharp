namespace DDDTW.Specification.CSharp.Core.Interfaces
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Configuration<TEntity> Internal { get; }
    }
}