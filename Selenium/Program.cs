// See https://aka.ms/new-console-template for more information

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class SeleniumManager
{

    public static void Main()
    {
        SendViaWhatsApp("39xxxxxxxxxx","Hi, this is John");
    }

    public static void SendViaWhatsApp(string mobile, string message)
    {
        //Get actual working directory
        string workingDir = Directory.GetCurrentDirectory();

        //specify location for profile creation/ access
        string seleniumDataPath = Path.Combine(workingDir, "seleniumdata");

        //specify drivers location
        string driversPath = Path.Combine(workingDir, "drivers");

        ChromeOptions options = new ChromeOptions();
        options.AddArguments(@"user-data-dir=" + seleniumDataPath);
        //options.AddArgument("--headless");

        var driver = new ChromeDriver(driversPath, options);

        //Goes to WhatsApp URL
        driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + mobile);

        //Finds the element
        var textBox = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p"));

        //Clicks on the text box
        textBox.Click();

        //Fills the box with the stringToSearch value
        textBox.SendKeys(message);

        //Gets the send arrow
        var sendArrow = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span"));

        //Clicks on the search button
        sendArrow.Click();

        driver.Quit();


    }

}
