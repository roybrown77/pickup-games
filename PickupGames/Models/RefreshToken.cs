using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickupGames.Models
{
    public class RefreshToken
    {
        public string ProtectedTicket { get; set; }

        public string ClientId { get; set; }

        public DateTime ExpiresUtc { get; set; }

        public string Id { get; set; }

        public DateTime IssuedUtc { get; set; }

        public string Subject { get; set; }
    }
}