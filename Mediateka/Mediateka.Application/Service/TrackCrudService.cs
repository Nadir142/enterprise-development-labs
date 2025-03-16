using AutoMapper;
using Mediateka.Application.Contracts;
using Mediateka.Application.Contracts.Track;
using Mediateka.Domain.Model;
using Mediateka.Domain.Services;
using System.Diagnostics;

namespace Mediateka.Application.Service;
/// <summary>
/// Служба слоя приложения для манипуляции над книгами
/// </summary>
/// <param name="repository">Доменная служба для книг</param>
/// <param name="mapper">Автомаппер</param>
/// <param name="albumRepository">Доменная служба для треков</param>
public class TrackCrudService(IRepository<Track, int> repository, IAlbumRepository albumRepository, IMapper mapper) : ICrudService<TrackDto, TrackCreateUpdateDto, int>
{
    public bool Create(TrackCreateUpdateDto newDto)
    {
        try
        {
            var newTrack = mapper.Map<Track>(newDto);
            newTrack.Id = repository.GetAll().Max(x => x.Id) + 1;

            var album = albumRepository.Get(newTrack.AlbumId);

            newTrack.Albums = album;

            album?.Tracks?.Add(newTrack);


            albumRepository.Update(album);


            return repository.Add(newTrack);
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var track = repository.Get(id);

            var album = albumRepository.Get(track.AlbumId);

            album?.Tracks?.Remove(track);

            albumRepository.Update(album);


            return repository.Delete(id);
        }
        catch
        {
            return false;
        }
    }

    public TrackDto? GetById(int id)
    {
        var track = repository.Get(id);
        return mapper.Map<TrackDto>(track);
    }

    public IList<TrackDto> GetList() =>
        mapper.Map<List<TrackDto>>(repository.GetAll());

    public bool Update(int key, TrackCreateUpdateDto newDto)
    {
        try
        {
            var oldTrack = repository.Get(key);
            var newTrack = mapper.Map<Track>(newDto);
            newTrack.Id = key;

            var oldAlbum = albumRepository.Get(oldTrack.AlbumId);
            oldAlbum?.Tracks?.Remove(oldTrack);
            albumRepository.Update(oldAlbum);

            var newAlbum = albumRepository.Get(newTrack.AlbumId);
            newAlbum?.Tracks?.Add(newTrack);
            albumRepository.Update(newAlbum);
            return repository.Update(newTrack);
        }
        catch
        {
            return false;
        }
    }
}