//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class 貼文
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 貼文()
        {
            this.Hashtag = new HashSet<Hashtag>();
        }
    
        public int 貼文編號 { get; set; }
        public string 會員帳號 { get; set; }
        public byte[] 貼文照片 { get; set; }
        public string 貼文文字 { get; set; }
        public System.DateTime 編輯日期 { get; set; }
        public string 商品標籤 { get; set; }
    
        public virtual 商品 商品 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hashtag> Hashtag { get; set; }
        public virtual 會員 會員 { get; set; }
    }
}
