using ms_partnership.Models.Entities.Dtos.Promo;

namespace ms_partnership.Models.Pagination
{
    public class PromoPagination
    {
        public PromoPagination(List<ReadPromoDto> contents, int actualPage, int totalItems, int totalPages)
        {
            this.Contents = contents;
            this.TotalPages = totalPages;
            this.TotalItems = totalItems;
            this.ActualPage = actualPage;
        }

        public List<ReadPromoDto> Contents { get; set; }
        public int ActualPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

    }
}