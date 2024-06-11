using Microsoft.EntityFrameworkCore;

public static class FilmeApi
{
    public static void MapFilmeApi(this WebApplication app)
    {
        var group = app.MapGroup("/filmes");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Filmes
                          .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var filme = await db.Filmes
                                .FirstOrDefaultAsync(f => f.ID == id);
            if (filme is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(filme);
        });

        group.MapPost("/", async (Filme filme, BancoDeDados db) =>
        {
            db.Filmes.Add(filme);
            await db.SaveChangesAsync();
            return Results.Created($"/filmes/{filme.ID}", filme);
        });

        group.MapPut("/{id}", async (int id, Filme filmeAlterado, BancoDeDados db) =>
        {
            var filme = await db.Filmes.FindAsync(id);
            if (filme is null)
            {
                return Results.NotFound();
            }

            filme.Titulo = filmeAlterado.Titulo;
            filme.Duracao = filmeAlterado.Duracao;
            filme.Classificacao = filmeAlterado.Classificacao;
            filme.Sinopse = filmeAlterado.Sinopse;
            filme.Categoria = filmeAlterado.Categoria;
            filme.Direcao = filmeAlterado.Direcao;
            filme.PaisOrigem = filmeAlterado.PaisOrigem;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var filme = await db.Filmes.FindAsync(id);
            if (filme is null)
            {
                return Results.NotFound();
            }

            db.Filmes.Remove(filme);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
