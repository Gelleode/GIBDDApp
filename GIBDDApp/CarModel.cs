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
    
    public partial class CarModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModel()
        {
            this.CarSpecification = new HashSet<CarSpecification>();
        }
    
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ManufacterId { get; set; }
        public string Model { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Manufacter Manufacter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSpecification> CarSpecification { get; set; }
    }
}
