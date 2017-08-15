using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bpt.api.Models;

namespace bptapi.Migrations
{
    [DbContext(typeof(BptContext))]
    [Migration("20170815142834_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("bpt.api.Models.Bullet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BulletPageId");

                    b.Property<int>("Downvotes");

                    b.Property<string>("Status");

                    b.Property<string>("Text");

                    b.Property<int>("Upvotes");

                    b.HasKey("Id");

                    b.HasIndex("BulletPageId");

                    b.ToTable("Bullets");
                });

            modelBuilder.Entity("bpt.api.Models.BulletPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BulletPages");
                });

            modelBuilder.Entity("bpt.api.Models.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("bpt.api.Models.MultipleChoiceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAnswer");

                    b.Property<int?>("MultipleChoiceQuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.ToTable("MultipleChoiceOption");
                });

            modelBuilder.Entity("bpt.api.Models.MultipleChoiceQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Explanation");

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.ToTable("MultipleChoiceQuestions");
                });

            modelBuilder.Entity("bpt.api.Models.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<int?>("MultipleChoiceQuestionId");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("bpt.api.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("bpt.api.Models.Bullet", b =>
                {
                    b.HasOne("bpt.api.Models.BulletPage", "BulletPage")
                        .WithMany("Bullets")
                        .HasForeignKey("BulletPageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bpt.api.Models.MultipleChoiceOption", b =>
                {
                    b.HasOne("bpt.api.Models.MultipleChoiceQuestion")
                        .WithMany("Options")
                        .HasForeignKey("MultipleChoiceQuestionId");
                });

            modelBuilder.Entity("bpt.api.Models.Reference", b =>
                {
                    b.HasOne("bpt.api.Models.MultipleChoiceQuestion")
                        .WithMany("References")
                        .HasForeignKey("MultipleChoiceQuestionId");
                });
        }
    }
}
