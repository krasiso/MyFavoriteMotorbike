using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class User : IdentityUser
    {
        public List<Motorbike> Motorbikes { get; set; } = new List<Motorbike>();
    }
}
