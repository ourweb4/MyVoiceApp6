// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-03-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 02-03-2023
// ***********************************************************************
// <copyright file="Apinet.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVoiceApp6.ViewModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AccessToken
    {
        public string name { get; set; }
        public List<string> abilities { get; set; }
        public object expires_at { get; set; }
        public int tokenable_id { get; set; }
        public string tokenable_type { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
    }

    public class Apinet
    {
        public User user { get; set; }
        public Token token { get; set; }
    }

    public class Token
    {
        public AccessToken accessToken { get; set; }
        public string plainTextToken { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
    }


}
