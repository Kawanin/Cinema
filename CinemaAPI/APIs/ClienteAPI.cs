using Microsoft.EntityFrameworkCore;

public static class ClienteApi
{
    public static void MapClienteApi(this WebApplication app)
    {
        var group = app.MapGroup("/clientes");

        group.MapGet("/", async (BancoDeDados db) =>
        {
            return await db.Clientes
                          .ToListAsync();
        });

        group.MapGet("/{id}", async (int id, BancoDeDados db) =>
        {
            var cliente = await db.Clientes
                .FirstOrDefaultAsync(c => c.ID == id);
            if (cliente is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(cliente);
        });

        group.MapPost("/", async (Cliente cliente, BancoDeDados db) =>
        {
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();

            return Results.Created($"/clientes/{cliente.ID}", new { Cliente = cliente });
        });

        group.MapPut("/{id}", async (int id, Cliente clienteAlterado, BancoDeDados db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente is null)
            {
                return Results.NotFound();
            }

            cliente.Nome = clienteAlterado.Nome;
            cliente.CPF = clienteAlterado.CPF;
            cliente.Telefone = clienteAlterado.Telefone;
            cliente.Email = clienteAlterado.Email;
            cliente.Idade = clienteAlterado.Idade;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente is null)
            {
                return Results.NotFound();
            }

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
