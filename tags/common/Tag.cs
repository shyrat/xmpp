// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Tag.cs">
//   
// </copyright>
// <summary>
//   The tag.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using XMPP.Registries;
using XMPP.Tags.Streams;

namespace XMPP.Tags
{
    public class Tag : XElement
    {
        private static int _packetCounter;

        protected Tag(XName identity) : base(identity)
        {
        }

        protected Tag(XElement other) : base(other)
        {
        }

        public byte[] Bytes
        {
            get { return System.Convert.FromBase64String(Value); }
            set { Value = System.Convert.ToBase64String(value); }
        }

        public static string NextId()
        {
            return string.Format("U{0}", Interlocked.Increment(ref _packetCounter));
        }

        public static implicit operator string(Tag tag)
        {
            return tag.ToString();
        }

        public object GetAttributeValue(XName name)
        {
            XAttribute attr = Attribute(name);
            if (attr != null)
                return attr.Value;
            return default(object);
        }

        public int? GetAttributeValueAsInt(XName name)
        {
            object value = GetAttributeValue(name);

            if (null != value)
            {
                int result;
                if (int.TryParse(value.ToString(), out result))
                {
                    return result;
                }
            }

            return null;
        }

        public long? GetAttributeValueAsLong(XName name)
        {
            object value = GetAttributeValue(name);

            if (null != value)
            {
                long result;
                if (long.TryParse(value.ToString(), out result))
                {
                    return result;
                }
            }

            return null;
        }

        public bool? GetAttributeValueAsBool(XName name)
        {
            object value = GetAttributeValue(name);

            if (null != value)
            {
                bool result;
                if (bool.TryParse(value.ToString(), out result))
                {
                    return result;
                }
            }

            return null;
        }

        public T GetAttributeEnum<T>(XName name)
        {
            var attr = (string) GetAttributeValue(name);
            if (attr != null)
            {
                Type enumType = typeof(T);
                foreach (string item in Enum.GetNames(enumType))
                {
                    EnumMemberAttribute enumMember =
                        ((EnumMemberAttribute[])
                            enumType.GetRuntimeField(item).GetCustomAttributes(typeof(EnumMemberAttribute), true))
                            .SingleOrDefault();
                    if (enumMember != null && enumMember.Value == attr)
                    {
                        return (T) Enum.Parse(enumType, item);
                    }
                }

                return (T) Enum.Parse(typeof(T), attr, true);
            }

            return default(T);
        }

        public void SetAttributeEnum<T>(XName name, object value)
        {
            object obj = Enum.ToObject(typeof(T), value);

            IDictionary<string, MemberInfo> members =
                obj.GetType().GetTypeInfo().DeclaredMembers.ToDictionary(c => c.Name);

            MemberInfo member;
            if (!members.TryGetValue(obj.ToString(), out member))
            {
                throw new InvalidOperationException();
            }

            IDictionary<Type, CustomAttributeData> customAttributes =
                member.CustomAttributes.ToDictionary(c => c.AttributeType);

            CustomAttributeData enumMemberAttribute;
            if (customAttributes.TryGetValue(typeof(EnumMemberAttribute), out enumMemberAttribute))
            {
                IDictionary<string, CustomAttributeNamedArgument> args =
                    enumMemberAttribute.NamedArguments.ToDictionary(c => c.MemberName);

                CustomAttributeNamedArgument arg;
                if (args.TryGetValue("Value", out arg))
                {
                    SetAttributeValue(name, arg.TypedValue.Value);
                    return;
                }
            }

            SetAttributeValue(name, ((T) value).ToString());
        }

        public new IEnumerable<Tag> Descendants()
        {
            return Descendants<Tag>();
        }

        public IEnumerable<T> Descendants<T>() where T : XElement
        {
            return base.Descendants().Select(descendant => Convert<T>(descendant));
        }

        public new IEnumerable<Tag> Descendants(XName name)
        {
            return Descendants<Tag>(name);
        }

        public IEnumerable<T> Descendants<T>(XName name) where T : XElement
        {
            return base.Descendants(name).Select(descendant => Convert<T>(descendant));
        }

        public new Tag Element(XName name)
        {
            return Element<Tag>(name);
        }

        public T Element<T>(XName name) where T : XElement
        {
            return Convert<T>(base.Element(name));
        }

        public new IEnumerable<XElement> Elements()
        {
            return Elements<Tag>();
        }

        public IEnumerable<T> Elements<T>() where T : XElement
        {
            return base.Elements().Select(element => Convert<T>(element));
        }

        public new IEnumerable<Tag> Elements(XName name)
        {
            return Elements<Tag>(name);
        }

        public IEnumerable<T> Elements<T>(XName name) where T : XElement
        {
            return base.Elements(name).Select(element => Convert<T>(element));
        }

        public new IEnumerable<Tag> AncestorsAndSelf()
        {
            return AncestorsAndSelf<Tag>();
        }

        public IEnumerable<T> AncestorsAndSelf<T>() where T : XElement
        {
            return base.AncestorsAndSelf().Select(ancestor => Convert<T>(ancestor));
        }

        public new IEnumerable<Tag> AncestorsAndSelf(XName name)
        {
            return AncestorsAndSelf<Tag>(name);
        }

        public IEnumerable<T> AncestorsAndSelf<T>(XName name) where T : XElement
        {
            return base.AncestorsAndSelf(name).Select(ancestor => Convert<T>(ancestor));
        }

        public new IEnumerable<Tag> DescendantsAndSelf()
        {
            return DescendantsAndSelf<Tag>();
        }

        public IEnumerable<T> DescendantsAndSelf<T>() where T : XElement
        {
            return base.DescendantsAndSelf().Select(descendant => Convert<T>(descendant));
        }

        public new IEnumerable<Tag> DescendantsAndSelf(XName name)
        {
            return DescendantsAndSelf<Tag>(name);
        }

        public IEnumerable<T> DescendantsAndSelf<T>(XName name) where T : XElement
        {
            return base.DescendantsAndSelf(name).Select(descendant => Convert<T>(descendant));
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

        private TReturn Convert<TReturn>(XElement element) where TReturn : XElement
        {
            if (element == null)
                return default(TReturn);

            ConstructorInfo ctor = GetConstructor(typeof(TReturn), new[] {typeof(XElement)});
            if (ctor != null)
                return (TReturn) ctor.Invoke(new object[] {element});
            return default(TReturn);
        }

        public static Tag Get(XElement element)
        {
            Tag tag = Static.TagRegistry.GetTag(element);

            return tag;
        }

        public static Tag Get(XName name)
        {
            Tag tag = Static.TagRegistry.GetTag(name);

            return tag;
        }

        public static Tag Get(string xml)
        {
            try
            {
                var document = new XDocument();
                var stringReader = new StringReader(xml);
                XmlReader xmlReader = XmlReader.Create(stringReader, Static.Settings, Static.Context);

                xmlReader.MoveToContent();
                while (xmlReader.ReadState != ReadState.EndOfFile)
                {
                    document.Add(ReadFrom(xmlReader));
                }

                FixNs(document.Root);

                return Get(document.Root);
            }
            catch
            {
                return null;
            }
        }

        private static void FixNs(XElement e)
        {
            if (e.Name.LocalName == "body" && e.Name.Namespace == "http://jabber.org/protocol/httpbind" &&
                !e.Ancestors().Any())
            {
                if (e.HasElements)
                {
                    foreach (XElement chield in e.Descendants())
                    {
                        FixNs(chield);
                    }
                }
            }
            else if (e.Name.LocalName == "iq" ||
                     e.Name.LocalName == "presence" ||
                     e.Name.LocalName == "message" ||
                     (e.Name.LocalName == "error" && e.Name.NamespaceName != Namespace.Name) ||
                     e.Name.LocalName == "body" ||
                     e.Name.LocalName == "show")
            {
                e.Name = XName.Get(e.Name.LocalName, "jabber:client");

                if (e.HasElements)
                {
                    foreach (XElement chield in e.Descendants())
                    {
                        FixNs(chield);
                    }
                }
            }
        }
    }
}