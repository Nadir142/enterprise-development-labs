using Mediateka.Domain.Model;


namespace Mediateka.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными.
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Список жанров
    /// </summary>
    public static readonly List<Genre> Genres =
    [
        new()
        {
            Id = 1,
            Name="Rock"
        },
        new()
        {
            Id = 2,
            Name="Pop"
        },
        new()
        {
            Id = 3,
            Name="Hip-Hop/Rap"
        },
        new()
        {
            Id = 4,
            Name="Jazz"
        },
        new()
        {
            Id = 5,
            Name="K-Pop"
        },

     ];

    /// <summary>
    /// Список артистов
    /// </summary>
    public static readonly List<Artist> Artists =
    [
        new()
        {
            Id = 1,
            Name="The Beatles",
            Biography = "Легендарная британская рок-группа, оказавшая огромное влияние на развитие музыки в XX веке.",
            GenreID = 2
        },
        new()
        {
            Id = 2,
            Name="Michael Jackson",
            Biography = "\"Король поп-музыки\", известен своими хитами, танцевальными движениями и инновациями в музыке.",
            GenreID = 1
        },
        new()
        {
            Id = 3,
            Name="Louis Armstrong",
            Biography = "Иконический джазовый трубач и вокалист, один из самых влиятельных музыкантов в истории джаза.\r\n",
            GenreID = 4
        },
        new()
        {
            Id = 4,
            Name="Eminem",
            Biography = "Один из самых успешных рэперов в мире, известный своей лирической сложностью и быстрым флоу",
            GenreID = 3
        },
        new()
        {
            Id = 5,
            Name="BTS",
            Biography = "Южнокорейская музыкальная группа, ставшая одной из самых влиятельных и популярных в мире.",
            GenreID = 5
        },
     ];

    /// <summary>
    /// Список артистов
    /// </summary>
    public static readonly List<Album> Albums =
    [
       new()
        {
            Id = 1,
            Name="BE ",
            Year = 2020,
        },
        new()
        {
            Id = 2,
            Name="Let It Be",
            Year = 1970,
        },
        new()
        {
            Id = 3,
            Name="Dangerous ",
            Year = 1991,
        },
        new()
        {
            Id = 4,
            Name="What a Wonderful World",
            Year = 1967,
        },
        new()
        {
            Id = 5,
            Name="Recovery",
            Year = 2010,

        },
        new()
        {
            Id = 6,
            Name="Map of the Soul: 7",
            Year = 2020,

        },
     ];

    /// <summary>
    /// Список треков
    /// </summary>
    public static readonly List<Track> Tracks =
    [
      new()
        {
            Id = 1,
            Name="Life Goes On",
            NumberInAlbum = 1,
            AlbumId = 1,
            Duration = 208,
        },
        new()
        {
            Id = 2,
            Name="Skit",
            NumberInAlbum = 2,
            AlbumId = 1,
            Duration = 94,
        },
        new()
        {
            Id = 3,
            Name="Telepathy",
            NumberInAlbum = 3,
            AlbumId = 1,
            Duration = 195,
        },
        new()
        {
            Id = 4,
            Name="Dynamite",
            NumberInAlbum = 4,
            AlbumId = 1,
            Duration = 199,
        },
        new()
        {
            Id = 5,
            Name="Two of Us",
            NumberInAlbum = 1,
            AlbumId = 2,
            Duration = 217,
        },
        new()
        {
            Id = 6,
            Name="Let It Be",
            NumberInAlbum = 6,
            AlbumId = 2,
            Duration = 243,
        },
        new()
        {
            Id = 7,
            Name="Jam",
            NumberInAlbum = 1,
            AlbumId = 3,
            Duration = 338,
        },
        new()
        {
            Id = 8,
            Name="Why You Wanna Trip on Me",
            NumberInAlbum = 2,
            AlbumId = 3,
            Duration = 327,
        },
        new()
        {
            Id = 9,
            Name="Dangerous",
            NumberInAlbum = 14,
            AlbumId = 3,
            Duration = 420,
        },
        new()
        {
            Id = 10,
            Name="What a Wonderful World",
            NumberInAlbum = 1,
            AlbumId = 4,
            Duration = 141,
        },
        new()
        {
            Id = 11,
            Name="Cabaret",
            NumberInAlbum = 2,
            AlbumId = 4,
            Duration = 185,
        },
        new()
        {
            Id = 12,
            Name="Not Afraid",
            NumberInAlbum = 1,
            AlbumId = 5,
            Duration = 248,
        },
        new()
        {
            Id = 3,
            Name="Black Swan",
            NumberInAlbum = 7,
            AlbumId = 6,
            Duration = 213,
        },
        ];

    static DataSeeder()
    {
        foreach (var t in Tracks)
        {
            t.Albums = Albums.FirstOrDefault(al => al.Id == t.AlbumId);
        }

        foreach (var al in Albums)
        {

            if (al.Tracks == null)
                al.Tracks = new List<Track>();


            al.Tracks.AddRange(Tracks.Where(t => t.AlbumId == al.Id));
        }
    }

}

