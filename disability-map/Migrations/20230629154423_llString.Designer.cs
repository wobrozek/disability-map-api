﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using disability_map.Data;

#nullable disable

namespace disability_map.Migrations
{
    [DbContext(typeof(DbMainContext))]
    [Migration("20230629154423_llString")]
    partial class llString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScoreUser", b =>
                {
                    b.Property<int>("DisLikesId")
                        .HasColumnType("int");

                    b.Property<string>("DisLikesPlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DisLikesId", "DisLikesPlaceId");

                    b.HasIndex("DisLikesPlaceId");

                    b.ToTable("ScoreUser");
                });

            modelBuilder.Entity("ScoreUser1", b =>
                {
                    b.Property<int>("LikesId")
                        .HasColumnType("int");

                    b.Property<string>("LikesPlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LikesId", "LikesPlaceId");

                    b.HasIndex("LikesPlaceId");

                    b.ToTable("ScoreUser1");
                });

            modelBuilder.Entity("disability_map.Models.Place", b =>
                {
                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("PlaceId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("disability_map.Models.Score", b =>
                {
                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlaceId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("disability_map.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ScoreUser", b =>
                {
                    b.HasOne("disability_map.Models.User", null)
                        .WithMany()
                        .HasForeignKey("DisLikesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("disability_map.Models.Score", null)
                        .WithMany()
                        .HasForeignKey("DisLikesPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScoreUser1", b =>
                {
                    b.HasOne("disability_map.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("disability_map.Models.Score", null)
                        .WithMany()
                        .HasForeignKey("LikesPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("disability_map.Models.Place", b =>
                {
                    b.HasOne("disability_map.Models.User", "Owner")
                        .WithMany("MyPlaces")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("disability_map.Models.User", b =>
                {
                    b.Navigation("MyPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
