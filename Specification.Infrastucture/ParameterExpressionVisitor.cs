using System.Linq.Expressions;

namespace Specification.Infrastucture
{
    internal class ParameterExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _source;

        internal ParameterExpressionVisitor(ParameterExpression source)
        {
            _source = source;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _source;
        }
    }
}
