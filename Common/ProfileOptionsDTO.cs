namespace ai_finder_be_schedulers_donetcore.Common
{
    public class ProfileOptionsDTO
    {
        public bool IsAlreadySeen { get; set; }
        public bool IsAlreadyContacted { get; set; }
        public bool IsInterestSent { get; set; }
        public bool IsShortListed { get; set; }
        public bool IsWithPhoto { get; set; }
        public bool IsOnline { get; set; }
        public bool IsPremium { get; set; }
    }
}