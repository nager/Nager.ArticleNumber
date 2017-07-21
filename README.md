# Nager.ArticleNumber

### nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.ArticleNumber)
```
PM> install-package Nager.ArticleNumber
```

### Examples

#### Detect article number type
```cs
var articleNumberType = ArticleNumberHelper.GetArticleNumberType("4002515289693");
if (articleNumberType == ArticleNumberType.EAN13)
{
    //print barcode
}
```

##### Validate article number
```cs
var isIsbn = ArticleNumberHelper.IsValidIsbn10("3551559015");
if (isIsbn)
{
    //buy book
}
```
