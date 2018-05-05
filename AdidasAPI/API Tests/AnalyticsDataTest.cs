using System;
using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace AdidasAPI
{
    public partial class APITests : TestBase
    {
        /// <summary>
        /// Checks for analytics data.
        /// SLAs/requirements: Every component has at least analytics data “analytics_name” in it 
        /// </summary>
        [Test]
        public void API_CheckForAnalyticsData()
        {
            try
            {
                System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Constants.apiPublicAddress);
                string result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                QuickType.Welcome data = QuickType.Welcome.FromJson(result);
                string analyticsName = string.Empty;

                foreach (var componentPresentation in data.ComponentPresentations)
                {
                    if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                    {
                        foreach (var item in componentPresentation.Component.ContentFields.Items)
                        {
                            try
                            {
                                var suportingFields = item.SupportingFields;

                                if (suportingFields?.SupportingFields?.StandardMetadata?.AnalyticsName != null)
                                {
                                    analyticsName = suportingFields.SupportingFields.StandardMetadata.AnalyticsName;
                                    Validation.ValidateAnalyticsNameExist(analyticsName);
                                }

                                testReport.Pass($"Component '{analyticsName}' have 'Analytics Name' in it!");
                            }
                            catch(AssertionException)
                            {
                                testReport.Fail($"Component '{analyticsName}' DO NOT have 'Analytics Name' in it!");
                                throw;
                            }
                            
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }
        }
    }
}
