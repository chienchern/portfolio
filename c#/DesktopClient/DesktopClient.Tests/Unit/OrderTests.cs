using System;
using System.Reflection;
using DesktopClient.Model;
using NUnit.Framework;

namespace DesktopClient.Tests.Unit
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void PropertyChangedIsCorrectlyRaisedOnAllProperties()
        {
            var propertyName = string.Empty;
            var order = CreateUnit();
            order.PropertyChanged += (s, e) => propertyName = e.PropertyName;
            
            var orderType = typeof (IOrder);
            foreach (var propertyInfo in orderType.GetProperties())
            {
                SetPropertyValue(propertyInfo, order);

                var errorMessage = string.Format("Expected property name [{0}] but was [{1}]", propertyInfo.Name, propertyName);
                Assert.That(propertyName, Is.EqualTo(propertyInfo.Name), errorMessage);
            }

        }

        private void SetPropertyValue(PropertyInfo propertyInfo, Order order)
        {
            try
            {
                propertyInfo.SetValue(order, "someValue");
            }
            catch (Exception e)
            {
                var error = string.Format("Unable to set property [{0}]{1}{2}", propertyInfo.Name, Environment.NewLine, e);
                Assert.Fail(error);
            }
        }

        private Order CreateUnit()
        {
            return new Order(null, null, null, null);
        }
    }
}