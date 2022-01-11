using ARM.Movies.Api.Controllers;
using ARM.Movies.Common.Interfaces;
using ARM.Movies.Common.Models;
using ARM.Movies.DataAccess.Repositories;
using ARM.Movies.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ARM.Movies.Tests
{
    /// <summary>
    /// Sets up a mock DB context and tests the repository and controller against it
    /// </summary>
    [TestFixture]
    public class MovieControllerUnitTests
    {
        //TODO: Cover test cases for all possible scenarios (with success/failure)
        
        private MoviesController _controller;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SetUpMockController();
        }

        [Test]
        [TestCase(4, "Movie")]
        [TestCase(2, "Movie", 2019)]
        [TestCase(1, "Movie", 2019, "Drama")]
        [TestCase(3, null, null, "Drama")]
        [TestCase(1, null, 2019, "Drama")]
        [TestCase(1, "Test", 2022, "Drama")]
        [TestCase(0, "Test", 2019, null)]
        [TestCase(1, "Test", null, "Drama")]
        public void Test_GetMovies_By_Search_Parameters(int expectedNumOfRecords, string title = null, int? yearOfRelease = null, string genre = null)
        {
            var result = _controller.Get(title, yearOfRelease, genre);

            if(result is OkObjectResult)
            {
                var okResult = result as OkObjectResult;
                Assert.AreEqual(okResult.StatusCode, 200);

                var resultMovies = (IEnumerable<MovieModel>)okResult.Value;
                Assert.AreEqual(resultMovies.Count(), expectedNumOfRecords);
            }

            if (result is NotFoundObjectResult)
            {
                var okResult = (result as NotFoundObjectResult);
                Assert.AreEqual(okResult.StatusCode, 404);
                Assert.AreEqual(0, expectedNumOfRecords);
            }
        }

        [Test]
        public void Test_GetTopMovies()
        {
            var result = _controller.GetTopMovies(2);
            
            var okResult = result as OkObjectResult;
            Assert.AreEqual(okResult.StatusCode, 200);

            var resultMovies = ((IEnumerable<MovieModel>)okResult.Value).ToArray();
            Assert.AreEqual(resultMovies[0].Id, 5);
            Assert.AreEqual(resultMovies[1].Id, 2);
            Assert.AreEqual(resultMovies[0].AverageRating, 4);
            Assert.AreEqual(resultMovies[1].AverageRating, 3);
        }

        [Test]
        public void Test_GetTopMovies_ByUser()
        {
            var result = _controller.GetTopMoviesByUser("user1", 3);
            
            var okResult = result as OkObjectResult;
            Assert.AreEqual(okResult.StatusCode, 200);

            var resultMovies = ((IEnumerable<MovieModel>)okResult.Value).ToArray();
            Assert.AreEqual(resultMovies[0].Id, 5);
            Assert.AreEqual(resultMovies[1].Id, 2);
            Assert.AreEqual(resultMovies[2].Id, 3);
            Assert.AreEqual(resultMovies[0].AverageRating, 4);
            Assert.AreEqual(resultMovies[1].AverageRating, 3);
            Assert.AreEqual(resultMovies[2].AverageRating, 2);           
        }

        [Test]
        public void Test_RateMovie()
        {
            var mockMovieUserRatingSet = new Mock<DbSet<MovieUserRating>>();
            var mockMovieContext = new Mock<IMovieContext>();
            mockMovieContext.Setup(c => c.MovieUserRatings).Returns(mockMovieUserRatingSet.Object);            

            mockMovieContext.Setup(c => c.Movies.Find(It.IsAny<int>())).Returns(new Movie { Id = 1 });
            mockMovieContext.Setup(c => c.Users.Find(It.IsAny<int>())).Returns(new User { Id = 1 });
            mockMovieContext.Setup(c => c.MovieUserRatings.Find(It.IsAny<int>(), It.IsAny<int>())).Returns<MovieUserRating>(null);

            var movieRepository = new MovieRepository(mockMovieContext.Object);
            var mockLogging = new Mock<ILoggerManager>();
            _controller = new MoviesController(movieRepository, mockLogging.Object);

            var result = _controller.RateMovie(
                new MovieUserRatingModel
                {
                    UserId = 1,
                    MovieId = 1,
                    Rating = 1
                }
            );
            
            var okResult = result as OkObjectResult;
            Assert.AreEqual(okResult.StatusCode, 200);            

            mockMovieUserRatingSet.Verify(m => m.Add(It.IsAny<MovieUserRating>()), Times.Once());
            mockMovieContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        private void SetUpMockController()
        {
            var movies = GetMovies();
            var users = GetUsers();
            var movieUserRatings = GetMovieUserRatings();

            //In order to be able to execute queries against mock DbSet, we need to setup an implementation
            //of IQueryable interface
            var mockMovieSet = new Mock<DbSet<Movie>>();
            mockMovieSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.Provider);
            mockMovieSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.Expression);
            mockMovieSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.ElementType);
            mockMovieSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockUserSet = new Mock<DbSet<User>>();
            mockUserSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockUserSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockUserSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockUserSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var mockMovieUserRatingSet = new Mock<DbSet<MovieUserRating>>();
            mockMovieUserRatingSet.As<IQueryable<MovieUserRating>>().Setup(m => m.Provider).Returns(movieUserRatings.Provider);
            mockMovieUserRatingSet.As<IQueryable<MovieUserRating>>().Setup(m => m.Expression).Returns(movieUserRatings.Expression);
            mockMovieUserRatingSet.As<IQueryable<MovieUserRating>>().Setup(m => m.ElementType).Returns(movieUserRatings.ElementType);
            mockMovieUserRatingSet.As<IQueryable<MovieUserRating>>().Setup(m => m.GetEnumerator()).Returns(movieUserRatings.GetEnumerator());

            //set up mock movie context 
            var mockMovieContext = new Mock<IMovieContext>();
            mockMovieContext.Setup(c => c.Movies).Returns(mockMovieSet.Object);
            mockMovieContext.Setup(c => c.Users).Returns(mockUserSet.Object);
            mockMovieContext.Setup(c => c.MovieUserRatings).Returns(mockMovieUserRatingSet.Object);

            mockMovieContext.Setup(c => c.Set<Movie>()).Returns(mockMovieSet.Object);
            mockMovieContext.Setup(c => c.Set<User>()).Returns(mockUserSet.Object);
            mockMovieContext.Setup(c => c.Set<MovieUserRating>()).Returns(mockMovieUserRatingSet.Object);

            // Set up repository with mock context
            var movieRepository = new MovieRepository(mockMovieContext.Object);

            var mockLogging = new Mock<ILoggerManager>();
            _controller = new MoviesController(movieRepository, mockLogging.Object);
        }

        private IQueryable<User> GetUsers()
        {
            return new List<User>{
                new User
                {
                    Id = 1,
                    Name = "user1",
                },
                new User
                {
                    Id = 2,
                    Name = "user2",
                },
                new User
                {
                    Id = 3,
                    Name = "user3"
                }
            }.AsQueryable();
        }

        private IQueryable<Movie> GetMovies()
        {
            return new List<Movie>{
                new Movie
                {
                    Id = 1,
                    Title = "Movie1",
                    YearOfRelease = 2019,
                    Genre = "Drama",
                    RunningTime = 75
                },
                new Movie
                {
                    Id = 2,
                    Title = "Movie2",
                    YearOfRelease = 2019,
                    Genre = "Comedy",
                    RunningTime = 75
                },
                new Movie
                {
                    Id = 3,
                    Title = "Movie3",
                    YearOfRelease = 2020,
                    Genre = "Drama",
                    RunningTime = 80
                },
                new Movie
                {
                    Id = 4,
                    Title = "Movie4",
                    YearOfRelease = 2021,
                    Genre = "Action",
                    RunningTime = 75
                },
                new Movie
                {
                    Id = 5,
                    Title = "Test",
                    YearOfRelease = 2022,
                    Genre = "Drama",
                    RunningTime = 80
                },
            }.AsQueryable();
        }

        private IQueryable<MovieUserRating> GetMovieUserRatings()
        {
            return new List<MovieUserRating>{
                new MovieUserRating
                {
                    MovieId = 1,
                    UserId = 1,
                    Rating = 1,
                },
                new MovieUserRating
                {
                    MovieId = 1,
                    UserId = 2,
                    Rating = 1,
                },
                new MovieUserRating
                {
                    MovieId = 1,
                    UserId = 3,
                    Rating = 1,
                },
                new MovieUserRating
                {
                    MovieId = 2,
                    UserId = 1,
                    Rating = 3,
                },
                new MovieUserRating
                {
                    MovieId = 2,
                    UserId = 2,
                    Rating = 3,
                },
                new MovieUserRating
                {
                    MovieId = 2,
                    UserId = 3,
                    Rating = 3,
                },
                new MovieUserRating
                {
                    MovieId = 3,
                    UserId = 1,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 3,
                    UserId = 2,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 3,
                    UserId = 3,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 4,
                    UserId = 1,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 4,
                    UserId = 2,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 4,
                    UserId = 3,
                    Rating = 2,
                },
                new MovieUserRating
                {
                    MovieId = 5,
                    UserId = 1,
                    Rating = 4,
                },
                new MovieUserRating
                {
                    MovieId = 5,
                    UserId = 2,
                    Rating = 4,
                },
                new MovieUserRating
                {
                    MovieId = 5,
                    UserId = 3,
                    Rating = 4,
                }

            }.AsQueryable();
        } 
    }
}