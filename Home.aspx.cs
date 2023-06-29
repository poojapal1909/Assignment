using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace APIassignment
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Get the username and password from the login form
            string username = TextBox1.Text;
            string password = TextBox2.Text;

            // Create the request body parameters
            var requestBody = new
            {
                emailNumber = username,
                password = password
            };
           

            // Convert the request body to a JSON string
            string jsonRequestBody = JsonConvert.SerializeObject(requestBody);

            // Specify the API URL
            string apiUrl = "https://genxhire-esurveillance-api.azurewebsites.net/api/user/login/admin";

            // Create the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
           
            request.Accept = "*/*";

            // Write the request body to the request stream
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonRequestBody);
                //Response.Write(jsonRequestBody);
                writer.Flush();
            }

            try
            {
                // Send the request and get the response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Read the response data
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string jsonResponse = reader.ReadToEnd();

                            // Parse the JSON response
                            dynamic responseData = JsonConvert.DeserializeObject(jsonResponse);
                            //Response.Write(jsonResponse);

                            // Retrieve the authentication token and userId from the response
                            string authToken = responseData.token;
                            string userId = responseData.id;
                            //Response.Write("Token :"+ authToken);
                            //Response.Write("User Id :"+ userId);
                         
                            // Store the authentication token securely in the web application
                      
                            Session["Token"] = authToken;
                            Session["userID"] = userId;
                     
                            // Redirect the user to the home page
                            Response.Redirect("page.aspx");
                        }
                    }
                    else
                    {
                        // Handle other status codes if needed
                        Label3.Text = "Username and Password is Incorrect ";
                        Label3.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle any exceptions
                Label3.Text = "Username and Password is Incorrect ";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    }
    


    
