using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class MemoController : ApiController
    {

        public IMemoService MemoService { get; set; }

        [HttpPost]
        public Memo AddMemo(Memo memo)
        {
            CheckMemoIsNotNullThrowException(memo);

            try
            {
                return MemoService.AddMemo(memo);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Memo UpdateMemo(Memo memo)
        {
            CheckmemoIsNullThrowException(memo);

            try
            {
                MemoService.UpdateMemo(memo);
                return MemoService.GetMemoByKeynote(memo.Keynote);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteEmployee(Memo memo)
        {
            try
            {
                MemoService.DeleteMemo(memo);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Memo> GetAllMemo()
        {
            return MemoService.GetAllMemo();
        }

        [HttpGet]
        public Memo GetMemoById(string id)
        {
            var memo = MemoService.GetMemoById(id);

            if (memo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return memo;
        }

        [HttpGet]
        [ActionName("Keynote")]
        public Memo GetMemoByName(string input)
        {
            var memo = MemoService.GetMemoByKeynote(input);

            if (memo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return memo;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="memo">
        ///     課程資料.
        /// </param>
        private void CheckmemoIsNullThrowException(Memo memo)
        {
            Memo dbMemo = MemoService.GetMemoById(memo.Id);

            if (dbMemo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param keynote="memo">
        ///     課程資料.
        /// </param>
        private void CheckMemoIsNotNullThrowException(Memo memo)
        {
            Memo dbMemo = MemoService.GetMemoById(memo.Id);

            if (dbMemo != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}