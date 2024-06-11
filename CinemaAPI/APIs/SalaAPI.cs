using Microsoft.EntityFrameworkCore;

public static class SalaApi
{
    public static void MapSalaApi(this WebApplication app)
    {
        var group = app.MapGroup("/sala");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Sala
                .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var sala = await db.Sala
                .FirstOrDefaultAsync(s => s.ID == id);
            if (sala is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(sala);
        });

        group.MapPost("/", async (Sala sala, BancoDeDados db) =>
        {
            db.Sala.Add(sala);
            await db.SaveChangesAsync();
            return Results.Created($"/sala/{sala.ID}", sala);
        });



        group.MapPut("/{id}", async (int id, Sala salaAlterada, BancoDeDados db) =>
        {
            var sala = await db.Sala.FindAsync(id);
            if (sala is null)
            {
                return Results.NotFound();
            }

            sala.Assento = salaAlterada.Assento;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var sala = await db.Sala.FindAsync(id);
            if (sala is null)
            {
                return Results.NotFound();
            }

            db.Sala.Remove(sala);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
