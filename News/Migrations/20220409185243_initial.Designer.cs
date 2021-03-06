// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.Data;

namespace News.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20220409185243_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("News.Data.Models.Pictures", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PieceOfNewsID")
                        .HasColumnType("int");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PieceOfNewsID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("News.Data.Models.PieceOfNews", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PieceOfNews");
                });

            modelBuilder.Entity("News.Data.Models.Subtitles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PieceOfNewsID")
                        .HasColumnType("int");

                    b.Property<string>("subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PieceOfNewsID");

                    b.ToTable("Subtitles");
                });

            modelBuilder.Entity("News.Data.Models.Pictures", b =>
                {
                    b.HasOne("News.Data.Models.PieceOfNews", "PieceOfNews")
                        .WithMany("pictures")
                        .HasForeignKey("PieceOfNewsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PieceOfNews");
                });

            modelBuilder.Entity("News.Data.Models.Subtitles", b =>
                {
                    b.HasOne("News.Data.Models.PieceOfNews", "PieceOfNews")
                        .WithMany("subtitles")
                        .HasForeignKey("PieceOfNewsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PieceOfNews");
                });

            modelBuilder.Entity("News.Data.Models.PieceOfNews", b =>
                {
                    b.Navigation("pictures");

                    b.Navigation("subtitles");
                });
#pragma warning restore 612, 618
        }
    }
}
