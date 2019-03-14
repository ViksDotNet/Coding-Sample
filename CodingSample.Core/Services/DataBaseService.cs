using CodingSample.Core.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSample.Core.Services
{
   public class DataBaseService : IDataService
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(DataBaseService));

        public DataBaseService(/* pass database information (dbContext e.g.) */)
        {
            //Database connection here
        }

        public void WriteData(OutputDataEntity entity)
        {
            try
            {               
                //Insert data to the database here
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return;
            }
            return;
        }
    }
}
