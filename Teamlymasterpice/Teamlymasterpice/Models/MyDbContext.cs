using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Teamlymasterpice.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiConversation> AiConversations { get; set; }

    public virtual DbSet<AiMessage> AiMessages { get; set; }

    public virtual DbSet<CompanyEmployee> CompanyEmployees { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PortfolioItem> PortfolioItems { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderService> ProviderServices { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    public virtual DbSet<SupportTicket> SupportTickets { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TEAMLY;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ai_conve__3213E83F9D4196C0");

            entity.ToTable("ai_conversations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AiConversations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ai_conver__user___0B5CAFEA");
        });

        modelBuilder.Entity<AiMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ai_messa__3213E83F29857854");

            entity.ToTable("ai_messages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .HasMaxLength(1000)
                .HasColumnName("body");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.Sender)
                .HasMaxLength(4)
                .HasColumnName("sender");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("sent_at");

            entity.HasOne(d => d.Conversation).WithMany(p => p.AiMessages)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ai_messag__conve__0F2D40CE");
        });

        modelBuilder.Entity<CompanyEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company___3213E83F3630E1DA");

            entity.ToTable("company_employees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasColumnName("specialty");

            entity.HasOne(d => d.Provider).WithMany(p => p.CompanyEmployees)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__company_e__provi__540C7B00");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__messages__3213E83F828A8C6B");

            entity.ToTable("messages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .HasMaxLength(250)
                .HasColumnName("body");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("sent_at");

            entity.HasOne(d => d.Project).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__messages__projec__7A3223E8");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__messages__receiv__7C1A6C5A");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__messages__sender__7B264821");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F962FD46A");

            entity.ToTable("notifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__user___7FEAFD3E");
        });

        modelBuilder.Entity<PortfolioItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__portfoli__3213E83FBFEA9E65");

            entity.ToTable("portfolio_items");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(300)
                .HasColumnName("file_url");
            entity.Property(e => e.MediaType)
                .HasMaxLength(10)
                .HasColumnName("media_type");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.PortfolioItems)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__portfolio__provi__503BEA1C");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F6C2DBE35");

            entity.ToTable("projects");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Budget)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("budget");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventType)
                .HasMaxLength(30)
                .HasColumnName("event_type");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects__client__56E8E7AB");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__provider__3213E83F1D13BF76");

            entity.ToTable("providers");

            entity.HasIndex(e => e.UserId, "UQ__provider__B9BE370EDB126A74").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BusinessEmail)
                .HasMaxLength(150)
                .HasColumnName("business_email");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .HasColumnName("company_name");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.PricingQuantity)
                .HasDefaultValue(1)
                .HasColumnName("pricing_quantity");
            entity.Property(e => e.PricingUnit)
                .HasMaxLength(20)
                .HasColumnName("pricing_unit");
            entity.Property(e => e.ProviderType)
                .HasMaxLength(10)
                .HasColumnName("provider_type");
            entity.Property(e => e.RepresentativeName)
                .HasMaxLength(100)
                .HasColumnName("representative_name");
            entity.Property(e => e.StartingPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("starting_price");
            entity.Property(e => e.Tagline)
                .HasMaxLength(150)
                .HasColumnName("tagline");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Provider)
                .HasForeignKey<Provider>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__providers__user___43D61337");
        });

        modelBuilder.Entity<ProviderService>(entity =>
        {
            entity.HasKey(e => new { e.ProviderId, e.ServiceId }).HasName("PK__provider__E302C89AF5E90902");

            entity.ToTable("provider_services");

            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.IsMain).HasColumnName("is_main");

            entity.HasOne(d => d.Provider).WithMany(p => p.ProviderServices)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__provider___provi__4B7734FF");

            entity.HasOne(d => d.Service).WithMany(p => p.ProviderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__provider___servi__4C6B5938");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__requests__3213E83F87615F49");

            entity.ToTable("requests");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("new")
                .HasColumnName("status");

            entity.HasOne(d => d.Project).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__requests__projec__5BAD9CC8");

            entity.HasOne(d => d.Provider).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__requests__provid__5CA1C101");

            entity.HasOne(d => d.Service).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__requests__servic__5D95E53A");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviews__3213E83F2060629E");

            entity.ToTable("reviews");

            entity.HasIndex(e => e.RequestId, "UQ__reviews__18D3B90E7D26AF6F").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Request).WithOne(p => p.Review)
                .HasForeignKey<Review>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reviews__request__6442E2C9");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__services__3213E83F7E1A1F28");

            entity.ToTable("services");

            entity.HasIndex(e => e.Name, "UQ__services__72E12F1B696F74A9").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subscrip__3213E83F36344C38");

            entity.ToTable("subscriptions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.RenewalDate).HasColumnName("renewal_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Plan).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__plan___6DCC4D03");

            entity.HasOne(d => d.Provider).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__provi__6CD828CA");
        });

        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subscrip__3213E83FE2C096B6");

            entity.ToTable("subscription_plans");

            entity.HasIndex(e => new { e.Name, e.ProviderType }, "UQ__subscrip__DB062A11D0D65701").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProviderType)
                .HasMaxLength(10)
                .HasColumnName("provider_type");
        });

        modelBuilder.Entity<SupportTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__support___3213E83F1150B7EE");

            entity.ToTable("support_tickets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(150)
                .HasColumnName("contact_email");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IssueType)
                .HasMaxLength(30)
                .HasColumnName("issue_type");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.Status)
                .HasMaxLength(12)
                .HasDefaultValue("open")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .HasColumnName("subject");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.SupportTickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__support_t__user___04AFB25B");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FDFA99560");

            entity.ToTable("transactions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Commission)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("commission");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Method)
                .HasMaxLength(20)
                .HasColumnName("method");
            entity.Property(e => e.PayerId).HasColumnName("payer_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Payer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__payer__73852659");

            entity.HasOne(d => d.Project).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__proje__72910220");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F1B536F13");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164A7289B67").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("active")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
