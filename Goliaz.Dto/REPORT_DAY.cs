//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Goliaz.Dto
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class REPORT_DAY
    {
        public int idReportDay { get; set; }
        public string Name { get; set; }
        public string DataInform { get; set; }
        public string Inform { get; set; }
        public Nullable<int> idRegister { get; set; }
    
        public virtual DAYS_REPORT DAYS_REPORT { get; set; }
    }
}
