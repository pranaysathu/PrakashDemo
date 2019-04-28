using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MDE.UITest
{
	public class LoginData
	{
		public LoginData()
		{
			UserList = new List<LoginData>();
			ApiData = new List<LoginData>();
		}

		[XmlElement("UserRole")]
		public string UserRole { get; set; }

		[XmlElement("UserMail")]
		public string UserMail { get; set; }

		[XmlElement("UserID")]
		public string UserID { get; set; }

		[XmlElement("Password")]
		public string Password { get; set; }

		[XmlElement("Data")]
		public List<LoginData> UserList { get; set; }

		[XmlElement("ApiData")]
		public List<LoginData> ApiData { get; set; }

		[XmlElement("AuthURL")]
		public string AuthUrl { get; set; }

		[XmlElement("ResourceID")]
		public string ResourceID { get; set; }

		[XmlElement("ClientID")]
		public string ClientID { get; set; }

		[XmlElement("WebApi")]
		public string WebApi { get; set; }

	}

	public class TestData
	{
		public TestData()
		{
			TestList = new List<TestData>();
			CalList = new List<TestData>();
			DataSetList = new List<TestData>();
		}

		[XmlElement("DataSet")]
		public List<TestData> DataSetList { get; set; }

		[XmlElement("FacilityName")]
		public string FacilityName { get; set; }

		[XmlElement("ConfigurationName")]
		public string ConfigurationName { get; set; }


		[XmlElement("Impersonation")]
		public string Impersonation { get; set; }

		[XmlElement("Data")]
		public List<TestData> TestList { get; set; }

		[XmlElement("CalculationVaraibles")]
		public List<TestData> CalList { get; set; }

		[XmlElement("CalculatedParameter")]
		public string CalculatedParameter { get; set; }

		[XmlElement("Variable")]
		public string Variable { get; set; }

		[XmlElement("Reading")]
		public string Reading { get; set; }

		[XmlElement("Output")]
		public string Output { get; set; }

	}
}
