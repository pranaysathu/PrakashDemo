using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using System.Threading;

namespace MDE.UITest
{
    public class ConfigurationsPageTests : TestBase
    {
        public void SelectConfiguration(IApp app, string configName = null)
        {
			app.WaitForElement(c => c.Marked(configpageobjs.ConfigurationList), "No Configurations get displayed", TimeSpan.FromSeconds(60));
			var cList = app.Query(c => c.Marked(configpageobjs.ConfigurationList));
			Assert.True(cList.Count() >= 1, "Configuration page is displayed and no Configurations found");
			if (configName != null)
			{
				app.ScrollTo(configName);
				int configcount = app.Query(c => c.All().Marked(configpageobjs.ConfigurationList)).Count();
				for (int i = 0; i < configcount; i++)
				{
					string cname = app.Query(c => c.Marked(configpageobjs.ConfigurationList).Index(i)).First().Text;
					if (cname.Contains(configName))
					{
						app.Tap(c => c.All().Marked(configpageobjs.ConfigurationList).Index(i));
						break;
					}
				}
			}
			else
			{
				app.Tap(c => c.Marked(configpageobjs.ConfigurationList).Index(0));
			}
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplesLeftArrow), "Could not find the Samples Page left arrow because of samples page is not displayed", TimeSpan.FromSeconds(60));
			app.Screenshot("Configuration Selected");
		}

    }
}
