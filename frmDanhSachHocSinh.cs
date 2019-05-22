using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_diem_HS_tieu_hoc
{
    public partial class frmDanhSachHocSinh : Form
    {
        public frmDanhSachHocSinh()
        {
            InitializeComponent();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemMoiHocSinh frm = new frmThemMoiHocSinh();
            frm.ShowDialog();
            HienThiThongTinHS();
        }

        private void frmDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            HienThiThongTinHS();
            HienThiDsLop();
        }
        private void HienThiThongTinHS()
        {
            DataTable dt = DataProvider.lstDanhSach.DsHocSinh();
            gridThongTin.DataSource = dt;
            for(int i=0;i<gridThongTin.RowCount-1;i++)
            {
                gridThongTin.Rows[i].Cells[0].Value = i+1;
            }
        }

        private void HienThiDsLop()
        {
            Lop service = new Lop();
            DataTable dtLop = service.DsLop();
            cbLop.DisplayMember = "Lop";
            cbLop.ValueMember = "Lop";
            cbLop.DataSource = dtLop;
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaHS = "";
            MaHS = "" + gridThongTin.CurrentRow.Cells[3].Value;

            frmXemDiem frm = new frmXemDiem();
            frm.MAHS = MaHS;
            frm.ShowDialog();
        

            
        }

        private void btnCapNhatTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaHS = "";
            MaHS = "" + gridThongTin.CurrentRow.Cells[3].Value;
            frmThemMoiHocSinh frm = new frmThemMoiHocSinh();
            frm.MaHS = MaHS;
            frm.ShowDialog();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaHS = "";
            MaHS = "" + gridThongTin.CurrentRow.Cells[3];

            DialogResult dr = MessageBox.Show("Bạn có muốn xóa thông tin về học sinh này ?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                bool ketQua = DataProvider.lstDanhSach.XoaThongTinHocSinh(MaHS);
                if (ketQua)
                {
                    MessageBox.Show("Thực hiện thành công", "Thông báo");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemBy(txtTimKiem.Text);
        }

        private void TimKiemBy(string HoTen)
        {
            HoTen = txtTimKiem.Text;
            string str;
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                str = "select h.Ho,h.Ten,h.MaHS,h.GioiTinh,h.NgaySinh,Lop from HocSinh h,Lop l where Ten LIKE N'%" + HoTen + "%' and Lop='" + cbLop.SelectedValue + "'";
            }
            else
            {
                str = "select h.Ho,h.Ten,h.MaHS,h.GioiTinh,h.NgaySinh,Lop from HocSinh h,Lop l where Lop='"+cbLop.SelectedValue+"' and h.MaLop=l.MaLop ORDER BY TEN ASC";
            }
            
            DataTable dt= DataProvider.LayDanhSach(str);
            gridThongTin.DataSource = dt;
            for (int i = 0; i < gridThongTin.RowCount - 1; i++)
            {
                gridThongTin.Rows[i].Cells[0].Value = i + 1;
            }

        }
    }
}
