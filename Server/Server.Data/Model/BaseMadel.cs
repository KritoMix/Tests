using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class BaseMadel
    {
        public long Id { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "timestamp with time zone")]
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow;
    }
}
