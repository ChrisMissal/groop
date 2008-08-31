using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CRIneta.Model;
using CRIneta.UnitTests;
using CRIneta.Website.Controllers;
using MvcContrib;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace CRIneta.UnitTests.Website.Controllers
{
    [TestFixture]
    public class FlashMessageComponentControllerTester : MockingBase
    {
        [Test]
        public void ShouldGetFlashMessages()
        {
            var messagesToReturn = new[]
                                       {
                                           new FlashMessage(FlashMessage.MessageType.Error, ""),
                                           new FlashMessage(FlashMessage.MessageType.Message, "")
                                       };

            var userSession = mockery.Stub<IUserSession>();
            SetupResult.For(userSession.PopUserMessages()).Return(messagesToReturn);

            mockery.ReplayAll();

            var component = new FlashMessageComponentController(userSession);
            var result = component.GetMessages() as ViewResult;
            var actualMessages = result.ViewData.Model as FlashMessage[];

            Assert.That(result.ViewName, Is.EqualTo("FlashMessageList"));
            Assert.That(actualMessages.Length, Is.EqualTo(2));
            Assert.That(actualMessages[0].Type, Is.EqualTo(FlashMessage.MessageType.Error));
            Assert.That(actualMessages[1].Type, Is.EqualTo(FlashMessage.MessageType.Message));
        }
    }
}