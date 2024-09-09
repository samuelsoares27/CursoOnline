using CursoOnline.Dominio.Model;

namespace CursoOnline.Dominio.Dto
{
    public class CursoDto
    {
        public string Nome { get; set; } = string.Empty;
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
