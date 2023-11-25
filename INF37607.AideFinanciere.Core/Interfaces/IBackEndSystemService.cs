using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IBackEndSystemService
    {
        Task sendRequestToBackEnd(Request request, string directory);
    }
}
