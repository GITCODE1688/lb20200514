using System.Data;
using System.Text;
using Microsoft.Azure;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
    {
    public partial class _default : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                DropDownList1.Items.Clear ( );
                DropDownList1.Items.Add ( "monk" );
                DropDownList1.Items.Add ( "邊緣人" );
                DropDownList1.Items.Add ( "彰化家" );
                DropDownList1.Items.Add ( "不要管" );
                DropDownList1.Items.Add ( "商管大群" );
                //DropDownList1.Text = DropDownList1.Items[2].Text;
                }

            }

        protected void Button1_Click(object sender, EventArgs e)
            {
            var ChannelAccessToken = "iNNBsIPiNof4jbpItGP+ypxTkKManP+E3hnBxXwi19ocbv3hc0SkKwo0AzBof1FIGtfwU2JhwlKliADbZ7R0zeCOPj2FNCnXpEjh41fDanX+1d59gZEOhMPF+AIiOfe3J1R+n/viuS50u3/iFocdhwdB04t89/1O/w1cDnyilFU=";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot ( ChannelAccessToken );

            var UserID = "";
            if (DropDownList1.SelectedIndex == 0)
                {
                UserID = "Uf0da07647506f8e77436b37d5a8f0d09";     //monk
                }
            else if (DropDownList1.SelectedIndex == 1)
                {
                UserID = "Cece3c46ed5a20297d7ce0a1b8ef65540";    //邊緣人聯天室
                }
           
            else if (DropDownList1.SelectedIndex == 2)
                {
                UserID = "Cff6b6e68e1fc385c6f8b61adc69e736d";     //彰化家聯天室
                }
            else if (DropDownList1.SelectedIndex == 3)
                {
                UserID = "C14faa0ade6aa7778a432519943f5433a";     //不要管
                }
            else if (DropDownList1.SelectedIndex == 4)
                {
                UserID = "C14ed8abef55a264f67d39cd7394bc160";     //彰商管樂大群
                }



            //U04b33175290d3954aeb879e920434f37     /   舜子


            String PustStr = TextBox1.Text;

            //push text
            //bot.PushMessage(UserID, PustStr );
            bot.PushMessage ( UserID, PustStr );
            ListBox1.Items.Add (DateTime.Now.ToString() + "　　　　" + PustStr );
            // AddID ( UserID );
            TextBox1.Text="";
            TextBox1.Focus ( );
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1;



            //建立actions，作為ButtonTemplate的用戶回覆行為
            //var actions = new List<isRock.LineBot.TemplateActionBase>();
            //actions.Add(new isRock.LineBot.MessageActon()
            //{ label = "點選這邊等同用戶直接輸入某訊息", text = "/例如這樣" });
            //actions.Add(new isRock.LineBot.UriActon()
            //{ label = "點這邊開啟網頁", uri = new Uri("http://www.google.com") });
            //actions.Add(new isRock.LineBot.PostbackActon()
            //{ label = "點這邊發生postack", data = "abc=aaa&def=111" });

            ////單一Button Template Message
            //var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            //{
            //    altText = "替代文字(在無法顯示Button Template的時候顯示)",
            //    text = "描述文字",
            //    title = "標題",
            //    //設定圖片
            //    thumbnailImageUrl = new Uri("https://scontent-tpe1-1.xx.fbcdn.net/v/t31.0-8/15800635_1324407647598805_917901174271992826_o.jpg?oh=2fe14b080454b33be59cdfea8245406d&oe=591D5C94"),
            //    actions = actions //設定回覆動作
            //};

            ////發送
            //bot.PushMessage(UserID, ButtonTemplate);
            }

        protected void Button2_Click(object sender, EventArgs e)
            {
            var UserID = "";
            if (DropDownList1.SelectedIndex == 0)
                {
                UserID = "Uf0da07647506f8e77436b37d5a8f0d09";     //monk
                }
            else if (DropDownList1.SelectedIndex == 1)
                {
                UserID = "Cece3c46ed5a20297d7ce0a1b8ef65540";    //邊緣人聯天室
                }
            else
                {
                UserID = "Cff6b6e68e1fc385c6f8b61adc69e736d";     //彰化家聯天室
                }
            var ChannelAccessToken = "iNNBsIPiNof4jbpItGP+ypxTkKManP+E3hnBxXwi19ocbv3hc0SkKwo0AzBof1FIGtfwU2JhwlKliADbZ7R0zeCOPj2FNCnXpEjh41fDanX+1d59gZEOhMPF+AIiOfe3J1R+n/viuS50u3/iFocdhwdB04t89/1O/w1cDnyilFU=";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot ( ChannelAccessToken );
            Int32 first = Convert.ToInt32 ( TextBox2.Text );
            Int32 second = Convert.ToInt32 ( TextBox3.Text );
            //push sticker
            try
                {
                bot.PushMessage ( UserID, first, second );
                }
            catch (Exception)
                {

                throw;
                }


            }

        protected void Button3_Click(object sender, EventArgs e)
            {
            var UserID = "";
            if (DropDownList1.SelectedIndex == 0)
                {
                UserID = "Uf0da07647506f8e77436b37d5a8f0d09";     //monk
                }
            else if (DropDownList1.SelectedIndex == 1)
                {
                UserID = "Cece3c46ed5a20297d7ce0a1b8ef65540";    //邊緣人聯天室
                }
            else
                {
                UserID = "Cff6b6e68e1fc385c6f8b61adc69e736d";     //彰化家聯天室
                }
            var ChannelAccessToken = "iNNBsIPiNof4jbpItGP+ypxTkKManP+E3hnBxXwi19ocbv3hc0SkKwo0AzBof1FIGtfwU2JhwlKliADbZ7R0zeCOPj2FNCnXpEjh41fDanX+1d59gZEOhMPF+AIiOfe3J1R+n/viuS50u3/iFocdhwdB04t89/1O/w1cDnyilFU=";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot ( ChannelAccessToken );
            //push image
            bot.PushMessage ( UserID, new Uri ( TextBox4.Text ) );
            }

        void AddID(String UserID)
            {
            string strPath = HttpContext.Current.Request.PhysicalApplicationPath + "LineID.csv";// "C:\\Test.csv";
            System.IO.FileInfo file;
            FileStream fs;
            StreamWriter sw;
            //CHECK LineID.csv exist   &   create lineID.csv
            if (File.Exists ( strPath ) == false)
                {
                file = new FileInfo ( strPath );
                fs = new FileStream ( strPath, FileMode.Append, FileAccess.Write );
                sw = new StreamWriter ( fs, Encoding.Default );
                sw.Write ( "LineID,Name,CreateTime", true );
                sw.Write ( Environment.NewLine, true );
                sw.Close ( );
                }


            string csvStr = "";
            System.Data.Odbc.OdbcConnection csvCn;
            System.Data.Odbc.OdbcCommand csvCmd;
            System.Data.Odbc.OdbcDataReader csvRes;
            csvCn = new System.Data.Odbc.OdbcConnection ( @"Driver={Microsoft Text Driver (*.txt; *.csv)};extensions=csv,txt;DBQ=" + HttpContext.Current.Request.PhysicalApplicationPath + ";" );
            csvCn.Open ( );
            csvStr = @"SELECT LineID FROM LineID.csv WHERE LineID = '" + UserID + "'";
            csvCmd = new System.Data.Odbc.OdbcCommand ( csvStr, csvCn );
            var tmp = csvCmd.ExecuteScalar ( );
            if (tmp == null)
                {
                //add id
                file = new FileInfo ( strPath );
                fs = new FileStream ( strPath, FileMode.Append, FileAccess.Write );
                sw = new StreamWriter ( fs, Encoding.Default );
                sw.Write ( UserID + ",," + DateTime.Now.ToString ( "yyyyMMdd_HHmmssfff" ), true );
                sw.Write ( Environment.NewLine, true );
                sw.Close ( );
                }
            else
                {


                }
            csvCn.Close ( );










            }

        protected void Button4_Click(object sender, EventArgs e)
            {
            string SqlStr = "";
            System.Data.Odbc.OdbcConnection Cn;
            System.Data.Odbc.OdbcCommand Cmd;
            System.Data.Odbc.OdbcDataReader Res;
            Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
            //SqlStr = @"CREATE TABLE lineID (SN INT IDENTITY PRIMARY KEY ,lineid nvarchar(50),Name nvarchar(50),type nvarchar(50),CreateTime nvarchar(50),UPDATETime nvarchar(50));";
            //SqlStr = @"ALTER TABLE lineID ALTER COLUMN Name nvarchar(50)";

            //drop table
            SqlStr = @"DROP TABLE Receivemsg;";
            Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
            try
                {
                Cn.Open ( );
                Cmd.ExecuteNonQuery ( );
                Cn.Close ( );
                lbCreateMSG.Text = "刪除 LineID成功";
                }
            catch (Exception ex)
                {
                lbCreateMSG.Text = ex.ToString ( );
                }

            //create table
            //SqlStr = @"CREATE TABLE lineID (SN INT IDENTITY PRIMARY KEY ,lineid nvarchar(50),Name nvarchar(50),type nvarchar(50),ENABLE int,CreateTime nvarchar(50),UPDATETime nvarchar(50));";
            //SqlStr = @"CREATE TABLE Replymsg (SN INT IDENTITY PRIMARY KEY ,keyValue nvarchar(50),returnMSG nvarchar(200),ENABLE int,CreateTime nvarchar(50),UPDATETime nvarchar(50));";
            SqlStr = @"CREATE TABLE Receivemsg (SN INT IDENTITY PRIMARY KEY ,addTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,msg nvarchar(200),fromUser nvarchar(50) ,fromRoom nvarchar(50));";
            Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
            try
                {
                Cn.Open ( );
                Cmd.ExecuteNonQuery ( );
                Cn.Close ( );
                lbCreateMSG.Text = "建立table成功";
                }
            catch (Exception ex)
                {
                lbCreateMSG.Text = ex.ToString ( );
                }
            }

        protected void Button5_Click(object sender, EventArgs e)
            {
            string SqlStr = "";
            System.Data.Odbc.OdbcConnection Cn;
            System.Data.Odbc.OdbcCommand Cmd;
            System.Data.Odbc.OdbcDataReader Res;
            string insertTime = DateTime.Now.ToString ( "yyyy-MM-dd HH:mm:ss" );
            Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
            //SqlStr = @"INSERT INTO lineid (lineid,name,type,ENABLE,createTime,UPDATETime) VALUES (N'abcdefedfsdfef',N'蘇永昇',N'userid',1,N'" + insertTime + "',N'" + insertTime + "');";
            //SqlStr = @"insert into Replymsg (keyValue,returnMSG,ENABLE,CreateTime,UPDATETime) values 
            //(N'你是誰',N'我？你竟然不知道我是誰？其實我也不知道我是誰？要問邀我進來的那個白目仔。',1,'20200512_100000','20200512_100000' );";

            //SqlStr = @"insert into Receivemsg (  MSG, fromUser, fromRoom ) values (  N'msgmsgmsg',  'userid', 'roomid' );  ";      接收訊息db

//            SqlStr = @"insert into Replymsg (keyValue,returnMSG,ENABLE,CreateTime,UPDATETime) values (N'白鳥',N'據傳他的奶茶是瀉藥中的勞斯萊斯！',1,'20200512_100000','20200512_100000' );
//insert into Replymsg (keyValue,returnMSG,ENABLE,CreateTime,UPDATETime) values (N'小號',N'其實sax比較帥，不然你問monk',1,'20200512_100000','20200512_100000' );
//insert into Replymsg (keyValue,returnMSG,ENABLE,CreateTime,UPDATETime) values (N'長號',N'老話一句，其實sax比較帥',1,'20200512_100000','20200512_100000' );";

            Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
            try
                {
                Cn.Open ( );
                Cmd.ExecuteNonQuery ( );
                lbinsertMSG.Text = "insert ok";
                }
            catch (Exception ex)
                {
                lbinsertMSG.Text = ex.ToString ( );
                }
            
            }
        }
    }