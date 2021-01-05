using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        private readonly CityInfoContext _context;

        public LanguageRepository(CityInfoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
