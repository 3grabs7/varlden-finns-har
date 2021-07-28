namespace DAL.Matching
{
    public class MatchingOptions
    {
        public bool MatchOnlyOnWeeks { get; set; } = false;
        public bool MatchOnlyOnSchedule { get; set; } = false;
        public bool MatchUncertainSchedule { get; set; } = false;

        public void SetAllToFalse()
        {
            MatchOnlyOnWeeks = false;
            MatchOnlyOnSchedule = false;
            MatchUncertainSchedule = false;
        }
    }
}
