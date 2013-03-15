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
    }
}