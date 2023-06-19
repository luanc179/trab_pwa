namespace CadastroAtletaApi.Models
{
    public class AtletaRecord : BaseModel
    {
        public AtletaRecord() { }

        public AtletaRecord(Atleta atleta) 
        {
            this.atleta = atleta;
        }

        public string? IdAtleta
        {
            get => atleta == null ? idAtleta : atleta.Id;
            set => idAtleta = value;
        }

        public DateTime Data { get; set; }

        public string Descricao { get; set; } = "";

        private string? idAtleta = null;
        private Atleta? atleta;
    }
}
