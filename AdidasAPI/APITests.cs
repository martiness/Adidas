using System;
using System.Net.Http;
using System.Diagnostics;
using NUnit.Framework;

namespace AdidasAPI
{
    public class APITests
    {
        /// <summary>
        /// Checks for reponse time test.
        /// SLAs/requirements: Response time should be bellow 1s
        /// </summary>
        [Test]
        public static void CheckForReponseTimeTest()
        {
            Client client = new Client();
            string apiAddress = apiAddress = @"api/pages/landing?path=/";

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = client.GetAsync(apiAddress);
            stopwatch.Stop();

            var elapsedTime = new TimeSpan(stopwatch.ElapsedTicks);
            var isLessThanSec = elapsedTime < TimeSpan.FromSeconds(1);
            System.Diagnostics.Debug.WriteLine(isLessThanSec);
            Assert.IsTrue(isLessThanSec,
                "Expected API request response to be bellow 1 second, but it isn't");
        }

        /// <summary>
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public static void CheckForEmptyImagesTest()
        {
            string apiAddress = apiAddress = @"api/pages/landing?path=/";

            var client = new Client();
            var response = client.GetAsync(apiAddress);
            var result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var data = QuickType.Welcome.FromJson(result);

            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (
                    componentPresentation.Component?.ContentFields != null
                    && componentPresentation.Component.ContentFields?.Items != null
                )
                {
                    foreach (var item in componentPresentation.Component.ContentFields.Items)
                    {
                        var images = item.BackgroundMedia;
                        if (!string.IsNullOrEmpty(images.DesktopImage.Url))
                        {
                            Assert.IsTrue(IsValidResponse(images.DesktopImage.Url),
                                "Expected Desкtop Images to be accessible (no 404/401s), but it isn't");
                        }
                        if (!string.IsNullOrEmpty(images.DesktopImage.Url))
                        {
                            Assert.IsTrue(IsValidResponse(images.MobileImage.Url),
                                "Expected Mobile Images to be accessible (no 404/401s), but it isn't");
                        }
                        if (!string.IsNullOrEmpty(images.DesktopImage.Url))
                        {
                            Assert.IsTrue(IsValidResponse(images.TabletImage.Url),
                                "Expected Responce Images to be accessible (no 404/401s), but it isn't");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks for analytics data.
        /// SLAs/requirements: Every component has at least analytics data “analytics_name” in it 
        /// </summary>
        [Test]
        public static void CheckForAnalyticsData()
        {
            string apiAddress = apiAddress = @"api/pages/landing?path=/";

            var client = new Client();
            var response = client.GetAsync(apiAddress);
            var result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var data = QuickType.Welcome.FromJson(result);

            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (
                    componentPresentation.Component?.ContentFields != null
                    && componentPresentation.Component.ContentFields?.Items != null
                )
                {
                    foreach (var item in componentPresentation.Component.ContentFields.Items)
                    {
                        var suportingFields = item.SupportingFields;
                        bool hasAnaliticsName = (!string.IsNullOrEmpty(suportingFields.SupportingFields.StandardMetadata?.AnalyticsName));
                        Assert.IsTrue(hasAnaliticsName,
                            "Expected component to have “analytics_name” in it, but it haven't!");
                        System.Diagnostics.Debug.WriteLine(hasAnaliticsName);
                    }
                }
            }
        }

        
        /// <summary>
        /// Checks for valid response, different from 401 and 404
        /// </summary>
        /// <param name="address"> Image address </param>
        /// <returns></returns>
        #region Helpers
        private static bool IsValidResponse(string address)
        {
            HttpResponseMessage message = new Client(address).GetAsync("").GetAwaiter().GetResult();
            bool isSuccessfulResponse = (int)message.StatusCode != 401 && (int)message.StatusCode != 404;

            System.Diagnostics.Debug.WriteLine(isSuccessfulResponse);
            System.Diagnostics.Debug.WriteLine((int)message.StatusCode);

            return isSuccessfulResponse;
        }

        #endregion Helpers
    }
}
