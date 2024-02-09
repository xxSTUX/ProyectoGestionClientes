﻿using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ProyectoDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Nombre Proyecto")]
        public string Nombre { get; set; } = null!;
        [JsonIgnore]
        public int IdCliente { get; set; }
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoProyecto { get; set; } = new List<TablaIntermedia>();
        [JsonPropertyName("Seguimientos de proyecto")]
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        [JsonPropertyName("Licitaciones de proyecto")]
        public virtual IList<LicitacionDetalle> Licitaciones { get; set; } = new List<LicitacionDetalle>();

    }
}
