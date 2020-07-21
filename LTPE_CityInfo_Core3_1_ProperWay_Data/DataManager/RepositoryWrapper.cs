using System;
using System.Collections.Generic;
using System.Text;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CityInfoContext _repoContext;

        private ICityInfoRepository _cityInfoRepositoryWrapper;
        private ICityLanguageRepository _cityLanguageRepositoryWrapper;
        private ILanguageRepository _languageRepositoryWrapper;

        public ICityInfoRepository CityInfoRepositoryWrapper
        {
            get
            {
                if (null == _cityInfoRepositoryWrapper)
                {
                    _cityInfoRepositoryWrapper = new CityInfoRepository(_repoContext);
                }

                return (_cityInfoRepositoryWrapper);
            }
        }

        public ICityLanguageRepository CityLanguageRepositoryWrapper
        {
            get
            {
                if (null == _cityLanguageRepositoryWrapper)
                {
                    _cityLanguageRepositoryWrapper = new CityLanguageRepository(_repoContext);
                }

                return (_cityLanguageRepositoryWrapper);
            }
        }

        public ILanguageRepository LanguageRepositoryWrapper
        {
            get
            {
                if (null == _languageRepositoryWrapper)
                {
                    _languageRepositoryWrapper = new LanguageRepository(_repoContext);
                }

                return (_languageRepositoryWrapper);
            }
        }

        public RepositoryWrapper(CityInfoContext repositoryContext)
        {
            this._repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
