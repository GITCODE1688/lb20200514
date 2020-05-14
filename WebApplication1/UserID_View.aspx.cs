using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication1
    {
    public partial class GRIDVIEW_TEST : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!Page.IsPostBack)
                {
                azure_DB ( );
                txtSN.Enabled = false;
                txtCol1.Enabled = false;
                txtCol2.Enabled = false;
                txtCol3.Enabled = false;
                txtCol4.Enabled = false;
                btnUpdate.Enabled = false;
                btnInsert.Enabled = false;
                btnDel.Enabled = false;
                //this.BindData ( );

                DropDownList1.Items.Add ( "訊息回覆庫" );
                DropDownList1.Items.Add ( "已接收訊息" );
                DropDownList1.Enabled = false;
                }


            }

        //取azure DB資料
        private void azure_DB()
            {
            DataTable dt;
            string SqlStr = "";
            System.Data.Odbc.OdbcConnection Cn;
            System.Data.Odbc.OdbcCommand Cmd;
            System.Data.Odbc.OdbcDataReader Res;
            System.Data.Odbc.OdbcDataAdapter da;
            Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
            //SqlStr = @"select sn,addTime,msg,fromUser,fromRoom from Receivemsg ;";
            if (DropDownList1.SelectedIndex == 0)
                {
                SqlStr = @"select * from Replymsg ;";
                }
            else if (DropDownList1.SelectedIndex == 0)
                {
                SqlStr = @"select sn,addTime,msg,fromUser,fromRoom from Receivemsg ;";
                }

                Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
            da = new System.Data.Odbc.OdbcDataAdapter ( Cmd );
            dt = new DataTable ( );
            Cn.Open ( );
            da.Fill ( dt );
            Cn.Close ( );
            GridView2.DataSource = dt;
            GridView2.DataBind ( );


            }

        //繫結資料
        private void BindData()
            {
            this.GVGetData ( this.GridView1 );
            }

        //抓取資料並繫結 GridView
        private void GVGetData(GridView pGridView)
            {
            try
                {
                //判斷是否排序過
                if (ViewState["NowSE"] == null)
                    {
                    //沒有排序過，直接抓 DataTable
                    System.Data.DataTable oDT = this.GetData ( );
                    this.BindGridView ( oDT, pGridView );
                    }
                else
                    {
                    //有排序，所以除了抓資料，還要排序
                    string NowSE = ViewState["NowSE"].ToString ( );
                    SortDirection NowSD = (SortDirection)ViewState["NowSD"];
                    this.GVGetData ( NowSD, NowSE, pGridView );
                    }
                }
            catch
                {
                throw;
                }
            }

        //有指定排序的抓資料並繫結 GridView
        private void GVGetData(SortDirection pSortDirection, string pSortExpression, GridView pGridView)
            {
            try
                {
                DataTable oDT = this.GetData ( );
                string sSort = string.Empty;
                if (pSortDirection == SortDirection.Ascending)
                    {
                    sSort = pSortExpression;
                    }
                else
                    {
                    sSort = pSortExpression + " DESC";
                    }

                DataView oDV = oDT.DefaultView;
                oDV.Sort = sSort;
                this.BindGridView ( oDV, pGridView );
                }
            catch
                {
                throw;
                }
            }

        //繫結 GridView
        private void BindGridView(System.Data.DataView InDV, GridView InGridView)
            {
            DataTable oDT = InDV.Table;
            this.BindGridView ( oDT, InGridView );
            }

        //繫結 GridView
        private void BindGridView(DataTable InDT, GridView InGridView)
            {
            //判斷 DataTable 有無資料
            if (InDT.Rows.Count == 0)
                {
                //設定筆數
                this.SetTotalData ( "0" );

                //使用與來源資料表相同的結構新增資料列
                DataRow oDR = InDT.NewRow ( );

                //允許資料列的欄位可以是 DBNULL 值
                foreach (DataColumn item in oDR.Table.Columns)
                    {
                    item.AllowDBNull = true;
                    }

                //DataTable 加入資料列
                InDT.Rows.Add ( oDR );

                //將資料來源結構指定給 Grid DataSource
                InGridView.DataSource = InDT;
                InGridView.DataBind ( );

                //取得儲存格筆數
                int columnCount = InGridView.Rows[0].Cells.Count;
                InGridView.Rows[0].Cells.Clear ( );
                InGridView.Rows[0].Cells.Add ( new TableCell ( ) );
                //合併儲存格
                InGridView.Rows[0].Cells[0].ColumnSpan = columnCount;
                //設定儲存格文字
                InGridView.Rows[0].Cells[0].Text = "No Data!";
                InGridView.RowStyle.HorizontalAlign = HorizontalAlign.Center;
                InGridView.RowStyle.VerticalAlign = VerticalAlign.Middle;
                }
            else
                {
                InGridView.DataSource = InDT;
                InGridView.DataBind ( );
                this.SetTotalData ( InDT.Rows.Count.ToString ( ) );
                }
            }


        /// <summary>
        /// 取得資料表。
        /// </summary>        
        private DataTable GetData()
            {
            string csvStr = "";
            System.Data.Odbc.OdbcConnection csvCn;
            csvCn = new System.Data.Odbc.OdbcConnection ( @"Driver={Microsoft Text Driver (*.txt; *.csv)};extensions=csv,txt;DBQ=" + HttpContext.Current.Request.PhysicalApplicationPath + ";" );
            System.Data.Odbc.OdbcCommand csvCmd;


            csvStr = @"SELECT *  FROM LineID.csv order by createtime";
            csvCmd = new System.Data.Odbc.OdbcCommand ( csvStr, csvCn );
            DataTable oDT = new DataTable ( );
            System.Data.Odbc.OdbcDataReader oDbReader = null;
            if (csvCn.State != ConnectionState.Open)
                {
                csvCn.Open ( );
                }
            try
                {
                csvCmd.Connection = csvCn;
                csvCmd.CommandText = this.GetQueryStringSelect ( );
                oDbReader = csvCmd.ExecuteReader ( CommandBehavior.CloseConnection );
                oDT.Load ( oDbReader );
                }
            catch
                {
                throw;
                }
            finally
                {
                if (oDbReader != null)
                    {
                    oDbReader.Dispose ( );
                    }
                }
            return oDT;
            }

        /// <summary>
        /// 取得 SQLCommand Select 字串。
        /// </summary>        
        private string GetQueryStringSelect()
            {
            string sResult = string.Empty;
            sResult = @"SELECT *  FROM LineID.csv order by createtime";
            return sResult;
            }

        /// <summary>
        /// 設定總筆數。
        /// </summary>        
        private void SetTotalData(string Value)
            {
            this.lblTotal.Text = string.Format ( "總比數：{0}", Value );
            }

        /// <summary>
        /// 分頁切換。
        /// </summary>        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
            //指定 GridView 的新頁面索引
            (sender as GridView).PageIndex = e.NewPageIndex;

            //重新繫結 GridView
            this.GVGetData ( sender as GridView );
            }

        /// <summary>
        /// 排序資料列。
        /// </summary>        
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
            {
            string NowSE = ViewState["NowSE"] != null ? ViewState["NowSE"].ToString ( ) : string.Empty;
            SortDirection NowSD = ViewState["NowSD"] != null ? (SortDirection)ViewState["NowSD"] : SortDirection.Ascending;

            if (string.IsNullOrEmpty ( NowSE ))
                {
                NowSE = e.SortExpression;
                NowSD = SortDirection.Ascending;
                }

            if (NowSE != e.SortExpression)
                {
                NowSE = e.SortExpression;
                NowSD = SortDirection.Ascending;
                }
            else
                {
                if (NowSD == SortDirection.Ascending)
                    {
                    NowSD = SortDirection.Descending;
                    }
                else
                    {
                    NowSD = SortDirection.Ascending;
                    }
                }

            ViewState["NowSD"] = NowSD;
            ViewState["NowSE"] = NowSE;

            this.GVGetData ( NowSD, NowSE, sender as GridView );
            }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
            {
            this.RowEditingGridVeiw ( sender as GridView, e.NewEditIndex );
            }

        /// <summary>
        /// 修改資料列。
        /// </summary>        
        protected void RowEditingGridVeiw(GridView pGridView, int NewEditIndex)
            {
            //設定 GridView 要編輯的資料列            
            pGridView.EditIndex = NewEditIndex;

            //取消新增資料列
            this.CancelRowAddGridView ( pGridView );
            }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            int selinx = e.RowIndex;

            this.UpdatingRowGridView ( sender as GridView, e );
            }


        /// <summary>
        /// 更新資料列。
        /// </summary>
        protected void UpdatingRowGridView(GridView pGridView, GridViewUpdateEventArgs e)
            {
            //DoUpdateData...
            TextBox t = (TextBox)GridView1.Rows[e.RowIndex].FindControl ( "lblLastName_E" );
            String tt = t.Text;


            //離開模式
            //this.CancelRowEditGridView(pGridView);
            }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            this.CancelRowEditGridView ( sender as GridView );
            }

        /// <summary>
        /// 取消資料列修改。
        /// </summary>        
        protected void CancelRowEditGridView(GridView pGridView)
            {
            pGridView.EditIndex = -1;
            this.GVGetData ( pGridView );
            }

        protected void lcmdAdd_Click(object sender, EventArgs e)
            {
            this.AddRowGridView ( this.GridView1 );
            }

        protected void AddRowGridView(GridView InGridView)
            {
            //顯示新增資料列
            InGridView.ShowFooter = true;

            //關閉修改列            
            this.CancelRowEditGridView ( InGridView );

            //關閉 No Data 資料列
            this.VisibleGridViewNoData ( InGridView, false );
            }


        protected void lcmdCancel_F_Click(object sender, EventArgs e)
            {
            this.CancelRowAddGridView ( this.GridView1 );
            }

        /// <summary>
        /// 取消資料列新增。
        /// </summary>        
        protected void CancelRowAddGridView(GridView InGridView)
            {
            InGridView.ShowFooter = false;
            this.GVGetData ( InGridView );
            }

        protected void lcmdSave_Click(object sender, EventArgs e)
            {
            this.SaveRowGridView ( this.GridView1 );
            }

        /// <summary>
        /// 儲存資料列。
        /// </summary>        
        protected void SaveRowGridView(GridView InGridView)
            {
            //DoInsertData...
            //this.CancelRowAddGridView(InGridView);
            }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            this.DeletingRowGridView ( sender as GridView, e.RowIndex );
            }

        /// <summary>
        /// 刪除資料列
        /// </summary>        
        protected void DeletingRowGridView(GridView InGridView, int RowIndex)
            {
            //DoDeleteData
            //this.GVGetData(InGridView);
            }

        /// <summary>
        /// 顯示 No Data 資料列。
        /// </summary>        
        protected void VisibleGridViewNoData(GridView InGridView, bool IsShow)
            {
            if (InGridView.Rows.Count == 1 && !IsShow)
                {
                if (InGridView.Rows[0].Cells[0].Text.Trim ( ).Equals ( "No Data!" ))
                    {
                    InGridView.Rows[0].Visible = IsShow;
                    }
                }
            }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
            {
            var t = e.NewValues["Name"];
            }

        protected void btnUpdate_Click(object sender, EventArgs e)
            {
            if (txtSN.Text == "")
                { }
            else
                {
                try
                    {
                    string SqlStr = "";
                    string insertTime = DateTime.Now.ToString ( "yyyyMMdd_hhmmss" );
                    System.Data.Odbc.OdbcConnection Cn;
                    System.Data.Odbc.OdbcCommand Cmd;
                    System.Data.Odbc.OdbcDataReader Res;
                    System.Data.Odbc.OdbcDataAdapter da;
                    Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
                    SqlStr = @"update lineid set name = N'" + txtCol2.Text + "',createTime = N'" + insertTime + "' where SN = " + Int32.Parse ( txtSN.Text ) + ";";
                    Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
                    Cn.Open ( );
                    //Cmd.ExecuteNonQuery ( );
                    Cn.Close ( );
                    lbUpdateMSG.Text = "ok";
                    azure_DB ( );
                    }
                catch (Exception ex)
                    {
                    lbUpdateMSG.Text = ex.ToString ( );
                    }
                }
            }

        protected void btnDel_Click(object sender, EventArgs e)
            {
            if (txtSN.Text == "")
                { }
            else
                {
                try
                    {
                    string SqlStr = "";
                    System.Data.Odbc.OdbcConnection Cn;
                    System.Data.Odbc.OdbcCommand Cmd;
                    System.Data.Odbc.OdbcDataReader Res;
                    System.Data.Odbc.OdbcDataAdapter da;
                    Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
                    SqlStr = @"DELETE FROM LINEID WHERE SN =  " + Convert.ToInt32 ( txtSN.Text ) + ";";
                    Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
                    Cn.Open ( );
                    //Cmd.ExecuteNonQuery ( );
                    Cn.Close ( );
                    lbUpdateMSG.Text = "ok";
                    azure_DB ( );
                    }
                catch (Exception ex)
                    {
                    lbUpdateMSG.Text = ex.ToString ( );
                    }
                }
            }

        protected void btnPwd_Click(object sender, EventArgs e)
            {
            bool UIenable = false;
            if (btnPwd.Text == "unlock")
                {
                if (txtPwd.Text == "123iop")
                    {
                    UIenable = true;
                    btnPwd.Text = "lock";
                    }
                }
            else
                {
                txtPwd.Text = "";
                UIenable = false;
                btnPwd.Text = "unlock";
                }

            txtSN.Enabled = UIenable;
            txtCol1.Enabled = UIenable;
            txtCol2.Enabled = UIenable;
            txtCol3.Enabled = UIenable;
            txtCol4.Enabled = UIenable;
            btnUpdate.Enabled = UIenable;
            btnInsert.Enabled = UIenable;
            btnDel.Enabled = UIenable;
            DropDownList1.Enabled = UIenable;
            }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
            azure_DB ( );
            }
        }
    }

