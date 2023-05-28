
using System.Collections.Generic;
namespace MySql.Models

    public class Prestamo
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public decimal TasaInteres { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int GarantiaId { get; set; }
        public Garantia Garantia { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public List<Prestamo>? Prestamos { get; set; }
    }

    public class Garantia
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string Descripcion { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
