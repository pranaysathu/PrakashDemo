using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using System.Configuration;
using System.Threading;
using MDE.UITest.Utilities;

namespace MDE.UITest.PageObjects
{

    public class LoginPage
    {
       // private string UserOutlook;
        public string UserNameOutlook
        {
            get
            {
                return LoginPageCtrls.Outlook_TxtBx_UserName;
            }            
        }

        public string UserNameOkta
        {
            get
            {
                return LoginPageCtrls.Okta_TxtBx_UserName;
            }
        }

        public string UserPassword
        {
            get
            {
                return LoginPageCtrls.Okta_TxtBx_Password;
            }
        }

        public string SignInOkta
        {
            get
            {
                return LoginPageCtrls.Okta_Btn_SignIn;
            }
        }

		public string UserNameOutlookCss
		{
			get
			{
				return LoginPageCtrls.Outlook_TxtBx_UserName_Css;
			}
		}

		public string UserNameOktaCss
		{
			get
			{
				return LoginPageCtrls.Okta_TxtBx_UserName_Css;
			}
		}

		public string UserPasswordCss
		{
			get
			{
				return LoginPageCtrls.Okta_TxtBx_Password_Css;
			}
		}

		public string UserNameLableCss
		{
			get
			{
				return LoginPageCtrls.Okta_UserNameLable_Css;
			}
		}

		public string UserPasswordOutlook
		{
			get
			{
				return LoginPageCtrls.Outlook_TxtBx_Password;
			}
		}

		public string UserPasswordOutlookCss
		{
			get
			{
				return LoginPageCtrls.Outlook_TxtBx_Password_Css;
			}
		}

		public string OutlookSignIn
		{
			get
			{
				return LoginPageCtrls.Outlook_Btn_SignIn;
			}
		}


	}
}
