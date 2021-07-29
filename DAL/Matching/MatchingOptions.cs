namespace DAL.Matching
{
    public class MatchingOptions
    {
        private bool _matchOnlyOnWeeks = false;
        public bool MatchOnlyOnWeeks
        {
            get
            {
                return _matchOnlyOnWeeks;
            }
            set
            {
                _matchOnlyOnSchedule = false;
                _matchOnlyOnWeeks = value;
            }
        }

        private bool _matchOnlyOnSchedule = false;
        public bool MatchOnlyOnSchedule
        {
            get
            {
                return _matchOnlyOnSchedule;
            }
            set
            {
                _matchOnlyOnWeeks = false;
                _matchOnlyOnSchedule = value;
            }
        }
        public bool MatchUncertainSchedule { get; set; } = false;

        public void SetAllToFalse()
        {
            MatchOnlyOnWeeks = false;
            MatchOnlyOnSchedule = false;
            MatchUncertainSchedule = false;
        }
    }
}
