﻿using System;
using System.Collections.Generic;

namespace AnotherTest.Models;

public partial class Article
{
    public int ArticleId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Tag> TagsTags { get; set; } = new List<Tag>();
}
