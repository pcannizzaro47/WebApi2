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
    [Migration("20210327183430_Adding-Models")]
    partial class AddingModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Esattore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Esattori");
                });

            modelBuilder.Entity("DAL.Models.Pratica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodiceCliente")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Pratiche");
                });

            modelBuilder.Entity("DAL.Models.PraticaEsattore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EsattoreId")
                        .HasColumnType("int");

                    b.Property<int>("PraticaId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EsattoreId");

                    b.HasIndex("PraticaId");

                    b.ToTable("PraticheEsattori");
                });

            modelBuilder.Entity("DAL.Models.PraticaEsattore", b =>
                {
                    b.HasOne("DAL.Models.Esattore", "Esattore")
                        .WithMany("Pratiche")
                        .HasForeignKey("EsattoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Pratica", "Pratica")
                        .WithMany("Esattori")
                        .HasForeignKey("PraticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Esattore");

                    b.Navigation("Pratica");
                });

            modelBuilder.Entity("DAL.Models.Esattore", b =>
                {
                    b.Navigation("Pratiche");
                });

            modelBuilder.Entity("DAL.Models.Pratica", b =>
                {
                    b.Navigation("Esattori");
                });
#pragma warning restore 612, 618
        }
    }
}
