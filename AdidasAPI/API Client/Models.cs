namespace AdidasAPI.QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    // Adidas API address: https://www.adidas.fi/api/pages/landing?path=/
    // Quick Type IO: https://app.quicktype.io/ (JSON to C# object)
    // JSON Beatifaier: https://codebeautify.org/jsonviewer

    public partial class Welcome
    {
        [JsonProperty("component_presentations")]
        public List<ComponentPresentation> ComponentPresentations { get; set; }

        [JsonProperty("regions")]
        public List<Region> Regions { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("publication_path")]
        public string PublicationPath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("revision_date")]
        public System.DateTimeOffset RevisionDate { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("last_published_date")]
        public System.DateTimeOffset LastPublishedDate { get; set; }

        [JsonProperty("metadata")]
        public WelcomeMetadata Metadata { get; set; }
    }

    public partial class ComponentPresentation
    {
        [JsonProperty("component")]
        public Component Component { get; set; }

        [JsonProperty("template_metadata")]
        public TemplateMetadata TemplateMetadata { get; set; }

        [JsonProperty("order_on_page")]
        public long OrderOnPage { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("content_fields", NullValueHandling = NullValueHandling.Ignore)]
        public ContentFields ContentFields { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("supporting_fields", NullValueHandling = NullValueHandling.Ignore)]
        public ComponentSupportingFields SupportingFields { get; set; }
    }

    public partial class ContentFields
    {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("certona_zone_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CertonaZoneId { get; set; }

        [JsonProperty("certona_recommendation_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? CertonaRecommendationCount { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("calls_to_action")]
        public CallsToActionUnion CallsToAction { get; set; }

        [JsonProperty("background_media")]
        public BackgroundMedia BackgroundMedia { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("supporting_fields")]
        public ItemSupportingFields SupportingFields { get; set; }

        [JsonProperty("media_items", NullValueHandling = NullValueHandling.Ignore)]
        public BackgroundMedia MediaItems { get; set; }
    }

    public partial class BackgroundMedia
    {
        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("desktop_image")]
        public Image DesktopImage { get; set; }

        [JsonProperty("tablet_image")]
        public Image TabletImage { get; set; }

        [JsonProperty("mobile_image")]
        public Image MobileImage { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class CallsToActionElement
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cta_text")]
        public string CtaText { get; set; }

        [JsonProperty("external_link")]
        public string ExternalLink { get; set; }

        [JsonProperty("target")]
        public Target Target { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("supporting_fields")]
        public CallsToActionSupportingFields SupportingFields { get; set; }
    }

    public partial class CallsToActionSupportingFields
    {
        [JsonProperty("supporting_fields")]
        public PurpleSupportingFields SupportingFields { get; set; }
    }

    public partial class PurpleSupportingFields
    {
        [JsonProperty("standard_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public PurpleStandardMetadata StandardMetadata { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public PurpleMetadata Metadata { get; set; }
    }

    public partial class PurpleMetadata
    {
        [JsonProperty("translationCampaign")]
        public string TranslationCampaign { get; set; }

        [JsonProperty("translationContentOwner")]
        public string TranslationContentOwner { get; set; }
    }

    public partial class PurpleStandardMetadata
    {
        [JsonProperty("analytics_name")]
        public string AnalyticsName { get; set; }
    }

    public partial class ItemSupportingFields
    {
        [JsonProperty("supporting_fields")]
        public FluffySupportingFields SupportingFields { get; set; }
    }

    public partial class FluffySupportingFields
    {
        [JsonProperty("standard_metadata")]
        public FluffyStandardMetadata StandardMetadata { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public FluffyMetadata Metadata { get; set; }
    }

    public partial class FluffyMetadata
    {
        [JsonProperty("translationTicket", NullValueHandling = NullValueHandling.Ignore)]
        public string TranslationTicket { get; set; }

        [JsonProperty("translationCampaign")]
        public string TranslationCampaign { get; set; }

        [JsonProperty("translationContentOwner")]
        public string TranslationContentOwner { get; set; }
    }

    public partial class FluffyStandardMetadata
    {
        [JsonProperty("analytics_name")]
        public string AnalyticsName { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string Tags { get; set; }

        [JsonProperty("style_overrides", NullValueHandling = NullValueHandling.Ignore)]
        public StyleOverrides StyleOverrides { get; set; }
    }

    public partial class StyleOverrides
    {
        [JsonProperty("display_styles")]
        public string DisplayStyles { get; set; }
    }

    public partial class ComponentSupportingFields
    {
        [JsonProperty("supporting_fields")]
        public TentacledSupportingFields SupportingFields { get; set; }
    }

    public partial class TentacledSupportingFields
    {
        [JsonProperty("metadata")]
        public PurpleMetadata Metadata { get; set; }
    }

    public partial class TemplateMetadata
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("component_type")]
        public string ComponentType { get; set; }
    }

    public partial class WelcomeMetadata
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("metadata_tags")]
        public List<MetadataTag> MetadataTags { get; set; }

        [JsonProperty("og_image")]
        public object OgImage { get; set; }

        [JsonProperty("analytics_data")]
        public AnalyticsData AnalyticsData { get; set; }

        [JsonProperty("h1_overwrite")]
        public object H1Overwrite { get; set; }

        [JsonProperty("h2_overwrite")]
        public object H2Overwrite { get; set; }

        [JsonProperty("h3_overwrite")]
        public object H3Overwrite { get; set; }

        [JsonProperty("page_category")]
        public object PageCategory { get; set; }

        [JsonProperty("seo_copy")]
        public object SeoCopy { get; set; }

        [JsonProperty("seo_copy_read_more")]
        public object SeoCopyReadMore { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class AnalyticsData
    {
        [JsonProperty("page_name")]
        public string PageName { get; set; }
    }

    public partial class MetadataTag
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("tag_content")]
        public string TagContent { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public enum Target { Default };

    public partial struct CallsToActionUnion
    {
        public CallsToActionElement CallsToActionElement;
        public List<CallsToActionElement> CallsToActionElementArray;
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }

    static class TargetExtensions
    {
        public static Target? ValueForString(string str)
        {
            switch (str)
            {
                case "default": return Target.Default;
                default: return null;
            }
        }

        public static Target ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Target value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Target.Default: serializer.Serialize(writer, "default"); break;
            }
        }
    }

    public partial struct CallsToActionUnion
    {
        public CallsToActionUnion(JsonReader reader, JsonSerializer serializer)
        {
            CallsToActionElement = null;
            CallsToActionElementArray = null;

            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    CallsToActionElementArray = serializer.Deserialize<List<CallsToActionElement>>(reader);
                    return;
                case JsonToken.StartObject:
                    CallsToActionElement = serializer.Deserialize<CallsToActionElement>(reader);
                    return;
            }
            throw new Exception("Cannot convert CallsToActionUnion");
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            if (CallsToActionElement != null)
            {
                serializer.Serialize(writer, CallsToActionElement);
                return;
            }
            if (CallsToActionElementArray != null)
            {
                serializer.Serialize(writer, CallsToActionElementArray);
                return;
            }
            throw new Exception("Union must not be null");
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Target) || t == typeof(CallsToActionUnion) || t == typeof(Target?) || t == typeof(CallsToActionUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Target))
                return TargetExtensions.ReadJson(reader, serializer);
            if (t == typeof(Target?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TargetExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(CallsToActionUnion) || t == typeof(CallsToActionUnion?))
                return new CallsToActionUnion(reader, serializer);
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Target))
            {
                ((Target)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(CallsToActionUnion))
            {
                ((CallsToActionUnion)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
