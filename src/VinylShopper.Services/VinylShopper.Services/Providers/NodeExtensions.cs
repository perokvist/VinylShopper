using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace VinylShopper.Services.Providers
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

        public static string FirstTextByClass(this HtmlNode node, string className)
        {
            var innerNode = node.ByClass(className).FirstOrDefault();
            return node.ByClass(className).FirstOrDefault() == null ? string.Empty : innerNode.InnerText.Trim();
        }
    }
}