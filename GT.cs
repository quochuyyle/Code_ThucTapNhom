using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quan_li_diem_HS_tieu_hoc
{
    public class GT
    {
        public DataTable GioiTinh()
        {
            string strSQL = "select GioiTinh from  GioiTinh ORDER BY STT ASC";
            return DataProvider.LayDanhSach(strSQL);
        }
    }
}
