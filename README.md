Nager.ArticleNumber
==========

#####nuget
install-package Nager.ArticleNumber


#####Example detect article number type
```cs
var articleNumberType = ArticleNumberHelper.GetArticleNumberType("4002515289693");
if (articleNumberType == ArticleNumberType.EAN13)
{
//print barcode
}
```

#####Example validate article number
```cs
var isIsbn = ArticleNumberHelper.IsValidIsbn10("3551559015");
if (isIsbn)
{
//buy book
}
```