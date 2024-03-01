using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Server.Optional.Model
{
    public class DateEntry : BaseModelOptional
    {
        public long IdEntry { get; set; } 
        [Column(TypeName = "timestamp with time zone")]
        public DateTime Dt { get; set; }
    }
}
