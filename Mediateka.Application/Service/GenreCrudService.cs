using AutoMapper;
using Mediateka.Application.Contracts;
using Mediateka.Application.Contracts.Genre;
using Mediateka.Domain.Model;
using Mediateka.Domain.Services;

namespace Mediateka.Application.Service;
/// <summary>
/// Служба слоя приложения для манипуляции над книгами
/// </summary>
/// <param name="repository">Доменная служба для книг</param>
/// <param name="mapper">Автомаппер</param>
public class GenreCrudService(IRepository<Genre, int> repository, IMapper mapper) : ICrudService<GenreDto, GenreCreateUpdateDto, int>
{
    public bool Create(GenreCreateUpdateDto newDto)
    {
        var newGenre = mapper.Map<Genre>(newDto);
        newGenre.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newGenre);
        return result;
    }

    public bool Delete(int id) =>
        repository.Delete(id);

    public GenreDto? GetById(int id)
    {
        var genre = repository.Get(id);
        return mapper.Map<GenreDto>(genre);
    }

    public IList<GenreDto> GetList() =>
        mapper.Map<List<GenreDto>>(repository.GetAll());

    public bool Update(int key, GenreCreateUpdateDto newDto)
    {
        var oldGenre = repository.Get(key);
        var newGenre = mapper.Map<Genre>(newDto);
        newGenre.Id = key;
        var result = repository.Update(newGenre);
        return result;
    }
}