using System;
using DesktopClient.Model;
using DesktopClient.View;
using DesktopClient.ViewModel;
using Moq;
using NUnit.Framework;

namespace DesktopClient.Tests.Unit
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        [Test]
        public void WhenNewOrderIsCreated_ThenItIsAddedToListOfOrders()
        {
            var expectedOrder = new Order("SomeGuid", "SomeCustomer", "SomeProduct", "SomeQuantity");
            var newOrderFormViewModel = new Mock<INewOrderFormViewModel>();
            Func<INewOrderFormViewModel> newOrderFormViewModelFactory = () => newOrderFormViewModel.Object;

            var unit = new MainWindowViewModel(newOrderFormViewModelFactory);
            unit.GetNewOrderFormViewModel();
            newOrderFormViewModel.Raise(n => n.OrderSubmitted += null, new NewOrderEventArgs(expectedOrder));

            Assert.That(unit.Orders.Count, Is.EqualTo(1));
            Assert.That(unit.Orders[0].Customer, Is.EqualTo(expectedOrder.Customer));
            Assert.That(unit.Orders[0].Id, Is.EqualTo(expectedOrder.Id));
            Assert.That(unit.Orders[0].Product, Is.EqualTo(expectedOrder.Product));
            Assert.That(unit.Orders[0].Quantity, Is.EqualTo(expectedOrder.Quantity));
        }
    }
}