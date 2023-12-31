﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using EAISolutionFrontEnd.Core;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IFinancialAideRepository : IAsyncRepository<FinancialAide>
    {
        Task<List<FinancialAide>> GetListByIdAsync(int userId, FinancialAideStatus status);
    }
}
