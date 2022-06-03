using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;
using UmbracoProject.ConfigSections;

namespace UmbracoProject.Yuzu.Mappings{

    public class GoogleMapTypeConvertor : IYuzuTypeConvertor<GoogleMap, vmBlock_GoogleMap>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<MapsApi> _mapsApi;

        public GoogleMapTypeConvertor(IMapper mapper, IOptions<MapsApi> mapsApi)
        {
            _mapper = mapper;
            _mapsApi = mapsApi;
        }
        public vmBlock_GoogleMap Convert(GoogleMap source, UmbracoMappingContext context)
        {
            var markers = source.Markers.SelectMany(marker =>
            {
                if (marker.Content is GoogleMapMarker googleMapMarker)
                {
                    return new List<vmSub_GoogleMapMarker>() {_mapper.Map<vmSub_GoogleMapMarker>(googleMapMarker)};
                }
                else if (marker.Content is MapMarkerPicker markerPicker)
                {
                    return markerPicker.Picker.Select(picker => _mapper.Map<vmSub_GoogleMapMarker>(picker)) ;
                }

                return null;
            }).ToList();

            return new vmBlock_GoogleMap()
            {
                ApiKey = _mapsApi?.Value?.Key ?? "AIzaSyAAG71brUMWu0OB42DjTAD38IXJ6tYMkZE",
                Markers = markers,
                Zoom = source.Zoom.ToString(CultureInfo.InvariantCulture),
                Latitude = source.Latitude.ToString(CultureInfo.InvariantCulture),
                Longitude = source.Longitude.ToString(CultureInfo.InvariantCulture),
                MapId = source.MapId
            };
        }
    }
    
    public class IGoogleMapTypeConvertor : IYuzuTypeConvertor<IGoogleMap, vmBlock_GoogleMap>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<MapsApi> _mapsApi;

        public IGoogleMapTypeConvertor(IMapper mapper, IOptions<MapsApi> mapsApi)
        {
            _mapper = mapper;
            _mapsApi = mapsApi;
        }
        public vmBlock_GoogleMap Convert(IGoogleMap source, UmbracoMappingContext context)
        {
            var markers = source.Markers.Select(marker =>
            {
                if (marker.Content is GoogleMapMarker googleMapMarker)
                {
                    return _mapper.Map<vmSub_GoogleMapMarker>(googleMapMarker);
                }
                else if (marker.Content is MapMarkerPicker markerPicker)
                {
                    return _mapper.Map<vmSub_GoogleMapMarker>(markerPicker.Picker);
                }

                return null;
            }).ToList();
            
            if (source is GoogleMapDoc doc)
            {
                var mapMarkers = doc.Children<GoogleMapMarkerDoc>().ToList();
                if (mapMarkers.Any())
                {
                    markers.AddRange(mapMarkers.Select(marker => _mapper.Map<vmSub_GoogleMapMarker>(marker as IGoogleMapMarker)));    
                }
                
            }
            
            return new vmBlock_GoogleMap()
            {
                ApiKey = _mapsApi?.Value?.Key ?? "AIzaSyAAG71brUMWu0OB42DjTAD38IXJ6tYMkZE",
                Markers = markers,
                Zoom = source.Zoom.ToString(CultureInfo.InvariantCulture),
                Latitude = source.Latitude.ToString(CultureInfo.InvariantCulture),
                Longitude = source.Longitude.ToString(CultureInfo.InvariantCulture),
                MapId = source.MapId
            };
        }
    }
    

}