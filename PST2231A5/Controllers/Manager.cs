using AutoMapper;
using PST2231A5.Data;
using PST2231A5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;

// ************************************************************************************
// WEB524 Project Template V2 == 2231-ea886f86-10f4-44f8-bd37-825baccc7f02
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************
// Name: Parita Sunilbhai Thakkar
// Student ID: 160107199
// Email: psthakkar1@myseneca.ca
// WEB 524 NSA - Assignment 6
// ************************************************************************************

namespace PST2231A5.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper instance
        public IMapper mapper;

        // Request user property...

        // Backing field for the property
        private RequestUser _user;

        // Getter only, no setter
        public RequestUser User
        {
            get
            {
                // On first use, it will be null, so set its value
                if (_user == null)
                {
                    _user = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);
                }
                return _user;
            }
        }

        // Default constructor...
        public Manager()
        {
            // If necessary, add constructor code here

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();

                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                cfg.CreateMap<Actor, ActorBaseViewModel>();
                cfg.CreateMap<Episode, EpisodeBaseViewModel>();
                cfg.CreateMap<ShowAddViewModel, Show>();
                cfg.CreateMap<Show, ShowBaseViewModel>();
                cfg.CreateMap<Genre, GenreBaseViewModel>();
                cfg.CreateMap<Actor, ActorWithDetailViewModel>();
                cfg.CreateMap<ActorAddViewModel, Actor>();
                cfg.CreateMap<Episode, EpisodeWithDetailViewModel>();
                cfg.CreateMap<EpisodeAddViewModel, Episode>();
                cfg.CreateMap<Show, ShowWithDetailViewModel>();
                cfg.CreateMap<Episode, EpisodeVideoViewModel>();
                cfg.CreateMap<ActorMediaItem, ActorMediaItemContentViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().




        // *** Add your methods above this line **


        #region Role Claims

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        #endregion

        #region Load Data Methods

        // Add some programmatically-generated objects to the data store
        // You can write one method or many methods but remember to
        // check for existing data first.  You will call this/these method(s)
        // from a controller action.

        public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // *** Role claims ***
            if (ds.RoleClaims.Count() == 0)
            {
                // Add role claims here
                ds.RoleClaims.Add(new RoleClaim() { Name = "Admin" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Executive" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Coordinator" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Clerk" });

                ds.SaveChanges();
                done = true;
            }

            return done;
        }

        public bool LoadGenres()
        {
            bool done = false;

            if (ds.Genres.Count() == 0)
            {

                ds.Genres.Add(new Genre() { Name = "Comedy" });
                ds.Genres.Add(new Genre() { Name = "Action" });
                ds.Genres.Add(new Genre() { Name = "Drama" });
                ds.Genres.Add(new Genre() { Name = "Adventure" });
                ds.Genres.Add(new Genre() { Name = "Mystery" });
                ds.Genres.Add(new Genre() { Name = "Fantasy" });
                ds.Genres.Add(new Genre() { Name = "Horror" });
                ds.Genres.Add(new Genre() { Name = "Fiction" });
                ds.Genres.Add(new Genre() { Name = "Thriller" });
                ds.Genres.Add(new Genre() { Name = "Anime" });

                ds.SaveChanges();
                done = true;
            }
            return done;
        }

        public bool LoadActors()
        {
            var user = HttpContext.Current.User.Identity.Name;
            bool done = false;

            if (ds.Actors.Count() == 0)
            {

                ds.Actors.Add(new Actor()
                {
                    Name = "Jennifer Aniston",
                    AlternateName = "Jennifer",
                    BirthDate = DateTime.Parse("1996-11-02"),
                    Executive = user,
                    Height = 1.64,
                    ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTnxeWsXoqOE1ok7ITDTu7_ppOOXdQNZkuEYLKpI8harloPMZiG"
                });
                ds.Actors.Add(new Actor()
                {
                    Name = "Jenna Ortega",
                    AlternateName = "Jenna",
                    BirthDate = DateTime.Parse("2002-09-27"),
                    Executive = user,
                    Height = 1.55,
                    ImageUrl = "https://assets.popbuzz.com/2019/51/how-old-is-jenna-ortega--1577119548-view-1.jpg"
                });
                ds.Actors.Add(new Actor()
                {
                    Name = "Patrick Dempsey",
                    AlternateName = "Patrick",
                    BirthDate = DateTime.Parse("1966-01-13"),
                    Executive = user,
                    Height = 1.76,
                    ImageUrl = "https://tvline.com/wp-content/uploads/2016/09/patrick-dempsey.jpg?w=619&h=421&crop=1"
                });

                ds.SaveChanges();
                done = true;
            }
            return done;
        }

        public bool LoadShows()
        {
            var user = HttpContext.Current.User.Identity.Name;
            bool done = false;
            var jenAniston = ds.Actors.SingleOrDefault(a => a.Name == "Jennifer Aniston");

            if (ds.Shows.Count() == 0)
            {

                ds.Shows.Add(new Show()
                {
                    Actors = new Actor[] { jenAniston },
                    Name = "Friends",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("1994-09-22"),
                    ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQMpWgFcYiV0MThcMMAVihr_5Zx2twoZ2Q_kVZOsVZ9nH1hmJZj",
                    Coordinator = user
                });

                ds.Shows.Add(new Show()
                {
                    Actors = new Actor[] { jenAniston },
                    Name = "The Morning Show",
                    Genre = "Drama",
                    ReleaseDate = DateTime.Parse("2019-11-01"),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmQySNEbn4--YYWFqtFEmAnHRrYsNDuMiz61-MpMO-sxN2uDXm",
                    Coordinator = user

                });

                ds.SaveChanges();
                done = true;
            }
            return done;
        }

        public bool LoadEpisodes()
        {
            var user = HttpContext.Current.User.Identity.Name;
            bool done = false;
            var friendsShow = ds.Shows.SingleOrDefault(a => a.Name == "Friends");
            var theMorningShow = ds.Shows.SingleOrDefault(a => a.Name == "The Morning Show");

            if (ds.Episodes.Count() == 0)
            {

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { friendsShow },
                    Name = "The One with the Monkey",
                    SeasonNumber = 1,
                    EpisodeNumber = 10,
                    Genre = "Comedy",
                    AirDate = DateTime.Parse("1994-12-15"),
                    ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTsvNDbqbvgRkIK8jGurSLSpiziMKV7sNsnfrZj79PUz4urt_08",
                    Clerk = user
                });

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { friendsShow },
                    Name = "The One with Unagi",
                    SeasonNumber = 6,
                    EpisodeNumber = 17,
                    Genre = "Comedy",
                    AirDate = DateTime.Parse("2000-02-24"),
                    ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS9EA9T15uKywwX-8-qwRu-KZ6zVXR9odnxiKLZ2Yn2mPTjo3U6",
                    Clerk = user
                });

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { friendsShow },
                    Name = "The One where Monica sings",
                    SeasonNumber = 9,
                    EpisodeNumber = 13,
                    Genre = "Comedy",
                    AirDate = DateTime.Parse("2003-01-30"),
                    ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRR0mVGZpTekLRp_QiOI_mPqihE26LUVL5Ys9_JoSAAeHefkEHt",
                    Clerk = user
                });

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { theMorningShow },
                    Name = "Ghosts",
                    SeasonNumber = 2,
                    EpisodeNumber = 5,
                    Genre = "Drama",
                    AirDate = DateTime.Parse("2021-10-15"),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSz_H1DHUYBApgaTmxm0qt6VWOmP8Z0jo6FzqfERWs1PeVXo-gi",
                    Clerk = user
                });

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { theMorningShow },
                    Name = "That Woman",
                    SeasonNumber = 1,
                    EpisodeNumber = 4,
                    Genre = "Drama",
                    AirDate = DateTime.Parse("2021-11-08"),
                    ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcT1ztrHZ-0y5rlBbgp2ebWdsdPWvJOJ-tDmjtPptLdc0F5ljrRN",
                    Clerk = user
                });

                ds.Episodes.Add(new Episode()
                {
                    Shows = new Show[] { theMorningShow },
                    Name = "Fever",
                    SeasonNumber = 2,
                    EpisodeNumber = 10,
                    Genre = "Drama",
                    AirDate = DateTime.Parse("2021-11-19"),
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUo2vcGAl3qxJBPlKfuRUuvOMxv23gahc3BvCFsGZ4J9Ih4ypP",
                    Clerk = user
                });

                ds.SaveChanges();
                done = true;
            }
            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.RoleClaims)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ActorBaseViewModel> ActorGetAll()
        {
            var allActors = ds.Actors;
            return mapper.Map<IEnumerable<Actor>, IEnumerable<ActorBaseViewModel>>(allActors);
        }

        public IEnumerable<EpisodeBaseViewModel> EpisodeGetAll()
        {
            var allEpisodes = ds.Episodes.Include("Shows");
            return mapper.Map<IEnumerable<Episode>, IEnumerable<EpisodeBaseViewModel>>(allEpisodes);

        }

        public IEnumerable<ShowBaseViewModel> ShowGetAll()
        {
            var allShows = ds.Shows;
            return mapper.Map<IEnumerable<Show>, IEnumerable<ShowBaseViewModel>>(allShows);

        }

        public IEnumerable<GenreBaseViewModel> GenreGetAll()
        {
            var allGenres = ds.Genres;
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBaseViewModel>>(allGenres);

        }

        public ActorWithDetailViewModel ActorGetByID(int? id)
        {
            var actor = ds.Actors.Include("Shows")
                                 .SingleOrDefault(a => a.ActorId == id);

            return actor == null ? null : mapper.Map<Actor, ActorWithDetailViewModel>(actor);

        }

        public EpisodeWithDetailViewModel EpisodeGetByID(int? id)
        {
            var episode = ds.Episodes.Include("Shows")
                                     .SingleOrDefault(e => e.EpisodeId == id);

            return episode == null ? null : mapper.Map<Episode, EpisodeWithDetailViewModel>(episode);

        }

        public ShowWithDetailViewModel ShowGetByID(int? id)
        {
            var show = ds.Shows.Include("Actors")
                               .Include("Episodes")
                               .SingleOrDefault(s => s.ShowId == id);

            return show == null ? null : mapper.Map<Show, ShowWithDetailViewModel>(show);

        }

        public ActorWithDetailViewModel ActorAdd(ActorAddViewModel addActor)
        {
            addActor.Executive = HttpContext.Current.User.Identity.Name;
            var actor = ds.Actors.Add(mapper.Map<ActorAddViewModel, Actor>(addActor));
            ds.SaveChanges();

            return actor == null ? null : mapper.Map<Actor, ActorWithDetailViewModel>(actor);
        }

        public ShowWithDetailViewModel ShowAdd(ShowAddViewModel addShow)
        {
            var user = HttpContext.Current.User.Identity.Name;

            var genre = ds.Genres.SingleOrDefault(g => g.GenreId == addShow.GenreId);
            var show = ds.Shows.Add(mapper.Map<ShowAddViewModel, Show>(addShow));

            if (show == null)
            {
                return null;
            }
            else
            {
                show.Coordinator = user;
                show.Genre = genre.Name;
                foreach (var id in addShow.ActorId)
                {
                    var actor = ds.Actors.Find(id);
                    show.Actors.Add(actor);
                }

                if (addShow.EpisodeId != null)
                {
                    foreach (var id in addShow.EpisodeId)
                    {
                        var episode = ds.Episodes.Find(id);
                        show.Episodes.Add(episode);
                    }
                }

                ds.SaveChanges();

                return mapper.Map<Show, ShowWithDetailViewModel>(show);
            }

        }

        public EpisodeWithDetailViewModel EpisodeAdd(EpisodeAddViewModel addEpisode)
        {
            var user = HttpContext.Current.User.Identity.Name;
            var show = ds.Shows.SingleOrDefault(s => s.ShowId == addEpisode.ShowShowId);
            var genre = ds.Genres.SingleOrDefault(g => g.GenreId == addEpisode.GenreId);
            var episode = ds.Episodes.Add(mapper.Map<EpisodeAddViewModel, Episode>(addEpisode));

            if (show == null)
            {
                return null;
            }
            else
            {
                episode.Clerk = user;
                episode.Genre = genre.Name;
                episode.ShowName = show.Name;
                episode.Shows.Add(show);

                byte[] videoBytes = new byte[addEpisode.VideoUpload.ContentLength];
                addEpisode.VideoUpload.InputStream.Read(videoBytes, 0, addEpisode.VideoUpload.ContentLength);
                episode.Video = videoBytes;
                episode.VideoContentType = addEpisode.VideoUpload.ContentType;
            }

            ds.SaveChanges();

            return mapper.Map<Episode, EpisodeWithDetailViewModel>(episode);
        }

        public EpisodeVideoViewModel EpisodeVideoGetById(int id)
        {
            var v = ds.Episodes.Find(id);

            return (v == null) ? null : mapper.Map<Episode, EpisodeVideoViewModel>(v);
        }

        public ActorMediaItemContentViewModel ActorMediaItemContentGetById(int id)
        {
            var c = ds.ActorMediaItems.Find(id);

            return (c == null) ? null : mapper.Map<ActorMediaItem, ActorMediaItemContentViewModel>(c);
        }

        public ActorWithDetailViewModel ActorMediaItemAdd(ActorMediaItemAddViewModel addMediaItem)
        {
            var actor = ds.Actors.Find(addMediaItem.ActorId);

            if (actor == null)
            {
                return null;
            }
            else
            {
                var item = new ActorMediaItem();
                ds.ActorMediaItems.Add(item);

                item.Caption = addMediaItem.Caption;
                item.Actor = actor;

                byte[] contentBytes = new byte[addMediaItem.ContentUpload.ContentLength];
                addMediaItem.ContentUpload.InputStream.Read(contentBytes, 0, addMediaItem.ContentUpload.ContentLength);

                item.Content = contentBytes;
                item.ContentType = addMediaItem.ContentUpload.ContentType;

                ds.SaveChanges();

                return null;
            }
        }

        #endregion

        #region RequestUser Class

        // This "RequestUser" class includes many convenient members that make it
        // easier work with the authenticated user and render user account info.
        // Study the properties and methods, and think about how you could use this class.

        // How to use...
        // In the Manager class, declare a new property named User:
        //    public RequestUser User { get; private set; }

        // Then in the constructor of the Manager class, initialize its value:
        //    User = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);

        public class RequestUser
        {
            // Constructor, pass in the security principal
            public RequestUser(ClaimsPrincipal user)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    Principal = user;

                    // Extract the role claims
                    RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                    // User name
                    Name = user.Identity.Name;

                    // Extract the given name(s); if null or empty, then set an initial value
                    string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                    if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                    GivenName = gn;

                    // Extract the surname; if null or empty, then set an initial value
                    string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                    if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                    Surname = sn;

                    IsAuthenticated = true;
                    // You can change the string value in your app to match your app domain logic
                    IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
                }
                else
                {
                    RoleClaims = new List<string>();
                    Name = "anonymous";
                    GivenName = "Unauthenticated";
                    Surname = "Anonymous";
                    IsAuthenticated = false;
                    IsAdmin = false;
                }

                // Compose the nicely-formatted full names
                NamesFirstLast = $"{GivenName} {Surname}";
                NamesLastFirst = $"{Surname}, {GivenName}";
            }

            // Public properties
            public ClaimsPrincipal Principal { get; private set; }

            public IEnumerable<string> RoleClaims { get; private set; }

            public string Name { get; set; }

            public string GivenName { get; private set; }

            public string Surname { get; private set; }

            public string NamesFirstLast { get; private set; }

            public string NamesLastFirst { get; private set; }

            public bool IsAuthenticated { get; private set; }

            public bool IsAdmin { get; private set; }

            public bool HasRoleClaim(string value)
            {
                if (!IsAuthenticated) { return false; }
                return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
            }

            public bool HasClaim(string type, string value)
            {
                if (!IsAuthenticated) { return false; }
                return Principal.HasClaim(type, value) ? true : false;
            }
        }

        #endregion
    }
}