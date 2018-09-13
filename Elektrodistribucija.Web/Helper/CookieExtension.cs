using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Elektrodistribucija.Web.Helper
{
    public static class CookieExtension
    {
        public static T GetCookieJson<T>(this HttpRequest request,string key)
        {
            string strValue = request.Cookies[key];
            return strValue == null
                ? default(T)
                : JsonConvert.DeserializeObject<T>(strValue);


        }
        public static void SetCookieJson(this HttpResponse response,string key, object value,int? expiretime=null)
        {
            if(value==null)
            {
                response.Cookies.Delete(key);
                return;
            }
            CookieOptions option = new CookieOptions();
            if (expiretime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expiretime.Value);
            else
                option.Expires = DateTime.Now.AddDays(7);

            string strValue = JsonConvert.SerializeObject(value);
            response.Cookies.Append(key, strValue, option);

        }

        public static void RemoveCookie(this HttpResponse response,string key)
        {
            response.Cookies.Delete(key);
        }

    }
}
