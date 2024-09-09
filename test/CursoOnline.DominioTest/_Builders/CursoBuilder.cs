using CursoOnline.Dominio.Dto;
using CursoOnline.Dominio.Model;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string _nome = "Curso de .Net 8";
        private double _cargaHoraria = 90.0;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950.0;
        private string _descricao = "Curso para aprimoramento em C#";

        public static CursoBuilder Novo() { 
            return new CursoBuilder();
        }

        public CursoBuilder WithNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder WithDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder WithCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder WithValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder WithPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor, _descricao); 
        }
    }
}
