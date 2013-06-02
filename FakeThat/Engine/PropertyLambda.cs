using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace FakeThat.Engine
{
    public class PropertyLambda<T>
    {
        private readonly string propertyName;

        public static PropertyLambda<T> Create<TRet>(Expression<Func<TRet>> expr)
        {
            return new PropertyLambda<T>(expr);
        }

        public PropertyLambda(LambdaExpression propertyLookupExpression)
        {
            if (propertyLookupExpression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception(@"Expected an expression of the form ""o => o.[some property]"" for the second argument.");
            }

            // get the "[closure object].o.[some property]" part (i.e. drop the "() =>")
            var expression = (MemberExpression)propertyLookupExpression.Body;
            propertyName = expression.Member.Name;
        }

        public MethodInfo Getter
        {
            get { return typeof(T).GetMethod("get_" + propertyName); }
        }

        public MethodInfo Setter
        {
            get { return typeof(T).GetMethod("set_" + propertyName); }
        }
    }
}
