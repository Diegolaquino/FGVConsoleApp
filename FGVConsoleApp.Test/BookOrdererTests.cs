using FGVConsoleApp.Exception;
using FGVConsoleApp.Model;
using FGVConsoleApp.Seed;
using FGVConsoleApp.Service;

namespace FGVConsoleApp.Test
{
    [TestClass]
    public sealed class BookOrdererTests
    {
        [TestMethod]
        public void Deve_Ordenar_Por_Titulo_Ascendente_E_Autor_Ascendente()
        {
            // Arrange
            var livros = Faker.CriarConjuntoPadraoDeLivros();

                    var regras = new List<SortRule>
            {
                new SortRule("Title", SortDirection.Ascending),
                new SortRule("AuthorName", SortDirection.Ascending)
            };

            var orderer = new BooksOrderer(regras);

            // Act
            var resultado = orderer.Order(livros).ToList();

            // Assert
            Assert.AreEqual("Head First Design Patterns", resultado[0].Title);
            Assert.AreEqual("Internet & World Wide Web: How to Program", resultado[1].Title);
            Assert.AreEqual("Java How to Program", resultado[2].Title);
            Assert.AreEqual("Patterns of Enterprise Application Architecture", resultado[3].Title);
        }

        [TestMethod]
        public void Deve_Ordenar_Por_Titulo_Descendente_E_Edicao_Descendente()
        {
            // Arrange
            var livros = Faker.CriarConjuntoPadraoDeLivros();

                var regras = new List<SortRule>
        {
            new SortRule("Title", SortDirection.Descending),
            new SortRule("EditionYear", SortDirection.Descending)
        };
            var orderer = new BooksOrderer(regras);

            // Act
            var resultado = orderer.Order(livros).ToList();

            // Assert
            Assert.AreEqual("Patterns of Enterprise Application Architecture", resultado[0].Title);
            Assert.AreEqual(2002, resultado[0].EditionYear);

            Assert.AreEqual("Java How to Program", resultado[1].Title);
            Assert.AreEqual(2007, resultado[1].EditionYear);

            Assert.AreEqual("Internet & World Wide Web: How to Program", resultado[2].Title);
            Assert.AreEqual(2007, resultado[2].EditionYear);

            Assert.AreEqual("Head First Design Patterns", resultado[3].Title);
            Assert.AreEqual(2004, resultado[3].EditionYear);
        }

        [TestMethod]
        public void Deve_Ordenar_Por_Autor_Descendente_E_Titulo_Ascendente()
        {
            // Arrange
            var livros = Faker.CriarConjuntoPadraoDeLivros();

                    var regras = new List<SortRule>
            {
                new SortRule("AuthorName", SortDirection.Descending),
                new SortRule("Title", SortDirection.Ascending)
            };
            var orderer = new BooksOrderer(regras);

            // Act
            var resultado = orderer.Order(livros).ToList();

            // Assert
            Assert.AreEqual("Patterns of Enterprise Application Architecture", resultado[0].Title);
            Assert.AreEqual("Martin Fowler", resultado[0].AuthorName);

            Assert.AreEqual("Head First Design Patterns", resultado[1].Title);
            Assert.AreEqual("Elisabeth Freeman", resultado[1].AuthorName);

            Assert.AreEqual("Internet & World Wide Web: How to Program", resultado[2].Title);
            Assert.AreEqual("Deitel & Deitel", resultado[2].AuthorName);

            Assert.AreEqual("Java How to Program", resultado[3].Title);
            Assert.AreEqual("Deitel & Deitel", resultado[3].AuthorName);
        }

        [TestMethod]
        public void Deve_Lancar_Excecao_Quando_Conjunto_For_Vazio()
        {
            // Arrange
            var livros = new List<Book>();

                    var regras = new List<SortRule>
            {
                new SortRule("Title", SortDirection.Ascending)
            };

            var orderer = new BooksOrderer(regras);

            // Act + Assert
            Assert.Throws<OrdenacaoException>(() =>
            {
                orderer.Order(livros);
            });
        }
    }
}