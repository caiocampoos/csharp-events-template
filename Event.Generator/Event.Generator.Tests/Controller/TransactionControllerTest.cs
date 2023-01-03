using FakeItEasy;
using Event.Generator.Application.Interfaces;
using Event.Generator.Domain.Models;
using Event.Generator.Api.Controllers.V1;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Event.Generator.Tests.Controller
{
    public class TransactionControllerTest
    {
        private readonly ITransactionHandler _transactionHandler;
        public TransactionControllerTest() 
        {
            _transactionHandler = A.Fake<ITransactionHandler>();
        }

        [Fact]
        public async Task TransactionController_RegisterTransaction_ReturnOK()
        {
            //Arrange
            var transaction = A.Fake<Transaction>();

            var controller = new TransactionController(_transactionHandler);


            //Act

            var result = await controller.RegisterTransaction(transaction);

            var okResult = result as StatusCodeResult;
            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(StatusCodeResult));
            okResult.Should().BeEquivalentTo(new StatusCodeResult(200));
        }   

    }
}
