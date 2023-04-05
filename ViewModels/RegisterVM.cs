﻿// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill  Banks
// Created          : 09-29-2022
//
// Last Modified By : Bill  Banks
// Last Modified On : 11-30-2022
// ***********************************************************************
// <copyright file="RegisterVM.cs" company="MyVoiceApp6">
//     Copyright (c) Ourweb. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace MyVoiceApp6.ViewModels
{
    /// <summary>
    /// Class RegisterVM.
    /// </summary>
    public partial class RegisterVM 
    {
        /// <summary>
        /// Gets or sets the fristname.
        /// </summary>
        /// <value>The fristname.</value>
        [JsonProperty("firstname")]
        
        public string firstname { get; set; }


        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>The lastname.</value>
        [JsonProperty("lastname")]
        public string lastname { get; set; }



        /// <summary>
        /// The email
        /// </summary>
        [JsonProperty("email")]
        public string email { get; set; }



        /// <summary>
        /// The password
        /// </summary>
        [JsonProperty("password")]
    
       public string password { get; set; }



    }
}
