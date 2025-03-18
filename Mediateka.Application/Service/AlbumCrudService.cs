using AutoMapper;
using Mediateka.Application.Contracts;
using Mediateka.Application.Contracts.Album;
using Mediateka.Domain.Model;
using Mediateka.Domain.Services;


namespace Mediateka.Application.Service;
/// <summary>
/// Служба слоя приложения для манипуляции над авторами
/// </summary>
/// <param name="repository">Доменная служба для авторов</param>
/// <param name="mapper">Автомаппер</param>
public class AlbumCrudService(IAlbumRepository repository, IMapper mapper) : ICrudService<AlbumDto, AlbumCreateUpdateDto, int>, IAlbumAnalyticsService
{
    public bool Create(AlbumCreateUpdateDto newDto)
    {
        var newAlbum = mapper.Map<Album>(newDto);
        newAlbum.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newAlbum);
        return result;
    }
    public bool Delete(int id) =>
        repository.Delete(id);

    public AlbumDto? GetById(int id)
    {
        var album = repository.Get(id);
        return mapper.Map<AlbumDto>(album);
    }

    public IList<AlbumDto> GetList() =>
        mapper.Map<List<AlbumDto>>(repository.GetAll());

    public bool Update(int key, AlbumCreateUpdateDto newDto)
    {
        var oldAlbum = repository.Get(key);
        var newAlbum = mapper.Map<Album>(newDto);

        newAlbum.Id = key;
        newAlbum.Tracks = oldAlbum?.Tracks;
        newAlbum.AlbumID = oldAlbum?.AlbumID;
        var result = repository.Update(newAlbum);
        return result;
    }
    public IList<string> GetTreksInAlbum() =>
        repository.GetTreksInAlbum();

    public IList<Tuple<string, int>> GetTop5AlbumsByDuration() =>
        repository.GetTop5AlbumsByDuration();

    public IEnumerable<(string AlbumName, int TrackCount)> GetAlbumsWithTrackCount() =>
        repository.GetAlbumsWithTrackCount();

    public Task<IList<(int MinDuration, double avgDuration, int maxDuration)>> GetAlbumDurationStatistics() =>
    repository.GetAlbumDurationStatistics();
}