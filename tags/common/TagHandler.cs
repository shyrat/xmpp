// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="TagHandler.cs">
//   
// </copyright>
// <summary>
//   The tag handler.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace XMPP.Tags
{
    public class TagHandler<TReturn>
    {
        private readonly TReturn _defaultReturn;

        public TagHandler()
        {
            _defaultReturn = default(TReturn);
        }

        public TagHandler(TReturn defaultReturn)
        {
            _defaultReturn = defaultReturn;
        }

        public TReturn Process(Tag tag)
        {
            Type tagType = tag.GetType();

            foreach (MethodInfo method in GetType().GetTypeInfo().DeclaredMethods)
            {
                foreach (ParameterInfo parameterInfo in method.GetParameters())
                {
                    if (parameterInfo.ParameterType == tagType)
                        return (TReturn) method.Invoke(this, new object[] {tag});
                }
            }

            return _defaultReturn;
        }
    }
}