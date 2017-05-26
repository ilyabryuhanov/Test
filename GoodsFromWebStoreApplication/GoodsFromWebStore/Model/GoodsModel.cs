using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GoodsFromWebStore.GoodsUtils;

namespace GoodsFromWebStore.Model
{
    public class GoodsModel
    {
        private const string HttpNikaElectricRuKabelnayaProdukciya = "http://nika-electric.ru/368-kabelnaya-produkciya";
        private const string HttpNikaElectricRuPvsProvodSoedenitelnyj = "http://nika-electric.ru/387-pvs-provod-soedenitelnyj";
        private const string HttpNikaElectricRuProvodUstanovochnyjPv1Pv3Pugvpuv = "http://nika-electric.ru/392-provod-ustanovochnyj-pv1pv3pugvpuv";
        private ObservableCollection<Good> _listGoods = new AsyncObservableCollection<Good>();
        public ObservableCollection<Good> ListGoods
        {
            set
            {
                _listGoods = value;
                
            }
            get { return _listGoods; }
        }

        public void LoadAllGoods()
        {
            ListGoods.Clear();
            NodeHtmlUtils.GetNodesFromWebUrl(HttpNikaElectricRuKabelnayaProdukciya, ListGoods);
            NodeHtmlUtils.GetNodesFromWebUrl(HttpNikaElectricRuPvsProvodSoedenitelnyj, ListGoods);
            NodeHtmlUtils.GetNodesFromWebUrl(HttpNikaElectricRuProvodUstanovochnyjPv1Pv3Pugvpuv, ListGoods);
        }
    }
}
