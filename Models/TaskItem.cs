using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fAmv.Models
{
    public class TaskItem
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public List<string> Target { get; set; } = new List<string>();
        public String OutPut { get; set; } = "";
        public TaskType Type { get; set; }
    }

    public enum TaskType
    {
        Single,
        Batch
    }
}
