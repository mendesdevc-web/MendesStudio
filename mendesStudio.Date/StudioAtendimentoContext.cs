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

            // 1. MAPEAMENTO DA TABELA POSTO
            modelBuilder.Entity<PostoModels>(entity =>
            {
                entity.ToTable("Postos");
                entity.HasKey(p => p.CodigoPosto);

                entity.Property(p => p.CodigoPosto)
                      .HasColumnName("codigo_posto");

                entity.Property(p => p.DescPosto)
                      .HasColumnName("desc_posto")
                      .IsRequired();

                entity.Property(p => p.NomeEmpresa)
                      .HasColumnName("nome_empresa")
                      .IsRequired();

                entity.Property(p => p.ContaBancaria)
                      .HasColumnName("conta_bancaria")
                      .IsRequired();
            });

            // 2. MAPEAMENTO DA TABELA ATENDIMENTO
            modelBuilder.Entity<AtendimentoModels>(entity =>
            {
                entity.ToTable("Atendimentos");
                entity.HasKey(a => new {a.CodigoAtendimento, a.CodigoCliente});

                // Mapeamento de Colunas
                entity.Property(a => a.CodigoAtendimento)
                      .HasColumnName("codigo_atendimento");

                entity.Property(a => a.CodigoPosto)
                      .HasColumnName("codigo_posto");

                entity.Property(a => a.CodigoCliente)
                      .HasColumnName("codigo_cliente");

                entity.Property(a => a.DataAtendimento)
                      .HasColumnName("data_atendimento")
                      .IsRequired();

                entity.Property(a => a.ValorTotal)
                      .HasColumnName("valor_total")
                      .HasPrecision(18, 2)
                      .IsRequired();

                // Relacionamento 1:N (1 Posto para Muitos Atendimentos)
                entity.HasOne<PostoModels>()
                      .WithMany()
                      .HasForeignKey(a => a.CodigoPosto)
                      .HasConstraintName("FK_Atendimento_Postos")
                      .OnDelete(DeleteBehavior.Restrict);

                // Relacionamento 1:N (1 Cliente para Muitos Atendimentos)
                entity.HasOne<ClienteModels>()
                      .WithMany()
                      .HasForeignKey(a => a.CodigoCliente)
                      .HasConstraintName("FK_Atendimento_Clientes")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 3. MAPEAMENTO DA TABELA CLIENTES
            modelBuilder.Entity<ClienteModels>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.CodigoCliente);

                entity.Property(c => c.CodigoCliente)
                      .HasColumnName("codigo_cliente");

                entity.Property(c => c.NomeCliente)
                      .HasColumnName("nome_cliente")
                      .IsRequired();

                entity.Property(c => c.SexoCliente)
                      .HasColumnName("sexo_cliente")
                      .IsRequired();

                entity.Property(c => c.NomeSocial)
                      .HasColumnName("nome_social")
                      .IsRequired(false); 

                entity.Property(c => c.CpfCliente)
                      .HasColumnName("cpf_cliente")
                      .IsRequired();

                entity.Property(c => c.RgCliente)
                      .HasColumnName("rg_cliente")
                      .IsRequired();
            });
            // 4. MAPEAMENTO DA TABELA PROCEDIMENTOS
            modelBuilder.Entity<ProcedimentoModels>(entity =>
            {
                entity.ToTable("Procedimentos");
                entity.HasKey(p => p.CodigoProcedimento);

                entity.Property(p => p.CodigoProcedimento)
                      .HasColumnName("codigo_procedimento");

                entity.Property(p => p.DescProcedimento)
                      .HasColumnName("desc_procedimento")
                      .IsRequired();

            });

            // 5. MAPEAMENTO DA TABELA INTERMEDIÁRIA (N:N)
            // Atendimento_Procedimentos
            modelBuilder.Entity<AtendimentoProcedimentoModels>(entity =>
            {
                entity.ToTable("Atendimento_Procedimentos");

                // 1. Chave Primária Composta (A combinação dos dois códigos cria o ID único da linha)
                entity.HasKey(ap => new { ap.CodigoAtendimento, ap.CodigoProcedimento });

                // 2. Mapeamento dos Nomes das Colunas
                entity.Property(ap => ap.CodigoAtendimento)
                      .HasColumnName("codigo_atendimento");

                entity.Property(ap => ap.CodigoProcedimento)
                      .HasColumnName("codigo_procedimento");

                entity.Property(ap => ap.PostoAtendimento)
                      .HasColumnName("posto_atendimento");

                // 3. Relacionamento 1:N com Atendimento (Muitos Atendimento_Procedimentos pertencem a 1 Atendimento)
                entity.HasOne<AtendimentoModels>()
                      .WithMany()
                      .HasForeignKey(ap => ap.CodigoAtendimento)
                      .HasConstraintName("FK_AtendimentoProcedimento_Atendimento")
                      .OnDelete(DeleteBehavior.Restrict);

                // 4. Relacionamento 1:N com Procedimento (Muitos Atendimento_Procedimentos pertencem a 1 Procedimento)
                entity.HasOne<ProcedimentoModels>()
                      .WithMany()
                      .HasForeignKey(ap => ap.CodigoProcedimento)
                      .HasConstraintName("FK_AtendimentoProcedimento_Procedimentos")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 6. MAPEAMENTO DE PAGAMENTOS: CARTÃO
            modelBuilder.Entity<PagamentosCartaoModels>(entity =>
            {
                entity.ToTable("PagamentosCartaoModels");

                entity.HasKey(p => p.CodPagamentoCartao);
                entity.Property(p => p.CodPagamentoCartao)
                      .HasColumnName("codigo_pagamento_cartao");

                entity.Property(p => p.CodigoAtendimento)
                      .HasColumnName("codigo_atendimento")
                      .IsRequired();

                entity.Property(p => p.NomeCartao)
                      .HasColumnName("nome_cartao")
                      .IsRequired();

                entity.Property(p => p.ValorCartao)
                      .HasColumnName("valor")
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(p => p.BandeiraCartao)
                      .HasColumnName("bandeira_cartao")
                      .IsRequired();

                entity.Property(p => p.DataCriacao)
                      .HasColumnName("data_criacao")
                      .IsRequired();

                entity.Property(p => p.DataUltimaModificacao)
                      .HasColumnName("data_ultima_modificacao")
                      .IsRequired();

                entity.Property(p => p.NumeroVezes)
                      .HasColumnName("numero_vezes")
                      .IsRequired();

                entity.Property(p => p.DebitoCredito)
                      .HasColumnName("debito_credito")
                      .IsRequired();

                // Relacionamento 1:N (Muitos Pagamentos em Cartão pertencem a 1 Atendimento)
                entity.HasOne<AtendimentoModels>()
                      .WithMany()
                      .HasForeignKey(p => p.CodigoAtendimento)
                      .HasConstraintName("FK_PagamentosCartao_Atendimento")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. MAPEAMENTO DE PAGAMENTOS: PIX
            modelBuilder.Entity<PagamentoPixModels>(entity =>
            {
                entity.ToTable("Pagamentos_Pix");

                entity.HasKey(p => p.CodPagamentoPix);

                entity.Property(p => p.CodigoAtendimento)
                      .HasColumnName("codigo_atendimento")
                      .IsRequired();

                entity.Property(p => p.CodPagamentoPix)
                      .HasColumnName("codigo_pagamento_pix")
                      .IsRequired();

                entity.Property(p => p.NomePagador)
                      .HasColumnName("nome_pagador")
                      .IsRequired();

                entity.Property(p => p.BancoPagador)
                      .HasColumnName("banco_pagador")
                      .IsRequired();


                entity.Property(p => p.ValorPix)
                      .HasColumnName("valor")
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(p => p.DataCriacao)
                      .HasColumnName("data_criacao")
                      .IsRequired();

                entity.Property(p => p.DataUltimaModificacao)
                      .HasColumnName("data_ultima_modificacao")
                      .IsRequired();

                // Relacionamento 1:N (Muitos Pagamentos em Pix pertencem a 1 Atendimento)
                entity.HasOne<AtendimentoModels>()
                      .WithMany()
                      .HasForeignKey(p => p.CodigoAtendimento)
                      .HasConstraintName("FK_PagamentosPix_Atendimento")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 8. MAPEAMENTO DE PAGAMENTOS: DINHEIRO
            modelBuilder.Entity<PagamentosDinheiroModels>(entity =>
            {
                entity.ToTable("Pagamentos_Dinheiro");

                entity.HasKey(p => p.CodPagamentoDinheiro);

                entity.Property(p => p.CodPagamentoDinheiro)
                      .HasColumnName("codigo_pagamento_dinheiro");

                entity.Property(p => p.CodigoAtendimento)
                      .HasColumnName("codigo_atendimento");

                entity.Property(p => p.PostoAtendimento)
                      .HasColumnName("posto_atendimento")
                      .IsRequired();

                entity.Property(p => p.NomePagador)
                      .HasColumnName("nome_pagador")
                      .IsRequired();

                entity.Property(p => p.BancoPagador)
                      .HasColumnName("banco_pagador")
                      .IsRequired();

                entity.Property(p => p.ValorDinheiro)
                      .HasColumnName("valor")
                      .HasPrecision(18, 2)
                      .IsRequired();


                // Relacionamento 1:N (Muitos Pagamentos em Dinheiro pertencem a 1 Atendimento)
                entity.HasOne<AtendimentoModels>()
                      .WithMany()
                      .HasForeignKey(p => p.CodigoAtendimento)
                      .HasConstraintName("FK_PagamentosDinheiro_Atendimento")
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}