namespace ai_finder_be_schedulers_donetcore.Common
{
    public class SearchResultDTO
    {
        public long TotalCount { get; set; }
        public IEnumerable<ResultDTO> Result { get; set; }
    }
}