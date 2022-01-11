﻿// <auto-generated />
using ARM.Movies.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARM.Movies.DataAccess.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220111014043_movies_db_script")]
    partial class movies_db_script
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ARM.Movies.Common.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RunningTime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Comedy",
                            RunningTime = 157,
                            Title = "Movie1",
                            YearOfRelease = 2000
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Drama",
                            RunningTime = 94,
                            Title = "Movie2",
                            YearOfRelease = 2008
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Comedy",
                            RunningTime = 104,
                            Title = "Movie3",
                            YearOfRelease = 2005
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Drama",
                            RunningTime = 65,
                            Title = "Movie4",
                            YearOfRelease = 2013
                        },
                        new
                        {
                            Id = 5,
                            Genre = "Comedy",
                            RunningTime = 147,
                            Title = "Movie5",
                            YearOfRelease = 2019
                        },
                        new
                        {
                            Id = 6,
                            Genre = "Drama",
                            RunningTime = 158,
                            Title = "Movie6",
                            YearOfRelease = 2003
                        },
                        new
                        {
                            Id = 7,
                            Genre = "Comedy",
                            RunningTime = 172,
                            Title = "Movie7",
                            YearOfRelease = 2014
                        },
                        new
                        {
                            Id = 8,
                            Genre = "Drama",
                            RunningTime = 130,
                            Title = "Movie8",
                            YearOfRelease = 2006
                        },
                        new
                        {
                            Id = 9,
                            Genre = "Comedy",
                            RunningTime = 154,
                            Title = "Movie9",
                            YearOfRelease = 2009
                        },
                        new
                        {
                            Id = 10,
                            Genre = "Drama",
                            RunningTime = 157,
                            Title = "Movie10",
                            YearOfRelease = 2020
                        });
                });

            modelBuilder.Entity("ARM.Movies.Common.Models.MovieUserRating", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieUserRatings");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            UserId = 1,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 3,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 4,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 5,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 6,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 7,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 8,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 9,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 1,
                            UserId = 10,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 1,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 2,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 3,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 4,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 5,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 6,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 7,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 8,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 9,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 10,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 1,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 3,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 4,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 5,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 6,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 7,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 8,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 9,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 10,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 1,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 3,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 4,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 5,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 6,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 7,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 8,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 9,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 4,
                            UserId = 10,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 1,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 3,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 4,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 5,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 6,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 7,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 8,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 9,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 5,
                            UserId = 10,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 1,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 2,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 3,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 4,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 5,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 6,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 7,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 8,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 9,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 6,
                            UserId = 10,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 1,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 3,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 4,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 5,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 6,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 7,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 8,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 9,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 7,
                            UserId = 10,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 1,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 2,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 3,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 4,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 5,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 6,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 7,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 8,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 9,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 8,
                            UserId = 10,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 1,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 2,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 3,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 4,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 5,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 6,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 7,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 8,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 9,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 9,
                            UserId = 10,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 1,
                            Rating = 3.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 2,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 3,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 4,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 5,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 6,
                            Rating = 4.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 7,
                            Rating = 2.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 8,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 9,
                            Rating = 1.0
                        },
                        new
                        {
                            MovieId = 10,
                            UserId = 10,
                            Rating = 3.0
                        });
                });

            modelBuilder.Entity("ARM.Movies.Common.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "user4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "user5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "user6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "user7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "user8"
                        },
                        new
                        {
                            Id = 9,
                            Name = "user9"
                        },
                        new
                        {
                            Id = 10,
                            Name = "user10"
                        });
                });

            modelBuilder.Entity("ARM.Movies.Common.Models.MovieUserRating", b =>
                {
                    b.HasOne("ARM.Movies.Common.Models.Movie", "Movie")
                        .WithMany("MovieUserRatings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARM.Movies.Common.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARM.Movies.Common.Models.Movie", b =>
                {
                    b.Navigation("MovieUserRatings");
                });

            modelBuilder.Entity("ARM.Movies.Common.Models.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}