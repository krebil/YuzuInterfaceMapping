using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;

namespace UmbracoProject.Yuzu.Mappings
{
    public class WebMappingConfig : YuzuMappingConfig
    {
        public WebMappingConfig()
        {
            ManualMaps.AddTypeReplace<GoogleMapTypeConvertor>();
            ManualMaps.AddTypeReplace<IGoogleMapTypeConvertor>();
            ManualMaps.AddTypeReplace<LibraryBlockPickerTypeConvertor>();
            ManualMaps.AddTypeReplace<IGoogleMapMarkerTypeConvertor>();
            ManualMaps.AddTypeReplace<GoogleMapMarkerTypeConvertor>();
        }
    }
}