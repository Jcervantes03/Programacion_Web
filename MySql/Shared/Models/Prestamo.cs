namespace NombreDeTuProyecto.Models
    public class Prestamo
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public decimal Monto { get; set; }
    public int Plazo { get; set; }
    public decimal TasaInteres { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Prestamo prestamo &&
               this.Id == prestamo.Id &&
               this.Cliente == prestamo.Cliente &&
               this.Monto == prestamo.Monto &&
               this.Plazo == prestamo.Plazo &&
               this.TasaInteres == prestamo.TasaInteres &&
               this.Id == prestamo.Id &&
               this.Monto == prestamo.Monto &&
               this.Plazo == prestamo.Plazo &&
               this.TasaInteres == prestamo.TasaInteres &&
               ClienteId == prestamo.ClienteId &&
               EqualityComparer<Cliente>.Default.Equals(this.Cliente, prestamo.Cliente) &&
               GarantiaId == prestamo.GarantiaId &&
               EqualityComparer<Garantia>.Default.Equals(Garantia, prestamo.Garantia);
    }
}

{
}
