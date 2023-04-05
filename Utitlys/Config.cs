// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 03-13-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 03-13-2023
// ***********************************************************************
// <copyright file="Config.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVoiceApp6.Utitlys
{
    /// <summary>
    /// Class Config.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token
        {
          get {
                var token = Preferences.Get("token", "");
                return token;
            }
            set
            {
                Preferences.Set("token", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Config"/> is autotalk.
        /// </summary>
        /// <value><c>true</c> if autotalk; otherwise, <c>false</c>.</value>
        public bool Autotalk
        {
            get
            {
                var autotalk = Preferences.Get("autotalk", true); 
                return autotalk;
            }
            set
            {
                Preferences.Set("autotalk", value);
            }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserID
        {
            get
            {
                var id = Preferences.Get("user_id",null);
                return id;
            }
            set { 
                Preferences.Set("user_id", value);
            } 
        
        }
    }
}
