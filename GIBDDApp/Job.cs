//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIBDDApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public int Id { get; set; }
        public int DriverGUID { get; set; }
        public string Company { get; set; }
        public string JobName { get; set; }
    
        public virtual Drivers Drivers { get; set; }
    }
}
