﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HurmatullinSystemForInstitute.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UchebnayaPraktika320BulatEntities1 : DbContext
    {
        public UchebnayaPraktika320BulatEntities1()
            : base("name=UchebnayaPraktika320BulatEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<academics> academics { get; set; }
        public virtual DbSet<Animal_Bulat> Animal_Bulat { get; set; }
        public virtual DbSet<Control_Bulat> Control_Bulat { get; set; }
        public virtual DbSet<countries> countries { get; set; }
        public virtual DbSet<Countries_Bulat> Countries_Bulat { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Facult> Facult { get; set; }
        public virtual DbSet<FlowersBulat> FlowersBulat { get; set; }
        public virtual DbSet<Kafedra> Kafedra { get; set; }
        public virtual DbSet<kafedra_mains> kafedra_mains { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Spec> Spec { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Student10> Student10 { get; set; }
        public virtual DbSet<students14> students14 { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<Licium> Licium { get; set; }
    }
}