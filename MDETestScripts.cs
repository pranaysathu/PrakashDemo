using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;


namespace MDE.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
   
    public class MDETestScripts : TestBase
    {
		TestData testdata;
		internal static IApp app;
		Platform platform;
		string FacilityName = null;
		string Impersonation = null;
		string ConfigurationName = null;
		public MDETestScripts(Platform platform)
		{
			this.platform = platform;
			testdata = SerializeConfig<TestData>.DeSerialize("TestData.xml");
			int count = testdata.DataSetList.Count;
			tData = new Random().Next(0, count);
			FacilityName = testdata.DataSetList[tData].TestList[0].FacilityName;
			Impersonation = testdata.DataSetList[tData].TestList[0].Impersonation;
			ConfigurationName = testdata.DataSetList[tData].TestList[0].ConfigurationName;
		}

		[SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
			try
			{
				app.WaitForElement(c => c.Marked("OK"));
				if (app.Query(c => c.Marked("OK")).Any())
				{
					app.Tap(c => c.Marked("OK"));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.InnerException);
			}
		}

        //[Test]
		[Category("Testing / Debug")]
		public void AppLaunches()
        {
			
            app.Screenshot("First screen.");
			//Login.LoginToApplication(app,"Sales");
			//Facility.ValidateUserLogin(app, "Sales");
			Login.LoginToApplication(app, "Android");
			app.Repl();
			Facility.SelectFacility(app, "poland Family Unit");
			//Facility.SelectFacility(app, "150122243");
			Configuration.SelectConfiguration(app);

			//Facility.ImpersonateUser(app, "75523");
			//Facility.ReloadFunctionality(app, "poland Family Unit");

			Samples.CollapsesamplePoints(app);
			Samples.validateCommentsFunctionality(app);
			Samples.expandIndividualAndEnterParameterReadings(app);
			//app.Repl();
		}


		//[Test]
		public void LoginMDE(string uRole = null)
		{
			app.Screenshot("First screen.");
			if (platform == Platform.Android)
			{
				if (uRole != null && uRole.Equals("Sales"))
					Login.LoginToApplication(app, "Android", "Sales");
				else
					Login.LoginToApplication(app, "Android");
			}
			else
			{
				if (uRole != null && uRole.Equals("Sales"))
					Login.LoginToApplication(app, "iOS", "Sales");
				else
					Login.LoginToApplication(app, "iOS");
			}
		}
		//[Test]
		public void ImpersonateUser()
		{
			LoginMDE();
			Facility.ImpersonateUser(app, Impersonation);
		}
		//[Test]
		public void Reloadfunctionality()
		{
			LoginMDE();
			Facility.ReloadFunctionality(app, FacilityName);
		}
		//[Test]
		[Category("Samples Page")]
		public void AdddataAdmin()
		{
			LoginMDE();
			Facility.SelectFacility(app, FacilityName);
			Configuration.SelectConfiguration(app);
			Samples.CollapsesamplePoints(app);
			Samples.validateCommentsFunctionality(app);
			Samples.expandIndividualAndEnterParameterReadings(app);
		}

		//[Test]
		[Category("Samples Page")]
		public void AdddataSales()
		{
			LoginMDE("Sales");
			Facility.SelectFacility(app, FacilityName);
			Configuration.SelectConfiguration(app, ConfigurationName);
			Samples.CollapsesamplePoints(app);
			//Samples.validateCommentsFunctionality(app);
			Samples.expandIndividualAndEnterParameterReadings(app);
		}

		//[Test]
		[Category("Samples Page")]
		public void CalculatedParametersAdmin()
		{
			LoginMDE();
			Facility.SelectFacility(app, FacilityName);
			Configuration.SelectConfiguration(app, ConfigurationName);
			Samples.validateCalculatedParameters(app);
		}

		//[Test]
		[Category("Samples Page")]
		public void CalculatedParametersSales()
		{
			LoginMDE("Sales");
			Facility.SelectFacility(app, FacilityName);
			Configuration.SelectConfiguration(app, ConfigurationName);
			Samples.validateCalculatedParameters(app);
		}

		//[Test]
		[Category("Facility Page")]
		public void FacilitiesPageTestsAdmin()
		{
			LoginMDE();
			Facility.ValidateUserLogin(app, "Admin");
			Facility.SearchFacility(app, FacilityName);
			Facility.ReloadFunctionality(app, FacilityName);
			Facility.ImpersonateUser(app, Impersonation);
			Facility.ExitImpersonation(app,Impersonation);
			Facility.ValidateSearchFacilitiesText(app,FacilityName);
		}

		//[Test]
		[Category("Facility Page")]
		public void FacilitiesPageTestsSales()
		{
			LoginMDE("Sales");
			Facility.ValidateUserLogin(app, "Sales");
			Facility.ValidateSearchFacilitiesText(app, FacilityName);
		}

		[Test]
		[Category("Api Tests")]
		public void VerifyDataSyncToDocumentDB()
		{
			AdddataSales();
			Thread.Sleep(30000);
			api.ValidatedatainDocumentDB();
			Thread.Sleep(5000);
		}

	}
}

