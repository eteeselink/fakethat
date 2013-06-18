using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace FakeThat.Engine
{
    /// <summary>
    /// Encapsulates a lambda expression that is used to identify a property
    /// (e.g. an expression like `() => fake.Object.SomeProperty`).
    /// </summary>
    public class PropertyLambda<T>
    {
        private readonly string propertyName;

        /// <summary>
        /// Helper method to allow creating PropertyLambda{T} objects without explicitly specifying T.
        /// </summary>
        public static PropertyLambda<T> Create<TRet>(Expression<Func<TRet>> expr)
        {
            return new PropertyLambda<T>(expr);
        }

        private PropertyLambda(LambdaExpression propertyLookupExpression)
        {
            if (propertyLookupExpression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception(@"Expected an expression of the form ""o => o.[some property]"" for the second argument.");
            }

            // get the "[closure object].o.[some property]" part (i.e. drop the "() =>")
            var expression = (MemberExpression)propertyLookupExpression.Body;
            propertyName = expression.Member.Name;
        }

        /// <summary>
        /// Gets the MethodInfo for this property's getter.
        /// </summary>
        public MethodInfo Getter
        {
            get { return typeof(T).GetMethod("get_" + propertyName); }
        }

        /// <summary>
        /// Gets the MethodInfo for this property's setter.
        /// </summary>
        public MethodInfo Setter
        {
            get { return typeof(T).GetMethod("set_" + propertyName); }
        }
    }
}
