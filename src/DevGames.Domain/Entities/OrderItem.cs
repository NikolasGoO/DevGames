using DevGames.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Amount { get; private set; }
        public decimal UnitValue { get; private set; }
        public string ProductImage { get; private set; }

        public Order Order { get; private set; }

        protected OrderItem() { }

        public OrderItem(Guid orderId,
            Guid productId,
            string productName,
            int amount,
            decimal unitValue,
            string productImage)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Amount = amount;
            UnitValue = unitValue;
            ProductImage = productImage;
        }

        internal decimal CalculeValue()
        {
            return Amount * UnitValue;
        }

        public void SetProductName(string name)
        {
            ProductName = name;
        }

        public void SetProductImage(string image)
        {
            ProductImage = image;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }
    }
}
