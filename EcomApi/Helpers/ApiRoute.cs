namespace EcomApi.Helpers
{
    public class ApiRoute
    {
        const string Root = "api";
        const string Version = "1";
        const string Base = Root + "/" + Version;
        internal static class general
        {
            const string Route = Base + "/general/";
            internal const string checkhealth = Route + "checkhealth";
            internal const string generatetoken = Route + "generatetoken";
        }
        internal static class users
        {
            const string Route = Base + "/users/";
            internal const string getusers = Route + "getusers";
            internal const string getuserbyid = Route + "getuserbyid";
            internal const string registeruser = Route + "registeruser";
            internal const string loginbyusername = Route + "loginbyusername";
            internal const string loginbyemail = Route + "loginbyemail";
        }
        internal static class orders
        {
            const string Route = Base + "/orders/";
            internal const string getorders = Route + "getorders";
        }
        internal static class products
        {
            const string Route = Base + "/products/";
            internal const string getproducts = Route + "getproducts";
            internal const string getproductbyid = Route + "getproductbyid";
            internal const string setproduct = Route + "setproduct";
            internal const string updateproduct = Route + "updateproduct";
            internal const string deleteproduct = Route + "deleteproduct";

            //product categories
            internal const string getcategories = Route + "getcategories";
            internal const string setcategory = Route + "setcategory";
            internal const string deletecategory = Route + "deletecategory";
            internal const string updatecategory = Route + "updatecategory";
        }
        internal static class carts
        {
            const string Route = Base + "/cart/";
        }
        internal static class wishlist
        {
            const string Route = Base + "/wishlist/";
        }
        internal static class image
        {
            const string Route = Base + "/image/";
            internal const string upload = Route + "upload";
            internal const string download = Route + "download";
        }

    }
}

