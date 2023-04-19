﻿// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill
// Created          : 09-29-2022
//
// Last Modified By : Bill
// Last Modified On : 03-07-2023
// ***********************************************************************
// <copyright file="Api.cs" company="MyVoiceApp6">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Text;
using MyVoiceApp6.ViewModels;
using Newtonsoft.Json;
using MyVoiceApp6.Models;
using System;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MyVoiceApp6.Utitlys
{
    /// <summary>
    /// Class Api.
    /// </summary>
    public class Api
    {


        /// <summary>
        /// The website
        /// </summary>
        public const string website = "https://ourvoiceapp.com";

        /// <summary>
        /// The client
        /// </summary>
        private HttpClient client;
        //   myApp = new App();
        /// <summary>
        /// The status
        /// </summary>
        public HttpStatusCode status;
        /// <summary>
        /// The message
        /// </summary>
        public string message;


        /// <summary>
        /// Initializes a new instance of the <see cref="Api" /> class.
        /// </summary>
        public Api()
        {
            client = new HttpClient()
            {
                //             BaseAddress = new Uri( App.website + "/api")
            };
        }



        /// <summary>
        /// Determines whether this instance is ok.
        /// </summary>
        /// <returns><c>true</c> if this instance is ok; otherwise, <c>false</c>.</returns>
        public bool IsOk()
        {
            return status == HttpStatusCode.OK ||
                   status == HttpStatusCode.Accepted ||
                   status == HttpStatusCode.Created ||
                   status == HttpStatusCode.Found;
        }

        /// <summary>
        /// Setheaders this instance.
        /// </summary>
        private void setheader()
        {
            //         var myApp = Application.Current as App;
            var token = Preferences.Get("token", "");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// as the URI.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Uri.</returns>
        private Uri aUri(string endpoint)
        {

            var BaseAddress = new Uri(website + "/api" + endpoint);
            return BaseAddress;
        }

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>System.String.</returns>
        public async Task<string> Login(LoginVM login)
        {

            //var myApp = Application.Current as App;
             

            var json = JsonConvert.SerializeObject(login);
         var content =
                new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(aUri("/Login"), content);
      //      var response = await httpresponse.Content.ReadAsStringAsync();  
            status = response.StatusCode;
             if (status == HttpStatusCode.OK || status == HttpStatusCode.Created)
            {
                var resdata = await response.Content.ReadAsStringAsync();
                var rjson = JsonConvert.DeserializeObject<Apinet>(resdata);
                //myApp.token = rjson.Token;
                Preferences.Set("token", rjson.token.plainTextToken);
                return rjson.token.plainTextToken;

            }
 
            else
            {
                message = Api_error(status);
                return message;
            }


        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public async Task Logout()
        {
            setheader();


            //var myApp = Application.Current as App;
            var response = await client.PostAsync(aUri("/Logout"), new StringContent(""));
            status = response.StatusCode;
            //myApp.token = null;
            Preferences.Set("token", null);

        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> Register(RegisterVM register)
        {

            //      var myApp = Application.Current as App;
            var json = JsonConvert.SerializeObject(register);
            var content =
                 new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(aUri("/Register"), content);
            status = response.StatusCode;
            if (status == HttpStatusCode.OK || status == HttpStatusCode.Created)
            {
                var resdata = await response.Content.ReadAsStringAsync();
                
                var rjson = JsonConvert.DeserializeObject<Apinet>(resdata);

                // myApp.token = rjson.Token;
                Preferences.Set("token", rjson.token.plainTextToken);

                return rjson.token.plainTextToken;

            }
            else
            {
                message = Api_error(status);
                return message;
            }


       }

        public async Task<string> Forgot(ForgotVM forgot)
        {

            //      var myApp = Application.Current as App;
            var json = JsonConvert.SerializeObject(forgot);
            var content =
                 new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(aUri("/Forgot"), content);
            status = response.StatusCode;
            if (status == HttpStatusCode.OK || status == HttpStatusCode.Created)
            {
                var resdata = await response.Content.ReadAsStringAsync();

                var rjson = JsonConvert.DeserializeObject<Apinet>(resdata);

                // myApp.token = rjson.Token;
//                Preferences.Set("token", rjson.token.plainTextToken);

                return null;

            }
            else
            {
                message = Api_error(status);
                return message;
            }


        }



        /// <summary>
        /// APIs the error.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>System.String.</returns>
        public string Api_error(HttpStatusCode status)
        {
            string msg = null;

            switch (status)
            {
                case HttpStatusCode.BadGateway:
                    msg = "Bad  Gateway ";
                    break;
                case HttpStatusCode.BadRequest:
                    msg = "Bad Request ";
                    break;
                case HttpStatusCode.Forbidden:
                    msg = "Forbidden Access ";
                    break;
                case HttpStatusCode.Unauthorized:
                    msg = "Bad Login ";
                    break;
                default:
                    msg = "Unknown Error";
                    break;
            }
            return msg;
        }



        // User

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>User.</returns>
        public async Task<AppUser> GetUser()
        {
            setheader();
            var response = await client.GetAsync(aUri("/User"));
             status = response.StatusCode;
            if (status == HttpStatusCode.OK || status == HttpStatusCode.Created)
            {
                var resdata = await response.Content.ReadAsStringAsync();

                var rjson = JsonConvert.DeserializeObject<AppUser>(resdata);
                return rjson;

            }
            else
            {
                message = Api_error(status);
                return null;
            }

        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public async Task SaveUser(AppUser user)
        {
            setheader();
            var json = JsonConvert.SerializeObject(user);

            var content =
                new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(aUri("/User"), content);
            status = response.StatusCode;

        }
    }

}