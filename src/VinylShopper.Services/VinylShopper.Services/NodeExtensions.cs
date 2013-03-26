using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace VinylShopper.Services
{
    static class NodeExtensions
    {
        public static IEnumerable<HtmlNode> Descendants(this HtmlNode node)
        {
            return node.ChildNodes.Concat(node.ChildNodes.SelectMany(n => n.Descendants()));
        }

        public static IEnumerable<HtmlNode> ByClass(this HtmlNode node, string className)
        {
            return node.Descendants()
                .Where(n => n.Attributes
                    .Any(a => a.Name == "class" && a.Value.Split(' ').Contains(className)));
        }

        public static IEnumerable<HtmlNode> ById(this HtmlNode node, string id)
        {
            return node.Descendants()
                .Where(n => n.Attributes
                    .Any(a => a.Name == "id" && a.Value == id));
        }


        public static IEnumerable<HtmlNode> ByAlt(this HtmlNode node, string alt)
        {
            return node.Descendants()
                .Where(n => n.Attributes
                    .Any(a => a.Name == "alt" && a.Value.Contains(alt)));
        }

        public static string FirstTextById(this HtmlNode node, string id)
        {
            var innerNode = node.ById(id).FirstOrDefault();
            return innerNode == null ? string.Empty : innerNode.InnerText.Trim();
        }

        public static string FirstTextByClass(this HtmlNode node, string className)
        {
            var innerNode = node.ByClass(className).FirstOrDefault();
            return innerNode == null ? string.Empty : innerNode.InnerText.Trim();
        }

        public static string FirstAttributeByClass(this HtmlNode node, string className, string attributeName)
        {
            var innerNode = node.ByClass(className).FirstOrDefault();
            return innerNode == null ? string.Empty : innerNode.AttributeValue(attributeName);
        }

        public static string AttributeValue(this HtmlNode node, string attributeName)
        {
            if (node != null)
                return node.Attributes[attributeName] == null ? string.Empty : node.Attributes[attributeName].Value.Trim();

            return string.Empty;
        }

    }
}