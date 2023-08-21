using System.Linq.Expressions;

namespace Specification.Infrastucture
{
    public class Spec<T> : SpecBase
    {
        // Represents the Expression Tree evaluating the Specification
        public Expression<Func<T, bool>> ExpressionTree { get; }

        public Spec(Expression<Func<T, bool>> expression)
        {
            ExpressionTree = expression;
        }

        // Performs a short circuiting conditional AND operation between the current Expression Tree and the given Expression (i.e: If the first operator evaluates to false, the second operator is not evaluated and false is returned)
        // returns: A Specification with an Expression Tree representing the short circuiting conditional AND operation between the two trees 
        public Spec<T> AndAlso(Expression<Func<T, bool>> expression)
        {
            if (expression == default(Expression<Func<T, bool>>))
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.AndAlso(ExpressionTree.Body, expression.Body)));
        }

        // Performs a short circuiting conditional AND operation between the current Expression Tree and the given Specification's Expression Tree (i.e: If the first operator evaluates to false, the second operator is not evaluated and false is returned)
        // returns: A Specification with an Expression Tree representing the short circuiting conditional AND operation between the two trees
        public Spec<T> AndAlso(Spec<T> target)
        {
            if (target == default(Spec<T>))
            {
                throw new ArgumentNullException(nameof(target));
            }

            return AndAlso(target.ExpressionTree);
        }

        // Performs a non-short-circuiting conditional AND operation between the current Expression Tree and the given Expression (i.e: Both expressions are always evaluated)
        // returns: A Specification with an Expression Tree representing the non-short-circuiting conditional AND operation between the two trees
        public Spec<T> And(Expression<Func<T, bool>> expression)
        {
            if (expression == default(Expression<Func<T, bool>>))
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.And(ExpressionTree.Body, expression.Body)));
        }

        // Performs a non-short-circuiting conditional AND operation between the current Expression Tree and the given Specification's Expression Tree (i.e: Both expressions are always evaluated)
        // returns: A Specification with an Expression Tree representing the non-short-circuiting conditional AND operation between the two trees
        public Spec<T> And(Spec<T> target)
        {
            if (target == default(Spec<T>))
            {
                throw new ArgumentNullException(nameof(target));
            }

            return And(target.ExpressionTree);
        }

        // Performs a short-circuiting conditional OR operation between the current Expression Tree and the given Expression (i.e: If the first operator evaluates to true, the second operator is not evaluated and true is returned)
        // returns: A Specification with an Expression Tree representing the short-circuiting conditional OR operation between the two trees
        public Spec<T> OrElse(Expression<Func<T, bool>> expression)
        {
            if (expression == default(Expression<Func<T, bool>>))
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.OrElse(ExpressionTree.Body, expression.Body)));
        }

        // Performs a short-circuiting conditional OR operation between the current Expression Tree and the given Specification's Expression Tree (i.e: If the first operator evaluates to true, the second operator is not evaluated and true is returned)
        // returns: A Specification with an Expression Tree representing the short-circuiting conditional OR operation between the two trees
        public Spec<T> OrElse(Spec<T> target)
        {
            if (target == default(Spec<T>))
            {
                throw new ArgumentNullException(nameof(target));
            }

            return OrElse(target.ExpressionTree);
        }

        // Performs a non-short-circuiting conditional OR operation between the current Expression Tree and the given Expression (i.e: Both expressions are always evaluated)
        // returns: A Specification with an Expression Tree representing the non-short-circuiting conditional OR operation between the two trees
        public Spec<T> Or(Expression<Func<T, bool>> expression)
        {
            if (expression == default(Expression<Func<T, bool>>))
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.Or(ExpressionTree.Body, expression.Body)));
        }

        // Performs a non-short-circuiting conditional OR operation between the current Expression Tree and the given Specification's Expression Tree (i.e: Both expressions are always evaluated)
        // returns: A Specification with an Expression Tree representing the non-short-circuiting conditional OR operation between the two trees
        public Spec<T> Or(Spec<T> target)
        {
            if (target == default(Spec<T>))
            {
                throw new ArgumentNullException(nameof(target));
            }

            return Or(target.ExpressionTree);
        }

        // Performs an Exclusive OR operation between the current Expression Tree and the given Expression
        // returns: A Specification with an Expression Tree representing the Exclusive OR operation between the two trees
        public Spec<T> Xor(Expression<Func<T, bool>> expression)
        {
            if (expression == default(Expression<Func<T, bool>>))
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new Spec<T>(RenameExpressionParameters<T>(Expression.ExclusiveOr(ExpressionTree.Body, expression.Body)));
        }

        // Performs an Exclusive OR operation between the current Expression Tree and the given Specification's Expression Tree
        // returns: A Specification with an Expression Tree representing the Exclusive OR operation between the two trees
        public Spec<T> Xor(Spec<T> target)
        {
            if (target == default(Spec<T>))
            {
                throw new ArgumentNullException(nameof(target));
            }

            return Xor(target.ExpressionTree);
        }

        // Evaluates the Expression Tree against a given argument
        // returns: A boolean indicating whether the argument satisfies the Specification
        public virtual bool IsSatisfied(T arg, params object[] args)
        {
            if (ExpressionTree == default(Expression<Func<T, bool>>))
            {
                throw new Exception("Expression Tree Not Provided.");
            }

            return ExpressionTree.Compile()(arg);
        }
    }
}