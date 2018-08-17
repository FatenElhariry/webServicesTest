using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using WebServices.Core;
using WebServices.Modal;

namespace WebServices
{
    /// <summary>
    /// Summary description for test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class test : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Product> GetALLProduct()
        {
          DataTable dt =  DBManger.ExecuteDataTable("select * from products ", 
                     System.Data.CommandType.Text);
           List<Product> products = Helper.DataTableToList<Product>(dt);
            return products;
        }
    }
}
