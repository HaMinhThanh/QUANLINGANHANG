using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class ThamSo
    {
		public DateTime ThoiGianApDung { get; set; }
		public double VonVayCaNhanToiDa { get; set; }
		public double VonVayToChucToiDa { get; set; }
		public bool YeuCauGiayToXacThuc { get; set; }
		public int TuoiDuocVayToiThieu { get; set; }
		public int KyHanToiDa { get; set; }
		public int KyHanToiThieu { get; set; }
		public double DinhGiaToiThieu { get; set; }
		public double LaiSuatToiDa { get; set; }
		public double LaiSuatToiThieu { get; set; }
		public int ThoiGianThongBaoTraNo { get; set; }
	}

	//ThoiGianApDung DATETIME NOT NULL,
	//VonVayCaNhanToiDa DECIMAL(32, 2) NOT NULL,
	//VonVayToChucToiDa DECIMAL(32, 2) NOT NULL,
	//YeuCauGiayToXacThuc BINARY NOT NULL,
	//TuoiDuocVayToiThieu INTEGER NOT NULL,
	//KyHanToiDa INTEGER NOT NULL,
	//KyHanToiThieu INTEGER NOT NULL,
	//DinhGiaToiThieu DECIMAL(7, 3) NOT NULL,
	//LaiSuatToiThieu DECIMAL(7, 3) NOT NULL,
	//LaiSuatToiDa DECIMAL(7, 3) NOT NULL,
	//ThoiGianThongBaoTraNo DECIMAL(5, 0) NOT NULL
}
