using System;
using DesktopClient.Extension;
using DesktopClient.Tests.Automation.Driver;
using DesktopClient.Tests.Automation.Helper;
using DesktopClient.Tests.Helper;
using NUnit.Framework;

namespace DesktopClient.Tests.Automation
{
    [TestFixture]
    public class AutomationTests
    {
        private readonly MainWindowDriver mainWindowDriver = new MainWindowDriver();

        [Test]
        public void ShowThatAnUnhandledExceptionCanFailTheTest()
        {
            BeforeEachTest();

            mainWindowDriver.ClickThrowExceptionButton();

            AfterEachTest();
        }

        [Test]
        public void WhenNewOrderIsSubmitted_ThenNewOrderFormIsClosed_AndNewOrderShowsUpInTheGrid()
        {
            BeforeEachTest();

            const string customer = "John";
            const string product = "Product1";
            const string quantity = "100";
            const int timeOutInMillis = 2 * 1000;
            
            NewOrderFormDriver newOrderFormDriver;
            var wasNewOrderFormCreated = mainWindowDriver.ClickNewOrderButton(timeOutInMillis, out newOrderFormDriver);
            Assert.True(wasNewOrderFormCreated, "New order form was not shown.");

            newOrderFormDriver.Populate(customer, product, quantity);
            newOrderFormDriver.SubmitOrder();
            var wasNewOrderFormClosed = newOrderFormDriver.WaitForNewOrderFormToBeClosed(timeOutInMillis);
            Assert.True(wasNewOrderFormClosed, "New order form was not closed.");

            var result = mainWindowDriver.CheckGridHasRow(
                r => DataGridViewRowHelper.GetId(r).IsGuid(),
                r => customer == DataGridViewRowHelper.GetCustomerValue(r),
                r => product == DataGridViewRowHelper.GetProductValue(r),
                r => quantity == DataGridViewRowHelper.GetQuantityValue(r));
            Assert.True(result, "Newly submitted order was not correctly displayed in the grid.");

            AfterEachTest();
        }

        private void BeforeEachTest()
        {
            // Prevent test runners (e.g. Resharper) from running tests in parallel. This allows each test to reliably check:
            // * At the end, if the main window needs to be closed due to unhandled exceptions.
            // * At the start, if the main window needs to be restarted because it was closed by a previous test
            // It also simulates the user's actions of taking one action at a time.
            TestSerializer.WaitToRunTest();
            mainWindowDriver.StartMainWindowIfNecessary();

        }

        private void AfterEachTest()
        {
            try
            {
                CheckForUnhandledExceptionAndCloseMainWindowIfNecessary();
            }
            finally
            {
                TestSerializer.FinishRunningTest();
            }
        }

        private void CheckForUnhandledExceptionAndCloseMainWindowIfNecessary()
        {
            var exception = mainWindowDriver.RetrieveUnhandledException();
            if (exception != null)
                mainWindowDriver.CloseMainWindowIfNecessary();

            Assert.That(exception, Is.Null, string.Format("Unhandled exception:{0}{1}", Environment.NewLine, exception));
        }

        [TestFixtureTearDown]
        public void AfterAllTests()
        {
            mainWindowDriver.CloseMainWindowIfNecessary();
        }
    }
}
