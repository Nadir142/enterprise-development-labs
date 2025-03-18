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
    /// ����������������� ���� ������, ���������� ����� � �������
    /// </summary>
    [Fact]
    public void GetTreksInAlbum_AlbumWithTracks_ReturnsOrderedTracks()
    {
        // Arrange
        var albumId = 1; // ������ "BE" � ����������� �������

        // Act
        var album = DataSeeder.Albums.FirstOrDefault(a => a.Id == albumId);
        var result = album?.Tracks
            .Where(track => track.AlbumId == albumId)
            .OrderBy(track => track.NumberInAlbum)
            .Select(track => $"����: {track.Name ?? "��� �����"}")
            .ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal("����: Life Goes On", result[0]);
        Assert.Equal("����: Skit", result[1]);
        Assert.Equal("����: Telepathy", result[2]);
        Assert.Equal("����: Dynamite", result[3]);
    }

    /// <summary>
    /// ����������������� ���� ������, ���������� ������� � ��������� ���
    /// </summary>
    [Fact]
    public void GetAlbumsWithTrackCount_AlbumsInYear_ReturnsAlbumsWithTrackCounts()
    {
        var year = 2020; // ��� ������� �������� "BE" � "Map of the Soul: 7"
        var result = _repository.GetAlbumsWithTrackCount(year);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    
}