namespace VinylShopper.Services
{
    public interface ISearchResult
    {
        string Artist { get; }
        string AlbumTitle { get; }
        string Label { get; }
        string ReleaseDate { get; }
    }
}