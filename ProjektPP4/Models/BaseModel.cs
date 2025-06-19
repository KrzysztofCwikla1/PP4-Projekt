﻿namespace ProjektPP4.Models
{
    public class BaseModel
    {
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
