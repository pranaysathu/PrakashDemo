using Microsoft.IdentityModel.Clients.ActiveDirectory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MDE.UITest
{
	public class ApiTests : TestBase
	{
		public static string token = string.Empty;
		LoginData logindata;
		public ApiTests()
		{
			logindata = SerializeConfig<LoginData>.DeSerialize("InputData.xml");
		}
		public void Token()
		{
			string uname = logindata.ApiData[0].UserMail;
			string password = DecryptPassword(logindata.ApiData[0].Password);
			string authUrl = logindata.ApiData[0].AuthUrl;
			string resourceID = logindata.ApiData[0].ResourceID;
			string clientID = logindata.ApiData[0].ClientID;

			var credentials = new UserPasswordCredential(uname, password);
			var context = new AuthenticationContext(authUrl);
			var authResult = context.AcquireTokenAsync(resourceID, clientID, credentials).Result; 
			token = authResult.AccessToken;

		}

		public async void ValidatedatainDocumentDB()
		{
			Token();
			using (var client = new HttpClient())
			{
				var url = logindata.ApiData[0].WebApi;
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
				var response = await client.GetStringAsync(url);
				Assert.IsTrue(response.Contains(SamplesPageTests.GeneralComment), "Records saved in Mobile not saved to Document DB");
			}
		}
	}
}
