using System;
using System.Collections.Generic;
using Elysium.Domains;
using Microsoft.EntityFrameworkCore;

namespace Elysium.Contexts;

public partial class ElysiumContext : DbContext
{
    public ElysiumContext()
    {
    }

    public ElysiumContext(DbContextOptions<ElysiumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administrador { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<CategoriaEvento> CategoriaEvento { get; set; }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Inscricao> Inscricao { get; set; }

    public virtual DbSet<Log_AlteracaoEvento> Log_AlteracaoEvento { get; set; }

    public virtual DbSet<Palestrante> Palestrante { get; set; }

    public virtual DbSet<Participante> Participante { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Elysium;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.AdministradorId).HasName("PK__Administ__2C780D76C859385B");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Administrador)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administrador_Usuario");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E57CB3C570");

            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoriaEvento>(entity =>
        {
            entity.HasKey(e => e.CategoriaEventoId).HasName("PK__Categori__72209C84CF8F838D");

            entity.HasOne(d => d.Categoria).WithMany(p => p.CategoriaEvento)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CatEv_Categoria");

            entity.HasOne(d => d.Evento).WithMany(p => p.CategoriaEvento)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CatEv_Evento");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__1EEB59219682F5C9");

            entity.ToTable(tb => tb.HasTrigger("trg_AlteracaoEvento"));

            entity.Property(e => e.Data).HasPrecision(0);
            entity.Property(e => e.Local)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.StatusEvento).HasDefaultValue(true);

            entity.HasOne(d => d.CriadoPorUsuario).WithMany(p => p.Evento)
                .HasForeignKey(d => d.CriadoPorUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evento_Criador");

            entity.HasOne(d => d.Palestrante).WithMany(p => p.Evento)
                .HasForeignKey(d => d.PalestranteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evento_Palestrante");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.InscricaoId).HasName("PK__Inscrica__CD089DAE9D583D1E");

            entity.HasIndex(e => new { e.EventoId, e.ParticipanteId }, "UK_Inscricao").IsUnique();

            entity.HasOne(d => d.Evento).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscricao_Evento");

            entity.HasOne(d => d.Participante).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscricao_Participante");
        });

        modelBuilder.Entity<Log_AlteracaoEvento>(entity =>
        {
            entity.HasKey(e => e.Log_AlteracaoId).HasName("PK__Log_Alte__E2FC4AC301BE3E1B");

            entity.Property(e => e.DataAlteracao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DataAnterior).HasColumnType("datetime");
            entity.Property(e => e.LocalAnterior)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.NomeAnterior)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.HasOne(d => d.Log_AlteracaoEventoNavigation).WithMany(p => p.Log_AlteracaoEvento)
                .HasForeignKey(d => d.Log_AlteracaoEventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Evento");
        });

        modelBuilder.Entity<Palestrante>(entity =>
        {
            entity.HasKey(e => e.PalestranteId).HasName("PK__Palestra__404E9696DBE67DB3");

            entity.Property(e => e.AreaAtuacao)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Palestrante)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Palestrante_Usuario");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.ParticipanteId).HasName("PK__Particip__E6DEAC5FBC7F297D");

            entity.HasIndex(e => e.UsuarioId, "UQ__Particip__2B3DE7B911718A7A").IsUnique();

            entity.HasOne(d => d.Usuario).WithOne(p => p.Participante)
                .HasForeignKey<Participante>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participante_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B818208966");

            entity.ToTable(tb => tb.HasTrigger("trg_ExclusaoUsuario"));

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053445F98630").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.StatusUsuario).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
