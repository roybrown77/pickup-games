﻿namespace PickupGames.Domain.Objects
{
    public abstract class ResponseBase
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}