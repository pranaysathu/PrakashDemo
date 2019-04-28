using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using Xamarin.UITest;
using System.Windows.Forms;
using System.Reflection;
using NUnit.Framework;

namespace MDE.UITest
{
    public class LoginPageTests : TestBase
    {
		LoginData logindata;

		public LoginPageTests()
		{
			logindata = SerializeConfig<LoginData>.DeSerialize("InputData.xml");
		}
		public void LoginToApplication(IApp app, string Platform, string uRole=null )
        {
			string userMailID = null, oktaUname = null, oktaPassword = null;
			string wUser = null;

			if (uRole != null && uRole.Equals("Sales"))
			{
				for (int i = 0; i < logindata.UserList.Count; i++)
				{
					if (logindata.UserList[i].UserRole == "Sales")
					{
						userMailID = logindata.UserList[i].UserMail;
						oktaUname = logindata.UserList[i].UserID;
						oktaPassword = DecryptPassword(logindata.UserList[i].Password);
					}
				}
			}
			else
			{
				for (int i = 0; i < logindata.UserList.Count; i++)
				{
					if (logindata.UserList[i].UserRole == "Admin")
					{
						userMailID = logindata.UserList[i].UserMail;
						oktaUname = logindata.UserList[i].UserID;
						oktaPassword = DecryptPassword(logindata.UserList[i].Password);
					}
				}
			}

			app.Screenshot(" Navigated to login screen");
			app.WaitForElement(c => c.Css(loginpageobjs.UserNameOutlookCss), "Outlook login page not displayed", TimeSpan.FromSeconds(90));
			string[] LoginType = userMailID.Split('@');
			if (Platform.Equals("Android"))
			{
				app.Query(c => c.WebView().Id("agentWebView").InvokeJS("document.getElementById('" + loginpageobjs.UserNameOutlook + "').value='" + userMailID + "'"));
				app.PressEnter();
				app.DismissKeyboard();
				if(LoginType[1].Equals("nalco.com"))
				{
					app.Tap(c => c.Css(loginpageobjs.UserPasswordOutlookCss));
					app.Query(c => c.WebView().Id("agentWebView").InvokeJS("document.getElementById('" + loginpageobjs.UserPasswordOutlook + "').value='" + oktaPassword + "'"));
					app.Tap(c => c.Css(loginpageobjs.OutlookSignIn));
				}
				else
				{
					app.WaitForElement(c => c.Css(loginpageobjs.UserNameOktaCss), "Okta login page not displayed", TimeSpan.FromSeconds(90));
					app.Query(c => c.WebView().Id("agentWebView").InvokeJS("document.getElementById('" + loginpageobjs.UserNameOkta + "').value='" + oktaUname + "'"));
					//app.Tap(c => c.Css(loginpageobjs.UserNameOktaCss));
					app.PressEnter();
					app.Tap(c => c.Css(loginpageobjs.UserPasswordCss));
					app.Query(c => c.WebView().Id("agentWebView").InvokeJS("document.getElementById('" + loginpageobjs.UserPassword + "').value='" + oktaPassword + "'"));
					app.Tap(c => c.Css(loginpageobjs.UserPasswordCss));
					app.PressEnter();
					//app.Tap(c => c.Css(loginpageobjs.SignInOkta));
				}
			}
			else
			{
				app.EnterText(c => c.Css(loginpageobjs.UserNameOutlookCss), userMailID);
				app.PressEnter();
				app.DismissKeyboard();
				if (LoginType[1].Equals("nalco.com"))
				{
					app.Tap(c => c.Css(loginpageobjs.UserPasswordOutlookCss));
					app.EnterText(c => c.Css(loginpageobjs.UserPasswordOutlookCss), oktaPassword);
					app.Tap(c => c.Css(loginpageobjs.OutlookSignIn));
				}
				else
				{
					app.WaitForElement(c => c.Css(loginpageobjs.UserNameOktaCss), "Okta login page not displayed", TimeSpan.FromSeconds(90));
					app.EnterText(c => c.Css(loginpageobjs.UserNameOktaCss), oktaUname);
					app.Tap(c => c.Css(loginpageobjs.UserPasswordCss));
					app.EnterText(c => c.Css(loginpageobjs.UserPasswordCss), oktaPassword);
					app.PressEnter();
					//app.Tap(c => c.Css(loginpageobjs.SignInOkta));
				}
			}
			app.Screenshot(" Clicked on Sign In button");
			app.WaitForElement(c => c.Marked(facilitiespageobjs.LoggedINUser), "Could not find the element: Logged in user name not displayed", TimeSpan.FromSeconds(90));
			wUser = app.Query(c => c.Marked(facilitiespageobjs.LoggedINUser)).First().Text;
			string[] userFname = wUser.Split(' ');
			string[] mailFname = userMailID.Split('.');
			Assert.IsTrue(userFname[1].ToLower().Contains(mailFname[0].ToLower()), "Landing Page Displayed and Unauthorized user access");
			if (uRole != null && uRole.Equals("Sales"))
			{
				app.WaitForElement(c => c.Marked(facilitiespageobjs.FacilityList), "No Facilties found for Sales user", TimeSpan.FromSeconds(200));
			}
			app.Screenshot("After Login");
		}
	}
}
