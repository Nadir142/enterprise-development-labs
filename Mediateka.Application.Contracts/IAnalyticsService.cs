namespace Mediateka.Application.Contracts;
/// <summary>
/// Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения
/// </summary>
public interface IAlbumAnalyticsService
{
    /// <summary>
    /// Возвращает список треков для указанного альбома
    /// </summary>
    /// <param name="albumId">ID альбома.</param>
    /// <returns>Список строк с информацией о треках.</returns>
    public IList<string> GetTreksInAlbum();

    /// <summary>
    /// Возвращает список треков для указанного альбома
    /// </summary>
    /// <param name="year">Год выпуска.</param>
    public IEnumerable<(string AlbumName, int TrackCount)> GetAlbumsWithTrackCount();

    /// <summary>
    /// Возвращает топ-5  альбомов по продолжительности
    /// </summary>
    public IList<Tuple<string, int>> GetTop5AlbumsByDuration();

    /// <summary>
    /// Получить информацию о количестве треков, среднем и максимальной дляительности для каждого альбома.
    /// </summary>
    /// <returns>Список с минимальной, средней и максимальной длительностью альбомов.</returns>
    public Task<IList<(int MinDuration, double avgDuration, int maxDuration)>> GetAlbumDurationStatistics();

}
public interface IArtistAnalyticsService
{
    /// <summary>
    /// Возвращает информацию о всех артистах в виде списка строк.
    /// </summary>
    public IList<string> GetAllArtisInfo();
    /// <summary>
    /// Метод для вывода артистов с максимальныи количествм альбомов
    /// </summary>
    /// <returns>Список артистов и альбомов</returns>
    public IList<string> GetArtistsWithMaxAlbums();
}