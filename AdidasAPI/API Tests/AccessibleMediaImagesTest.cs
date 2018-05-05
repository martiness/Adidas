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
        [Test]
        public void API_CheckForEmptyBackgroundImagesTest()
        {
            try
            {
                foreach (var componentPresentation in data.ComponentPresentations)
                {
                    if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                    {
                        foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                        {
                            QuickType.BackgroundMedia backgroundMediaItems = item.BackgroundMedia;

                            #region Verification for Is Asset Type an Image 
                            try
                            {
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.AssetType))
                                {
                                    Validation.ValidateAssetTypeContent(backgroundMediaItems.AssetType);
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.DesktopImage?.Url))
                                {
                                    string desktopImageUrl = backgroundMediaItems.DesktopImage.Url;
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.DesktopImage?.Url))
                                {
                                    string desktopImageUrl = backgroundMediaItems.DesktopImage.Url;
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.MobileImage?.Url))
                                {
                                    string mobileImageUrl = backgroundMediaItems.MobileImage.Url;
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.MobileImage?.Url))
                                {
                                    string mobileImageUrl = backgroundMediaItems.MobileImage.Url;
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.TabletImage?.Url))
                                {
                                    string tabletImageUrl = backgroundMediaItems.TabletImage.Url;
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
                                if (!string.IsNullOrEmpty(backgroundMediaItems?.TabletImage?.Url))
                                {
                                    string tabletImageUrl = backgroundMediaItems.TabletImage.Url;
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
            catch (NotImplementedException ex)
            {
                testReport.Fail(ex.StackTrace);
                throw;
            }

        }
    }
}
