//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuestionarioWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_Tipos_Pregunta_Cuestionario
    {
        public C_Tipos_Pregunta_Cuestionario()
        {
            this.C_Preguntas_Cuestionario = new HashSet<C_Preguntas_Cuestionario>();
        }
    
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Tipo_Pregunta { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Ingles { get; set; }
    
        public virtual ICollection<C_Preguntas_Cuestionario> C_Preguntas_Cuestionario { get; set; }
        public virtual S_Hoteles S_Hoteles { get; set; }
    }
}
