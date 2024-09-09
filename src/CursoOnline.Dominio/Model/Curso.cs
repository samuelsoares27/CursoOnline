namespace CursoOnline.Dominio.Model
{
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
        {

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio.");

            if (cargaHoraria <= 0)
                throw new ArgumentException("Carga Horária deve ser maior que zero.");

            if (valor < 1)
                throw new ArgumentException("Valor não pode ser negativo.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição não pode ser vazio.");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }
        public string Nome { get; private set; } = string.Empty;
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
    }
}
