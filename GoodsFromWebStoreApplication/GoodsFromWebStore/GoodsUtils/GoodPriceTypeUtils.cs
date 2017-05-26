using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsFromWebStore.GoodsUtils
{
    public static class GoodPriceTypeUtils
    {
        private const string Rub = "Руб.";
        private const string Usd = "Долл.";
        private const string Eur = "Евро";

        private static readonly Dictionary<GoodsPriceType, string> GoodsPriceTypeDescr = new Dictionary<GoodsPriceType, string>()
        {
            { GoodsPriceType.Rub , Rub},
            { GoodsPriceType.Usd , Usd},
            { GoodsPriceType.Euro ,Eur }
        };

        public static string GetGoodsPriceDescription(GoodsPriceType goodsPriceType)
        {
            if (!GoodsPriceTypeDescr.ContainsKey(goodsPriceType)) return String.Empty;
            return GoodsPriceTypeDescr[goodsPriceType];
        }
    }

}
