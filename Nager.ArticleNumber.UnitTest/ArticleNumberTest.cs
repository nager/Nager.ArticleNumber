using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.ArticleNumber.UnitTest
{
    [TestClass]
    public class ArticleNumberTest
    {
        [TestMethod]
        public void TestIsAsin()
        {
            var isAsin = ArticleNumberHelper.IsValidAsin("B007KKKJYK");
            Assert.AreEqual(isAsin, true);
        }

        [TestMethod]
        public void TestIsIsbn()
        {
            var isIsbn10 = ArticleNumberHelper.IsValidIsbn10("3551559015");
            Assert.AreEqual(isIsbn10, true);

            var isIsbn13 = ArticleNumberHelper.IsValidIsbn13("978-3551559012");
            Assert.AreEqual(isIsbn13, true);
        }

        [TestMethod]
        public void TestIsEan()
        {
            var isEan = ArticleNumberHelper.IsValidEan("4002515289693");
            Assert.AreEqual(isEan, true);
        }

        [TestMethod]
        public void TestArtileNumberType()
        {
            var articleNumberType = ArticleNumberHelper.GetArticleNumberType("4002515289693");
            Assert.AreEqual(articleNumberType, ArticleNumberType.EAN13);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("978-3551559012");
            Assert.AreEqual(articleNumberType, ArticleNumberType.ISBN13);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("B007KKKJYK");
            Assert.AreEqual(articleNumberType, ArticleNumberType.ASIN);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("test");
            Assert.AreEqual(articleNumberType, ArticleNumberType.UNKNOWN);
        }
    }
}
