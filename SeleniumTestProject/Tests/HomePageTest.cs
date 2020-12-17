using SeleniumTestProject.Init;
using SeleniumTestProject.Pages;
using System;
using Xunit;

namespace SeleniumTestProject
{
    public class HomePageTests : IClassFixture<TestStartupInitializerDefault>
    {
        private readonly TestStartupInitializerDefault _initializer;
        private readonly HomePage _page;

        public HomePageTests(TestStartupInitializerDefault initializer)
        {
            _initializer = initializer;
            _page = new HomePage(initializer);
        }


        [Fact]
        public void NavBarTest()
        {
            _page.Navigate();
            _page.HotClick();

            Assert.Contains("Горячее", _page.Title);

            _page.BestClick();
            Assert.Contains("Лучшие", _page.Title);

            _page.NewClick();
            Assert.Contains("Свежие", _page.Title);

            _page.SubsClick();
            Assert.Contains("Лента подписок", _page.Title);

            _page.CommunitiesClick();
            Assert.Contains("Сообщества", _page.Title);

            _page.ExtraHover();
            _page.ExtraMostSaved();
            Assert.Contains("Самые сохраняемые", _page.Title);

            _page.ExtraHover();
            _page.ExtraDisputed();
            Assert.Contains("Самые обсуждаемые", _page.Title);

        }

        [Fact]
        public void SearchFTest()
        {
            string text = "Кек";
            _page.Navigate();
            _page.SearchHover();
            _page.SearchEdit(text);
            Assert.Equal(text, _page.getSearchFText());
            _page.PerformSearch();
        }

        [Fact]
        public void LoginRegisterTest()
        {
            string login = "Kekega";
            string password = "Abkal*63";
            string phone = "88005553535";
            string email = "Kekega@mail.ru";
            Exception ex;
            _page.Navigate();
            _page.LoginEdit(login);
            _page.PasswordEdit(password);
            Assert.Equal(login, _page.getAutLoginText());
            Assert.Equal(password, _page.getAutPasswordText());
            Assert.True(_page.IsAutLabelVisible());
            Assert.False(_page.IsRegLabelVisible());
             _page.SubmitBtnClick();

            _initializer.EnsureServerRestart();
            _page.Navigate();
            _page.SwitchActionToRegBtnClick();
            Assert.True(_page.IsRegLabelVisible());
            Assert.False(_page.IsAutLabelVisible());
            _page.RegLoginEdit(login);
            _page.RegPasswordEdit(password);
            _page.RegPhoneEdit(phone);
            _page.RegEmailEdit(email);
            
            Assert.Equal(login, _page.getRegLoginText());
            Assert.Equal(password, _page.getRegPasswordText());
            Assert.Equal(phone, _page.getRegPhoneText());
            Assert.Equal(email, _page.getRegEmailText());
            try
            {
                 ex = Assert.Throws<Exception>(() => _page.RegisterBtnClick());
                 Assert.Equal("Captcha", ex.Message);
                
            }

            catch
            {
                try
                {
                    _page.RegisterBtnClick();
                     ex = Assert.Throws<Exception>(() => _page.IsPopupVisible());
                    _page.IsPopupVisible();
                    _page.closePopupClick();
                }
                catch
                {}
            }
            _page.SwitchActionToAutBtnClick();
            Assert.True(_page.IsAutLabelVisible());
            
         }
    }
    }