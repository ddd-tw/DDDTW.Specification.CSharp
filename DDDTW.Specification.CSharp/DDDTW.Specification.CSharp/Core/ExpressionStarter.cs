using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DDDTW.Specification.CSharp.Core
{
    public class ExpressionStarter<T>
    {
        #region Constructors

        internal ExpressionStarter() : this(false)
        {
        }

        internal ExpressionStarter(bool defaultExpression)
        {
            if (defaultExpression)
                DefaultExpression = f => true;
            else
                DefaultExpression = f => false;
        }

        internal ExpressionStarter(Expression<Func<T, bool>> exp) : this(false)
        {
            _predicate = exp;
        }

        #endregion Constructors

        private Expression<Func<T, bool>> Predicate => (IsStarted || !UseDefaultExpression) ? _predicate : DefaultExpression;

        private Expression<Func<T, bool>> _predicate;

        public bool IsStarted => _predicate != null;

        public bool UseDefaultExpression => DefaultExpression != null;

        public Expression<Func<T, bool>> DefaultExpression { get; set; }

        public Expression<Func<T, bool>> Start(Expression<Func<T, bool>> exp)
        {
            if (IsStarted)
                throw new Exception("Predicate cannot be started again.");

            return _predicate = exp;
        }

        public Expression<Func<T, bool>> Or([NotNull] Expression<Func<T, bool>> expr2)
        {
            return (IsStarted) ? _predicate = Predicate.Or(expr2) : Start(expr2);
        }

        public Expression<Func<T, bool>> And([NotNull] Expression<Func<T, bool>> expr2)
        {
            return (IsStarted) ? _predicate = Predicate.And(expr2) : Start(expr2);
        }

        public override string ToString()
        {
            return Predicate?.ToString();
        }

        #region Implicit Operators

        public static implicit operator Expression<Func<T, bool>>(ExpressionStarter<T> right)
        {
            return right?.Predicate;
        }

        public static implicit operator Func<T, bool>(ExpressionStarter<T> right)
        {
            return right == null ? null : (right.IsStarted || right.UseDefaultExpression) ? right.Predicate.Compile() : null;
        }

        public static implicit operator ExpressionStarter<T>(Expression<Func<T, bool>> right)
        {
            return right == null ? null : new ExpressionStarter<T>(right);
        }

        #endregion Implicit Operators

        public Func<T, bool> Compile()
        {
            return Predicate.Compile();
        }

        public Func<T, bool> Compile(DebugInfoGenerator debugInfoGenerator)
        {
            return Predicate.Compile(debugInfoGenerator);
        }

        public Expression<Func<T, bool>> Update(Expression body, IEnumerable<ParameterExpression> parameters)
        {
            return Predicate.Update(body, parameters);
        }

        public Expression Body => Predicate.Body;

        public ExpressionType NodeType => Predicate.NodeType;

        public ReadOnlyCollection<ParameterExpression> Parameters => Predicate.Parameters;

        public Type Type => Predicate.Type;

        public string Name => Predicate.Name;

        public Type ReturnType => Predicate.ReturnType;

        public bool TailCall => Predicate.TailCall;

        public virtual bool CanReduce => Predicate.CanReduce;
    }
}