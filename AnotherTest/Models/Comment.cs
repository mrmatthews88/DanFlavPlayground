﻿using System;
using System.Collections.Generic;

namespace AnotherTest.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public int ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
