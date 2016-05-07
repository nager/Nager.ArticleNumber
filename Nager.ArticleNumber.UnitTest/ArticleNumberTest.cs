using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.ArticleNumber.UnitTest
{
    [TestClass]
    public class ArticleNumberTest
    {
        [TestMethod]
        public void TestIsAsin()
        {
            var isAsin = ArticleNumberHelper.IsValidAsin(null);
            Assert.AreEqual(isAsin, false);

            isAsin = ArticleNumberHelper.IsValidAsin(string.Empty);
            Assert.AreEqual(isAsin, false);

            isAsin = ArticleNumberHelper.IsValidAsin("B007KKKJYK");
            Assert.AreEqual(isAsin, true);
        }

        [TestMethod]
        public void TestIsIsbn()
        {
            var isIsbn10 = ArticleNumberHelper.IsValidIsbn10(null);
            Assert.AreEqual(isIsbn10, false);

            isIsbn10 = ArticleNumberHelper.IsValidIsbn10(string.Empty);
            Assert.AreEqual(isIsbn10, false);

            isIsbn10 = ArticleNumberHelper.IsValidIsbn10("3551559015");
            Assert.AreEqual(isIsbn10, true);

            var isIsbn13 = ArticleNumberHelper.IsValidIsbn13(null);
            Assert.AreEqual(isIsbn13, false);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13(string.Empty);
            Assert.AreEqual(isIsbn13, false);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13("978-3551559012");
            Assert.AreEqual(isIsbn13, true);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13("9783551559012");
            Assert.AreEqual(isIsbn13, true);
        }

        [TestMethod]
        public void TestIsEan()
        {
            var isEan = ArticleNumberHelper.IsValidEan(null);
            Assert.AreEqual(isEan, false);

            isEan = ArticleNumberHelper.IsValidEan(string.Empty);
            Assert.AreEqual(isEan, false);

            isEan = ArticleNumberHelper.IsValidEan("4002515289693");
            Assert.AreEqual(isEan, true);

            isEan = ArticleNumberHelper.IsValidEan("4039784974876");
            Assert.AreEqual(isEan, true);
        }

        [TestMethod]
        public void TestArtileNumberType()
        {
            var articleNumberType = ArticleNumberHelper.GetArticleNumberType(null);
            Assert.AreEqual(articleNumberType, ArticleNumberType.UNKNOWN);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType(string.Empty);
            Assert.AreEqual(articleNumberType, ArticleNumberType.UNKNOWN);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("4002515289693");
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
