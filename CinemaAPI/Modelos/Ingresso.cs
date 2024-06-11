using System.ComponentModel.DataAnnotations.Schema;

public class Ingresso
{
    public int ID { get; set; }
    public double Valor { get; set; }
    public int ClienteID { get; set; }
    [ForeignKey("ClienteID")]
    //public virtual Cliente Cliente { get; set; }
    public int FilmeID { get; set; }
    [ForeignKey("FilmeID")]
    //public virtual Filme? Filme { get; set; }
    public double? TotalBomboniere { get; set; }
    //public virtual List<ProdutoBomboniere>? CarrinhoBomboniere { get; set; } = new List<ProdutoBomboniere>();
    public double TotalCompra { get; set; }
    //Cliente[] result = System.Text.Json.JsonSerializer.Deserialize<Cliente[]>(json);
}

