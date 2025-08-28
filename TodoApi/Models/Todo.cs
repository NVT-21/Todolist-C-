using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Todo
    {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
    }
}