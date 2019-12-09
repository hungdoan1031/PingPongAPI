﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingPongAPI.Utils;

namespace PingPongAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("PingPongAPI.Entities.ShirtSize", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ShirtSizes");

                    b.HasData(
                        new
                        {
                            Id = "XS",
                            Name = "XS",
                            Order = 0
                        },
                        new
                        {
                            Id = "S",
                            Name = "S",
                            Order = 0
                        },
                        new
                        {
                            Id = "M",
                            Name = "M",
                            Order = 0
                        },
                        new
                        {
                            Id = "L",
                            Name = "L",
                            Order = 0
                        },
                        new
                        {
                            Id = "XL",
                            Name = "XL",
                            Order = 0
                        },
                        new
                        {
                            Id = "XXL",
                            Name = "XXL",
                            Order = 0
                        });
                });

            modelBuilder.Entity("PingPongAPI.Entities.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = "Red",
                            Color = "#ff0000",
                            Name = "Red"
                        },
                        new
                        {
                            Id = "Black",
                            Color = "#000000",
                            Name = "Black"
                        });
                });

            modelBuilder.Entity("PingPongAPI.Entities.TeamMember", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShirtSizeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShirtSizeId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("PingPongAPI.Entities.TeamMember", b =>
                {
                    b.HasOne("PingPongAPI.Entities.ShirtSize", "ShirtSize")
                        .WithMany("TeamMembers")
                        .HasForeignKey("ShirtSizeId");

                    b.HasOne("PingPongAPI.Entities.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
