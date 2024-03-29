﻿using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class LicitacionDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int Estado { get; set; } = 0;
        public bool Eliminado { get; set; } = false;

    }
}
