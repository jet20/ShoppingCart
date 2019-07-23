using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ShoppingCart.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString HtmlConvertToJson(this HtmlHelper html, object value)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(value, settings);
            return new MvcHtmlString(json);
        }
    }
}