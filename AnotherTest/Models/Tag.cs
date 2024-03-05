using System;
using System.Collections.Generic;

namespace AnotherTest.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Article> ArticlesArticles { get; set; } = new List<Article>();
}
