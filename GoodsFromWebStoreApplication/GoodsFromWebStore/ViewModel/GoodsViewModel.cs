using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsFromWebStore.GoodsUtils;
using GoodsFromWebStore.Model;
using GoodsFromWebStore.ViewModel.Commands;

namespace GoodsFromWebStore.ViewModel
{
    public class GoodsViewModel
    {
        private GoodsModel _model;
        public GoodsViewModel()
        {
            Model=new GoodsModel();
            LoadAllGoodsCommand = new LoadAllGoodsCommand(this);
           
        }
        
        public LoadAllGoodsCommand LoadAllGoodsCommand { set; get; }
        public ObservableCollection<Good> ListGoods
        {
            get { return Model.ListGoods; }
        }

        public GoodsModel Model
        {
            private set { _model = value; }
            get { return _model; }
        }

        public  void LoadAllGoods()
        {
           _model.LoadAllGoods();
        }

    }
}
