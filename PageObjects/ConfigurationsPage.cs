using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.UITest.PageObjects
{
    public class ConfigurationsPage
    {
        public string ConfigurationList
        {
            get
            {
                return ConfigurationsPageCtrls.ConfigurationList;
            }
        }

        public string ConfigurationLable
        {
            get
            {
                return ConfigurationsPageCtrls.Configuration_Lable;
            }
        }

        public string ConfigurationRightArrow
        {
            get
            {
                return ConfigurationsPageCtrls.ConfigurationRightArrow;
            }
        }

		public string ConfigurationBackArrow
		{
			get
			{
				return ConfigurationsPageCtrls.ConfiguarionBack;
			}
		}

	}
}
