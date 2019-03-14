using CodingSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSample.Core.Services
{
   public interface IDataService
    {
        void WriteData(OutputDataEntity entity);
    }
}
