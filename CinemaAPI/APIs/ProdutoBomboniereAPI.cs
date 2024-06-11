using Microsoft.EntityFrameworkCore;

public static class ProdutosBomboniereAPI
{
    public static void MapProdutosBomboniereApi(this WebApplication app)
    {
        var group = app.MapGroup("/bomboniere");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Produtos
                          .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var produto = await db.Produtos
                                .FirstOrDefaultAsync(p => p.ID == id);
            if (produto is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(produto);
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var produto = await db.Produtos.FindAsync(id);
            if (produto is null)
            {
                return Results.NotFound();
            }

            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
