using Microsoft.AspNetCore.Identity;

namespace MyFavoriteMotobike.Infrastructure.Data.Entities
{
    public class User : IdentityUser
    {
        public List<Motorbike> Motorbikes { get; set; } = new List<Motorbike>();
    }
}
