using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testing5.Models.ViewModels
{
    public class VM_pengguna
    {
        public int reportID { get; set; }
        public string RefNo { get; set; }
        public string Pengadu { get; set; }
        public string AduanWhatsapp { get; set; }
        public string Jenis_Aduan { get; set; }
        public Nullable<System.DateTime> Tarikh_Aduan { get; set; }
        public Nullable<System.DateTime> Tarikh_Aduan_Selesai { get; set; }
        public string Tindakan { get; set; }
        public string Images { get; set; }

        public List<tbl_syarikat> syarikat{ get; set; }
}
    public class VM_penggunaEdit: VM_pengguna
    {
        public DateTime tarikh_edit { get; set; }
    }
    public class tbl_syarikat
    {
        public int reportID { get; set; }
        public string RefNo { get; set; }
        public string Pengadu { get; set; }
        public string AduanWhatsapp { get; set; }
        public string Jenis_Aduan { get; set; }
        public Nullable<System.DateTime> Tarikh_Aduan { get; set; }
        public Nullable<System.DateTime> Tarikh_Aduan_Selesai { get; set; }
        public string Tindakan { get; set; }
        public string Images { get; set; }

    }

}