using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Data
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly IXmlRepository xmlRepository;
        private IEnumerable<Facility> allFacilities;

        public FacilityRepository(IXmlRepository xmlRepository)
        {
            this.xmlRepository = xmlRepository;
            this.xmlRepository.DataChangedEventHandler += (o, e) => allFacilities = null;
        }

        public Facility GetById(int key)
        {
            return AllFacilities
                .FirstOrDefault(x => x.FacilityId == key);
        }

        protected IEnumerable<Facility> AllFacilities
        {
            get
            {
                if (allFacilities == null)
                    allFacilities = xmlRepository.GetAll<Facility>();

                return allFacilities;
            }
        }

        public IList<Facility> GetAll()
        {
            return AllFacilities.ToList();
        }

        public int Add(Facility facility)
        {
            xmlRepository.Add(facility, (f, id) => f.FacilityId = id);
            return facility.FacilityId;
        }
    }
}