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
    
    public partial class R_UserInfo_ActionInfo
    {
        public int Id { get; set; }
        public short DelFlag { get; set; }
        public bool HasPermission { get; set; }
        public int UserInfoId { get; set; }
        public int ActionInfoId { get; set; }
    
        public virtual ActionInfo ActionInfo { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
