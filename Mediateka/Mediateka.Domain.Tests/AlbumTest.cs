using Mediateka.Domain.Services.InMemory;
using Mediateka.Domain.Data;

namespace Mediateka.Domain.Tests;
public class AlbumTests
{
    private readonly AlbumInMemoryRepository _repository;
    public AlbumTests()
    {
        _repository = new AlbumInMemoryRepository();
    }

    /// <summary>
    /// Параметризованный тест метода, возвращающего список треков по ID альбома
    /// </summary>
    /// <param name="AlbumId">Идентификатор альбома</param>
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetTreksInAlbum_ReturnsGetTreksInAlbum(int AlbumId)
    {
        var result = _repository.GetTreksInAlbum(AlbumId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);

        var track = DataSeeder.Tracks
            .Where(track => track.AlbumId == AlbumId)
            .OrderBy(track => track.NumberInAlbum)
            .ToList();

        foreach (var tracks in track)
        {
            var expectedInfo = $"Трек: {tracks.Name}";
            Assert.Contains(expectedInfo, result);
        }
    }

    /// <summary>
    /// Параметризованный тест метода, возвращающего альбомов за указаный год
    /// </summary>
    /// <param name="Year">Идентификатор альбома</param>
    [Theory]
    [InlineData(2020, 2)] // Ожидаем 2 альбома за 2020 год
    [InlineData(1970, 1)] // Ожидаем 1 альбом за 1970 год
    [InlineData(1991, 1)] // Ожидаем 1 альбом за 1991 год
    [InlineData(2023, 0)] // Ожидаем 0 альбомов за 2023 год
    public void GetAlbumsWithTrackCount_ReturnsCorrectData_ForGivenYear(int year, int expectedCount)
    {
        var result = _repository.GetAlbumsWithTrackCount(year).ToList();
        Assert.Equal(expectedCount, result.Count);
    }

    /// <summary>
    /// Тест метода, возвращающего топ-5 альбомов по длительнсти
    /// </summary>
    [Fact]
    public void GetTop5AlbumsByDuration_Success()
    {
        var repo = new AlbumInMemoryRepository();
        var albums = repo.GetTop5AlbumsByDuration();
        Assert.Equal(5, albums.Count);
    }

}
