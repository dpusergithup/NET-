//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 代码熟练度练习3
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleInfo()
        {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int Id { get; set; }
        public string RoleName { get; set; }
        public System.DateTime SubTime { get; set; }
        public System.DateTime ModifedOn { get; set; }
        public string Remark { get; set; }
        public short DelFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
