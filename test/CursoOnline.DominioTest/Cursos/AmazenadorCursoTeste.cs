

using Castle.Components.DictionaryAdapter.Xml;
using Moq;

namespace CursoOnline.DominioTest.Cursos
{
    public class AmazenadorCursoTeste
    {
        private readonly CursoDto _cursoDto;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public AmazenadorCursoTeste()
        {
            var faker = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Words(),
                CargaHoraria = faker.Random.Double(50, 400),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Double(500, 4000),
                Descricao = faker.Lorem.Paragraph()
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            
            _cursoDto.PublicoAlvo = "Médico";

            Assert.Throws<ArgumentException>(() => 
                _armazenadorDeCurso.Armazenar(_cursoDto))
                .WithMessage("Público Alvo Inválido"); ;

        }

        [Fact]
        public void DeveAdicionarCurso()
        {            
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c =>
                    c.Nome == _cursoDto.Nome &&
                    c.CargaHoraria == _cursoDto.CargaHoraria &&                    
                    c.Valor == _cursoDto.Valor &&
                    c.Descricao == _cursoDto.Descricao
                )
            ), Times.AtLeast(1));

            // Times.AtLeast(2) : Define quantas vezes o método tem que ser chamado
            // Times.Never      : Nunca pode ser chamado
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
    }
    public class ArmazenadorDeCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo is null)
                throw new ArgumentException("Público Alvo inválido");

            var curso = new Curso(cursoDto.Nome, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor, cursoDto.Descricao);
            _cursoRepositorio.Adicionar(curso);
        }
    }
}
