using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ComicSharedModels;
using System.Net.Http;

namespace ComicClient
{
    public interface IComicService
    {
        Task<ComicModel> GetMostRecentComicAsync();
    }
}
