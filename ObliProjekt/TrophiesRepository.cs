namespace ObliProjekt
{
    public class TrophiesRepository
    {
        /// <summary>
        /// Represents the collection of trophies associated with the current instance.
        /// </summary>
        /// <remarks>This field is intended to store a list of <see cref="Trophy"/> objects.  It is used
        /// internally to manage and track the trophies.</remarks>
        private List<Trophy> _trophies = new List<Trophy>();
        private int _nextId = 1;
        public TrophiesRepository()
        {
            Add(new Trophy(1, "Champions League", 2020));
            Add(new Trophy(2, "La Liga", 2021));
            Add(new Trophy(3, "Premier League", 2022));
            Add(new Trophy(4, "Serie A", 2023));
            Add(new Trophy(5, "Bundesliga", 2024));
        }

        /// <summary>
        /// Retrieves a list of trophies, optionally filtered by year and sorted by a specified criterion.
        /// </summary>
        /// <param name="year">The year to filter trophies by. If null, no filtering is applied.</param>
        /// <param name="sortby">The sorting criterion for the trophies.  Use "competition" to sort by competition name, "year" to sort by
        /// year, or null to maintain the default order.</param>
        /// <returns>A list of trophies filtered by the specified year (if provided) and sorted by the specified criterion (if
        /// provided).</returns>
        public List<Trophy> get(int? year = null, string sortby = null)
        {
            List<Trophy> result = _trophies;

            if (year.HasValue)
            {
                result = result.Where(t => t.Year == year.Value).ToList();
            }

            if (sortby == "competition")
            {
                result = result.OrderBy(t => t.Competition).ToList();
            }
            else if (sortby == "year")
            {
                result = result.OrderBy(t => t.Year).ToList();
            }
            return result;
        }

        /// <summary>
        /// Retrieves a trophy by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the trophy to retrieve.</param>
        /// <returns>The <see cref="Trophy"/> object with the specified identifier, or <see langword="null"/> if no trophy with
        /// the given identifier exists.</returns>
        public Trophy? GetById(int id)
        {
            return _trophies.Find(t => t.Id == id);
        }

        /// <summary>
        /// Adds a new trophy to the collection.
        /// </summary>
        /// <param name="trophy">The <see cref="Trophy"/> object to add. Must not be <see langword="null"/> and must have a unique <c>Id</c>.</param>
        /// <returns>The added <see cref="Trophy"/> object.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="trophy"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if a trophy with the same <c>Id</c> already exists in the collection.</exception>
        public Trophy Add(Trophy trophy)
        {
            if (trophy == null)
            {
                throw new ArgumentNullException(nameof(trophy), "Trophy cannot be null.");
            }
            if (_trophies.Any(t => t.Id == trophy.Id))
            {
                throw new ArgumentException($"A trophy with Id {trophy.Id} already exists.");
            }
            try
            {
                trophy.Id = _nextId++;
                _trophies.Add(trophy);
            }
            catch (Exception ex)
            {
                throw;
            }

            return trophy;
        }

        /// <summary>
        /// Removes the trophy with the specified identifier from the collection.
        /// </summary>
        /// <remarks>If no trophy with the specified identifier is found, the collection remains
        /// unchanged.</remarks>
        /// <param name="id">The unique identifier of the trophy to remove.</param>
        /// <returns>The removed <see cref="Trophy"/> if a trophy with the specified identifier exists; otherwise, <see
        /// langword="null"/>.</returns>
        public Trophy? Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
            }
            return trophy;
        }

        /// <summary>
        /// Updates the properties of an existing trophy with the values from a new trophy.
        /// </summary>
        /// <remarks>This method updates the competition and year of the existing trophy with the
        /// corresponding values from <paramref name="newTrophy"/>.</remarks>
        /// <param name="id">The unique identifier of the trophy to update.</param>
        /// <param name="newTrophy">The trophy containing the updated values. Cannot be <see langword="null"/>.</param>
        /// <returns>The updated trophy if the trophy with the specified <paramref name="id"/> exists and <paramref
        /// name="newTrophy"/> is not <see langword="null"/>; otherwise, <see langword="null"/>.</returns>
        public Trophy? Update(int id, Trophy newTrophy)
        {
            var existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                throw new ArgumentException($"No trophy found with Id {id}.");
            }

            if (newTrophy == null)
            {
                throw new ArgumentNullException(nameof(newTrophy), "New trophy cannot be null.");
            }
            existingTrophy.Competition = newTrophy.Competition;
            existingTrophy.Year = newTrophy.Year;
            return existingTrophy;
        }
    }
}
