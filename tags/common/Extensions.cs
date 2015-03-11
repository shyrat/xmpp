using System.Xml.Linq;
using XMPP.Tags;

namespace XMPP.Extensions
{
    public static class Extensions
    {
        public static Tag Add(this Tag obj, Tag tag)
        {
            ((XElement)obj).Add((XElement)tag);
            return obj;
        }

        public static Tag Add(this Tag obj, XElement element)
        {
            ((XElement)obj).Add(element);
            return obj;
        }

        public static Tag Add(this Tag obj, XAttribute attr)
        {
            ((XElement)obj).Add(attr);
            return obj;
        }

        public static bool HasElements(this Tag obj)
        {
            return ((XElement)obj).HasElements;
        }
    }
}
