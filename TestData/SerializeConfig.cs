using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;


namespace MDE.UITest
{
	public class SerializeConfig<T> where T : class
	{
		public static void Serialize(string path, T type)
		{
			var serializer = new XmlSerializer(type.GetType());
			using (var writer = new FileStream(path, FileMode.Create))
			{
				serializer.Serialize(writer, type);
			}
		}

		public static T DeSerialize(string fileName)
		{
			T type;
			var assembly = Assembly.GetExecutingAssembly();
			Stream stream = assembly.GetManifestResourceStream("MDE.UITest.TestData." + fileName);

			using (StreamReader sreader = new StreamReader(stream))
			{
				using (XmlReader xreader = XmlReader.Create(sreader))
				{
					var serializer = new XmlSerializer(typeof(T));
					type = serializer.Deserialize(xreader) as T;
				}
			}
			return type;
		}
	}
}
