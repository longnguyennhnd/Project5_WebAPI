using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EClassCDCDWebAPI.Models
{
    public partial class EclassCDCDContext : DbContext
    {
        public EclassCDCDContext()
        {
        }

        public EclassCDCDContext(DbContextOptions<EclassCDCDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<AnswerDetails> AnswerDetails { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<UserRequests> UserRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI\\LongNguyen;Database=EclassCDCD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Accounts_Departments");
            });

            modelBuilder.Entity<AnswerDetails>(entity =>
            {
                entity.HasKey(e => new { e.AnswerId, e.QuestionId });

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswerDetails)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_AnswerDetails_Answers");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AnswerDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_AnswerDetails_Questions");
            });

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId)
                    .HasName("PK_Answers_1");

                entity.Property(e => e.AnswerId)
                    .HasColumnName("AnswerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Plans");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId)
                    .HasColumnName("CateID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CateName).HasMaxLength(250);
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId)
                    .HasColumnName("ClassID")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("FacultyID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Period)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Classes_Employees");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("FacultyID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Departments_Faculties");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<Faculties>(entity =>
            {
                entity.HasKey(e => e.FacultyId);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("FacultyID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyName).HasMaxLength(200);
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.HasKey(e => e.OptionId);

                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Value).HasMaxLength(250);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Options_Questions");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.FacultyId)
                    .IsRequired()
                    .HasColumnName("FacultyID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__Facul__5070F446");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__Usern__5165187F");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.ActiveDate).HasColumnType("datetime");

                entity.Property(e => e.CateId)
                    .HasColumnName("CateID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("ClassID")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.HasMark).HasDefaultValueSql("((0))");

                entity.Property(e => e.MarkCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarkDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasColumnName("SubjectID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__Plans__CateID__4BAC3F29");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Plans_Classes");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Plans_Employees");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Plans_Subjects");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId)
                    .HasColumnName("QuestionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CateId)
                    .HasColumnName("CateID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Desciption).HasMaxLength(250);

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasColumnName("TypeID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Questions_Categories");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Types");
            });

            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasKey(e => e.ScoreId);

                entity.Property(e => e.ScoreId).HasColumnName("ScoreID");

                entity.Property(e => e.Details).HasMaxLength(100);

                entity.Property(e => e.FinalScore).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(20);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasColumnName("SubjectID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Scores__StudentI__29221CFB");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Scores__SubjectI__2A164134");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("ClassID")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Students_Classes");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Subjects__Depart__5AEE82B9");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName).HasMaxLength(250);
            });

            modelBuilder.Entity<UserRequests>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsFromStudent)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
