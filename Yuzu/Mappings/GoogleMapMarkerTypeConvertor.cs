using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Umbraco.Cms.Web.Common.PublishedModels;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace UmbracoProject.Yuzu
{
    public class IGoogleMapMarkerTypeConvertor : IYuzuTypeConvertor<IGoogleMapMarker, vmSub_GoogleMapMarker>
    {
        private readonly IMapper _mapper;

        public IGoogleMapMarkerTypeConvertor(IMapper mapper)
        {
            _mapper = mapper;
        }
        public vmSub_GoogleMapMarker Convert(IGoogleMapMarker source, UmbracoMappingContext context)
        {
            return new vmSub_GoogleMapMarker()
            {
                Icon = _mapper.Map<vmBlock_DataImage>(source.Icon),
                Latitude = source.Latitude.ToString(CultureInfo.InvariantCulture),
                Longitude = source.Longitude.ToString(CultureInfo.InvariantCulture),
                Text = source.Text.ToHtmlString()
            };
        }
    }
    public class GoogleMapMarkerTypeConvertor : IYuzuTypeConvertor<GoogleMapMarker, vmSub_GoogleMapMarker>
    {
        private readonly IMapper _mapper;

        public GoogleMapMarkerTypeConvertor(IMapper mapper)
        {
            _mapper = mapper;
        }
        public vmSub_GoogleMapMarker Convert(GoogleMapMarker source, UmbracoMappingContext context)
        {
            return new vmSub_GoogleMapMarker()
            {
                Icon = _mapper.Map<vmBlock_DataImage>(source.Icon),
                Latitude = source.Latitude.ToString(CultureInfo.InvariantCulture),
                Longitude = source.Longitude.ToString(CultureInfo.InvariantCulture),
                Text = source.Text.ToHtmlString()
            };
        }
    }
}