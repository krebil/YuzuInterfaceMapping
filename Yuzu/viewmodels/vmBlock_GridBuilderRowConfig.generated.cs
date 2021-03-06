using YuzuDelivery.Umbraco.BlockList;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.Umbraco.Forms;
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.0.23.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace YuzuDelivery.ViewModels
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v13.0.0.0)")]
    [YuzuMap("GridBuilderRowConfig")]
    public partial class vmBlock_GridBuilderRowConfig 
    {
        [Newtonsoft.Json.JsonProperty("backgroundColor", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BackgroundColor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("width", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigWidth Width { get; set; }
    
        [Newtonsoft.Json.JsonProperty("removeTopWhiteSpace", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool RemoveTopWhiteSpace { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keepColumns", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool KeepColumns { get; set; }
    
        [Newtonsoft.Json.JsonProperty("stackFromRight", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool StackFromRight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorScheme", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigColorScheme ColorScheme { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hide", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigHide Hide { get; set; }
    
        [Newtonsoft.Json.JsonProperty("_ref", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _ref { get; set; }
    
        [Newtonsoft.Json.JsonProperty("_modifiers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<string> _modifiers { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigWidth
    {
        [System.Runtime.Serialization.EnumMember(Value = @"container")]
        Container = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"full-width")]
        FullWidth = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigColorScheme
    {
        [System.Runtime.Serialization.EnumMember(Value = @"light")]
        Light = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"dark")]
        Dark = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum vmSub_GridBuilderRowConfigVmBlock_GridBuilderRowConfigHide
    {
        [System.Runtime.Serialization.EnumMember(Value = @"")]
        Empty = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"hidden lg:grid")]
        Hidden_lgGrid = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"grid lg:hidden")]
        Grid_lgHidden = 2,
    
    }
}