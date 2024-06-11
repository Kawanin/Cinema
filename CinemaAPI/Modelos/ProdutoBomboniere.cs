public class ProdutoBomboniere
{
    public virtual int ID { get; set; }
    public virtual string? Nome { get; set; }
    public virtual double? Valor { get; set; }
    public virtual ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
}
