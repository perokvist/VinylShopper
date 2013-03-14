using System;
using System.Threading.Tasks;

namespace VinylShopper.Services
{
    public interface IWebFetcher
    {
        Task<string> GetStringAsync(Uri uri);
    }
}