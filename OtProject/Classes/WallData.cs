using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtProject.Classes
{
    public class WallData
    {
        public Guid ID { get; set; }
        public byte Tip { get; set; }
        public Guid? UyeID1 { get; set; }
        public Guid? UyeID2 { get; set; }
        public string Aciklama { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string KalanSure { get; set; }
        public string Yer { get; set; }
        public bool Mustehcen { get; set; }
        public bool Acik { get; set; }
        public int ToplamPoka { get; set; }
        public string AdYer1 { get; set; }
        public int Oy1 { get; set; }
        public int Poka1 { get; set; }
        public string AdYer2 { get; set; }
        public int Oy2 { get; set; }
        public int Poka2 { get; set; }
    }
}