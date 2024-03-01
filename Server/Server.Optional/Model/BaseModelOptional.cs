using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Optional.Model
{
    public class BaseModelOptional
    {
        public long Id { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "timestamp with time zone")]
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow;
    }
}
