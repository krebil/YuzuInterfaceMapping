using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using YuzuDelivery.Core;

namespace UmbracoProject.helpers;

public static class TypesHelper
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static IEnumerable<Type> GetViewModelTypes()
    {
        var types = Assembly.GetTypes().Where(type => type.Namespace == "YuzuDelivery.ViewModels");
        return types;
    }

    public static IEnumerable<Type> GetPublishedModelTypes()
    {
        var types = Assembly.GetTypes().Where(type => type.Namespace == "Umbraco.Cms.Web.Common.PublishedModels" || type.Namespace == "YuzuDelivery.UmbracoModels");
        return types;
    }
    public static Type GetSourceType(IPublishedContent content)
    {
        return GetPublishedModelTypes().FirstOrDefault(t =>
        {
            return string.Equals(t.FullName.Split(".").LastOrDefault(), content.ContentType.Alias.FirstCharacterToUpper()) ;
        });
    }
    public static Type GetSourceType(IPublishedElement content)
    {
        return GetPublishedModelTypes().FirstOrDefault(t =>
        {
            return string.Equals(t.FullName.Split(".").LastOrDefault(), content.ContentType.Alias.FirstCharacterToUpper()) ;
        });
    }
    
    public static Type GetDistType(IPublishedContent content)
    {
        var contentTypeName = content.ContentType.Alias.FirstCharacterToUpper();
        var interfaces = GetInterfaces(contentTypeName);

        return GetViewModelTypes().FirstOrDefault(t =>
        {
            return string.Equals(t.Name, "vmBlock_" + contentTypeName) || (interfaces != null && interfaces.Any(iface => string.Equals( "vmBlock_" + iface.Name.Remove(0,1),  t.Name)));
        });
    }
    public static Type GetDistType(IPublishedElement content)
    {
        var contentTypeName = content.ContentType.Alias.FirstCharacterToUpper();
        var interfaces = GetInterfaces(contentTypeName);

        return GetViewModelTypes().FirstOrDefault(t =>
        {
            return string.Equals(t.Name, "vmBlock_" + contentTypeName) || (interfaces != null && interfaces.Any(iface => string.Equals( "vmBlock_" + iface.Name.Remove(0,1),  t.Name)));
        });
    }

    private static List<Type> GetInterfaces(string contentTypeName)
    {
        var t = Assembly.GetType($"Umbraco.Cms.Web.Common.PublishedModels.{contentTypeName}");
        if(t == null)
            t= Assembly.GetType($"YuzuDelivery.UmbracoModels.{contentTypeName}");
        return t?.GetInterfaces().Where(type => type.FullName != null  && !type.FullName.Contains("IPublishedContent") && !type.FullName.Contains("IPublishedElement")).ToList();
    }
}

