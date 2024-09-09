using CursoOnline.Dominio.Model;
using CursoOnline.DominioTest._Builders;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste : IDisposable
    {
        private ITestOutputHelper _outputHelper;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTeste(ITestOutputHelper outputHelper)
        {

            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Construtor sendo Executado");

            var faker = new Faker();

            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(1, 1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(1, 10000);
            _descricao = faker.Lorem.Text();
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("Dispose sendo Executado");
        }

        [Fact]
        public void Should_Create_Course()
        {
            var cursoExpected = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Curso(cursoExpected.Nome, cursoExpected.CargaHoraria,
                cursoExpected.PublicoAlvo, cursoExpected.Valor, cursoExpected.Descricao);

            cursoExpected.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Not_Invalid_Name(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().WithNome(nomeInvalido).Build())
                .WithMessage("Nome não pode ser vazio.");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Should_Not_CargaHorario_Less_One(double cargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, cargaHorariaInvalida, _publicoAlvo, _valor, _descricao))
                .WithMessage("Carga Horária deve ser maior que zero.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Should_Not_Valor_Less_One(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().WithValor(valorInvalido).Build())
                .WithMessage("Valor não pode ser negativo.");

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Not_Invalid_Description(string descricaoInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().WithDescricao(descricaoInvalido).Build())
                .WithMessage("Descrição não pode ser vazio.");

        }
    }
}