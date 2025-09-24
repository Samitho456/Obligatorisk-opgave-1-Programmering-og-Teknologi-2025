namespace ObliProjekt
{
    public class Trophy
    {
        private string _competition;
        private int _year;


        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }

        public Trophy(){}

        public int Id { get; set;  }

        public string Competition
        {
            get { return _competition; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Competition name cannot be null or empty.");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Competition name must be at least 3 characters");
                }
                _competition = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1970 || value > 2025)
                {
                    throw new ArgumentOutOfRangeException("Year must be between 1970 and 2025.");
                }
                _year = value;
            }
        }

        public override string ToString()
        {
            return $"id: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
