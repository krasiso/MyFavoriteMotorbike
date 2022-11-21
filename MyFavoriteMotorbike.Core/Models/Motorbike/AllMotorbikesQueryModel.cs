using MyFavoriteMotorbike.Core.Models.Sorting;

namespace MyFavoriteMotorbike.Core.Models.Motorbike
{
    public class AllMotorbikesQueryModel
    {
        public const int MotorbikesPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public MotorbikeSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalMotorbikesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<MotorbikeServiceModel> Motorbikes { get; set; } = Enumerable.Empty<MotorbikeServiceModel>();
    }
}
