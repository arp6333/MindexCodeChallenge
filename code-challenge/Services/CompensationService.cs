using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    /// <summary>
    /// The service handler for compensation.
    /// </summary>
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        /// <summary>
        /// Create a new compensation service object.
        /// </summary>
        /// <param name="logger">Logger object.</param>
        /// <param name="compensationRepository">Compensation repository.</param>
        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        /// <summary>
        /// Create a new compensation object.
        /// </summary>
        /// <param name="compensation">Compensation object to create.</param>
        /// <returns>Created compensation object.</returns>
        public Compensation Create(Compensation compensation)
        {
            if(compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /// <summary>
        /// Get a compensation object by employee id.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Compensation for the given employee id.</returns>
        public Compensation GetById(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }
    }
}
