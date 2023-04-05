﻿// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill  Banks
// Created          : 09-29-2022
//
// Last Modified By : Bill  Banks
// Last Modified On : 09-29-2022
// ***********************************************************************
// <copyright file="LoginVM.cs" company="MyVoiceApp6">
//     Copyright (c) Ourweb. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace MyVoiceApp6.ViewModels
{
    /// <summary>
    /// Class LoginVM.
    /// </summary>
    public partial class LoginVM
    {

        /// <summary>
        /// The email
        /// </summary>
        [JsonProperty("email")]
        public string email;
        /// <summary>
        /// The password
        /// </summary>
        [JsonProperty("password")]
        public string password;

   //     public string Email { get => email; set => email = value; }
   //      public string Password { get => password; set => password = value; }
    }
}
