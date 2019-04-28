using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using NUnit.Framework;
using System.Threading;

namespace MDE.UITest
{
    public class FacilitiesPageTests : TestBase
    {
        
        public void SearchFacility(IApp app, string FacilityName)
        {
                        
            app.Screenshot("Facilties Page");
            app.EnterText(c => c.Marked(facilitiespageobjs.SearchFacilities), FacilityName);
			app.DismissKeyboard();
            app.Tap(c => c.Marked(facilitiespageobjs.SearchButton));
			app.WaitForElement(c => c.Marked(facilitiespageobjs.FacilityList), "No Facilties found with Search criteria", TimeSpan.FromSeconds(90));
			var flList = app.Query(c => c.Marked(facilitiespageobjs.FacilityList));
            Assert.True(flList.Count() >= 1 , "No Facilities Found");
            string resultText = flList[0].Text;
            Assert.True(resultText.Contains(FacilityName.ToUpper()), "Invalid search Results");
			app.Screenshot("After searching the Facility");
        }

        public void SelectFacility(IApp app, string FacilityName)
        {
            SearchFacility(app, FacilityName);
            app.Tap(c => c.Marked(facilitiespageobjs.FacilityList).Index(0));
            app.WaitForElement(c => c.Marked(configpageobjs.ConfigurationLable), timeoutMessage: "Could not find the Configurations lable because of configuration page is not displayed", timeout: TimeSpan.FromSeconds(10), retryFrequency: TimeSpan.FromSeconds(2), postTimeout: TimeSpan.FromSeconds(5));
            var cList = app.Query(c => c.Marked(configpageobjs.ConfigurationList));
            Assert.True(cList.Count() >= 1, "Configuration page is displayed and no Configurations found");
			app.Screenshot("After selecting the Facillity");
        }

        public void ImpersonateUser(IApp app, string UserId)
        {
            app.Tap(c => c.Marked(facilitiespageobjs.Reload));
			Thread.Sleep(5000);
            var beforeImp = app.Query(c => c.Marked(facilitiespageobjs.FacilityList));
            app.Tap(c => c.Marked(facilitiespageobjs.Impersonate));
            app.EnterText(c => c.Marked(facilitiespageobjs.ImpersonateUserID), UserId);
			app.Tap(c => c.Marked(facilitiespageobjs.ImpersonateOk));
			app.WaitForElement(c => c.Marked(facilitiespageobjs.FacilityList), "No Facilties assgined to the sales user", TimeSpan.FromSeconds(120));
			var afterImp = app.Query(c => c.Marked(facilitiespageobjs.FacilityList));
            Assert.True(!beforeImp.Count().Equals(afterImp.Count()), "Impersonation not successful OR User is not assigned to any Facilities");
			app.Screenshot("After impersonating the user");
        }

        public void ReloadFunctionality(IApp app, string FaciltyName)
        {
			app.ClearText(c => c.Marked(facilitiespageobjs.SearchFacilities));
			app.Tap(c => c.Marked(facilitiespageobjs.Reload));
            SearchFacility(app, FaciltyName);
            var fList = app.Query(c => c.Marked(facilitiespageobjs.FacilityList));
            int count = fList.Count();
            if (count > 0)
            {
                app.ClearText(c => c.Marked(facilitiespageobjs.SearchFacilities));
                app.Tap(c => c.Marked(facilitiespageobjs.Reload));
				app.WaitForNoElement(c => c.Marked(facilitiespageobjs.FacilityList), "Reload Not successful", TimeSpan.FromSeconds(90));
            }
			app.Screenshot("After Reload");
        }

		public void ExitImpersonation(IApp app,string UserId)
		{
			app.Tap(c => c.Marked(facilitiespageobjs.Impersonate));
			app.ClearText(c => c.Text(UserId));
			app.Tap(c => c.Marked(facilitiespageobjs.ImpersonateOk));
			Thread.Sleep(2000);
			var fList = app.Query(c => c.Marked(facilitiespageobjs.FacilityList));
			Assert.True(fList.Count() == 0, "Exit impersonation is not successful");
			app.Screenshot("After exiting the Impersonation");
		}

		public void ValidateUserLogin(IApp app, string uType)
		{
			if(uType.Equals("Sales"))
			{
				app.WaitForElement(c => c.Marked(facilitiespageobjs.Reload), "No Reload symbol displayed for sales user", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.SearchFacilities), "Search field not displayed for sales user", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.SearchButton), "No search button displayed for sales user", TimeSpan.FromSeconds(60));
				app.WaitForNoElement(c => c.Marked(facilitiespageobjs.Impersonate), "Impersonate Icon displayed for sales user where sales user not eligible for impersonattion", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.FacilityList), "No Facilties assigned to the user", TimeSpan.FromSeconds(180));
				app.Screenshot("After validating the user details - Sales");
			}
			else if(uType.Equals("Admin"))
			{
				app.WaitForElement(c => c.Marked(facilitiespageobjs.Reload), "No Reload symbol displayed for Admin user", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.SearchFacilities), "Search field not displayed for Admin user", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.SearchButton), "No search button displayed for Admin user", TimeSpan.FromSeconds(60));
				app.WaitForElement(c => c.Marked(facilitiespageobjs.Impersonate), "Impersonate Icon not displayed for Admin user", TimeSpan.FromSeconds(60));
				app.Screenshot("After validating the user details - Admin");
			}
		}

		public void ValidateSearchFacilitiesText(IApp app, string FaciltyName)
		{
			SelectFacility(app, FaciltyName);
			app.Tap(c => c.Marked(configpageobjs.ConfigurationBackArrow));
			string fName = app.Query(c => c.Marked(facilitiespageobjs.SearchFacilities)).First().Text;
			app.Screenshot("After Navigate Back to Facilities Page");
			Assert.True(string.IsNullOrEmpty(fName), "After selecting the Faciltiy search text not Cleared");
		}
	}
}
