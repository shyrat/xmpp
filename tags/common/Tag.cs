// Copyright © 2006 - 2012 Dieter Lunn
// Modified 2012 Paul Freund ( freund.paul@lvl3.org )
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
// You should have received a copy of the GNU Lesser General Public License along
// with this library; if not, write to the Free Software Foundation, Inc., 59
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

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
    public class Tag
    {
        private static int _packetCounter;

        protected Tag(XName identity)
        {
            InnerElement = new XElement(identity);
        }

        protected Tag(XElement other)
        {
            InnerElement = new XElement(other);
        }

        protected XElement InnerElement { get; private set; }

        public byte[] Bytes
        {
            get { return System.Convert.FromBase64String(InnerElement.Value); }
            set { InnerElement.Value = System.Convert.ToBase64String(value); }
        }

        public static string NextId()
        {
            return string.Format("U{0}", Interlocked.Increment(ref _packetCounter));
        }

        public static implicit operator string(Tag tag)
        {
            return tag.InnerElement.ToString();
        }

        public object GetAttributeValue(XName name)
        {
            XAttribute attr = InnerElement.Attribute(name);
            if (attr != null)
            {
                return attr.Value;
            }

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
            var attr = (string)GetAttributeValue(name);
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
                        return (T)Enum.Parse(enumType, item);
                    }
                }

                return (T)Enum.Parse(typeof(T), attr, true);
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

            IDictionary<Type, CustomAttributeData> customAttributes = member.CustomAttributes.ToDictionary(c => c.AttributeType);

            CustomAttributeData enumMemberAttribute;
            if (customAttributes.TryGetValue(typeof(EnumMemberAttribute), out enumMemberAttribute))
            {
                IDictionary<string, CustomAttributeNamedArgument> args =
                    enumMemberAttribute.NamedArguments.ToDictionary(c => c.MemberName);

                CustomAttributeNamedArgument arg;
                if (args.TryGetValue("Value", out arg))
                {
                    InnerElement.SetAttributeValue(name, arg.TypedValue.Value);
                    return;
                }
            }

            InnerElement.SetAttributeValue(name, ((T)value).ToString());
        }

        public IEnumerable<Tag> Descendants()
        {
            return Descendants<Tag>();
        }

        public IEnumerable<T> Descendants<T>() where T : Tag
        {
            return InnerElement.Descendants().Select(descendant => Convert<T>(descendant));
        }

        public IEnumerable<Tag> Descendants(XName name)
        {
            return Descendants<Tag>(name);
        }

        public IEnumerable<T> Descendants<T>(XName name) where T : Tag
        {
            return InnerElement.Descendants(name).Select(descendant => Convert<T>(descendant));
        }

        public Tag Element(XName name)
        {
            return Element<Tag>(name);
        }

        public T Element<T>(XName name) where T : Tag
        {
            return Convert<T>(InnerElement.Element(name));
        }

        public IEnumerable<XElement> Elements()
        {
            return InnerElement.Elements();
        }

        public IEnumerable<T> Elements<T>() where T : Tag
        {
            return InnerElement.Elements().Select(element => Convert<T>(element));
        }

        public IEnumerable<Tag> Elements(XName name)
        {
            return Elements<Tag>(name);
        }

        public IEnumerable<T> Elements<T>(XName name) where T : Tag
        {
            return InnerElement.Elements(name).Select(element => Convert<T>(element));
        }

        public IEnumerable<Tag> AncestorsAndSelf()
        {
            return AncestorsAndSelf<Tag>();
        }

        public IEnumerable<T> AncestorsAndSelf<T>() where T : Tag
        {
            return InnerElement.AncestorsAndSelf().Select(ancestor => Convert<T>(ancestor));
        }

        public IEnumerable<Tag> AncestorsAndSelf(XName name)
        {
            return AncestorsAndSelf<Tag>(name);
        }

        public IEnumerable<T> AncestorsAndSelf<T>(XName name) where T : Tag
        {
            return InnerElement.AncestorsAndSelf(name).Select(ancestor => Convert<T>(ancestor));
        }

        public IEnumerable<Tag> DescendantsAndSelf()
        {
            return DescendantsAndSelf<Tag>();
        }

        public IEnumerable<T> DescendantsAndSelf<T>() where T : Tag
        {
            return InnerElement.DescendantsAndSelf().Select(descendant => Convert<T>(descendant));
        }

        public IEnumerable<Tag> DescendantsAndSelf(XName name)
        {
            return DescendantsAndSelf<Tag>(name);
        }

        public IEnumerable<T> DescendantsAndSelf<T>(XName name) where T : Tag
        {
            return InnerElement.DescendantsAndSelf(name).Select(descendant => Convert<T>(descendant));
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

        private TReturn Convert<TReturn>(XElement element) where TReturn : Tag
        {
            if (element == null)
            {
                return default(TReturn);
            }

            ConstructorInfo ctor = GetConstructor(typeof(TReturn), new[] { typeof(XElement) });
            if (ctor != null)
            {
                return (TReturn)ctor.Invoke(new object[] { element });
            }

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

        public static explicit operator XElement(Tag tag)
        {
            return tag.InnerElement;
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
                    document.Add(XNode.ReadFrom(xmlReader));
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
                     (e.Name.LocalName == "error" && e.Name.NamespaceName != Namespace.XmlNamespace) ||
                     e.Name.LocalName == "body" ||
                     e.Name.LocalName == "show" ||
                     e.Name.LocalName == "subject")
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