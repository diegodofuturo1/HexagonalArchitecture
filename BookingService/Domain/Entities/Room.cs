﻿namespace Domain.Entities
{
    internal class Room: Entity
    {
        public string? Name { get; set; }
        public int? Level { get; set; }
        public bool InMaintence { get; set; }

        public bool IsAvailable {
            get {
                if (InMaintence || HasGuest) {
                    return false;
                }
                return true;
            }
        }

        public bool HasGuest { 
            get {
                return false;
            } 
        }
    }
}