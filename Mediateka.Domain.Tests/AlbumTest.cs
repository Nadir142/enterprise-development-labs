using Mediateka.Domain.Data;
using Mediateka.Domain.Services.InMemory;

namespace Mediateka.Domain.Tests;

public class AlbumServiceTests
{
    private readonly AlbumInMemoryRepository _repository;
    public AlbumServiceTests()
    {
        _repository = new AlbumInMemoryRepository();
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего треки в альбоме
    /// </summary>
    [Fact]
    public void GetTreksInAlbum_AlbumWithTracks_ReturnsOrderedTracks()
    {
        // Arrange
        var albumId = 1; // Альбом "BE" с несколькими треками

        // Act
        var album = DataSeeder.Albums.FirstOrDefault(a => a.Id == albumId);
        var result = album?.Tracks
            .Where(track => track.AlbumId == albumId)
            .OrderBy(track => track.NumberInAlbum)
            .Select(track => $"Трек: {track.Name ?? "Без имени"}")
            .ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal("Трек: Life Goes On", result[0]);
        Assert.Equal("Трек: Skit", result[1]);
        Assert.Equal("Трек: Telepathy", result[2]);
        Assert.Equal("Трек: Dynamite", result[3]);
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего альбомы в указанный год
    /// </summary>
    [Fact]
    public void GetAlbumsWithTrackCount_AlbumsInYear_ReturnsAlbumsWithTrackCounts()
    {
        var year = 2020; // Год выпуска альбомов "BE" и "Map of the Soul: 7"
        var result = _repository.GetAlbumsWithTrackCount(year);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    
}