// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 04-08-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 04-08-2023
// ***********************************************************************
// <copyright file="ForgotVM.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVoiceApp6.ViewModels
{
    /// <summary>
    /// Class ForgotVM.
    /// </summary>
    public partial class ForgotVM
    {
        /// <summary>
        /// The email
        /// </summary>
        [JsonProperty("email")]
        public string email;
    }
}
