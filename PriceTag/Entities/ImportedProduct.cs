﻿using System.Globalization;

namespace PriceTag.Entities
{
    class ImportedProduct : Product
    {
        public double CustomsFee { get; private set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customsFee)
            : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return Name +
                " $ " +
                TotalPrice() + 
                " (Customs fee: $ " + 
                CustomsFee.ToString("F2", CultureInfo.InvariantCulture) + 
                ")";
        }
    }
}
