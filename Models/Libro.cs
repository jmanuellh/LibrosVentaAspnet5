namespace LibrosVentaAspnet5.Models
{
  public class Libro
  {
      public long Id {get;set;}
      public string Nombre {get;set;}
      public long ClienteId {get;set;}
      public Cliente Cliente {get;set;}
  }
}
