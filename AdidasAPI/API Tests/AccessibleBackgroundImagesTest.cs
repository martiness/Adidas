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
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public void API_CheckForEmptyMediaImagesTest()
        {
            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                {
                    foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                    {
                        QuickType.BackgroundMedia mediaItems = item.MediaItems;

                        #region Verification for Is Asset Type an Image 
                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.AssetType))
                            {
                                Validation.ValidateAssetTypeContent(mediaItems.AssetType);
                            }
                            testReport.Pass(ErrorMessages.apiAssetTypePassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiAssetTypeFailedMessage);
                            throw;
                        }
                        #endregion

                        #region  TODO: Check For Content-Type: image/jpeg 
                        //response.Result.Content.Headers.ContentType
                        //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;
                        #endregion

                        #region Verification for Is Desktop Image has OK response and Is Desktop Image extention JPG
                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.DesktopImage?.Url))
                            {
                                string desktopImageUrl = mediaItems.DesktopImage.Url;
                                Validation.ValidateResponseCode(desktopImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageResponsePassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageResponseFailedMessage);
                            throw;
                        }

                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.DesktopImage?.Url))
                            {
                                string desktopImageUrl = mediaItems.DesktopImage.Url;
                                Validation.ValidateUrlForJPGImageExtention(desktopImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageJpgExtentionPassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageJpgExtentionFailedMessage);
                            throw;
                        }
                        #endregion

                        #region Verification for Is Mobile Image has OK response and Is Mobile Image extention JPG
                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.MobileImage?.Url))
                            {
                                string mobileImageUrl = mediaItems.MobileImage.Url;
                                Validation.ValidateResponseCode(mobileImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageResponsePassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageResponseFailedMessage);
                            throw;
                        }

                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.MobileImage?.Url))
                            {
                                string mobileImageUrl = mediaItems.MobileImage.Url;
                                Validation.ValidateUrlForJPGImageExtention(mobileImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageJpgExtentionPassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageJpgExtentionFailedMessage);
                            throw;
                        }
                        #endregion

                        #region Verification for Is Tablet Image has OK response and Is Tablet Image extention JPG
                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.TabletImage?.Url))
                            {
                                string tabletImageUrl = mediaItems.TabletImage.Url;
                                Validation.ValidateResponseCode(tabletImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageResponsePassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageResponseFailedMessage);
                            throw;
                        }

                        try
                        {
                            if (!string.IsNullOrEmpty(mediaItems?.TabletImage?.Url))
                            {
                                string tabletImageUrl = mediaItems.TabletImage.Url;
                                Validation.ValidateUrlForJPGImageExtention(tabletImageUrl);
                            }
                            testReport.Pass(ErrorMessages.apiImageJpgExtentionPassedMessage);
                        }
                        catch (AssertionException)
                        {
                            testReport.Fail(ErrorMessages.apiImageJpgExtentionFailedMessage);
                            throw;
                        }
                        #endregion
                    }

                }
            }
        }
    }
}
