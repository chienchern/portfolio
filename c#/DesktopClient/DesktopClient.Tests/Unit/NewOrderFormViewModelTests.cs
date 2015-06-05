using DesktopClient.Model;
using DesktopClient.ViewModel;
using NUnit.Framework;

namespace DesktopClient.Tests.Unit
{
    [TestFixture]
    public class NewOrderFormViewModelTests
    {
        [Test]
        public void WhenSubmitIsCalled_ThenOrderSubmittedEventIsRaised()
        {
            const string customer = "SomeClient";
            const string product = "SomeProduct";
            const string quantity = "SomeQuantity";
            IOrder order = null;

            var unit = new NewOrderFormViewModel();
            unit.OrderSubmitted += (sender, args) => order = args.Order;
            unit.SubmitOrder(customer, product, quantity);

            Assert.That(order.Customer, Is.EqualTo(customer));
            Assert.That(order.Product, Is.EqualTo(product));
            Assert.That(order.Quantity, Is.EqualTo(quantity));
        }
    }
}