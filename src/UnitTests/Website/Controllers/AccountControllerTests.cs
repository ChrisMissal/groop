using System;
using System.Web.Mvc;
using CRIneta.DataAccess;
using CRIneta.Model;
using CRIneta.Model.Domain;
using CRIneta.Model.Security;
using CRIneta.Model.Security.Cryptography;
using CRIneta.Website.Controllers;
using CRIneta.Website.Services.Email;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using Is=Rhino.Mocks.Constraints.Is;
using Text=Rhino.Mocks.Constraints.Text;

namespace CRIneta.UnitTests.Website.Controllers
{
    [TestFixture]
    public class AccountControllerTests : MockingBase
    {
        #region Setup/Teardown

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion

        private IUserSession mockUserSession;
        private IMemberRepository mockMemberRepository;
        private IAuthenticator mockAuthenticator;
        private ICryptographer mockCryptographer;
        private IEmailService mockEmailService;

        private AccountController GetController()
        {
            mockUserSession = mockery.DynamicMock<IUserSession>();
            mockMemberRepository = mockery.DynamicMock<IMemberRepository>();
            mockAuthenticator = mockery.DynamicMock<IAuthenticator>();
            mockCryptographer = mockery.DynamicMock<ICryptographer>();
            mockEmailService = mockery.DynamicMock<IEmailService>();

            var controller = new AccountController(mockUserSession, mockMemberRepository, mockAuthenticator,
                                                   mockCryptographer, mockEmailService);

            return controller;
        }

        
        [Test]
        public void Check_that_the_Index_method_returns_title_of_Login()
        {
            AccountController controller = GetController();

            // Execute
            var result = controller.Login() as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Login", viewData["Title"]);
        }

        
        //[Test]
        //public void A_newly_registered_user_should_be_redirected_to_the_account_home_page()
        //{
        //    AccountController controller = GetController();
        //    string email = "joeuser@gmail.com";
        //    var stubUser = new Member("joeuser", "Joe", "User", "joeuser@gmail.com");
        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(null);

        //    mockery.ReplayAll();

        //    var result =
        //        controller.ProcessRegistration("Joe", "User", "joeuser", email, "password", "password") as
        //        RedirectToRouteResult;

        //    Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
        //    Assert.That(result.Values["action"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Index"));
        //    Assert.That(result.Values["controller"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Account"));
        //}


        //[Test]
        //public void Ensure_that_a_null_or_empty_email_address_passed_to_Register_redirects_to_Register_view()
        //{
        //    AccountController controller = GetController();

        //    var result = controller.ProcessRegistration(null, null, null, null, null, null) as RedirectToRouteResult;

        //    Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
        //    Assert.That(result.Values["action"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Register"));
        //}

        //[Test]
        //public void Can_register_a_user_successfully_in_the_UserRepository()
        //{
        //    //AccountController controller = GetController();

        //    //controller.ProcessRegistration("FirstName", "LastName", "UserName", "Email@Address.com", "", "");

        //    //Expect.Call(mockMemberRepository.AddUser(null));
        //}

        //[Test]
        //public void ForgotPassword_should_render_ForgotPassword_View()
        //{
        //    AccountController controller = GetController();

        //    var result = controller.ForgotPassword() as ViewResult;

        //    Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("ForgotPassword"));
        //}

        [Test]
        public void IAuthenticator_should_be_called_from_Authenticate_method()
        {
            AccountController controller = GetController();

            string email = "something@something.com";
            string password = "password";

            var stubUser = new Member("joeuser", "Joe", "User", "joeuser@gmail.com");

            SetupResult.For(mockMemberRepository.GetByUsername(email)).Return(stubUser);

            // expecatations
            Expect.Call(mockAuthenticator.VerifyAccount(stubUser, password)).Return(true);

            mockery.ReplayAll();

            controller.ProcessLogin(email, password, null);

            // assert
            mockery.VerifyAll();
        }

        [Test]
        public void IAuthenticator_SignOut_should_be_called_when_LogOut_action_is_called()
        {
            AccountController controller = GetController();

            // expectations
            mockAuthenticator.SignOut();

            mockery.ReplayAll();

            controller.LogOut();

            mockery.VerifyAll();
        }

        [Test]
        public void If_the_user_is_not_found_the_user_should_be_redirected_to_Login()
        {
            AccountController controller = GetController();

            string email = "something@something.com";
            string password = "password";

            SetupResult.For(mockMemberRepository.GetByUsername(email)).Return(null);

            mockery.ReplayAll();

            var result = controller.ProcessLogin(email, password, null) as RedirectToRouteResult;

            Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
            Assert.That(result.Values["action"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Login"));
        }

        [Test]
        public void Login_action_should_return_login_view()
        {
            AccountController controller = GetController();

            // Executes
            var result = controller.Login() as ViewResult;

            // Verify
            Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("Login"));
        }

        [Test]
        public void Logout_action_should_return_logout_view()
        {
            AccountController controller = GetController();

            // Executes
            var result = controller.LogOut() as RedirectToRouteResult;

            // Verify
            Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
            Assert.That(result.Values["action"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Index"));
            Assert.That(result.Values["controller"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Home"));
        }

        //[Test]
        //public void ProcessForgotPassword_should_redirect_back_to_ForgotPassword_if_email_is_null_or_empty()
        //{
        //    AccountController controller = GetController();

        //    string email = null;

        //    var result = controller.ProcessForgotPassword(email) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("ForgotPassword"));
        //}

        //[Test]
        //public void ProcessForgotPassword_should_redirect_to_ForgotPassword_if_email_is_not_found_in_the_repository()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";

        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(null);

        //    mockery.ReplayAll();

        //    var result = controller.ProcessForgotPassword(email) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("ForgotPassword"));
        //}

        //[Test]
        //public void ProcessForgotPassword_should_redirect_to_RequestSent_action_if_email_is_found_in_the_repository()
        //{
        //    var mockedhttpContext = mockery.DynamicMock<HttpContextBase>();
        //    var mockedHttpRequest = mockery.DynamicMock<HttpRequestBase>();

        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";

        //    var stubUser = mockery.Stub<IUser>();
        //    var stubUri = new Uri("http://www.jpcycles.com");

        //    SetupResult.For(mockedhttpContext.Request).Return(mockedHttpRequest);
        //    SetupResult.For(mockedHttpRequest.Url).Return(stubUri);
        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(stubUser);

        //    controller.ControllerContext = new ControllerContext(mockedhttpContext, new RouteData(), controller);

        //    mockery.ReplayAll();

        //    var result = controller.ProcessForgotPassword(email) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("RequestSent"));
        //}

        //[Test]
        //public void ProcessForgotPassword_should_send_an_email_out_through_the_email_service()
        //{
        //    var mockedhttpContext = mockery.DynamicMock<HttpContextBase>();
        //    var mockedHttpRequest = mockery.DynamicMock<HttpRequestBase>();

        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";

        //    var stubUser = mockery.Stub<IUser>();
        //    var stubUri = new Uri("http://www.jpcycles.com");

        //    SetupResult.For(mockedhttpContext.Request).Return(mockedHttpRequest);
        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(stubUser);
        //    SetupResult.For(mockCryptographer.HashString(email, null)).IgnoreArguments().Return("joeuser@gmail.com");
        //    SetupResult.For(mockedHttpRequest.Url).Return(stubUri);

        //    Expect.Call(() => mockEmailService.Send(email, null, null, null)).Constraints(Is.Equal(email), Is.Anything(),
        //                                                                                  Is.Anything(),
        //                                                                                  Text.Contains(
        //                                                                                      "http://www.jpcycles.com"));

        //    controller.ControllerContext = new ControllerContext(mockedhttpContext, new RouteData(), controller);

        //    mockery.ReplayAll();

        //    var result = controller.ProcessForgotPassword(email) as RedirectToRouteResult;

        //    mockery.VerifyAll();
        //}

        //[Test]
        //public void ProcessResestPassword_should_redirect_to_Login_action_if_password_do_not_match_confirm()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string password = "password";
        //    string passwordConfirm = "assword"; // different than password

        //    var result = controller.ProcessResetPassword(email, password, passwordConfirm) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("ResetPassword"));
        //}

        //[Test]
        //public void ProcessResestPassword_should_redirect_to_Login_action_if_user_does_not_exist()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string password = "password";
        //    string passwordConfirm = password;

        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(null);

        //    mockery.ReplayAll();

        //    var result = controller.ProcessResetPassword(email, password, passwordConfirm) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("ResetPassword"));
        //}

        //[Test]
        //public void ProcessResestPassword_should_redirect_user_to_Login_action_after_resetting_password()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string password = "password";
        //    string passwordConfirm = password;

        //    var stubUser = new Member("joeuser", "Joe", "User", "someemail@someaddress.com");
        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(stubUser);

        //    mockery.ReplayAll();

        //    var result = controller.ProcessResetPassword(email, password, passwordConfirm) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("Login"));
        //}

        //[Test]
        //public void ProcessResestPassword_should_set_password_and_passwordSalt_on_User_And_Save_User()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string password = "password";
        //    string passwordConfirm = password;

        //    var stubUser = mockery.Stub<IUser>();

        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(stubUser);
        //    SetupResult.For(mockCryptographer.CreateSalt()).Return("salty");
        //    SetupResult.For(mockCryptographer.HashString(password, "salty")).Return("hashedpassword");

        //    Expect.Call(() => mockMemberRepository.UpdateUser(stubUser));

        //    mockery.ReplayAll();

        //    controller.ProcessResetPassword(email, password, passwordConfirm);

        //    Assert.That(stubUser.PasswordSalt, NUnit.Framework.SyntaxHelpers.Is.EqualTo("salty"));
        //    Assert.That(stubUser.Password, NUnit.Framework.SyntaxHelpers.Is.EqualTo("hashedpassword"));
        //    mockery.VerifyAll();
        //}

        //[Test]
        //public void RequestSent_should_render_RequestSent_view()
        //{
        //    AccountController controller = GetController();

        //    var result = controller.RequestSent() as ViewResult;

        //    Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("RequestSent"));
        //}

        //[Test]
        //public void ResetPassword_should_redirect_to_Login_view_if_decrypted_code_does_not_equals_email()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string code = "xxx";

        //    SetupResult.For(mockCryptographer.HashString(email, null)).IgnoreArguments().Return("skdaflaskfjlasdf");

        //    mockery.ReplayAll();

        //    var result = controller.ResetPassword(email, code) as RedirectToRouteResult;

        //    Assert.That(result.Action(), NUnit.Framework.SyntaxHelpers.Is.EqualTo("ForgotPassword"));
        //}

        //[Test]
        //public void ResetPassword_should_return_ResetPassword_view_if_decrypted_code_equals_email()
        //{
        //    AccountController controller = GetController();

        //    string email = "joeuser@gmail.com";
        //    string code = "xxx";

        //    SetupResult.For(mockCryptographer.HashString(email, null)).IgnoreArguments().Return(code);

        //    mockery.ReplayAll();

        //    var result = controller.ResetPassword(email, code) as ViewResult;

        //    Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("ResetPassword"));
        //}

        [Test]
        public void Should_be_redirected_to_account_index_action_if_login_succeeds()
        {
            AccountController controller = GetController();
            string email = "joeuser@gmail.com";
            string password = "password";

            var stubUser = new Member("joeuser", "Joe", "User", "joeuser@gmail.com");

            SetupResult.For(mockMemberRepository.GetByUsername(email)).Return(stubUser);
            SetupResult.For(mockAuthenticator.VerifyAccount(null, null)).IgnoreArguments().Return(true);

            mockery.ReplayAll();

            var result = controller.ProcessLogin(email, password, null) as RedirectToRouteResult;

            Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
            Assert.That(result.Values["action"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Index"));
            Assert.That(result.Values["controller"], NUnit.Framework.SyntaxHelpers.Is.EqualTo("Account"));
        }

        [Test]
        public void Should_be_redirected_to_specified_Url_if_one_is_present_and_authentication_is_succesfull()
        {
            AccountController controller = GetController();
            string email = "joeuser@gmail.com";
            string password = "password";

            var stubUser = new Member("joeuser", "Joe", "User", "joeuser@gmail.com");

            SetupResult.For(mockMemberRepository.GetByUsername(email)).Return(stubUser);
            SetupResult.For(mockAuthenticator.VerifyAccount(null, null)).IgnoreArguments().Return(true);

            mockery.ReplayAll();

            string redirectUrl = "http://www.google.com";
            var result = controller.ProcessLogin(email, password, redirectUrl) as RedirectResult;

            Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
            Assert.That(result.Url, NUnit.Framework.SyntaxHelpers.Is.EqualTo(redirectUrl));
        }

        //[Test]
        //public void Should_return_register_view()
        //{
        //    AccountController controller = GetController();

        //    // Executes
        //    var result = controller.Register() as ViewResult;

        //    // Verify
        //    Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("Register"));
        //}

        //[Test]
        //public void Should_return_user_to_the_Register_view_if_a_registration_is_attempted_with_an_already_existing_email_address()
        //{
        //    AccountController controller = GetController();
        //    string email = "joeuser@gmail.com";
        //    var stubUser = new Member("joeuser", "Joe", "User", "joeuser@gmail.com");
        //    SetupResult.For(mockMemberRepository.GetByEmail(email)).Return(stubUser);

        //    mockery.ReplayAll();

        //    var result =
        //        controller.ProcessRegistration("Joe", "User", "joeuser", email, "password", "password") as ViewResult;

        //    Assert.That(result, NUnit.Framework.SyntaxHelpers.Is.Not.Null);
        //    Assert.That(result.ViewName, NUnit.Framework.SyntaxHelpers.Is.EqualTo("Register"));
        //}

        [Test]
        public void UserRepository_should_not_be_called_when_we_can_see_that_loginData_is_invalid()
        {
            AccountController controller = GetController();

            Expect.Call(mockMemberRepository.GetByUsername("")).IgnoreArguments().Repeat.Never();

            mockery.ReplayAll();

            controller.ProcessLogin("", "", null);

            mockery.VerifyAll();
        }

        //[Test]
        //public void
        //    Verify_that_a_call_to_register_with_different_passwords_does_not_attempt_to_see_if_user_exists_since_input_data_is_invalid
        //    ()
        //{
        //    AccountController controller = GetController();

        //    var stubUser = new Member("manbearpig", "will", "crosby", "crosby@server.net");

        //    Expect.Call(mockMemberRepository.GetByEmail(null)).IgnoreArguments().Repeat.Never();
        //        // this should never be called (passwords don't match)

        //    mockery.ReplayAll();

        //    var result =
        //        controller.ProcessRegistration(stubUser.First, stubUser.Last, stubUser.Username, stubUser.Email, "one",
        //                                       "two") as ViewResult;

        //    mockery.VerifyAll();
        //}

        //[Test]
        //public void Ensure_that_a_forgotten_password_can_be_reset_for_a_valid_email_address()
        //{
        //    AccountController controller = GetController();

        //    var stubUser = new Member("joeuser", "Joe", "User", "someemail@someaddress.com");
        //    SetupResult.For(mockMemberRepository.GetByEmail("someemail@someaddress.com")).Return(stubUser);

        //    mockery.ReplayAll();

        //    var result = controller.ForgotPassword("someemail@someaddress.com") as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("RequestSent"));
        //}

        //[Test]
        //public void Ensure_that_a_forgotten_password_can_not_be_reset_for_an_invalid_email_address()
        //{
        //    AccountController controller = GetController();

        //    SetupResult.For(mockMemberRepository.GetByEmail("someemail@someaddress.com")).Return(null);

        //    mockery.ReplayAll();

        //    var result = controller.ForgotPassword("first@last.net") as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("RequestPassword"));
        //}

        //[Test]
        //public void Ensure_that_a_forgotten_password_can_not_be_reset_for_a_null_email_address()
        //{
        //    AccountController controller = GetController();

        //    var result = controller.ForgotPassword(null) as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("RequestPassword"));
        //}

        //[Test]
        //public void Check_that_an_email_and_hashed_email_match_as_well_as_password()
        //{
        //    AccountController controller = GetController();

        //    SetupResult.For(mockCryptographer.HashString("", "")).IgnoreArguments().Return("ivWzZ9EF27fKx4qWtIs5RtD0XKI=");
        //    mockery.ReplayAll();

        //    var result = controller.ResetPassword("cmissal@jpcycles.com", "ivWzZ9EF27fKx4qWtIs5RtD0XKI=", "password", "password") as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("ForgotPassword"));
        //}

        //[Test]
        //public void Check_that_an_email_and_hashed_email_do_not_match()
        //{
        //    AccountController controller = GetController();

        //    SetupResult.For(mockCryptographer.HashString("", "")).IgnoreArguments().Return("ivWzZ9EF27fKx4qWtIs5RtD0XKI=");
        //    mockery.ReplayAll();

        //    var result = controller.ResetPassword("jpcycles@cmissal.com", "ivWzZ9EF27fKx4qWtIs5RtD0XKI=", "password", "password") as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("ForgotPassword"));
        //}

        //[Test]
        //[Ignore]
        //public void Send_email_to_address_for_password_reset_request()
        //{
        //    AccountController controller = GetController();

        //    var stubUser = new Member("cmissal", "Chris", "Missal", "cmissal@jpcycles.com");
        //    SetupResult.For(mockMemberRepository.GetByEmail("")).IgnoreArguments().Return(stubUser);
        //    mockery.ReplayAll();

        //    var result = controller.ForgotPassword("cmissal@jpcycles.com") as ViewResult;

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.ViewName, Is.EqualTo("RequestSent"));
        //}
    }
}