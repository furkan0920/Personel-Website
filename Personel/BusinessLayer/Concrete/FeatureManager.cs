using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IGenericService<Feature>
    {
        IFeatureDaL _featureDaL;

        public FeatureManager(IFeatureDaL featureDaL)
        {
            _featureDaL = featureDaL;
        }
        public Feature GetByID(int id)
        {
            return _featureDaL.GetByID(id); 
        }

        public void TAdd(Feature t)
        {
            _featureDaL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDaL.Delete(t);
        }

        public List<Feature> TGetList()
        {
            return _featureDaL.GetList();
        }

        public void TUpdate(Feature t)
        {
            _featureDaL.Update(t);      
        }
    }
}
