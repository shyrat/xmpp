// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="TagRegistry.cs">
//   
// </copyright>
// <summary>
//   The xmpp tag attribute.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using XMPP.Tags;

namespace XMPP.Registries
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class XmppTagAttribute : Attribute
    {
        public readonly XName Name;
        public readonly Type Type;

        public XmppTagAttribute(Type namespaceType, Type elementType)
        {
            if (namespaceType != null && namespaceType.Name == "Namespace")
            {
                foreach (FieldInfo field in namespaceType.GetTypeInfo().DeclaredFields)
                {
                    if (field.IsStatic && field.Name == elementType.Name)
                    {
                        Name = (XName)field.GetValue(null);
                    }
                }

                Type = elementType;
            }
        }

        public string LocalName
        {
            get { return Name.LocalName; }
        }

        public string Namespace
        {
            get { return Name.NamespaceName; }
        }
    }

    public class TagRegistry
    {
        private readonly Dictionary<XName, Type> _registeredItems = new Dictionary<XName, Type>();

        public TagRegistry()
        {
            AddAssembly(typeof(Client).GetTypeInfo().Assembly);
        }

        public void AddAssembly(Assembly assembly)
        {
            XmppTagAttribute[] tags = GetAttributes<XmppTagAttribute>(assembly);
            foreach (XmppTagAttribute tag in tags)
            {
                _registeredItems.Add(tag.Name, tag.Type);
            }
        }

        public XName GetName(Type type)
        {
            if (_registeredItems.ContainsValue(type))
            {
                foreach (var element in _registeredItems)
                {
                    if (element.Value == type)
                        return element.Key;
                }
            }

            return null;
        }

        public Tag GetTag(string name, string ns)
        {
            return GetTag(XName.Get(name, ns));
        }

        public Tag GetTag(XName name)
        {
            try
            {
                Type type;
                if (_registeredItems.TryGetValue(name, out type))
                {
                    // Try doc and qname constructor
                    ConstructorInfo ctorName = GetConstructor(type, new[] { name.GetType() });
                    if (ctorName != null)
                        return ctorName.Invoke(new object[] { name }) as Tag;

                    // Try empty constructor
                    ConstructorInfo ctorDefault = GetConstructor(type, new Type[] { });
                    if (ctorDefault != null)
                        return ctorDefault.Invoke(new object[] { }) as Tag;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public Tag GetTag(XElement element)
        {
            try
            {
                Type type;

                bool gotType = _registeredItems.TryGetValue(element.Name, out type);

                if (gotType)
                {
                    ConstructorInfo ctorName = GetConstructor(type, new[] { element.GetType() });
                    if (ctorName != null)
                        return ctorName.Invoke(new object[] { element }) as Tag;

                    ConstructorInfo ctorDefault = GetConstructor(element.GetType(), new[] { typeof(Tag) });
                    if (ctorDefault != null)
                        return ctorDefault.Invoke(new object[] { element }) as Tag;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        protected TE[] GetAttributes<TE>(Assembly assembly)
        {
            var returns = new List<TE>();
            foreach (TypeInfo type in assembly.DefinedTypes)
            {
                var attributes = (IEnumerable<TE>)type.GetCustomAttributes(typeof(TE), false);

                foreach (TE attribute in attributes)
                {
                    returns.Add(attribute);
                }
            }

            return returns.ToArray();
        }

        public ConstructorInfo GetConstructor(Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors.FirstOrDefault();
        }

        public ConstructorInfo GetConstructor(Type type, bool isStatic, bool isPrivate)
        {
            IEnumerable<ConstructorInfo> results = type.GetTypeInfo().DeclaredConstructors;

            foreach (ConstructorInfo result in results)
            {
                if (result.IsStatic == isStatic && result.IsPrivate == isPrivate)
                    return result;
            }

            return null;
        }

        public ConstructorInfo GetConstructor(Type type, Type[] parameters)
        {
            IEnumerable<ConstructorInfo> results = from constructor in type.GetTypeInfo().DeclaredConstructors
                let constructorParameters = constructor.GetParameters().Select(_ => _.ParameterType).ToArray()
                where constructorParameters.Length == parameters.Length &&
                      !constructorParameters.Except(parameters).Any() &&
                      !parameters.Except(constructorParameters).Any()
                select constructor;

            return results.FirstOrDefault();
        }
    }
}