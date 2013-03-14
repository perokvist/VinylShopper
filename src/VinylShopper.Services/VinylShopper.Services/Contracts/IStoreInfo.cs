using System;

namespace VinylShopper.Services.Contracts
{
    public interface IStoreInfo
    {
        string StoreName { get; }
        Uri StoreLogo { get; } 
    }
}