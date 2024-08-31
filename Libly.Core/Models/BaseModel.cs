using System;

namespace Libly.Core.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; }

        // Parameterless constructor
        protected BaseModel()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
