using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class MemoService : IMemoService
    {
        public IMemoService MemoDao { get; set; }

        public Memo AddMemo(Memo memo)
        {
            MemoDao.AddMemo(memo);
            return GetMemoByKeynote(memo.Keynote);
        }

        public void UpdateMemo(Memo memo)
        {
            MemoDao.UpdateMemo(memo);
        }

        public void DeleteMemo(Memo memo)
        {
            memo = MemoDao.GetMemoByKeynote(memo.Keynote);

            if (memo != null)
            {
                MemoDao.DeleteMemo(memo);
            }
        }

        public IList<Memo> GetAllMemo()
        {
            return MemoDao.GetAllMemo();
        }

        public Memo GetMemoByKeynote(string keynote)
        {
            return MemoDao.GetMemoByKeynote(keynote);
        }

        public Memo GetMemoById(string id)
        {
            return MemoDao.GetMemoById(id);
        }
    }
}
