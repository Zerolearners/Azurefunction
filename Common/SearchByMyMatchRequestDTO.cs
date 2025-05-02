namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SearchByMyMatchRequestDTO
    {
        public PaginationDTO Pagination { get; set; }
        public List<SortDTO> Sort { get; set; }
        public MatchFilterDTO Filters { get; set; }
    }
}