﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JabbR_Core.Data.Models
{
    public partial class ChatUserIdentity
    {
        public int Key { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string ProviderName { get; set; }

        public ChatUser UserKeyNavigation { get; set; }
    }
}
