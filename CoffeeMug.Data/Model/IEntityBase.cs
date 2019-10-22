using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Data.Model
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
