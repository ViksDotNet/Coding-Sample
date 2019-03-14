using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingSample.Core.Entities;


namespace CodingSample.Core.Services
{
    public class ConsoleDataService : IDataService
    {
        public void WriteData(OutputDataEntity entity)
        {
            try
            {
                Console.WriteLine(entity.OutputData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            return;
        }
    }
}
