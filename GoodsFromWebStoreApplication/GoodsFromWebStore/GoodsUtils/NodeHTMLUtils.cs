using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.String;

namespace GoodsFromWebStore.GoodsUtils
{
    public static class NodeHtmlUtils
    {
        //http://nika-electric.ru/368-kabelnaya-produkciya
        //

        private static Regex regexObj = new Regex(@"[^\d]");

        public static void GetGoodFromHtmlDocumentByOrederAsync(HtmlWeb web, HtmlDocument doc, int goodOrder, ObservableCollection<Good> listGoods)
        {
            var pictureUrl = TryGetPictureUrl(doc, goodOrder);
            var goodAttributes = TryGetGoodAttributes(doc, goodOrder);
            var name = TryGetGoodName(goodAttributes);
            var url = TryGetGoodUrl(goodAttributes);
            var price = TryGetGoodPrice(doc, goodOrder);
            var type = TryGetPriceType(doc, goodOrder);
            var oldPrice = TryGetGoodOldPrice(doc, goodOrder);
            var discount = TryGetDiscount(doc, goodOrder);
            var description = TryGetDescription(web, url);
            listGoods.Add(new Good(name, description, url, pictureUrl, price, oldPrice, discount, type));
        }

        public static void GetNodesFromWebUrl(string webUrl, ObservableCollection<Good> listGoods)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(webUrl);
            var countOfGoodsInPage = doc.DocumentNode.SelectNodes(" //*[@id=\"center_column\"]/ul")[0].ChildNodes.Count;
            for (int i = 1; i < countOfGoodsInPage +1; i++)
            {
                GetGoodFromHtmlDocumentByOrederAsync(web, doc, i, listGoods);
            }
        }

        private static string TryGetDescription(HtmlWeb web,string url)
        {
            if (url == Empty)
                return Empty;
            var docForDescription = web.Load(url);
            if (docForDescription == null)
                return Empty;
            var nodes = docForDescription.DocumentNode.SelectNodes("//*[@id=\"moreinfo\"]/li/p[2]");
            if (nodes != null && nodes.Any())
            {
                return nodes[0].InnerHtml.Replace("<br>","\n");
            }
            return Empty;
        }

        private static double TryGetDiscount(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[2]/div[1]/span[3]");
            return GetDoubleValue(nodes);
        }

        private static GoodsPriceType TryGetPriceType(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[2]/div[1]/meta");
            if (nodes != null && nodes.Any())
            {
                var type = nodes[0].Attributes["content"].Value;
                return type == "RUB" ? GoodsPriceType.Rub : GoodsPriceType.Usd;
            }
            return GoodsPriceType.Rub;
        }
       
        private static double TryGetGoodOldPrice(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[2]/div[1]/span[2]");
            return GetDoubleValue(nodes);
        }

        private static double GetDoubleValue(HtmlNodeCollection nodes)
        {
            if (nodes != null && nodes.Any())
            {
                double value;
                if (double.TryParse(regexObj.Replace(nodes[0].InnerText, ""), out value))
                {
                    return value;
                }
            }
            return double.NaN;
        }

        private static double TryGetGoodPrice(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[2]/div[1]/span[1]");
            return GetDoubleValue(nodes);
        }

        private static string TryGetGoodUrl(HtmlAttributeCollection goodAttributes)
        {
            if (goodAttributes != null)
                return goodAttributes["href"].Value;
            return Empty;
           
        }

        private static string TryGetGoodName(HtmlAttributeCollection goodAttributes)
        {
            if (goodAttributes !=null)
                return goodAttributes["title"].Value;
            return Empty;
        }

        private static HtmlAttributeCollection TryGetGoodAttributes(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[2]/h5/a");
            if (nodes !=null && nodes.Any())
                return nodes[0].Attributes;
            return null;
        }

        private static string TryGetPictureUrl(HtmlDocument doc, int i)
        {
            var nodes = doc.DocumentNode.SelectNodes($"//*[@id=\"center_column\"]/ul/li[{i}]/div/div[1]/a/img");
            if (nodes!=null && nodes.Any())
            {
                return nodes[0].Attributes["src"].Value;
            }
            return Empty;
        }
       
    }
}
