using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APIassignment
{
    public partial class page : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            
            
          
            //// Specify the user ID for the request
            //string userId = "4f291688-8615-4db8-ac1c-aafe19585e05";
            string userId = Session["userID"] as string;

            // Construct the API URL with the user ID
            string apiUrl = "https://genxhire-esurveillance-api.azurewebsites.net/api/user/" + userId;

            // Create the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";

            // Set the Authorization header with the authentication token
            string authToken = Session["Token"] as string;
            //string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI0ZjI5MTY4OC04NjE1LTRkYjgtYWMxYy1hYWZlMTk1ODVlMDUiLCJuYW1lIjoiVGVzdCBFbmdpbmVlciIsImVtYWlsIjoidGVzdC5lbmdpbmVlckBnZW54aGlyZS5pbiIsImV4cCI6MTY4ODU2NjQxOSwiaXNzIjoiR2VueGhpcmVFU3VydmVpbGxhbmNlIiwiYXVkIjoiR2VueGhpcmVFU3VydmVpbGxhbmNlIn0.607ArZWmsmNFUQk5b4H_7xLZ5CY0q38t7u_49fvq4_c";
            request.Headers["Authorization"] = "Bearer " + authToken;

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
                            string jsonData = reader.ReadToEnd();

                            // Parse the JSON data
                            
                            TextBox1.Text = jsonData;
                        }
                    }
                    else
                    {
                       
                        Label1.Text = "Error: " + response.StatusCode;
                    }
                }
            }
            catch (WebException ex)
            {
            
                Response.Redirect("Home.aspx");
                Label1.Text = "Error: " + ex.Message;
            }
            



        }
    }
}

