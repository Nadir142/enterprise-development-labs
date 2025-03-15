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
    /// ����������������� ���� ������, ������������� ������ ������ �� ID �������
    /// </summary>
    /// <param name="AlbumId">������������� �������</param>
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
            var expectedInfo = $"����: {tracks.Name}";
            Assert.Contains(expectedInfo, result);
        }
    }

    /// <summary>
    /// ����������������� ���� ������, ������������� �������� �� �������� ���
    /// </summary>
    /// <param name="Year">������������� �������</param>
    [Theory]
    [InlineData(2020, 2)] // ������� 2 ������� �� 2020 ���
    [InlineData(1970, 1)] // ������� 1 ������ �� 1970 ���
    [InlineData(1991, 1)] // ������� 1 ������ �� 1991 ���
    [InlineData(2023, 0)] // ������� 0 �������� �� 2023 ���
    public void GetAlbumsWithTrackCount_ReturnsCorrectData_ForGivenYear(int year, int expectedCount)
    {
        var result = _repository.GetAlbumsWithTrackCount(year).ToList();
        Assert.Equal(expectedCount, result.Count);
    }

    /// <summary>
    /// ���� ������, ������������� ���-5 �������� �� �����������
    /// </summary>
    [Fact]
    public void GetTop5AlbumsByDuration_Success()
    {
        var repo = new AlbumInMemoryRepository();
        var albums = repo.GetTop5AlbumsByDuration();
        Assert.Equal(5, albums.Count);
    }

}
