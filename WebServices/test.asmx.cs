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
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)] //to Add two method with the same name and unique identify them with messageName
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class test : System.Web.Services.WebService
    {

        [WebMethod(Description ="get all product in northwind DB",MessageName = "Products")]
        public List<Product> GetALLProduct()
        {
          DataTable dt =  DBManger.ExecuteDataTable("select * from products ", 
                     System.Data.CommandType.Text);
           List<Product> products = Helper.DataTableToList<Product>(dt);
            
            return products;
        }
        [WebMethod]
        public int Add(int x , int y ,int z)
        {
            return x + y + z;
        }

        [WebMethod(EnableSession = true,Description = "Add two integer number ",MessageName = "Add2Num")]
        public int Add (int x , int y)
        {
            List<string> calculation;
            if (Session["calculation"] == null)
            {
                calculation = new List<string>();
            }
            else
            {
                calculation =(List<string>)Session["calculation"];
            }
            string strRecentCalc = x + " + " + y + " = " + (x + y);

            calculation.Add(strRecentCalc);

            Session["calculation"] = calculation;

            return x + y ;
        }

        [WebMethod(EnableSession =true)]
        public List<string> GetCalculation()
        {
            List<string> Calculation;
            if (Session["calculation"] == null)
            {
                Calculation = new List<string>();
                Calculation.Add("You Don't add Any calculation ");

            }
            else
                Calculation = (List<string>)Session["calculation"];

            return Calculation;
        }

        [WebMethod]
        public Product GetProductbyID(int id)
        {
           var list = Helper.DataTableToList<Product>(
               DBManger.ExecuteDataTable("select top(1) * from products where ProductID = @ID", CommandType.Text,
                new System.Data.SqlClient.SqlParameter("@ID", id))
                );
            return list[0];

        }
    }
}
