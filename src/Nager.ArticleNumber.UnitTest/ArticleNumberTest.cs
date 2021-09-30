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
            Assert.IsFalse(isAsin);

            isAsin = ArticleNumberHelper.IsValidAsin(string.Empty);
            Assert.IsFalse(isAsin);

            isAsin = ArticleNumberHelper.IsValidAsin("B007KKKJYK");
            Assert.IsTrue(isAsin);
        }

        [TestMethod]
        public void TestIsIsbn()
        {
            var isIsbn10 = ArticleNumberHelper.IsValidIsbn10(null);
            Assert.IsFalse(isIsbn10);

            isIsbn10 = ArticleNumberHelper.IsValidIsbn10(string.Empty);
            Assert.IsFalse(isIsbn10);

            isIsbn10 = ArticleNumberHelper.IsValidIsbn10("3551559015");
            Assert.IsTrue(isIsbn10);

            var isIsbn13 = ArticleNumberHelper.IsValidIsbn13(null);
            Assert.IsFalse(isIsbn13);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13(string.Empty);
            Assert.IsFalse(isIsbn13);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13("978-3551559012");
            Assert.IsTrue(isIsbn13);

            isIsbn13 = ArticleNumberHelper.IsValidIsbn13("9783551559012");
            Assert.IsTrue(isIsbn13);
        }

        [TestMethod]
        public void TestIsIssn()
        {
            var isIssn = ArticleNumberHelper.IsValidIssn(null);
            Assert.IsFalse(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn(string.Empty);
            Assert.IsFalse(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("2229-5518");
            Assert.IsTrue(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("1365-201X");
            Assert.IsTrue(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("1911-1479");
            Assert.IsTrue(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("2049-3630");
            Assert.IsTrue(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("XXXX-0000");
            Assert.IsFalse(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("0000-000X");
            Assert.IsFalse(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("0000-00X0");
            Assert.IsFalse(isIssn);

            isIssn = ArticleNumberHelper.IsValidIssn("1234ffsfe");
            Assert.IsFalse(isIssn);
        }

        [TestMethod]
        public void TestIsEan()
        {
            var isEan = ArticleNumberHelper.IsValidEan(null);
            Assert.IsFalse(isEan);

            isEan = ArticleNumberHelper.IsValidEan(string.Empty);
            Assert.IsFalse(isEan);

            isEan = ArticleNumberHelper.IsValidEan("849172008847 ");
            Assert.IsFalse(isEan);

            isEan = ArticleNumberHelper.IsValidEan("4002515289693");
            Assert.IsTrue(isEan);

            isEan = ArticleNumberHelper.IsValidEan("4039784974876");
            Assert.IsTrue(isEan);
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
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
            code = "614141007349";
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
            code = "012993101619";
            Assert.IsTrue(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");

            // Invalid tests
            code = "042100005260";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
            code = "00421000052644";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
            code = "";
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
            code = null;
            Assert.IsFalse(ArticleNumberHelper.IsValidUpc(code), $"IsValidUpc failed for {code}");
        }

        [TestMethod]
        public void TestConvertUpcToGtin()
        {
            // Valid cases - UPC
            var code = "042100005264";
            var expected = "00042100005264";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out var actual), code);
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
            // Valid - EAN
            var code = "4002515289693";
            var expected = "04002515289693";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out var actual), code);
            Assert.AreEqual(expected, actual);

            code = "4039784974876";
            expected = "04039784974876";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out actual), code);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestConvertGtinToGtin()
        {
            // Valid - GTIN
            var code = "04002515289693";
            var expected = "04002515289693";
            Assert.IsTrue(ArticleNumberHelper.TryConvertToGtin(code, out var actual), code);
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
            // Valid - GTIN
            var code = "96385074";
            var expected = "";
            Assert.IsFalse(ArticleNumberHelper.TryConvertToGtin(code, out var actual), code);
            Assert.AreEqual(expected, actual);
        }

    }
}
