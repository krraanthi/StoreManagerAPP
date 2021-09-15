using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Store_Manager_APP.Data
{
    public class UriGenerator
    {
        static string BaseUri = "https://my-store-manager.herokuapp.com/api/";
        internal static string GetUri(string controller,int id)
        {
            return BaseUri + controller + "/" + id;
        }

        internal static string GetUri(string controller, string id)
        {
            return BaseUri + controller + "/" + id;
        }

        internal static string GetUri(string controller)
        {
            return BaseUri + controller;
        }
    }
}
