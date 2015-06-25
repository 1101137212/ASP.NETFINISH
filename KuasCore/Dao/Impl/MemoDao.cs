using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class MemoDao : GenericDao<Memo>, IMemoDao
    {
        override protected IRowMapper<Memo> GetRowMapper()
        {
            return new MemoRowMapper();
        }

        public void AddMemo(Memo memo)
        {
            string command = @"INSERT INTO Memo (Memo_Id, Memo_Keynote, Memo_Detail) VALUES (@Id, @Keynote, @Detail);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = memo.Id;
            parameters.Add("Keynote", DbType.String).Value = memo.Keynote;
            parameters.Add("Detail", DbType.String).Value = memo.Detail;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateMemo(Memo memo)
        {
            string command = @"UPDATE Memo SET Memo_Keynote = @Keynote, Memo_Detail = @Detail WHERE Memo_Id = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = memo.Id;
            parameters.Add("Keynote", DbType.String).Value = memo.Keynote;
            parameters.Add("Detail", DbType.String).Value = memo.Detail;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteMemo(Memo memo)
        {
            string command = @"DELETE FROM Memo WHERE Memo_Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = memo.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Memo> GetAllMemo()
        {
            string command = @"SELECT * FROM Memo ORDER BY Memo_Id ASC";
            IList<Memo> memo = ExecuteQueryWithRowMapper(command);
            return memo;
        }

        public Memo GetMemoByKeynote(string keynote)
        {
            string command = @"SELECT * FROM Memo WHERE Memo_Keynote = @Keynote";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Keynote", DbType.String).Value = keynote;

            IList<Memo> memo = ExecuteQueryWithRowMapper(command, parameters);
            if (memo.Count > 0)
            {
                return memo[0];
            }

            return null;
        }

        public Memo GetMemoById(string id)
        {
            string command = @"SELECT * FROM Memo WHERE Memo_Id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = id;

            IList<Memo> memo = ExecuteQueryWithRowMapper(command, parameters);
            if (memo.Count > 0)
            {
                return memo[0];
            }

            return null;
        }
    }
}
