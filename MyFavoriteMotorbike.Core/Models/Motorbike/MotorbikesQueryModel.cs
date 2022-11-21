namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class MotorbikesQueryModel
    {
        public int TotalMotorbikesCount { get; set; }

        public IEnumerable<MotorbikeServiceModel> Motorbikes { get; set; } = new List<MotorbikeServiceModel>();
    }
}
