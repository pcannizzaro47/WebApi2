// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20210328190913_Refactoring-FromItaToEng")]
    partial class RefactoringFromItaToEng
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Collector", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Nome");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Cognome");

                    b.HasKey("ID");

                    b.ToTable("Esattori");
                });

            modelBuilder.Entity("DAL.Models.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("CodiceCliente");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Pratiche");
                });

            modelBuilder.Entity("DAL.Models.FileCollector", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollectorId")
                        .HasColumnType("int")
                        .HasColumnName("EsattoreId");

                    b.Property<int>("FileId")
                        .HasColumnType("int")
                        .HasColumnName("PraticaId");

                    b.HasKey("ID");

                    b.HasIndex("FileId");

                    b.HasIndex("CollectorId", "FileId")
                        .IsUnique();

                    b.ToTable("PraticheEsattori");
                });

            modelBuilder.Entity("DAL.Models.FileCollector", b =>
                {
                    b.HasOne("DAL.Models.Collector", "Collector")
                        .WithMany("FileCollectors")
                        .HasForeignKey("CollectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.File", "File")
                        .WithMany("FilesCollectors")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collector");

                    b.Navigation("File");
                });

            modelBuilder.Entity("DAL.Models.Collector", b =>
                {
                    b.Navigation("FileCollectors");
                });

            modelBuilder.Entity("DAL.Models.File", b =>
                {
                    b.Navigation("FilesCollectors");
                });
#pragma warning restore 612, 618
        }
    }
}
