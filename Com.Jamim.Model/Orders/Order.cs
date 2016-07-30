using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Model.Customers;
using Com.Jamim.Model.ValueObjects;

namespace Com.Jamim.Model.Orders
{
    public class Order
    {

        private IOrderState _orderState;

        public Order(IOrderState baseState)
        {
            _orderState = baseState;
        }

        public Order()
        {
            // TODO: Complete member initialization
        }

        public OrderStatus Status()
        {
            return _orderState.Status;
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int RetailerId { get; set; }
        public int DeliveryPersonId { get; set; }

        public DateTime OrderDate { get; set; }
        public double EstimatedDeliveryTime { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReviseDeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public double OrderAmount { get; set; }
        public double OrderDiscount { get; set; }
        public double ShippingCharge { get; set; }
        public double OrderSumWithoutTax { get; set; }
        public double OrderSumWithTax { get; set; }

        public string ShippingNotice { get; set; }

        public int? ShippingAddressId { get; set; } 

        public virtual Customer Customer { get; set; }
        public virtual Retailer Retailer { get; set; }
        public virtual Address ShippingAddress { get; set; }


        public bool CanCancel()
        {
            return _orderState.CanCancel(this);
        }

        public void Cancel()
        {
            _orderState.Cancel(this);
        }

        public bool CanShip()
        {
            return _orderState.Canship(this);
        }

        public void Ship()
        {
            _orderState.Ship(this);
        }

        internal void Change(IOrderState orderState)
        {
            _orderState = orderState;
        }


    }

    public class OrderNewState : IOrderState
    {

        public bool Canship(Order order)
        {
            return true;
        }

        public void Ship(Order order)
        {
            order.Change(new OrderShippedState());
        }

        public bool CanCancel(Order order)
        {
            return true;
        }

        public void Cancel(Order order)
        {
            order.Change(new OrderCancelState());
        }

        public OrderStatus Status
        {
            get { return OrderStatus.New; }
        }
    }

    public class OrderShippedState : IOrderState
    {

        public bool Canship(Order order)
        {
            return false;
        }

        public void Ship(Order order)
        {
            throw new ApplicationException("You can't ship a shipped oeder!");
        }

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new ApplicationException("Shipped order can't be canceled!");
        }


        public OrderStatus Status
        {
            get { return OrderStatus.Shipped; }
        }
    }

    public class OrderCancelState : IOrderState
    {

        public bool Canship(Order order)
        {
            return false;
        }

        public void Ship(Order order)
        {
            throw new ApplicationException("Canceled Order Can not be Shipped!");
        }

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new ApplicationException("The order is already canceled!");
        }


        public OrderStatus Status
        {
            get { return OrderStatus.Canceled; }
        }
    }
   
    public class test
    {
        public test()
        {
            IOrderState s = new OrderCancelState();
            Order o = new Order();
            o.Change(new OrderCancelState());
        }
    }

}
