using AutoMapper;
using Mediateka.Application.Contracts;
using Mediateka.Application.Contracts.Artist;
using Mediateka.Domain.Model;
using Mediateka.Domain.Services;


namespace Mediateka.Application.Service;
/// <summary>
/// Служба слоя приложения для манипуляции над авторами
/// </summary>
/// <param name="repository">Доменная служба для авторов</param>
/// <param name="mapper">Автомаппер</param>
public class ArtistCrudService(IArtistRepository repository, IMapper mapper) : ICrudService<ArtistDto, ArtistCreateUpdateDto, int>, IArtistAnalyticsService
{
    public bool Create(ArtistCreateUpdateDto newDto)
    {
        var newArtist = mapper.Map<Artist>(newDto);
        newArtist.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newArtist);
        return result;
    }

    public bool Delete(int id) =>
        repository.Delete(id);

    public ArtistDto? GetById(int id)
    {
        var artist = repository.Get(id);
        return mapper.Map<ArtistDto>(artist);
    }

    public IList<ArtistDto> GetList() =>
        mapper.Map<List<ArtistDto>>(repository.GetAll());

    public bool Update(int key, ArtistCreateUpdateDto newDto)
    {
        var oldArtist = repository.Get(key);
        var newArtist = mapper.Map<Artist>(newDto);
        newArtist.Id = key;
        newArtist.Albums = oldArtist?.Albums;
        var result = repository.Update(newArtist);
        return result;
    }

    /// <summary>
    /// Возвращает информацию о всех артистах в виде списка строк.
    /// </summary>
    public IList<string> GetAllArtisInfo() =>
         repository.GetAllArtisInfo();

    /// <summary>
    /// Метод для вывода артистов с максимальныи количествм альбомов
    /// </summary>
    /// <returns>Список артистов и альбомов</returns>
    public IList<string> GetArtistsWithMaxAlbums() =>
         repository.GetArtistsWithMaxAlbums();
}
