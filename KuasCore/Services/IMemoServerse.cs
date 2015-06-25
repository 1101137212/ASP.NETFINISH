using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services
{
    public interface IMemoService
    {
        Memo AddMemo(Memo memo);

        void UpdateMemo(Memo memo);

        void DeleteMemo(Memo memo);

        IList<Memo> GetAllMemo();

        Memo GetMemoByKeynote(string keynote);

        Memo GetMemoById(string id);
    }
}
