 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDE.UITest.PageObjects;
using NUnit.Framework;
using System.IO;

namespace MDE.UITest
{
    public class TestBase
    {
		static internal int tData;
		private LoginPage login;
        public LoginPage loginpageobjs
        {
            get
            {
                login = new LoginPage();
                return login;
            }
        }

        private FacilitiesPage facilities;
        public FacilitiesPage facilitiespageobjs
        {
            get
            {
                facilities = new FacilitiesPage();
                return facilities;
            }
        }

        private ConfigurationsPage config;
        public ConfigurationsPage configpageobjs
        {
            get
            {
                config = new ConfigurationsPage();
                return config;
            }
        }

        private SamplesPage samples;
        public SamplesPage samplespageobjs
        {
            get
            {
                samples = new SamplesPage();
                return samples;
            }
        }

		private LoginPageTests loginT;
		public LoginPageTests Login
		{
			get
			{
				loginT = new LoginPageTests();
				return loginT;
			}
		}

		private FacilitiesPageTests facilityT;
		public FacilitiesPageTests Facility
		{
			get
			{
				facilityT = new FacilitiesPageTests();
				return facilityT;
			}
		}

		private ConfigurationsPageTests configurationT;
		public ConfigurationsPageTests Configuration
		{
			get
			{
				configurationT = new ConfigurationsPageTests();
				return configurationT;
			}
		}

		private SamplesPageTests sampleT;
		public SamplesPageTests Samples
		{
			get
			{
				sampleT = new SamplesPageTests();
				return sampleT;
			}
		}

		private ApiTests apiT;

		public ApiTests api
		{
			get
			{
				apiT = new ApiTests();
				return apiT;
			}
		}

		public void EncryptPassword()
		{
			byte[] passBytes = System.Text.Encoding.Unicode.GetBytes("");
			string encryptPass = Convert.ToBase64String(passBytes);
		}

		public string DecryptPassword(string encryptedPassword)
		{
			byte[] passByteData = Convert.FromBase64String(encryptedPassword);
			string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
			return originalPassword;
		}

		[TestFixtureTearDown]
		public void Report()
		{
			StringBuilder sb = new StringBuilder();
			var trxBat = Directory.GetCurrentDirectory() + @"\TestResult.bat";
			var xmlPath = Directory.GetCurrentDirectory() + @"\TestResult.xml";
			var reportPath = Directory.GetCurrentDirectory() + @"\Report.html";
			TextWriter tw = new StreamWriter(trxBat, false);
			sb.Append("reportunit ");
			sb.Append($"\"{xmlPath}\"");
			sb.Append($" \"{reportPath}\"");
			tw.Write(sb.ToString());
			tw.Close();
		}

	}

}
