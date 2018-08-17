using System;
using WebApplication1.GetProductService;

namespace WebApplication1
{
    public partial class testServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this is proxy client to use services 
            testSoapClient testSoapClient = new testSoapClient();
            Product[] list = testSoapClient.GetALLProduct();

            
            GridView1.DataSource = list;
            GridView1.DataBind();
            

        }
    }
}