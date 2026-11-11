using System;
using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    public class Form
    {
        public Guid? RecordId { get; set; }
        public List<FormValue> Fields { get; set; } = new List<FormValue>();
    }
}
