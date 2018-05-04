using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AdidasAPI.API_Client;

namespace AdidasAPI.API_Tests
{
    public partial class APITests
    {
        /// <summary>
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public static void API_CheckForEmptyMediaImagesTest()
        {
            Client client = new Client();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Keywords.apiPublicAddress);
            string result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            QuickType.Welcome data = QuickType.Welcome.FromJson(result);


            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                {
                    foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                    {
                        QuickType.BackgroundMedia mediaItems = item.MediaItems;

                        if (!string.IsNullOrEmpty(mediaItems?.AssetType))
                        {
                            Validation.ValidateAssetTypeContent(mediaItems.AssetType);
                        }

                        //TODO: Check For Content-Type: image/jpeg 
                        //response.Result.Content.Headers.ContentType
                        //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;

                        if (!string.IsNullOrEmpty(mediaItems?.DesktopImage?.Url))
                        {
                            string desktopImageUrl = mediaItems.DesktopImage.Url;
                            Validation.ValidateResponseCode(desktopImageUrl, "Expected 'Desktop Images' to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(desktopImageUrl);
                        }

                        if (!string.IsNullOrEmpty(mediaItems?.MobileImage?.Url))
                        {
                            string mobileImageUrl = mediaItems.MobileImage.Url;
                            Validation.ValidateResponseCode(mobileImageUrl, "Expected 'Mobile Images' to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(mobileImageUrl);
                        }


                        if (!string.IsNullOrEmpty(mediaItems?.TabletImage?.Url))
                        {
                            string tabletImageUrl = mediaItems.TabletImage.Url;
                            Validation.ValidateResponseCode(tabletImageUrl, "Expected 'Tablet Images' to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(tabletImageUrl);
                        }

                    }

                }
            }
        }
    }
}
