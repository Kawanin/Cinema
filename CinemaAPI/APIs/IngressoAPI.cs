using Microsoft.EntityFrameworkCore;

public static class IngressoApi
{
    public static void MapIngressoAPI(this WebApplication app)
    {
        var group = app.MapGroup("/ingresso");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Ingresso
                          .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var ingresso = await db.Ingresso
                                .FirstOrDefaultAsync(f => f.ID == id);
            if (ingresso is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(ingresso);
        });

        group.MapPost("/", async (Ingresso ingresso, BancoDeDados db) =>
        {
            db.Ingresso.Add(ingresso);
            await db.SaveChangesAsync();
            return Results.Created($"/ingresso/{ingresso.ID}", ingresso);
        });

        // group.MapPut("/{id}", async (int id, Ingresso ingressoAlterado, BancoDeDados db) =>
        // {
        //     var ingresso = await db.Ingresso.FindAsync(id);
        //     if (ingresso is null)
        //     {
        //         return Results.NotFound();
        //     }

        //     ingresso.Valor = ingressoAlterado.Valor;

        //     ingresso.TotalBomboniere = ingressoAlterado.TotalBomboniere;

        //     ;;ingresso.List<ProdutoBomboniere> = ingressoAlterado.Classificacao;

        //     ingresso.TotalCompra = ingressoAlterado.TotalCompra;


        //     await db.SaveChangesAsync();

        //     return Results.NoContent();
        // });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var ingresso = await db.Ingresso.FindAsync(id);
            if (ingresso is null)
            {
                return Results.NotFound();
            }

            db.Ingresso.Remove(ingresso);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
