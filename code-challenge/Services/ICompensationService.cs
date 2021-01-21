using challenge.Models;

namespace challenge.Services
{
    public interface ICompensationService
    {
        /// <summary>
        /// Get a compensation by employee id.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Compensation for the given employee id.</returns>
        Compensation GetById(string id);

        /// <summary>
        /// Create a new compensation object.
        /// </summary>
        /// <param name="compensation">Compensation object to create.</param>
        /// <returns>Created compensation object.</returns>
        Compensation Create(Compensation compensation);
    }
}
