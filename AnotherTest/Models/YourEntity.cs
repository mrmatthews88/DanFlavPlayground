using System;
using System.Collections.Generic;

namespace AnotherTest.Models;

public partial class YourEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }
}
