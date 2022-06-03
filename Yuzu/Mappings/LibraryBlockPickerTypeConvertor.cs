using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoProject.helpers;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace UmbracoProject.Yuzu
{
    public class LibraryBlockPickerTypeConvertor : IYuzuTypeConvertor<LibraryBlockPicker, vmBlock_LibraryBlockPicker>
    {
        private readonly IMapper _mapper;
        private readonly IContentTypeService _contentTypeService;

        public LibraryBlockPickerTypeConvertor(IMapper mapper, IContentTypeService contentTypeService)
        {
            _mapper = mapper;
            _contentTypeService = contentTypeService;
        }

        public vmBlock_LibraryBlockPicker Convert(LibraryBlockPicker source, UmbracoMappingContext context)
        {
            var stringBuilder = new StringBuilder();

            if (!context.IsInPreview() && context.Html != null)
            {
                foreach (var block in source.Block)
                {
                    var sourceType = TypesHelper.GetSourceType(block);
                    var distType = TypesHelper.GetDistType(block);
                    //var mapped = _mapper.Map<vmBlock_GoogleMap>(block);
                    var lookup = new Dictionary<string, object> {{"Html", context.Html}};
                    var mapped = _mapper.Map(block, sourceType, distType, lookup );
                    if (mapped == null) continue;
                    var htmlContent = context.Html.RenderYuzu(new RenderSettings()
                    {
                        Template = "parGoogleMap",
                        Data = () => mapped
                    });
                    stringBuilder.Append(htmlContent);
                }
            }
            else
            {

                stringBuilder.Append("<div class=\"prose\">");
                if (source.Block.Any())
                {
                    stringBuilder.Append("<h2>Picked items</h2><ol>");
                    foreach (var block in source.Block)
                    {
                        var t = block.ContentType;
                        var icon = _contentTypeService.Get(t.Id);
                        
                        stringBuilder.Append($"<li>{block.Name} - {icon.Name}</li>");
                    }

                    stringBuilder.Append("</ol>");
                }
                else
                {
                    stringBuilder.Append("<p><b> Choose block </b></p>");
                }

                stringBuilder.Append("</div>");
            }

            return new vmBlock_LibraryBlockPicker()
            {
                Block = stringBuilder.ToString()
            };
        }
    }
}