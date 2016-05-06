Nager.ArticleNumber
==========

#####nuget
install-package Nager.ArticleNumber


#####Example Item Search
```cs
var articleNumberType = ArticleNumberHelper.GetArticleNumberType("4002515289693");
if (articleNumberType == ArticleNumberType.EAN13)
{
//print barcode
}
```