using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MDE.UITest
{
    public class SamplesPageTests : TestBase
    {
		TestData testdata;
		public static string GeneralComment = string.Empty;
		public SamplesPageTests()
		{
			testdata = SerializeConfig<TestData>.DeSerialize("TestData.xml");
		}
		public string generateRandomString(int stringLength)
		{
			string allowedChars = "1234567890";
			var rSeed = new Random();
			char[] newChars = new char[stringLength];

			for (int i = 0; i < stringLength; i++)
			{
				newChars[i] = allowedChars[rSeed.Next(allowedChars.Length)];
			}
			String randString = new String(newChars);
			return randString;
		}

		public void CollapsesamplePoints(IApp app)
		{
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus), timeoutMessage: "Could not find the sample point down arrow", timeout: TimeSpan.FromSeconds(10), retryFrequency: TimeSpan.FromSeconds(2), postTimeout: TimeSpan.FromSeconds(5));
			var spMinusArrows = app.Query(c => c.All().Marked(samplespageobjs.SamplePointDownArrowMinus));
			int intialCount = spMinusArrows.Count();
			string firstSamplePoint, latestSP;
			firstSamplePoint = app.Query(c => c.Marked(samplespageobjs.SamplePointName)).First().Text;
			for (int i = 0; i < intialCount; i++)
			{
				AppResult[] Minus = app.Query(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
				if(Minus.Count() > 0)
				{
					app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
				}
				else
				{
					i--;
					app.ScrollDown();
				}
			}
			do
			{
				app.ScrollUp();
				latestSP = app.Query(c => c.Marked(samplespageobjs.SamplePointName)).First().Text;
			}
			while (!latestSP.Equals(firstSamplePoint));
			app.Screenshot("Collapsed Screenshot");
		}

		

		public void validateCommentsFunctionality(IApp app)
		{
			app.Tap(c => c.Marked(samplespageobjs.GeneralCommentEmpty));
			app.WaitForElement(c => c.Marked(samplespageobjs.GeneralCommentText), "Comment textbox not getting displayed after tapping General comment empty Icon ", TimeSpan.FromSeconds(60));
			app.EnterText(c => c.Marked(samplespageobjs.GeneralCommentText), "Generalcomment");
			app.WaitForElement(c => c.Marked(samplespageobjs.GeneralCommentFull), "After entering the comments,General comment icon not changed to comment full icon", TimeSpan.FromSeconds(60));
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			app.WaitForNoElement(c => c.Marked(samplespageobjs.GeneralCommentText), "General comment text field not hided after tapping on comment full");

			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointName), "Could not find the sample point Name, There is no Sample points", TimeSpan.FromSeconds(60));
			string samplePoint = app.Query(c => c.All().Marked(samplespageobjs.SamplePointName)).First().Text;
			app.Tap(c => c.Marked(samplespageobjs.SamplePointCommentEmpty));
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointCommentText), "Comment textbox not getting displayed after tapping Sample point comment empty Icon ", TimeSpan.FromSeconds(60));
			app.EnterText(c => c.Marked(samplespageobjs.SamplePointCommentText), samplePoint + " samplepointlevelcomment");
			app.ScrollUp();
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointCommentFull), "After entering the comments,Samplepoint  comment icon not changed to comment full icon", TimeSpan.FromSeconds(60));
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			app.WaitForNoElement(c => c.Marked(samplespageobjs.SamplePointCommentText), "Samplepoint comment text field not hided after tapping on comment full");

			app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowPlus));
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus), "Could not find the Expanded/Minus Icon, Expand Not successful", TimeSpan.FromSeconds(60));
			string sampleParameter = app.Query(c => c.Marked(samplespageobjs.ParameterName)).First().Text;
			app.Tap(c => c.Marked(samplespageobjs.ParameterReadingCommentsEmpty));
			app.WaitForElement(c => c.Marked(samplespageobjs.ParameterReadingCommentsText), "Comment textbox not geting displayed after tapping Sample parameter comment empty Icon ", TimeSpan.FromSeconds(60));
			app.EnterText(c => c.Marked(samplespageobjs.ParameterReadingCommentsText), sampleParameter + " parameterlevelComment");
			app.ScrollUp();
			app.WaitForElement(c => c.Marked(samplespageobjs.ParameterReadingCommentsFull), "After entering the comments,Sampleparameter  comment icon not changed to comment full icon", TimeSpan.FromSeconds(60));
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			app.WaitForNoElement(c => c.Marked(samplespageobjs.ParameterReadingCommentsText), "Sampleparameter comment text field not hided after tapping on comment full");
			app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));

			app.Tap(c => c.Marked(samplespageobjs.GeneralCommentFull));
			app.ClearText(c => c.Marked(samplespageobjs.GeneralCommentText));
			app.WaitForElement(c => c.Marked(samplespageobjs.GeneralCommentEmpty), "After clearing the comments general comment full icon not changed to empty icon", TimeSpan.FromSeconds(60));
			app.Tap(c => c.Marked(samplespageobjs.Samples));

			app.Tap(c => c.Marked(samplespageobjs.SamplePointCommentFull));
			app.ClearText(c => c.Marked(samplespageobjs.SamplePointCommentText));
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			app.ScrollUp();
			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointCommentEmpty), "After clearing the comments sample point comment full icon not changed to empty icon", TimeSpan.FromSeconds(60));

			app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowPlus));
			app.Tap(c => c.Marked(samplespageobjs.ParameterReadingCommentsFull));
			app.ClearText(c => c.Marked(samplespageobjs.ParameterReadingCommentsText));
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			app.ScrollUp();
			app.WaitForElement(c => c.Marked(samplespageobjs.ParameterReadingCommentsEmpty), "After clearing the comments sampleparameter comment full icon not changed to empty icon", TimeSpan.FromSeconds(60));
			app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
		}

		public void expandIndividualAndEnterParameterReadings(IApp app)
		{
			#region Add data General Comments
			app.Tap(c => c.Marked(samplespageobjs.GeneralCommentEmpty));
			GeneralComment = "Generalcomment" + DateTime.Now;
			app.EnterText(c => c.Marked(samplespageobjs.GeneralCommentText), GeneralComment);
			app.Tap(c => c.Marked(samplespageobjs.Samples));
			#endregion

			app.WaitForElement(c => c.Marked(samplespageobjs.SamplePointName), "Could not find the sample point Name", TimeSpan.FromSeconds(60));
			var spDownArrows = app.Query(c => c.All().Marked(samplespageobjs.SamplePointDownArrowPlus));
			int intialCount = spDownArrows.Count();
			if (intialCount > 0)
			{
				for (int i = 0; i < intialCount; i++)
				{
					app.Tap(c => c.All().Marked(samplespageobjs.SamplePointDownArrowPlus).Index(i));
					AppResult[] Minus = app.Query(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
					if (Minus.Count() < 1)
					{
						app.ScrollDown();
						Minus = app.Query(C => C.Marked(samplespageobjs.SamplePointDownArrowMinus));
						if(Minus.Count() < 1)
						{
							app.Tap(c => c.All().Marked(samplespageobjs.SamplePointDownArrowPlus).Index(i));
						}
					}
					var samplePoints = app.Query(c => c.Marked(samplespageobjs.ParameterReading));
					var readingCount = samplePoints.Count();
					if (readingCount > 0)
					{
						for (int j = 0, k = 0; k < readingCount; j++, k++)
						{
							#region Parameter Level Data
							// Code to handle the sample parameter readings for ios (ios: if more sample points in ios app is scrolling up to handle the code)
							var currentsamplecount = app.Query(c => c.Marked(samplespageobjs.ParameterReading));
							if (currentsamplecount.Count() < readingCount)
							{
								j--;
							}

							string ParameterName = app.Query(c => c.Marked(samplespageobjs.ParameterName).Index(j)).First().Text;
							ParameterName = ParameterName.Substring(0, ParameterName.LastIndexOf("(")).Trim();
							bool checkpoint = true;
							double LeftLimit = 0, RightLimit = 0;
							AppResult TextField = app.Query(c => c.Marked(samplespageobjs.ParameterReading).Index(j)).First();
							if (TextField.Enabled == true)
							{
								try
								{
									string LeftLimitText = app.Query(c => c.Marked(ParameterName + samplespageobjs.ParameterLeftLimit)).First().Text;
									string[] Limit = LeftLimitText.Split('-');
									LeftLimit = double.Parse(Limit[0]);
									checkpoint = false;
									string RighLimitText = app.Query(c => c.Marked(ParameterName + samplespageobjs.ParameterRightLimit)).First().Text;
									RightLimit = Convert.ToDouble(RighLimitText);
									double value = (LeftLimit + RightLimit) / 2;
									RightLimit++;
									app.EnterText(c => c.Marked(samplespageobjs.ParameterReading).Index(j), "" + RightLimit);
									app.ClearText(c => c.Marked(samplespageobjs.ParameterReading).Index(j));
									app.EnterText(c => c.Marked(samplespageobjs.ParameterReading).Index(j), "" + value);
									app.DismissKeyboard();
								}
								catch
								{
									if (checkpoint)
									{
										app.EnterText(c => c.Marked(samplespageobjs.ParameterReading).Index(j), generateRandomString(2));
										app.DismissKeyboard();
									}
									else if (!checkpoint)
									{
										app.EnterText(c => c.Marked(samplespageobjs.ParameterReading).Index(j), "" + LeftLimit);
										app.DismissKeyboard();
									}
								}
							}
							#endregion
						}
					}
					AppResult[] minusArrow = app.Query(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
					while (minusArrow.Count() < 1)
					{
						app.ScrollUp();
						minusArrow = app.Query(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
					}
					app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));

					AppResult[] Readings = app.Query(c => c.Marked(samplespageobjs.ParameterReading));
					if(Readings.Count() == 1)
					{
						app.ScrollUp();
						app.Tap(c => c.Marked(samplespageobjs.SamplePointDownArrowMinus));
					}
				}
			}
			app.ScrollUp();
			app.Tap(c => c.Marked(samplespageobjs.Save));
			app.Screenshot("Save data");
			Thread.Sleep(10000);
			app.WaitForElement(c => c.Marked(configpageobjs.ConfigurationLable), "After save configuration page is not displayed", TimeSpan.FromSeconds(60));
		}

		public void validateCalculatedParameters(IApp app)
		{
			List<string> sampleDisplayName = new List<string>();
			List<string> sampleReading = new List<string>();
			string calculatedValue = null;
			string calculatedParameter = null;

			calculatedValue = testdata.DataSetList[tData].CalList[0].Output;
			calculatedParameter = testdata.DataSetList[tData].CalList[0].CalculatedParameter;
			string[] smpleParam = testdata.DataSetList[tData].CalList[0].Variable.Split(',');
			string[] smpleRead = testdata.DataSetList[tData].CalList[0].Reading.Split(',');

			for (int i = 0; i < smpleParam.Count(); i++)
			{
				sampleDisplayName.Add(smpleParam[i]);
				sampleReading.Add(smpleRead[i]);
			}

			string firstSamplePoint, latestSP;
			firstSamplePoint = app.Query(c => c.Marked(samplespageobjs.SamplePointName)).First().Text;

			int sampleParametersCount = app.Query(c => c.All().Marked(samplespageobjs.ParameterName)).Count();


			for (int j = 0; j < sampleDisplayName.Count(); j++) // Test Data
			{
				for (int i = 0; i < sampleParametersCount; i++) // Loop for findout the parameter positon
				{
					string sampleParameterName = app.Query(c => c.All().Marked(samplespageobjs.ParameterName).Index(i)).First().Text;
					if (sampleParameterName.Contains(sampleDisplayName[j]))
					{

						bool validation = false;
						do
						{
							int visibleCount = app.Query(c => c.Marked(samplespageobjs.ParameterName)).Count();
							for (int k = 0; k < visibleCount; k++) // Looping to make the required parameter is visible in UI
							{
								sampleParameterName = app.Query(c => c.Marked(samplespageobjs.ParameterName).Index(k)).First().Text;
								Console.WriteLine(sampleParameterName);
								if (sampleParameterName.Contains(sampleDisplayName[j]))
									validation = true;
							}
							if (!validation)
								app.ScrollDown();

						}
						while (!validation);

						app.EnterText(c => c.All().Marked(samplespageobjs.ParameterReading).Index(i), sampleReading[j]);
						app.DismissKeyboard();
					}
				}
				do
				{
					app.ScrollUp();
					latestSP = app.Query(c => c.Marked(samplespageobjs.SamplePointName)).First().Text;
				}
				while (!latestSP.Equals(firstSamplePoint));
				app.ScrollUp();
			}
			for (int i = 0; i < sampleParametersCount; i++)
			{
				string sampleParameterName = app.Query(c => c.All().Marked(samplespageobjs.ParameterName).Index(i)).First().Text;
				if (sampleParameterName.Contains(calculatedParameter))
				{
					string calResult = app.Query(c => c.All().Marked(samplespageobjs.ParameterReading).Index(i)).First().Text;
					Assert.IsTrue(calculatedValue.Equals(calResult),"Calculation failed");
				}
			}


		}









	}
}
