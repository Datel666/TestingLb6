using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.Init;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestProject.Pages
{
    public class HomePage : TestPageBase
    {
        public override Uri Uri => new Uri(Initializer.RootUri, "");

        #region Navbar
        public IWebElement Hot => Initializer.Driver.FindElement(By.CssSelector("[href*='/']"));

        public IWebElement Best => Initializer.Driver.FindElement(By.CssSelector("[href*='/best']")); 
        public IWebElement New => Initializer.Driver.FindElement(By.CssSelector("[href*='/new']"));
        public IWebElement Subs => Initializer.Driver.FindElement(By.CssSelector("[href*='/subs']"));
        public IWebElement Communities => Initializer.Driver.FindElement(By.CssSelector("[href*='/communities']"));

        //public IWebElement Extra => Initializer.Driver.FindElement(By.CssSelector("[class*='header-menu__extra']"));

        public IWebElement MostSaved => Initializer.Driver.FindElement(By.CssSelector("[href*='/most-saved']"));

        public IWebElement Disputed => Initializer.Driver.FindElement(By.CssSelector("[href*='/disputed']"));


        public IWebElement SearchF => Initializer.Driver.FindElement(By.CssSelector("[class*='input__input'][name*='q']"));

        

        #endregion

        #region Authorization

        public IWebElement Login => Initializer.Driver.FindElement(By.XPath("//form[@id='signin-form']/div/div/div/input"));

        public IWebElement RegLogin => Initializer.Driver.FindElement(By.XPath("//div[2]/div[2]/form/div/div/div/input"));

        public IWebElement Password => Initializer.Driver.FindElement(By.XPath("//form[@id='signin-form']/div[2]/div/div/input"));

        public IWebElement RegPassword => Initializer.Driver.FindElement(By.XPath("(//input[@name='password'])[2]"));

        public IWebElement RefPhone => Initializer.Driver.FindElement(By.XPath("//input[@name='phone']"));

        public IWebElement RegEmail => Initializer.Driver.FindElement(By.XPath("//input[@name='email']"));

        public IWebElement SubmitBtn => Initializer.Driver.FindElement(By.CssSelector("[class*='button_success']"));

        public IWebElement RegisterBtn => Initializer.Driver.FindElement(By.XPath("//div[8]/button/span"));

        public IWebElement PopupWindow => Initializer.Driver.FindElement(By.XPath("//body/div[4]/div/div/div/div[2]"));

        public IWebElement ClosePopupBtn => Initializer.Driver.FindElement(By.XPath("//button[2]"));

        public IWebElement SwitchActionToReg => Initializer.Driver.FindElement(By.XPath("//div[7]/span"));
        public IWebElement SwitchActionToAut => Initializer.Driver.FindElement(By.XPath("//div[9]/span"));

        public IWebElement AutLabel => Initializer.Driver.FindElement(By.XPath("//aside/div/div/div/div/div"));

        public IWebElement AutErrorLabel => Initializer.Driver.FindElement(By.XPath("//form[@id='signin-form']/div[4]/span"));

        public IWebElement RegLabel => Initializer.Driver.FindElement(By.XPath("//aside/div/div/div/div[2]/div"));
        #endregion




        #region navBarFunctions
        public void HotClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", Hot);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Горячее"));
        }
        public void BestClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", Best);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Лучшие"));
        }
        public void NewClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", New);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Свежие"));
        }
        public void SubsClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", Subs);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Лента подписок"));
        }
        public void CommunitiesClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", Communities);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Сообщества"));
        }

        public void ExtraHover()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class*='header-menu__extra']")));

            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();
        }
       
        public void ExtraMostSaved()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", MostSaved);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Самые сохраняемые"));
        }

        public void ExtraDisputed()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", Disputed);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Самые обсуждаемые"));
        }

        public void SearchHover()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class*='header-right-menu__item header-right-menu__search']")));

            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();
        }
        public void SearchEdit(string text)
        {
            SearchF.SendKeys(text);
        }

        public void PerformSearch()
        {
            SearchF.SendKeys(Keys.Enter);
        }

        public string getSearchFText()
        {
            return SearchF.GetAttribute("value");
        }
        
        #endregion

        #region Login&RegFunctions

        public void LoginEdit(string text)
        {
            Login.SendKeys(text);
        }

        public void PasswordEdit(string text)
        {
            Password.SendKeys(text);
        }
        
        public string getAutLoginText()
        {
            return Login.GetAttribute("value");
        }
        public string getAutPasswordText()
        {
            return Password.GetAttribute("value");
        }

        public void RegLoginEdit(string text)
        {
            RegLogin.SendKeys(text);
        }
        public string getRegLoginText()
        {
            return RegLogin.GetAttribute("value");
        }
        public void RegPasswordEdit(string text)
        {
            RegPassword.SendKeys(text);
        }
        public string getRegPasswordText()
        {
            return RegPassword.GetAttribute("value");
        }
        public void RegEmailEdit(string text)
        {
            RegEmail.SendKeys(text);
        }
        public string getRegEmailText()
        {
            return RegEmail.GetAttribute("value");
        }
        public void RegPhoneEdit(string text)
        {
            if(ulong.TryParse(text,out ulong n))
            {
                RefPhone.SendKeys(text);
            }
            else
            {
                throw new Exception("Not a number");
            }
        }
        public string getRegPhoneText()
        {
            return RefPhone.GetAttribute("value");
        }

        public void SubmitBtnClick()
        {
            try
            {
                Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", SubmitBtn);

            }
            catch
            {
                throw new Exception("Something went wrong");
            }

        }

        public void RegisterBtnClick()
        {
            try
            {
                Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", RegisterBtn);

            }
            catch
            {
                throw new Exception("Captcha");
            }
        }

        public bool IsPopupVisible()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//body/div[4]/div/div/div/div[2]")));
                return PopupWindow.Displayed;
            }
            catch
            {
                throw new Exception("Captcha");
            }
            
        }

        public void closePopupClick()
        {
            try
            {
                Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", ClosePopupBtn);

            }
            catch
            {
                throw new Exception("Something went wrong");
            }
        }

        public bool IsAutLabelVisible()
        {
            return AutLabel.Displayed;
        }

        public bool IsRegLabelVisible()
        {
            return RegLabel.Displayed;
        }

        public void SwitchActionToAutBtnClick()
        {
          Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", SwitchActionToAut);
        }

        public void SwitchActionToRegBtnClick()
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", SwitchActionToReg);
        }


        #endregion





        public HomePage(ITestStartupInitializer initializer) : base(initializer)
        {
        }
    }
}
