using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrdersCRUD.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseInfo> CourseInfos { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employees2> Employees2s { get; set; }

    public virtual DbSet<EnrollmentInfo> EnrollmentInfos { get; set; }

    public virtual DbSet<GradeInfo> GradeInfos { get; set; }

    public virtual DbSet<InstructorInfo> InstructorInfos { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SectionInfo> SectionInfos { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentInfo> StudentInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ZipcodeInfo> ZipcodeInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TOPBRAINS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseInfo>(entity =>
        {
            entity.HasKey(e => e.CourseNo).HasName("COURSE_NO_PK");

            entity.ToTable("COURSE_INFO");

            entity.Property(e => e.CourseNo)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("COURSE_NO");
            entity.Property(e => e.Cost)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("COST");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COURSE_NAME");
            entity.Property(e => e.CoursePrerequisite)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("COURSE_PREREQUISITE");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptid).HasName("PK__DEPARTME__E0EBD3AC05555A22");

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.Deptid)
                .ValueGeneratedNever()
                .HasColumnName("DEPTID");
            entity.Property(e => e.Deptname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPTNAME");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLOYEE__3214EC2704B1D6A5");

            entity.ToTable("EMPLOYEES");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Dept)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DEPT");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Salary).HasColumnName("SALARY");
        });

        modelBuilder.Entity<Employees2>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__EMPLOYEE__14CCD97D93A56F7A");

            entity.ToTable("EMPLOYEES2");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("EMPID");
            entity.Property(e => e.Deptid).HasColumnName("DEPTID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Salary).HasColumnName("SALARY");
        });

        modelBuilder.Entity<EnrollmentInfo>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.SectionId }).HasName("ENROLLMENT_STUD_SECT_PK");

            entity.ToTable("ENROLLMENT_INFO");

            entity.Property(e => e.StudentId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.SectionId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("SECTION_ID");
            entity.Property(e => e.EnrollmentDate).HasColumnName("ENROLLMENT_DATE");

            entity.HasOne(d => d.Section).WithMany(p => p.EnrollmentInfos)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_SECTION_ID_FK");

            entity.HasOne(d => d.Student).WithMany(p => p.EnrollmentInfos)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_STUDENT_ID_FK");
        });

        modelBuilder.Entity<GradeInfo>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.SectionId, e.GradeTypeCode, e.GradeCodeOccurance }).HasName("GRADE_STUD_SECT_TYPE_CODE_PK");

            entity.ToTable("GRADE_INFO");

            entity.Property(e => e.StudentId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.SectionId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("SECTION_ID");
            entity.Property(e => e.GradeTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GRADE_TYPE_CODE");
            entity.Property(e => e.GradeCodeOccurance)
                .HasColumnType("numeric(38, 0)")
                .HasColumnName("GRADE_CODE_OCCURANCE");
            entity.Property(e => e.NumericGrade)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("NUMERIC_GRADE");

            entity.HasOne(d => d.Section).WithMany(p => p.GradeInfos)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_SECTION_ID_FK");

            entity.HasOne(d => d.Student).WithMany(p => p.GradeInfos)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_STUDENT_ID_FK");
        });

        modelBuilder.Entity<InstructorInfo>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("INSTRUCTOR_ID_PK");

            entity.ToTable("INSTRUCTOR_INFO");

            entity.Property(e => e.InstructorId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.InstructorFirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("INSTRUCTOR_FIRST_NAME");
            entity.Property(e => e.InstructorLastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("INSTRUCTOR_LAST_NAME");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STREET_ADDRESS");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ZIP_CODE");

            entity.HasOne(d => d.ZipCodeNavigation).WithMany(p => p.InstructorInfos)
                .HasForeignKey(d => d.ZipCode)
                .HasConstraintName("ZIP_INSTRUCTOR_FK");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.MarkId).HasName("PK__MARKS__844C8101F187AC45");

            entity.ToTable("MARKS");

            entity.Property(e => e.MarkId).HasColumnName("MARK_ID");
            entity.Property(e => e.Marks).HasColumnName("MARKS");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__MARKS__STUDENT_I__6C190EBB");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => new { e.CustomerId, e.OrderDate }, "IX_Orders_CustomerId_OrderDate");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__ORDERITE__E15C43169BC62DB1");

            entity.ToTable("ORDERITEMS");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("ORDER_ITEM_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTS__52B41763528B6DDD");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__SALES__8C7545E1140BBE98");

            entity.ToTable("SALES");

            entity.Property(e => e.SaleId).HasColumnName("SALE_ID");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.SaleDate).HasColumnName("SALE_DATE");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SALES__PRODUCT_I__71D1E811");
        });

        modelBuilder.Entity<SectionInfo>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("SECTION_ID_PK");

            entity.ToTable("SECTION_INFO");

            entity.Property(e => e.SectionId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("SECTION_ID");
            entity.Property(e => e.Capacity)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.CourseNo)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("COURSE_NO");
            entity.Property(e => e.InstructorId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.SectionNo)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("SECTION_NO");

            entity.HasOne(d => d.CourseNoNavigation).WithMany(p => p.SectionInfos)
                .HasForeignKey(d => d.CourseNo)
                .HasConstraintName("COURSE_SECTION_FK");

            entity.HasOne(d => d.Instructor).WithMany(p => p.SectionInfos)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("INSTRUCTOR_SECTION_FK");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__STUDENT__E69FE77BB8C8884B");

            entity.ToTable("STUDENT");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
        });

        modelBuilder.Entity<StudentInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("STUDENT_ID_PK");

            entity.ToTable("STUDENT_INFO");

            entity.Property(e => e.StudentId)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STREET_ADDRESS");
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("STUDENT_FIRST_NAME");
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("STUDENT_LAST_NAME");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ZIP_CODE");

            entity.HasOne(d => d.ZipCodeNavigation).WithMany(p => p.StudentInfos)
                .HasForeignKey(d => d.ZipCode)
                .HasConstraintName("ZIP_STUDENT_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__F3BEEBFF793E8A77");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("USER_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<ZipcodeInfo>(entity =>
        {
            entity.HasKey(e => e.ZipCode).HasName("ZIP_PK");

            entity.ToTable("ZIPCODE_INFO");

            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ZIP_CODE");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("STATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
