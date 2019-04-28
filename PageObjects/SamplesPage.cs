using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.UITest.PageObjects
{
    public class SamplesPage
    {
        #region  General Pageobjects 
        public string SamplesLeftArrow
        {
            get
            {
                return SamplesPageCtrls.SamplesLeftArrow;
            }
        }

        public string Date
        {
            get
            {
                return SamplesPageCtrls.DatePicker;
            }
        }

        public string Time
        {
            get
            {
                return SamplesPageCtrls.TimePicker;
            }
        }

        public string GeneralCommentEmpty
        {
            get
            {
                return SamplesPageCtrls.GeneralComment_Empty;
            }
        }

        public string GeneralCommentFull
        {
            get
            {
                return SamplesPageCtrls.GeneralComment_Full;
            }
        }

        public string GeneralCommentText
        {
            get
            {
                return SamplesPageCtrls.GeneralComment_Text;
            }
        }

        public string Save
        {
            get
            {
                return SamplesPageCtrls.SaveButton;
            }
        }

		public string Samples
		{
			get
			{
				return SamplesPageCtrls.SamplesLable;
			}
		}
        #endregion
       
        #region SamplepointlevelPageobjects
        public string SamplePointName
        {
            get
            {
                return SamplesPageCtrls.SamplePointName;
            }
        }

        public string SamplePointCommentEmpty
        {
            get
            {
                return SamplesPageCtrls.SamplePointComment_Empty;
            }
        }

        public string SamplePointCommentFull
        {
            get
            {
                return SamplesPageCtrls.SamplePointComment_Full;
            }
        }

        public string SamplePointCommentText
        {
            get
            {
                return SamplesPageCtrls.SamplePointComment_Text;
            }
        }

        public string SamplePointDownArrowMinus
        {
            get
            {
                return SamplesPageCtrls.SamplePoint_DownArrowMinus;
            }
        }

		public string SamplePointDownArrowPlus
		{
			get
			{
				return SamplesPageCtrls.SamplePoint_DownArrowPlus;
			}
		}
		#endregion

		#region Parameter level Page objects
		public string ParameterName
        {
            get
            {
                return SamplesPageCtrls.SampleParameterName;
            }
        }

        public string ParameterLeftLimit
        {
            get
            {
                return SamplesPageCtrls.SampleParameterLeftLimit;
            }
        }

        public string ParameterRightLimit
        {
            get
            {
                return SamplesPageCtrls.SampleParameterRightLimit;
            }
        }

        public string ParameterUnits
        {
            get
            {
                return SamplesPageCtrls.SampleParameterMeasureUnit;
            }
        }

        public string ParameterReading
        {
            get
            {
                return SamplesPageCtrls.SampleParameterReading;
            }
        }

        public string ParameterReadingCommentsEmpty
        {
            get
            {
                return SamplesPageCtrls.SampleParameterReadingComments_Empty;
            }
        }

        public string ParameterReadingCommentsFull
        {
            get
            {
                return SamplesPageCtrls.SampleParameterReadingComments_Full;
            }
        }

        public string ParameterReadingCommentsText
        {
            get
            {
                return SamplesPageCtrls.SampleParameterComment_Text;
            }
        }
        #endregion
    }
}
