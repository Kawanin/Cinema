public class Filme
{
    public virtual int ID { get; set; }
    public virtual string? Titulo { get; set; }
    public virtual string? Duracao { get; set; }
    public virtual string? Classificacao { get; set; }
    public virtual string? Sinopse { get; set; }
    public virtual string? Categoria { get; set; }
    public virtual string? Direcao { get; set; }
    public virtual string? PaisOrigem { get; set; }
    public virtual string Poster { get; set; }
    //public virtual ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
}
