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
    
    public partial class CarSpecification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarSpecification()
        {
            this.TypeOfDriveOfCar = new HashSet<TypeOfDriveOfCar>();
        }
    
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public int Color { get; set; }
        public int EngineType { get; set; }
    
        public virtual CarModel CarModel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfDriveOfCar> TypeOfDriveOfCar { get; set; }
    }
}
