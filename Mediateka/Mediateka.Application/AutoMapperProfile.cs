using AutoMapper;
using Mediateka.Application.Contracts.Album;
using Mediateka.Application.Contracts.Artist;
using Mediateka.Application.Contracts.Genre;
using Mediateka.Application.Contracts.Track;
using Mediateka.Domain.Model;

namespace Mediateka.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Album, AlbumDto>();
        CreateMap<AlbumCreateUpdateDto, Album>();

        CreateMap<Artist, ArtistDto>();
        CreateMap<ArtistCreateUpdateDto, Artist>();

        CreateMap<Genre, GenreDto>();
        CreateMap<GenreCreateUpdateDto, Genre>();

        CreateMap<Track, TrackDto>();
        CreateMap<TrackCreateUpdateDto, Track>();
    }
}