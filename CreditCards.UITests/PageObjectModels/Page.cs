using OpenQA.Selenium;
using System;

namespace CreditCards.UITests.PageObjectModels
{
    class Page
    {
        protected IWebDriver Driver;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        // Checks that the URL and page title are as expected
        // Set to false to do an exact match of the title
        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
    }
}
