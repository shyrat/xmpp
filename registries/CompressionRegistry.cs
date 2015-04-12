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
using System.Reflection;
using XMPP.compression;

namespace XMPP.Registries
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class CompressionAttribute : Attribute
    {
        private readonly string _compression;

        private readonly Type _type;

        public CompressionAttribute(string compression, Type type)
        {
            _compression = compression;
            _type = type;
        }

        public string Algorithm
        {
            get { return _compression; }
        }

        public Type ClassType
        {
            get { return _type; }
        }
    }

    public class CompressionRegistry
    {
        private readonly Dictionary<string, Type> _registeredItems = new Dictionary<string, Type>();

        public bool AlgorithmsAvailable
        {
            get { return _registeredItems.Count >= 1; }
        }

        public void AddCompression(Assembly a)
        {
            CompressionAttribute[] tags = GetAttributes<CompressionAttribute>(a);
            foreach (CompressionAttribute tag in tags)
            {
                _registeredItems.Add(tag.Algorithm, tag.ClassType);
            }
        }

        public ICompression GetCompression(string algorithm)
        {
            ICompression stream;
            try
            {
                Type t;
                if (_registeredItems.TryGetValue(algorithm, out t))
                {
                    stream = (ICompression) Activator.CreateInstance(t);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return stream;
        }

        public bool SupportsAlgorithm(string algorithm)
        {
            return _registeredItems.ContainsKey(algorithm);
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
    }
}