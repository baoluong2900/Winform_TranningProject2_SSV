//---------------------------------------------------------------------------
//	System		:	FF3
//	Class Name	:	INP020017PBaoLV
//	Overview	:	Tranning OP
//	Designer	:	baolv＠SSV
//	Programmer	:	baolv＠SSV
//	Created Date:	2022/01/10
//
#region ----------< History >------------------------------------------------
//	ID			:	
//	Designer	:	
//	Programmer	:	
//	Updated Date:	
//	Comment		:	
//	Version		:	
//---------------------------------------------------------------------------
#endregion

#region using
// System
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// ID 000016 ADD Begin
using System.Collections.Generic;
// ID 000016 ADD End

// EFSA
using Jp.Co.Unisys.EFSA.Windows.Forms;
// ID 000016 ADD Begin
using Jp.Co.Unisys.EFSA.Core.Entity;
// ID 000016 ADD End

using Jp.Co.Unisys.FF3.Constants;
using Jp.Co.Unisys.FF3.Entity.CMN;
using Jp.Co.Unisys.FF3.Entity.INP._02;
using Jp.Co.Unisys.FF3.ServiceCall.INP._02;
using Jp.Co.Unisys.FF3.Sys.Entity;
using Jp.Co.Unisys.FF3.Sys.Entity.Base;
using Jp.Co.Unisys.FF3.Sys.Windows;
using Jp.Co.Unisys.FF3.Sys.Windows.Utility;
using Jp.Co.Unisys.FF3.Utility.Ap.FrontCmn;
// ID 000016 ADD Begin
using Jp.Co.Unisys.FF3.Utility.Ap;
using System.Globalization;
using Jp.Co.Unisys.EFSA.Core.ExceptionManagement;
using System.Reflection;
using Jp.Co.Unisys.FF3.Utility.ApWindows;
using Jp.Co.Unisys.EFSA.Core.Utility;
// ID 000016 ADD End

#endregion using

namespace Jp.Co.Unisys.FF3.WinForms.INP
{
	public partial class INP020017PBaoLV : WAOSubFormBase
	{
		#region Hàm gọi sẵn dùng chung

		/// <summary>Hàm tìm kiếm gọi tới severcall </summary>
		INP02MCustBaoLVInfoInqSc sc = new INP02MCustBaoLVInfoInqSc();

		/// <summary>Hàm goik tới Dataset </summary>
		MCustBaoLVDs mCustBaoLVDs = new MCustBaoLVDs();

		/// <summary>Hàm thêm mới gọi tới severcall </summary>
		INP02MCustBaoLVInsSc scUp = new INP02MCustBaoLVInsSc();

		/// <summary>Hàm cập nhật gọi tới severcall </summary>
		INP02MCustBaoLVUpdSc scUpd = new INP02MCustBaoLVUpdSc();

		/// <summary>Hàm xóa gọi tới severcall </summary>
		INP02MCustBaoLVDelSc scDel = new INP02MCustBaoLVDelSc();
		
		#endregion

		#region const

		/// <summary>MSG_REPLACE_CUSTNO</summary>
		const string MSG_REPLACE_CUSTNO = "Vui lòng nhập mã";

		/// <summary>定数 : 日付編集用定数_"/"</summary>
		private const string CALCDATE_SLASH = ":";

		/// <summary>MSG_FAILURE_ENTER_COMPARE_DATE</summary>
		const string MSG_FAILURE_ENTER_COMPARE_DATE = "Ngày trước lớn hơn ngày sau";

		/// <summary>MSG_FAILURE_SEARCH_CUSTNO_OR_DATE</summary>
		const string MSG_FAILURE_SEARCH_CUSTNO_OR_DATE = "Chưa nhập Cust No hoặc ngày tìm kiếm ";

		/// <summary>MSG_FAILURE_SEARCH_PERSON</summary>
		const string MSG_FAILURE_SEARCH_PERSON = "Tìm kiếm thất bại";

		/// <summary>NUMER_VALUE_STR</summary>
		const string NUMER_VALUE_STR = "0";

		/// <summary>NUMER_VALUE</summary>
		const int NUMER_VALUE_INT = 0;

		/// <summary>MSG_FAILURE_SEARCH_PERSON</summary>
		const string MSG_NOT_EXIST_SEARCH_PERSON = "Không tìm thấy";

		/// <summary>CUST_NO_SELECT</summary>
		const int CUST_NO_SELECT = 0;

		/// <summary>定数 : 時間用フォーマット：{0}/{1}/{2}</summary>
		private const string FORMAT_DATE = "{0}/{1}/{2}";

		/// <summary>定数 : 日付編集用定数_10000</summary>
		private const int CALCDATE_10000 = 10000;

		/// <summary>定数 : 日付編集用定数_100</summary>
		private const int CALCDATE_100 = 100;

		private const string FORMAT_INTDATE = "{0:D2}";

		/// <summary>MSG_FAILURE_SELECT_QUERY</summary>
		const string MSG_FAILURE_SELECT_QUERY = "Vui lòng chọn thông cần truy vấn";

		/// <summary>SEX_MAN_TEXT</summary>
		const string SEX_MAN_TEXT = "Man";

		/// <summary>SEX_WOMAN_TEXT</summary>
		const string SEX_WOMAN_TEXT = "Woman";

		/// <summary>MSG_SUCCESS_ADD_PERSON</summary>
		const string MSG_SUCCESS_ADD_PERSON = "Thêm thành công";

		/// <summary>MSG_SUCCESS_UPDE_PERSON</summary>
		const string MSG_SUCCESS_UPD_PERSON = "Cập nhật thành công";

		/// <summary>MSG_SUCCESS_DELETE_PERSON</summary>
		const string MSG_SUCCESS_DELETE_PERSON = "Xóa thành công";

		/// <summary>MSG_EXIST_ADD_PERSON</summary>
		const string MSG_EXIST_ADD_PERSON = "Thông người dùng đã tồn tại ";
		#endregion const

		#region Khởi tạo biến enum cho bảng speard

		/// <summary>
		/// Danh sách khởi tạo biến enum cho bảng speard MCustBaoLV
		/// </summary>
		private enum SPREAD_COL
		{
			COL_CUSTNO = 1,
			COL_CUSTNAME = 2,
			COL_CUSTNAMEKANA = 3,
			COL_BIRTHDAY = 4,
			COL_SEXKBN = 5
		}

		#endregion Khởi tạo biến enum cho bảng speard

		#region Hàm khởi tạo khi chạy chương trình
		/// <summary>
		/// Hàm khởi tạo khi chạy chương trình
		/// </summary>
		public INP020017PBaoLV()
		{
			InitializeComponent();
		}
		#endregion Hàm khởi tạo khi chạy chương trình

		#region Các control được khởi tạo lại ban đầu

		/// <summary>
		///  Các control được khởi tạo lại ban đầu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dmButtonClear_Click(object sender, EventArgs e)
		{
			dmTextBoxFndCustNo.Text = String.Empty;
			dmiFndDateTo.Text = String.Empty;
			dmiFndDateFrom.Text = String.Empty;
			dmTextboxInfName.Text = String.Empty;
			dmTextboxInfCustNoChkDgt.Text = String.Empty;
			dmTextboxInfNameKana.Text = String.Empty;
			dmiInfDateBirthDay.Text = String.Empty;
			dmTextboxInfCustNo.Text = String.Empty;
			dmTextBoxSelNo.Text = String.Empty;
			this.dmTextBoxFndCustNo.ExIsPaintErrorColor = false;
			this.dmSpreadMCust.ExRows.Clear();
			this.dmiFndDateTo.ExIsPaintErrorColor = false;
			this.dmiFndDateFrom.ExIsPaintErrorColor = false;
			dmTextBoxTotal.Text = String.Empty;
			dmButtonSelect.Enabled = false;
			dmButtonAdd.Enabled = false;
			dmButtonDelete.Enabled = false;
			dmButtonUpdate.Enabled = false;
		}

		#endregion Các control được khởi tạo lại ban đầu

		#region Hàm khởi tạo ban đầu

		/// <summary>
		/// Hàm load dữ liệu khi chạy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void INP020017PBaoLV_Load(object sender, EventArgs e)
		{
			//dmButtonAdd.Enabled = false;
			dmButtonUpdate.Enabled = false;
		//	dmButtonSelect.Enabled = false;
			dmButtonDelete.Enabled = false;
		}

		#endregion Hàm khởi tạo ban đầu

		#region Hàm kiếm thông tin của person theo mã nhập vào

		/// <summary>
		/// Hàm kiểm tra so sánh ngày trước và sau
		/// </summary>
		/// <param name="DateStart">Ngày tìm kiếm bắt đầu</param>
		/// <param name="DateEnd">Ngày tìm kiếm kết thúc</param>
		/// <returns>Trả về nếu true nếu ngày bắt đầu lớn ngày kết thúc</returns>
		private Boolean CheckDate(String DateStart, String DateEnd)
		{
			try
			{
				DateTime dt1 = DateTime.Parse(DateStart);
				DateTime dt2 = DateTime.Parse(DateEnd);
				if (dt1.Date > dt2.Date)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		#endregion Hàm kiếm thông tin của person theo mã nhập vào

		#region Hàm tìm kiếm danh sách người dùng

		/// <summary>
		/// Hàm tìm kiếm danh sách người dùng
		/// </summary>
		private void SearchPerson()
		{
			if (String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()) && (dmiFndDateFrom.ExNumber != NUMER_VALUE_INT && dmiFndDateTo.ExNumber != NUMER_VALUE_INT))
			{
				if (CheckDate(dmiFndDateFrom.Text, dmiFndDateTo.Text))
				{
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_FAILURE_ENTER_COMPARE_DATE);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
				}
				else if (CheckCountListPersonDate() > 0)
				{
					SearchListPersonCustNoIsNull(0);
					dmButtonSelect.Enabled = true;
				}
				else
				{
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_NOT_EXIST_SEARCH_PERSON);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
					ListPersonIsNull();
				}
				RestColorSearch();
			}
			else if (String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()) && (dmiFndDateFrom.ExNumber == NUMER_VALUE_INT || dmiFndDateTo.ExNumber == NUMER_VALUE_INT))
			{
				List<string> messageList = new List<string>();
				messageList.Add(INP020017PBaoLV.MSG_FAILURE_SEARCH_CUSTNO_OR_DATE);
				EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
				if (String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()))
				{
					this.dmTextBoxFndCustNo.ExIsPaintErrorColor = true;
				}
				if (dmiFndDateFrom.ExNumber == NUMER_VALUE_INT)
				{
					this.dmiFndDateFrom.ExIsPaintErrorColor = true;
				}
				if (dmiFndDateFrom.ExNumber == NUMER_VALUE_INT)
				{
					this.dmiFndDateFrom.ExIsPaintErrorColor = true;
				}
				if (dmiFndDateTo.ExNumber == NUMER_VALUE_INT)
				{
					this.dmiFndDateTo.ExIsPaintErrorColor = true;
				}
			}
			else if (!String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()))
			{
				if (CheckCountListPersonCustNo() > 0)
				{
					SearchListPersonDateIsNull(Int32.Parse(this.dmTextBoxFndCustNo.Text));
					dmButtonSelect.Enabled = true;
				}
				else
				{
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_NOT_EXIST_SEARCH_PERSON);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
					ListPersonIsNull();
				}
				RestColorSearch();
			}
			else if (String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()) && (dmiFndDateFrom.ExNumber != NUMER_VALUE_INT && dmiFndDateTo.ExNumber != NUMER_VALUE_INT))
			{
				SearchListPersonCustNoIsNull(0);
				dmButtonSelect.Enabled = true;
				RestColorSearch();
			}
			else if (!String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()) && (dmiFndDateFrom.ExNumber != NUMER_VALUE_INT && dmiFndDateTo.ExNumber != NUMER_VALUE_INT))
			{
				SearchListPersonCustNoIsNull(Int32.Parse(this.dmTextBoxFndCustNo.Text));
				dmButtonSelect.Enabled = true;
				RestColorSearch();
			}
			else
			{
				List<string> messageList = new List<string>();
				messageList.Add(INP020017PBaoLV.MSG_FAILURE_SEARCH_PERSON);
				EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
				RestColorSearch();
			}
		}

		#endregion Hàm tìm kiếm danh sách người dùng

		#region Hàm thiết lập trạng thái không tìm thấy

		/// <summary>
		/// Hàm thiết lập trạng thái khi không tìm thấy hoặc tìm kiếm thất bại
		/// </summary>
		private void ListPersonIsNull()
		{
			dmTextBoxSelNo.Text = NUMER_VALUE_STR;
			dmTextBoxTotal.Text = NUMER_VALUE_STR;
			if (dmTextBoxSelNo.Text == NUMER_VALUE_STR)
			{
				dmButtonSelect.Enabled = false;
			}
			else
			{
				dmButtonSelect.Enabled = true;
			}
			this.dmSpreadMCust.ExRows.Clear();
		}

		#endregion Hàm thiết lập trạng thái không tìm thấy

		#region Hàm đếm danh sách theo tìm kiếm ngày

		/// <summary>
		/// Hàm đếm danh sách theo tìm kiếm ngày
		/// </summary>
		/// <returns>Trả về số lượng danh sách tìm kiếm được</returns>
		private int CheckCountListPersonDate()
		{
			DateTime dtBirthDayTo = Convert.ToDateTime(this.dmiFndDateTo.Text);
			int bdTo = DateTimeUtil.ConvertToIntDate(dtBirthDayTo);
			DateTime dtBirthDayForm = Convert.ToDateTime(this.dmiFndDateFrom.Text);
			int bdForm = DateTimeUtil.ConvertToIntDate(dtBirthDayForm);
			sc.Call(0, bdForm, bdTo);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int rowCnt = mCustBaoLVDs.MCustBaoLV.Rows.Count;
			return rowCnt;
		}

		#endregion Hàm đếm danh sách theo tìm kiếm ngày

		#region Hàm đếm danh sách theo mã tìm kiếm được

		/// <summary>
		/// Hàm đếm danh sách theo mã tìm kiếm được
		/// </summary>
		/// <returns>Trả về số lượng danh sách tìm kiếm được</returns>
		private int CheckCountListPersonCustNo()
		{
			sc.Call(Int32.Parse(this.dmTextBoxFndCustNo.Text), NUMER_VALUE_INT, NUMER_VALUE_INT);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int rowCnt = mCustBaoLVDs.MCustBaoLV.Rows.Count;
			return rowCnt;
		}

		#endregion Hàm đếm danh sách theo mã tìm kiếm được

		#region hàm kiếm theo mã trường hợp không chọn ngày

		/// <summary>
		/// hàm kiếm theo mã trường hợp không chọn ngày
		/// </summary>
		/// <param name="custNo">nhập mã cần tìm kiếm</param>
		private void SearchListPersonDateIsNull(int custNo)
		{
			sc.Call(custNo, NUMER_VALUE_INT, NUMER_VALUE_INT);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int rowCnt = mCustBaoLVDs.MCustBaoLV.Rows.Count;
			this.dmTextBoxFndCustNo.ExIsPaintErrorColor = false;
			this.dmSpreadMCust.ExSetRowCount(rowCnt);
			PrintList(rowCnt);
			dmTextBoxTotal.Text = rowCnt.ToString();
			dmButtonSelect.Enabled = true;
		}

		#endregion hàm kiếm theo mã trường hợp không chọn ngày

		#region hàm kiếm danh sách người dùng

		/// <summary>
		/// hàm kiếm danh sách người dùng
		/// </summary>
		/// <param name="custNo">Nhập cần tìn kiếm</param>
		private void SearchListPersonCustNoIsNull(int custNo)
		{
			DateTime dtBirthDayTo = Convert.ToDateTime(this.dmiFndDateTo.Text);
			int bdTo = DateTimeUtil.ConvertToIntDate(dtBirthDayTo);
			DateTime dtBirthDayForm = Convert.ToDateTime(this.dmiFndDateFrom.Text);
			int bdForm = DateTimeUtil.ConvertToIntDate(dtBirthDayForm);
			sc.Call(custNo, bdForm, bdTo);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int rowCnt = mCustBaoLVDs.MCustBaoLV.Rows.Count;
			this.dmTextBoxFndCustNo.ExIsPaintErrorColor = false;
			this.dmSpreadMCust.ExSetRowCount(rowCnt);
			PrintList(rowCnt);
			dmTextBoxTotal.Text = rowCnt.ToString();
			dmButtonSelect.Enabled = true;
		}

		#endregion hàm kiếm danh sách người dùng

		#region Hàm trả về danh sách khi truyền số hàng

		/// <summary>
		/// Hàm trả về danh sách khi truyền số hàng
		/// </summary>
		/// <param name="rowCnt">Số hàng tìm đc</param>
		private void PrintList(int rowCnt)
		{
			for (int ii = 0; ii < rowCnt; ii++)
			{
				this.dmSpreadMCust.ExSetValue(ii, 0, ii + 1);
				this.dmSpreadMCust.ExSetValue(ii, (int)SPREAD_COL.COL_CUSTNO, mCustBaoLVDs.MCustBaoLV[ii].CustNo);
				this.dmSpreadMCust.ExSetValue(ii, (int)SPREAD_COL.COL_CUSTNAME, mCustBaoLVDs.MCustBaoLV[ii].CustName);
				this.dmSpreadMCust.ExSetValue(ii, (int)SPREAD_COL.COL_CUSTNAMEKANA, mCustBaoLVDs.MCustBaoLV[ii].CustNameKana);
				this.dmSpreadMCust.ExSetValue(ii, (int)SPREAD_COL.COL_BIRTHDAY, IntToDateTimeString(mCustBaoLVDs.MCustBaoLV[ii].Birthday));
				this.dmSpreadMCust.ExSetValue(ii, (int)SPREAD_COL.COL_SEXKBN, mCustBaoLVDs.MCustBaoLV[ii].SexKbn);
			}
		}
		#endregion Hàm trả về danh sách khi truyền số hàng

		#region hàm chuyển datetime sang int

		/// <summary>
		/// hàm chuyển datetime sang int 
		/// </summary>
		/// <param name="date">Ngày cần convert</param>
		/// <param name="intDate">Trả về kiểu int </param>
		/// <returns>Trả về điều kiện nếu covert được </returns>
		private bool DateTimeToInt(DateTime? date, out int intDate)
		{
			// 引数の日付が有効である場合
			if (date.HasValue)
			{
				// 引数の日付を文字列へ変換する。（ついでに"/"も削除）
				string dateStr = Convert.ToString(date).Replace(CALCDATE_SLASH, string.Empty);
				if (string.IsNullOrEmpty(dateStr))
				{
					// 0を返す。
					intDate = default(int);
					return false;
				}
				else
				{
					intDate = Convert.ToInt32(dateStr);
					return true;
				}
			}
			// 引数の日付が無効である場合
			else
			{
				// 0を返す。
				intDate = default(int);
				return false;
			}
		}

		#endregion hàm chuyển datetime sang int

		#region Chức năng tìm kiếm

		/// <summary>
		/// Chức năng tìm kiếm
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmButtonSearch_Click(object sender, EventArgs e)
		{
			SearchPerson();
			dmTextBoxSelNo.Text = String.Empty;
			dmButtonAdd.Enabled = true;
		}

		#endregion Chức năng tìm kiếm

		#region Chức năng truy vấn

		/// <summary>
		/// Chức năng truy vấn
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmButtonSelect_Click(object sender, EventArgs e)
		{
			int selectedRowNo = 0;
			selectedRowNo = this.dmSpreadMCust.ExGetActiveRow();
			if (!String.IsNullOrEmpty(dmTextBoxSelNo.Text))
			{
				SelectPerson(selectedRowNo);
				dmButtonAdd.Enabled = false;
				CountPersonByName(dmTextboxInfName.Text.Trim());
				LockButton();
			}
			else
			{
				List<string> messageList = new List<string>();
				messageList.Add(INP020017PBaoLV.MSG_FAILURE_SELECT_QUERY);
				EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120022, messageList);
			}
		}

		#endregion Chức năng truy vấn

		#region Hàm làm mới khi chọn danh sách

		/// <summary>
		/// Hàm làm mới khi chọn danh sách
		/// </summary>
		private void Reset()
		{
			dmTextboxInfCustNo.Text = String.Empty;
			dmTextboxInfName.Text = String.Empty;
			dmTextboxInfNameKana.Text = String.Empty;
			dmiInfDateBirthDay.Text = String.Empty;
			dmCheckBoxInfSex.Checked = false;
		}

		#endregion Hàm làm mới khi chọn danh sách

		#region Hàm khóa chức năng chỉnh sửa và delete

		/// <summary>
		/// Hàm khóa chức năng chỉnh sửa và delete
		/// </summary>
		private void LockButton()
		{
			dmButtonUpdate.Enabled = true;
			dmButtonDelete.Enabled = true;
			dmButtonAdd.Enabled = false;
			this.dmTextboxInfCustNo.ReadOnly = true;
		}

		#endregion Hàm khóa chức năng chỉnh sửa và delete

		#region Hàm chọn vị trí trên bảng để hiện thị thông tin chi tiết

		/// <summary>
		/// Hàm chọn vị trí trên bảng để hiện thị thông tin chi tiết
		/// </summary>
		/// <param name="SelectRow">Truyền vào hàng cần hiển thị</param>
		private void SelectPerson(int SelectRow)
		{
			dmTextboxInfCustNo.Text = this.dmSpreadMCust.ExGetText(SelectRow, (int)SPREAD_COL.COL_CUSTNO).ToString().Trim();
			dmTextboxInfName.Text = this.dmSpreadMCust.ExGetText(SelectRow, (int)SPREAD_COL.COL_CUSTNAME).ToString().Trim();
			dmTextboxInfNameKana.Text = this.dmSpreadMCust.ExGetText(SelectRow, (int)SPREAD_COL.COL_CUSTNAMEKANA).ToString().Trim();
			dmiInfDateBirthDay.Text = this.dmSpreadMCust.ExGetText(SelectRow, (int)SPREAD_COL.COL_BIRTHDAY);
			if (this.dmSpreadMCust.ExGetText(SelectRow, (int)SPREAD_COL.COL_SEXKBN).ToString().Trim() == SEX_MAN_TEXT)
			{
				this.dmCheckBoxInfSex.Checked = true;
			}
			else
			{
				this.dmCheckBoxInfSex.Checked = false;
			}
		}


		#endregion Hàm chọn vị trí trên bảng để hiện thị thông tin chi tiết

		#region Hàm chuyển đổi kiểu int sang dateTimeString

		/// <summary>
		/// Hàm chuyển đổi kiểu int sang dateTimeString
		/// </summary>
		/// <param name="intDate">date kiểu int</param>
		/// <returns>Trả về kiểu dateTimeStrinjg</returns>
		private string IntToDateTimeString(int intDate)
		{
			// 引数の日付を文字列型へ変換する。
			if (0 < intDate)
			{
				return string.Format(
					FORMAT_DATE,
					Convert.ToString(intDate / CALCDATE_10000),
					string.Format(FORMAT_INTDATE, (intDate % CALCDATE_10000) / CALCDATE_100),
					string.Format(FORMAT_INTDATE, intDate % CALCDATE_100));
			}
			else
			{
				return string.Empty;
			}
		}

		#endregion Hàm chuyển đổi kiểu int sang dateTimeString

		#region Hàm đếm tên được chọn

		/// <summary>
		/// Hàm đếm tên được chọn
		/// </summary>
		/// <param name="strNameSearchCount">Tên được truyền vào khi được chọn</param>
		private void CountPersonByName(string strNameSearchCount)
		{
			sc.Call(NUMER_VALUE_INT, NUMER_VALUE_INT, NUMER_VALUE_INT);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int varResult = mCustBaoLVDs.MCustBaoLV.Where(x => x.CustName.Trim() == strNameSearchCount.Trim()).ToList().Count();
			dmTextboxInfCustNoChkDgt.Text = varResult.ToString();
		}

		#endregion

		#region Chọn danh sách trên bảng spread
		/// <summary>
		/// Chọn danh sách trên bảng spread
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmSpreadMCust_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (!e.ColumnHeader)
			{
				dmTextBoxSelNo.Text = this.dmSpreadMCust.ExGetText(e.Row, NUMER_VALUE_INT).ToString();
				Reset();
				dmTextboxInfCustNoChkDgt.Text = String.Empty;
				dmCheckBoxInfSex.Checked = false;
			}
		}

		#endregion Chọn danh sách trên bảng spread

		#region Hàm khi nhập mã tìm kiếm sẽ khôi phục lại màu

		/// <summary>
		/// Hàm khi nhập mã tìm kiếm sẽ khôi phục lại màu
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmTextBoxFndCustNo_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmTextBoxFndCustNo.Text.Trim()))
			{
				this.dmTextBoxFndCustNo.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm khi nhập mã tìm kiếm sẽ khôi phục lại màu

		#region Hàm chọn ngày bắt đầu sẽ khôi phục lại màu

		/// <summary>
		/// Hàm chọn ngày bắt đầu sẽ khôi phục lại màu
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmiFndDateFrom_ValueChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmiFndDateFrom.Text.Trim()))
			{
				this.dmiFndDateFrom.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm chọn ngày bắt đầu sẽ khôi phục lại màu

		#region Hàm chọn ngày kết thúc sẽ khôi phục lại màu

		/// <summary>
		/// Hàm chọn ngày sẽ khôi phục lại màu
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmiFndDateTo_ValueChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmiFndDateTo.Text.Trim()))
			{
				this.dmiFndDateTo.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm chọn ngày kết thúc sẽ khôi phục lại màu

		#region Hàm khôi phục màu lỗi
		/// <summary>
		/// Hàm khôi phục màu lỗi
		/// </summary>
		private void RestColorSearch()
		{
			this.dmiFndDateTo.ExIsPaintErrorColor = false;
			this.dmiFndDateFrom.ExIsPaintErrorColor = false;
			this.dmTextBoxFndCustNo.ExIsPaintErrorColor = false;
		}

		#endregion Hàm khôi phục màu lỗi

		#region Chức năng thêm thông tin person

		/// <summary>
		/// Chức năng thêm thông tin person
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmButtonAdd_Click(object sender, EventArgs e)
		{
			AddPeson();

		}

		#endregion Chức năng thêm thông tin person

		#region Hàm thêm thông tin Peson

		/// <summary>
		/// Hàm thêm thông tin Peson
		/// </summary>
		private void AddPeson()
		{
			if (String.IsNullOrEmpty(dmTextboxInfCustNo.Text.Trim()))
			{
				this.dmTextboxInfCustNo.ExIsPaintErrorColor = true;
			}
			else if (String.IsNullOrEmpty(dmTextboxInfName.Text.Trim()))
			{
				this.dmTextboxInfName.ExIsPaintErrorColor = true;
			}
			else if (String.IsNullOrEmpty(dmTextboxInfNameKana.Text.Trim()))
			{
				this.dmTextboxInfNameKana.ExIsPaintErrorColor = true;
			}
			else if (String.IsNullOrEmpty(dmiInfDateBirthDay.Text))
			{
				this.dmTextboxInfNameKana.ExIsPaintErrorColor = true;
			}
			else
			{
				if (CheckCountListPersonCustNo(int.Parse(this.dmTextboxInfCustNo.Text)) > 0)
				{
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_EXIST_ADD_PERSON);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120003, messageList);
				}
				else
				{
					MCustBaoLVDs listPerson = new MCustBaoLVDs();
					MCustBaoLVDs.MCustBaoLVRow row = listPerson.MCustBaoLV.NewMCustBaoLVRow();
					row.CustNo = int.Parse(dmTextboxInfCustNo.Text.Trim());
					row.CustName = dmTextboxInfName.Text.Trim();
					row.CustNameKana = dmTextboxInfNameKana.Text.Trim();
					DateTime convertDate = Convert.ToDateTime(this.dmiInfDateBirthDay.Text);
					int bdTo = DateTimeUtil.ConvertToIntDate(convertDate);
					row.Birthday = bdTo;
					if (dmCheckBoxInfSex.Checked)
					{
						row.SexKbn = SEX_MAN_TEXT;
					}
					else
					{
						row.SexKbn = SEX_WOMAN_TEXT;
					}
					listPerson.MCustBaoLV.AddMCustBaoLVRow(row);
					scUp.Call(listPerson);
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_SUCCESS_ADD_PERSON);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120003, messageList);
					SearchListPersonDateIsNull(Int32.Parse(this.dmTextboxInfCustNo.Text));
				}
			}
		}

		#endregion Hàm thêm thông tin  Peson

		#region Hàm đếm kiểm tra user tồn tại không

		/// <summary>
		/// Hàm đếm danh sách theo mã tìm kiếm được
		/// </summary>
		/// <returns>Trả về số lượng danh sách tìm kiếm được</returns>
		private int CheckCountListPersonCustNo( int custNo)
		{
			sc.Call(custNo, NUMER_VALUE_INT, NUMER_VALUE_INT);
			mCustBaoLVDs = sc.MCustBaoLVDs;
			int rowCnt = mCustBaoLVDs.MCustBaoLV.Rows.Count;
			return rowCnt;
		}

		#endregion Hàm đếm danh sách theo mã tìm kiếm được

		#region Chức năng cập nhật person

		/// <summary>
		/// Chức năng cập nhật person
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmButtonUpdate_Click(object sender, EventArgs e)
		{
			
			if (String.IsNullOrEmpty(dmTextboxInfName.Text.Trim()))
			{
				this.dmTextboxInfName.ExIsPaintErrorColor = true;
			}
			else if (String.IsNullOrEmpty(dmTextboxInfNameKana.Text.Trim()))
			{
				this.dmTextboxInfNameKana.ExIsPaintErrorColor = true;
			}
			else if (String.IsNullOrEmpty(dmiInfDateBirthDay.Text))
			{
				this.dmTextboxInfNameKana.ExIsPaintErrorColor = true;
			}
			else
			{
					for (int ii = 0; ii < this.mCustBaoLVDs.MCustBaoLV.Count; ii++)
					{
						if (this.mCustBaoLVDs.MCustBaoLV[ii].CustNo == int.Parse(this.dmTextboxInfCustNo.Text))
						{
							this.mCustBaoLVDs.MCustBaoLV[ii].CustNo = int.Parse(this.dmTextboxInfCustNo.Text);
							this.mCustBaoLVDs.MCustBaoLV[ii].CustName = this.dmTextboxInfName.Text;
							this.mCustBaoLVDs.MCustBaoLV[ii].CustNameKana = this.dmTextboxInfNameKana.Text;
							DateTime convertDate = Convert.ToDateTime(this.dmiInfDateBirthDay.Text);
							int bdTo = DateTimeUtil.ConvertToIntDate(convertDate);
							this.mCustBaoLVDs.MCustBaoLV[ii].Birthday = bdTo;
							if (dmCheckBoxInfSex.Checked)
							{
								this.mCustBaoLVDs.MCustBaoLV[ii].SexKbn = SEX_MAN_TEXT;
							}
							else
							{
								this.mCustBaoLVDs.MCustBaoLV[ii].SexKbn = SEX_WOMAN_TEXT;
							}
							mCustBaoLVDs.MCustBaoLV[ii].AcceptChanges();
							break;
						}
					}
					scUpd.Call(mCustBaoLVDs);
					List<string> messageList = new List<string>();
					messageList.Add(INP020017PBaoLV.MSG_SUCCESS_UPD_PERSON);
					EFSAMessageBox.ShowMessageArea(this, APMessage.CMN.CD120003, messageList);
					SearchListPersonDateIsNull(Int32.Parse(this.dmTextboxInfCustNo.Text));
			}
		}

		#endregion Chức năng cập nhật person

		#region Hàm khôi phục màu khi nhập CustNo

		/// <summary>
		/// Hàm khôi phục màu khi nhập CustNo
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmTextboxInfCustNo_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmTextboxInfCustNo.Text.Trim()))
			{
				this.dmTextboxInfCustNo.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm khôi phục màu khi nhập CustNo

		#region Hàm khôi phục màu khi nhập Name

		/// <summary>
		/// Hàm khôi phục màu khi nhập Name
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmTextboxInfName_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmTextboxInfName.Text.Trim()))
			{
				this.dmTextboxInfName.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm khôi phục màu khi nhập Name

		#region  Hàm khôi phục màu khi nhập NameKana

		/// <summary>
		/// Hàm khôi phục màu khi nhập NameKana
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmTextboxInfNameKana_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmTextboxInfNameKana.Text.Trim()))
			{
				this.dmTextboxInfNameKana.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm khôi phục màu khi nhập NameKana

		#region Hàm khôi phục màu khi chọn ngày sinh nhật

		/// <summary>
		/// Hàm khôi phục màu khi chọn ngày sinh nhật
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void dmiInfDateBirthDay_ValueChanged_1(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dmiInfDateBirthDay.Text.Trim()))
			{
				this.dmiInfDateBirthDay.ExIsPaintErrorColor = false;
			}
		}

		#endregion Hàm khôi phục màu khi chọn ngày sinh nhật

		private void dmButtonDelete_Click(object sender, EventArgs e)
		{
			DeletePerson();
		}
		private void DeletePerson()
		{
			bool CheckExistPerson = false;
			string strCheckSex = "";
			int bdTo=0;
			for ( int ii = 0; ii < this.mCustBaoLVDs.MCustBaoLV.Count; ii++ )
			{
				DateTime convertDate = Convert.ToDateTime( this.dmiInfDateBirthDay.Text );
				 bdTo = DateTimeUtil.ConvertToIntDate( convertDate );

				if ( dmCheckBoxInfSex.Checked )
				{
					strCheckSex = SEX_MAN_TEXT;
				}
				else
				{
					strCheckSex = SEX_WOMAN_TEXT;
				}

				if (this.mCustBaoLVDs.MCustBaoLV[ii].CustNo == int.Parse(this.dmTextboxInfCustNo.Text)
					&& this.mCustBaoLVDs.MCustBaoLV[ii].CustName.Trim() == this.dmTextboxInfName.Text.Trim()
					&& this.mCustBaoLVDs.MCustBaoLV[ii].CustNameKana.Trim() == this.dmTextboxInfNameKana.Text.Trim()
					&& this.mCustBaoLVDs.MCustBaoLV[ii].Birthday == bdTo
					&& this.mCustBaoLVDs.MCustBaoLV[ii].SexKbn.Trim() == strCheckSex.Trim() 
					)
				{
					this.mCustBaoLVDs.MCustBaoLV[ii].CustNo = int.Parse(this.dmTextboxInfCustNo.Text);
					this.mCustBaoLVDs.MCustBaoLV[ii].CustName = this.dmTextboxInfName.Text.Trim();
					this.mCustBaoLVDs.MCustBaoLV[ii].CustNameKana = this.dmTextboxInfNameKana.Text.Trim();
					this.mCustBaoLVDs.MCustBaoLV[ii].SexKbn = strCheckSex.Trim();
					mCustBaoLVDs.MCustBaoLV[ii].AcceptChanges();
					mCustBaoLVDs.MCustBaoLV[ii].SetModified();
					CheckExistPerson = true;
					break;
				}
			}
			if (CheckExistPerson)
			{
				scDel.Call(mCustBaoLVDs, int.Parse(this.dmTextboxInfCustNo.Text), this.dmTextboxInfName.Text, this.dmTextboxInfNameKana.Text, bdTo, strCheckSex);
			}
		}
	}
}