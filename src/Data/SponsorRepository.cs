using System.Collections.Generic;
using System.Linq;
using Groop.Core.Data;
using Groop.Core.Domain;

namespace Groop.Data
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IXmlRepository xmlRepository;
        private IEnumerable<Sponsor> allSponsors;

        public SponsorRepository(IXmlRepository xmlRepository)
        {
            this.xmlRepository = xmlRepository;
            this.xmlRepository.DataChangedEventHandler += (o, e) => allSponsors = null;
        }

        protected IEnumerable<Sponsor> AllSponsors
        {
            get
            {
                if (allSponsors == null)
                    allSponsors = xmlRepository.GetAll<Sponsor>();

                return allSponsors;
            }
        }

        public Sponsor GetById(int key)
        {
            return xmlRepository.Get<Sponsor>(key);
        }

        public int Add(Sponsor sponsor)
        {
            xmlRepository.Add(sponsor, (x, id) => x.SponsorId = id);
            return sponsor.SponsorId;
        }

        public IList<Sponsor> GetAll()
        {
            return AllSponsors.ToList();
        }
    }
}