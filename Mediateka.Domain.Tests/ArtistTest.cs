using Mediateka.Domain.Model;
using Mediateka.Domain.Services.InMemory;
using Mediateka.Domain.Data;

namespace Mediateka.Domain.Tests;

/// <summary>
/// Класс с юнит-тестами
/// </summary>
public class ArtistTests
{
    private readonly ArtistInMemoryRepository _repository;
    public ArtistTests()
    {
        _repository = new ArtistInMemoryRepository();
    }

    /// <summary>
    /// Тест метода, возвращающего информацию о всех артистах
    /// </summary>
    [Fact]
    public void GetAllArtisInfo_ReturnsCorrectArtistDetails()
    {
        var result = _repository.GetAllArtisInfo();
        Assert.NotNull(result);
        Assert.Equal(DataSeeder.Artists.Count, result.Count);

        foreach (var artist in DataSeeder.Artists)
        {
            var expectedInfo = $"Имя: {artist.Name}, Биография: {artist.Biography}, Жанр: {artist.Genre} ";
            Assert.Contains(expectedInfo, result);
        }
    }

    /// <summary>
    /// Тест метода, возвращающего артистов с максимальным количеством альбомов
    /// </summary>
    [Fact]
    public void GetArtistsWithMaxAlbums_ReturnsGetArtistsWithMaxAlbums()
    {
        var result = _repository.GetArtistsWithMaxAlbums();

        Assert.NotNull(result);
        Assert.NotEmpty(result);

        var maxAlbums = DataSeeder.Artists
            .Where(a => a.Albums != null)
            .Max(f => f.AlbumCount);

        var expectedArtists = DataSeeder.Artists
            .Where(a => a.Albums != null && a.Albums.Count == maxAlbums)
            .ToList();

        foreach (var artist in expectedArtists)
        {
            var expectedInfo = $"Имя: {artist.Name}, Биография: {artist.Biography}, Жанр: {artist.Genre} " +
                $"Количество альбомов: {artist.AlbumCount}";
            Assert.Contains(expectedInfo, result);
        }
    }
}