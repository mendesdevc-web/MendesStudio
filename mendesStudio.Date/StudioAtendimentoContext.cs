using Studio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Studio.Date
{
    public class StudioAtendimentoContext : DbContext
    {
        public StudioAtendimentoContext(DbContextOptions<StudioAtendimentoContext> options) : base(options)
        {
        }
        public DbSet<AtendimentoModels> Atendimentos { get; set; }
        public DbSet<ClienteModels> Clientes { get; set; }
        public DbSet<PostoModels> Postos { get; set; }
        public DbSet<ProcedimentoModels> Procedimentos { get; set; }
        public DbSet<AtendimentoProcedimentoModels> Atendimento_Procedimentos { get; set; }
        public DbSet<PagamentosCartaoModels> Pagamentos_Cartao { get; set; }
        public DbSet<PagamentoPixModels> Pagamentos_Pix { get; set; }
        public DbSet<PagamentosDinheiroModels> Pagamentos_Dinheiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            
            modelBuilder.Entity<PostoModels>(entity =>
            {
                entity.ToTable("Postos");

                entity.HasKey(e => e.CodigoPosto)
                    .HasName("PK_Posto");

                entity.Property(e => e.CodigoPosto)
                    .HasColumnName("codigo_posto")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescPosto)
                    .HasColumnName("desc_posto")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.NomeEmpresa)
                    .HasColumnName("nome_empresa")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.ContaBancaria)
                    .HasColumnName("conta_bancaria")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsRequired();
            });

            modelBuilder.Entity<AtendimentoModels>(entity =>
            {
                entity.ToTable("Atendimentos");

                entity.HasKey(e => new
                {
                    e.CodigoAtendimento,
                    e.CodigoPosto
                })
                .HasName("PK_Atendimento");

                entity.Property(e => e.CodigoAtendimento)
                    .HasColumnName("codigo_atendimento")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoPosto)
                    .HasColumnName("codigo_posto")
                    .IsRequired();

                entity.Property(e => e.CodigoCliente)
                    .HasColumnName("codigo_cliente")
                    .IsRequired();

                entity.Property(e => e.DataAtendimento)
                    .HasColumnName("data_atendimento")
                    .IsRequired();

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("valor_total")
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.HasOne(e => e.Posto)
                   .WithMany(p => p.Atendimentos)
                   .HasForeignKey(e => e.CodigoPosto)
                   .HasConstraintName("FK_Atendimento_Posto")
                   .OnDelete(DeleteBehavior.Restrict);



            });

            modelBuilder.Entity<ClienteModels>(entity =>
            {
                entity.ToTable("Clientes");

                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK_Clientes");

                entity.Property(e => e.CodigoCliente)
                    .HasColumnName("codigo_cliente")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NomeCliente)
                    .HasColumnName("nome_cliente")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.SexoCliente)
                    .HasColumnName("sexo_cliente")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasConversion<string>()
                    .IsRequired();

                entity.Property(e => e.NomeSocial)
                    .HasColumnName("nome_social")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CpfCliente)
                    .HasColumnName("cpf_cliente")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasConversion<string>()
                    .IsRequired();

                entity.Property(e => e.RgCliente)
                    .HasColumnName("rg_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsRequired();

                entity.HasIndex(e => e.CpfCliente)
                    .IsUnique()
                    .HasDatabaseName("UQ_Clientes_CPF");


                //entity.HasOne(e => e.Posto)
                //   .WithMany(p => p.Atendimentos)
                //   .HasForeignKey(e => e.CodigoPosto)
                //   .HasConstraintName("FK_Atendimento_Posto")
                //   .OnDelete(DeleteBehavior.Restrict);


                entity.HasMany(c => c.Atendimentos)
                    .WithOne(a => a.Cliente)
                    .HasForeignKey(a => a.CodigoCliente)
                    .HasConstraintName("FK_Atendimento_Cliente")
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<PagamentosCartaoModels>(entity =>
            {
                entity.ToTable("PAGAMENTOS_CARTAO");

                entity.HasKey(e => e.CodPagamentoCartao)
                    .HasName("PK_Pagamentos_Cartao");

                entity.Property(e => e.CodPagamentoCartao)
                    .HasColumnName("cod_pagamento_cartao")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoAtendimento)
                    .HasColumnName("codigo_atendimento")
                    .IsRequired();

                entity.Property(e => e.PostoAtendimento)
                    .HasColumnName("posto_atendimento")
                    .IsRequired();

                entity.Property(e => e.NomeCartao)
                    .HasColumnName("nome_cartao")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.NumeroCartao)
                    .HasColumnName("numero_cartao")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.ValorCartao)
                    .HasColumnName("valor")
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(e => e.BandeiraCartao)
                    .HasColumnName("bandeira_cartao")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .IsRequired();

                entity.Property(e => e.DataUltimaModificacao)
                    .HasColumnName("data_ultima_modificacao");

                entity.Property(e => e.NumeroVezes)
                    .HasColumnName("numero_vezes")
                    .IsRequired();

                entity.Property(e => e.DebitoCredito)
                    .HasColumnName("debito_credito")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasOne(e => e.Atendimento)
                    .WithMany(a => a.PagamentosCartao)
                    .HasForeignKey(e => new {  e.CodigoAtendimento, e.PostoAtendimento })
                    .HasConstraintName("FK_Pagamentos_Cartao_Atendimento")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PagamentosDinheiroModels>(entity =>
            {
                entity.ToTable("PAGAMENTOS_DINHEIRO");

                entity.HasKey(e => e.CodPagamentoDinheiro)
                    .HasName("PK_Pagamentos_Dinheiro");

                entity.Property(e => e.CodPagamentoDinheiro)
                    .HasColumnName("cod_pagamento_dinheiro")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoAtendimento)
                    .HasColumnName("codigo_atendimento")
                    .IsRequired();

                entity.Property(e => e.PostoAtendimento)
                    .HasColumnName("posto_atendimento")
                    .HasMaxLength(10);

                entity.Property(e => e.NomePagador)
                    .HasColumnName("nome_pagador")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.CpfPagador)
                    .HasColumnName("cpf_pagador")
                    .HasMaxLength(14)
                    .IsRequired();

                entity.Property(e => e.ValorDinheiro)
                    .HasColumnName("valor")
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .IsRequired();

                entity.Property(e => e.DataUltimaModificacao)
                    .HasColumnName("data_ultima_modificacao");

                entity.HasOne(e => e.Atendimento)
                    .WithMany(a => a.PagamentosDinheiro)
                    .HasForeignKey(e => new {  e.CodigoAtendimento, e.PostoAtendimento })
                    .HasConstraintName("FK_Pagamentos_Dinheiro_Atendimento")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PagamentoPixModels>(entity =>
            {
                entity.ToTable("PAGAMENTOS_PIX");

                entity.HasKey(e => e.CodPagamentoPix)
                    .HasName("PK_Pagamentos_Pix");

                entity.Property(e => e.CodPagamentoPix)
                    .HasColumnName("cod_pagamento_pix")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoAtendimento)
                    .HasColumnName("codigo_atendimento")
                    .IsRequired();

                entity.Property(e => e.PostoAtendimento)
                    .HasColumnName("posto_atendimento")
                    .IsRequired();

                entity.Property(e => e.NomePagador)
                    .HasColumnName("nome_pagador")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.BancoPagador)
                    .HasColumnName("banco_pagador")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.ValorPix)
                    .HasColumnName("valor")
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .IsRequired();

                entity.Property(e => e.DataUltimaModificacao)
                    .HasColumnName("data_ultima_modificacao");

                entity.HasOne(e => e.Atendimento)
                    .WithMany(a => a.PagamentosPix)
                    .HasForeignKey(e => new { e.CodigoAtendimento, e.PostoAtendimento })
                    .HasConstraintName("FK_Pagamentos_Pix_Atendimento")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProcedimentoModels>(entity =>
            {
                entity.ToTable("Procedimentos");

                entity.HasKey(e => e.CodigoProcedimento)
                    .HasName("PK_Procedimentos");

                entity.Property(e => e.CodigoProcedimento)
                    .HasColumnName("codigo_procedimento")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescProcedimento)
                    .HasColumnName("nome_procedimento")
                    .HasMaxLength(200)
                    .IsRequired();

                entity.HasMany(e => e.Atendimentos)
                    .WithMany(a => a.Procedimentos);
                    
            });

            modelBuilder.Entity<AtendimentoProcedimentoModels>(entity =>
            {
                entity.ToTable("Atendimento_Procedimentos");
                
                entity.HasKey(e => new { e.CodigoAtendimento, e.PostoAtendimento, e.CodigoProcedimento })
                    .HasName("PK_Atendimento_Procedimentos");
                entity.Property(e => e.CodigoAtendimento)
                    .HasColumnName("codigo_atendimento")
                    .IsRequired();
                entity.Property(e => e.CodigoProcedimento)
                    .HasColumnName("codigo_procedimento")
                    .IsRequired();
                entity.Property(e => e.PostoAtendimento)
                    .HasColumnName("posto_atendimento")
                    .IsRequired();


                entity.HasOne(e => e.Atendimento)
                    .WithMany(a => a.AtendimentoProcedimentos)
                    .HasForeignKey(e => new { e.CodigoAtendimento, e.PostoAtendimento })
                    .HasConstraintName("FK_AP_Atendimento")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Procedimento)
                    .WithMany(p => p.AtendimentoProcedimentos)
                    .HasForeignKey(e => e.CodigoProcedimento)
                    .HasConstraintName("FK_AP_Procedimento")
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}