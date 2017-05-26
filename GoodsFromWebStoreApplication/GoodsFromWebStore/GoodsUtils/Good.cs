using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoodsFromWebStore.GoodsUtils
{
    //http://nika-electric.ru/368-kabelnaya-produkciya
    public class Good : INotifyPropertyChanged
    {
        private const double Tolerance = 0.00001;
        private string _name;
        private string _description;
        private string _pictureUrl;
        private string _goodUrl;
        private double _currentPrice;
        private GoodsPriceType _goodsPriceType;
        private double _oldPrice;
        private double _discount;

        public Good(string name,string description,string goodUrl,string pictureUrl,double currentPrice, double oldPrice,double discount, GoodsPriceType goodsPriceType)
        {
            Name = name;
            Description = description;
            GoodUrl = goodUrl;
            PictureUrl = pictureUrl;
            CurrentPrice = currentPrice;
            OldPrice = oldPrice;
            Discount = discount;
            GoodsPriceType = goodsPriceType;
        }


        public string Name
        {
            set
            {
                if (value != null && value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }

            }
            get { return _name; }
        }

        public string Description
        {
            set
            {
                if (value != null && value != _description)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
            get { return _description; }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set
            {
                if (value != null && value != _pictureUrl)
                {
                    _pictureUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GoodUrl
        {
            set
            {
                if (value != null && value != _goodUrl)
                {
                    _goodUrl = value;
                    OnPropertyChanged();
                }
            }
            get { return _goodUrl; }
        }

        public double CurrentPrice
        {
            set
            {
                if ( Math.Abs(value - _currentPrice) > Tolerance)
                {
                    _currentPrice = value;
                    OnPropertyChanged();
                }
            }
            get { return _currentPrice; }
        }

        public double OldPrice
        {
            set
            {
                if ( Math.Abs(value - _oldPrice) > Tolerance)
                {
                    _oldPrice = value;
                    OnPropertyChanged();
                }
            }
            get { return _oldPrice; }
        }

        public double Discount
        {
            set
            {
                
                if (Math.Abs(value - _discount) > Tolerance)
                {
                    _discount = value;
                    OnPropertyChanged();
                }
            }
            get { return _discount; }
        }

        public GoodsPriceType GoodsPriceType
        {
            set
            {
                if (value != _goodsPriceType)
                {
                    _goodsPriceType = value;
                    OnPropertyChanged();
                }
            }
            get { return _goodsPriceType; }
        }

        public string GoodsPriceTypeDescription 
        {
            get { return GoodPriceTypeUtils.GetGoodsPriceDescription(GoodsPriceType); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}