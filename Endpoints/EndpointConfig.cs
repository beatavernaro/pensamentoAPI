using pensamentoAPI.Data;
using pensamentoAPI.Model;

namespace pensamentoAPI.Endpoints
{
    public class EndpointConfig
    {
        public static void AddEndpoint(WebApplication app)
        {
            #region GET
            app.MapGet("/pensamentos", async (AppDbContext context) =>
            {
                var pensamentos = (from pensamento in context.Pensamentos
                                   orderby pensamento.Id
                                   select pensamento).ToList();
                if (pensamentos.Count == 0) return Results.Ok("Nenhum pensamento encontrado");

                return Results.Ok(pensamentos);
            });

            app.MapGet("/pensamentos/{id}", async (int id, AppDbContext context) =>
            {
                var pensamentoPorId = (from pensamento in context.Pensamentos
                                       where pensamento.Id == id
                                       select pensamento).FirstOrDefault();

                if (pensamentoPorId is null) return Results.NoContent();
                return Results.Ok(pensamentoPorId);
            });

            #endregion

            #region POST

            app.MapPost("/pensamentos", async (PensamentoModel pensamento, AppDbContext context) =>
            {
                //adicionar o mapper
                context.Pensamentos.Add(pensamento);
                await context.SaveChangesAsync();
                return Results.Created($"Created at /{pensamento.Id}", pensamento);
            });

            #endregion

            #region PUT

            app.MapPut("/pensamentos/{id}", async (PensamentoModel pensamento, AppDbContext context, int id) =>
            {
                var pensamentoAtualizar = await context.Pensamentos.FindAsync(id);

                if (pensamentoAtualizar is null) return Results.NotFound("Sem pensamentos encontrados para esse id");

                pensamentoAtualizar.Conteudo = pensamento.Conteudo;
                pensamentoAtualizar.Autoria = pensamento.Autoria;
                pensamentoAtualizar.Modelo = pensamento.Modelo;

                await context.SaveChangesAsync();
                return Results.Ok(pensamentoAtualizar);
            });

            #endregion

            app.MapDelete("/pensamentos/{id}", async (int id, AppDbContext context) =>
            {
                var pensamentoDeletar = await context.Pensamentos.FindAsync(id);

                if (pensamentoDeletar is null) return Results.NotFound("Nenhum pensamento encontrado para esse id");
                _ = context.Pensamentos.Remove(pensamentoDeletar);
                await context.SaveChangesAsync();

                return Results.Ok("Deletado!");

            });
        }
    }
}
