using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    public class TableRowDTO
    {
        public List<CellDTO> Cells { get; set; } = new List<CellDTO>();
        public Dictionary<string, object> MetaData { get; set; } = new Dictionary<string, object>();
    }
}
