
using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace KuasCore.Dao.Mapper
{
    class MemoRowMapper : IRowMapper<Memo>
    {
        public Memo MapRow(IDataReader dataReader, int rowNum)
        {
            Memo target = new Memo();

            target.Id = dataReader.GetString(dataReader.GetOrdinal("Memo_Id"));
            target.Keynote = dataReader.GetString(dataReader.GetOrdinal("Memo_Keynote"));
            target.Detail = dataReader.GetString(dataReader.GetOrdinal("Memo_Detail"));

            return target;
        }
    }
}
