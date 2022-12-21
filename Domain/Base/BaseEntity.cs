using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey>, ITrackable
    {
        public TKey Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset? UpdatedDateTime { get; set; }
    }
}
