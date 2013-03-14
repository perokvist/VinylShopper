using System;

namespace VinylShopper.Services
{
    public interface IStoreInfo
    {
        string StoreName { get; }
        Uri StoreLogo { get; } 
    }
}