namespace AdidasAPI
{
    public class ErrorMessages
    {
        #region Possitive Error Messages
        public const string apiAnalyticsNamePassedMessage = "Component to have 'Analytics Name' in it!";
        public const string apiAssetTypePassedMessage = "'Asset Type' is an 'Image'";
        public const string apiImageJpgExtentionPassedMessage = "This Url contain image with .jpg extention!";
        public const string apiResponseErrorPassedMessage = "API request response is bellow 1 second!";
        public const string apiImageResponsePassedMessage = "Images is accessible, response code 200!";
        #endregion

        #region Negative Error Messages
        public const string apiAnalyticsNameFailedMessage = "Expected component to have 'Analytics Name' in it!";
        public const string apiAssetTypeFailedMessage = "Expected 'Asset Type' to be an 'Image'";
        public const string apiImageJpgExtentionFailedMessage = "Expected Url to contain image with .jpg extention!";
        public const string apiResponseErrorFailedMessage = "Expected API request response to be bellow 1 second!";
        public const string apiImageResponseFailedMessage = "Expected Images to be accessible!";
        #endregion

        #region Response Error Messages
        public const int errorMessageUnautorized = 401;
        public const int errorMessageNotFound = 404;
        #endregion
    }
}
