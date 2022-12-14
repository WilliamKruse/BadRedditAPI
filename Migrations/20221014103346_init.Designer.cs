// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedditAPI.Model;

#nullable disable

namespace RedditAPI.Migrations
{
    [DbContext(typeof(RedditContext))]
    [Migration("20221014103346_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("CommentUser", b =>
                {
                    b.Property<long>("CommentVotesCommentId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserVotesUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentVotesCommentId", "UserVotesUserId");

                    b.HasIndex("UserVotesUserId");

                    b.ToTable("CommentUser");
                });

            modelBuilder.Entity("PostUser", b =>
                {
                    b.Property<long>("PostVotesPostId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserVotesUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostVotesPostId", "UserVotesUserId");

                    b.HasIndex("UserVotesUserId");

                    b.ToTable("PostUser");
                });

            modelBuilder.Entity("RedditAPI.Model.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Votes")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RedditAPI.Model.Post", b =>
                {
                    b.Property<long>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Votes")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("RedditAPI.Model.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CommentUser", b =>
                {
                    b.HasOne("RedditAPI.Model.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentVotesCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedditAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserVotesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostUser", b =>
                {
                    b.HasOne("RedditAPI.Model.Post", null)
                        .WithMany()
                        .HasForeignKey("PostVotesPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedditAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserVotesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
