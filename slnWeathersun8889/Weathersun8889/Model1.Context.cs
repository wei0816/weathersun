﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weathersun8889
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeathersunEntities : DbContext
    {
        public WeathersunEntities()
            : base("name=WeathersunEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberFeedback> MemberFeedback { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WebpageFeedback> WebpageFeedback { get; set; }
    }
}
