using Mediateka.Domain.Data;
using Mediateka.Domain.Model;
namespace Mediateka.Domain.Services.InMemory;

/// <summary>
/// Реализация репозитория артистов в памяти.
/// </summary>
public class ArtistInMemoryRepository : IRepository<Artist, int>
{
    private List<Artist> _artists;
    public ArtistInMemoryRepository()
    {
        _artists = DataSeeder.Artists;
    }

    public bool Add(Artist entity)
    {
        try
        {
            _artists.Add(entity);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Delete(int key)
    {
        try
        {
            var artist = Get(key);
            if (artist != null)
                _artists.Remove(artist);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Update(Artist entity)
    {
        try
        {
            Delete(entity.Id);
            Add(entity);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public Artist? Get(int key) =>
        _artists.FirstOrDefault(item => item.Id == key);
    public IList<Artist> GetAll() =>
        _artists;

    /// <summary>
    /// Возвращает информацию о всех артистах в виде списка строк.
    /// </summary>
    public IList<string> GetAllArtisInfo()
    {
        return _artists.Select(Artist =>
                $"Имя: {Artist.Name}, Биография: {Artist.Biography}, Жанр: {Artist.Genre} ")
            .ToList();
    }

    /// <summary>
    /// Метод для вывода артистов с максимальныи количествм альбомов
    /// </summary>
    /// <returns>Список артистов и альбомов</returns>
    /// <summary>
    public IList<string> GetArtistsWithMaxAlbums()
    {
        var maxAlbums = _artists
            .Where(Artist => Artist.Albums != null)
            .Max(Artist => Artist.AlbumCount);

        return _artists
            .Where(Artist => Artist.Albums != null && Artist.Albums.Count == maxAlbums)
            .Select(Artist =>
                $"Имя: {Artist.Name}, Биография: {Artist.Biography}, Жанр: {Artist.Genre} " +
                $"Количество альбомов: {Artist.AlbumCount}")
            .ToList();
    }
}