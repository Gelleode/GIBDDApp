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
    
    public partial class Contact
    {
        public int Id { get; set; }
        public int DriverGUID { get; set; }
        public string AddressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressLifeStreet { get; set; }
        public string AdressLifeCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    
        public virtual Drivers Drivers { get; set; }
    }
}
