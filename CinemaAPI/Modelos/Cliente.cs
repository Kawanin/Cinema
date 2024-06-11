public class Cliente
{
    public virtual int ID { get; set; }
    public virtual string? Nome { get; set; }
    public virtual string? CPF { get; set; }
    public virtual string? Telefone { get; set; }
    public virtual string? Email { get; set; }
    public virtual int? Idade { get; set; }
    public virtual ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
}
