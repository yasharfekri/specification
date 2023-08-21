using System.Linq.Expressions;

namespace Specification.Infrastucture
{
    public abstract class SpecBase
    {

        internal SpecBase() { }

        // Performs a NOT operation on the Expression Tree
        // returns: A Specification with an Expression Tree representing a negation of the original Specification
        public static Spec<T> Not<T>(Spec<T> spec)
        {
            if (spec.ExpressionTree == default(Expression<Func<T, bool>>))
            {
                throw new Exception("Expression Tree Not Provided.");
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.Not(spec.ExpressionTree.Body)));
        }

        protected static Expression<Func<T, bool>> RenameExpressionParameters<T>(Expression expr)
        {
            var param = Expression.Parameter(typeof(T));
            return new ParameterExpressionVisitor(param).Visit(Expression.Lambda<Func<T, bool>>(expr, param))
            as Expression<Func<T, bool>>;
        }
    }
}