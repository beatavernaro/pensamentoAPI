namespace pensamentoAPI.Model
{
    public class PensamentoModel
    {
        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public string? Autoria { get; set; }
        public string? Modelo { get; set; }

    }
}
//  re3cebo um json da API e preciso transformar em um objeto do tipo ??? para colocar nos campos do html
// jsonserializer onde?
// dto onde?