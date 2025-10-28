using OrangeHRM.Pages;
using OrangeHRM.Tests;

namespace OrangeHRM.Tests
{
    public class HomeTests : BaseTest
    {
        [Fact]
        public void Verify_HomePage_Title()
        {
            var loginPage = new LoginPage(Driver);
            //var expectedUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

            //loginPage.NavigateTo(expectedUrl);
            
            loginPage.Login("Admin", "admin123");
            
            Thread.Sleep(5000);
        }
    }
}