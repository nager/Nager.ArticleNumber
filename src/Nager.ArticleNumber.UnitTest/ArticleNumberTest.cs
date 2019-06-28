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
        public void TestIsIssn()
        {
            var isIssn = ArticleNumberHelper.IsValidIssn(null);
            Assert.AreEqual(isIssn, false);

            isIssn = ArticleNumberHelper.IsValidIssn(string.Empty);
            Assert.AreEqual(isIssn, false);

            isIssn = ArticleNumberHelper.IsValidIssn("2229-5518");
            Assert.AreEqual(isIssn, true);

            isIssn = ArticleNumberHelper.IsValidIssn("1365-201X");
            Assert.AreEqual(isIssn, true);

            isIssn = ArticleNumberHelper.IsValidIssn("1911-1479");
            Assert.AreEqual(isIssn, true);

            isIssn = ArticleNumberHelper.IsValidIssn("2049-3630");
            Assert.AreEqual(isIssn, true);

            isIssn = ArticleNumberHelper.IsValidIssn("XXXX-0000");
            Assert.AreEqual(isIssn, false);

            isIssn = ArticleNumberHelper.IsValidIssn("0000-000X");
            Assert.AreEqual(isIssn, false);

            isIssn = ArticleNumberHelper.IsValidIssn("0000-00X0");
            Assert.AreEqual(isIssn, false);
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
        public void TestArticleNumberType()
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

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("1748-7188");
            Assert.AreEqual(articleNumberType, ArticleNumberType.ISSN);

            articleNumberType = ArticleNumberHelper.GetArticleNumberType("test");
            Assert.AreEqual(articleNumberType, ArticleNumberType.UNKNOWN);
        }

        [TestMethod]
        public void TestIsUpc()
        {
            var code = "";

            // Valid tests
            code = "042100005264";
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
            code = "614141007349";
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
            code = "012993101619";
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);

            // Invalid tests
            code = "042100005260";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
            code = "00421000052644";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
            code = "";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
            code = null;
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), "IsValidUpc failed for " + code);
        }

        [TestMethod]
        public void TestConvertUpcToGtin()
        {
            var code = "";
            var expected = "";
            var actual = "";

            // Valid cases - UPC
            code = "042100005264";
            expected = "00042100005264";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);

            code = "614141007349";
            expected = "00614141007349";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);

            code = "012993101619";
            expected = "00012993101619";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);

            code = "020529309620";
            expected = "00020529309620";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertEan13ToGtin()
        {
            var code = "";
            var expected = "";
            var actual = "";

            // Valid - EAN
            code = "4002515289693";
            expected = "04002515289693";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);

            code = "4039784974876";
            expected = "04039784974876";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestConvertGtinToGtin()
        {
            var code = "";
            var expected = "";
            var actual = "";

            // Valid - GTIN
            code = "04002515289693";
            expected = "04002515289693";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
           
            code = "10099429309556";
            expected = "10099429309556";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);

            code = "30073202109001";
            expected = "30073202109001";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertEan8ToGtin()
        {
            var actual = "";

            // Valid - GTIN
            var code = "96385074";
            var expected = "";
            Assert.IsFalse(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
        }

    }
}
