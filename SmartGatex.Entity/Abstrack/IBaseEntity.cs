using System;

namespace SmartGatex.Entity.Abstrack
{
    public abstract class IBaseEntity
    {
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
