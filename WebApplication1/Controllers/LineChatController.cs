//無法建立CSV，也無法寫入CSV
using System.Web.UI;
using System.Web.UI.WebControls;
using LineBot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using isRock.LineBot;
using System.Data.OleDb;
using System.Data;

namespace WebApplication1.Controllers
    {
    public class LineChatController : ApiController
        {
        string UserID = "";
        // string Name = "20200511";
        string RoomID = "";
        string Message;
        int step = 0;
        [HttpPost]
        public IHttpActionResult POST()
            {
            string ChannelAccessToken = "iNNBsIPiNof4jbpItGP+ypxTkKManP+E3hnBxXwi19ocbv3hc0SkKwo0AzBof1FIGtfwU2JhwlKliADbZ7R0zeCOPj2FNCnXpEjh41fDanX+1d59gZEOhMPF+AIiOfe3J1R+n/viuS50u3/iFocdhwdB04t89/1O/w1cDnyilFU=";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot ( ChannelAccessToken );
            //取得 http Post RawData(should be JSON)
            string postData = Request.Content.ReadAsStringAsync ( ).Result;
            var ReceivedMessage = isRock.LineBot.Utility.Parsing ( postData );



            var item = ReceivedMessage.events[0];

            //var userinfo = isRock.LineBot.Utility.GetUserInfo ( ReceivedMessage.events[0].source.userId, ChannelAccessToken );
            //var userInfo = bot.GetUserInfo ( ReceivedMessage.events.FirstOrDefault ( ).source.userId );

            //var userInfo = bot.GetUserInfo ( ReceivedMessage.events.FirstOrDefault ( ).source.userId );

            //var UserSays = ReceivedMessage.events[0].message.text;
            var ReplyToken = ReceivedMessage.events[0].replyToken;
            //string Message = "";
            bool Trigger = false;
            //String CurrMsg = ReceivedMessage.events[0].message.text.Substring ( 4 ).ToString ( );

            if (ReceivedMessage.events[0].message.type.ToLower ( ) == "sticker")
                {
                bot.ReplyMessage ( ReceivedMessage.events[0].replyToken, " 我的主人還沒教我怎麼使用貼圖！><'''" );
                return Ok ( );
                }
            else
                {
                try
                    {
                    UserID = ReceivedMessage.events[0].source.userId;
                    string RoomID = "";
                    if (item.source.type.ToLower ( ) == "room")
                        {
                        RoomID = item.source.roomId;
                        }
                    else if (item.source.type.ToLower ( ) == "group")
                        {
                        RoomID = item.source.groupId;
                        }
                    else { }
                    AddMsg ( UserID, RoomID, ReceivedMessage.events[0].message.text );
                    }
                catch (Exception ex)
                    {
                    bot.ReplyMessage ( ReceivedMessage.events[0].replyToken, "add ERR:" + ex.ToString ( ) );
                    }

                Message = REPLAYMSG ( ReceivedMessage.events[0].message.text );
                if (Message == "")
                    {
                    if (ReceivedMessage.events[0].message.text.Length < 15 && ReceivedMessage.events[0].message.text.ToLower ( ).IndexOf ( "google", 0 ) > -1)
                        {
                        string searchStr = "";
                        searchStr = ReceivedMessage.events[0].message.text;
                        searchStr = searchStr.Replace ( "GOOGLE", "" );
                        searchStr = searchStr.Replace ( "google", "" );
                        searchStr = searchStr.Replace ( " ", "" );

                        Message = "google大神是你的好朋友" + "\n" + "https://www.google.com/search?q=" + searchStr;
                        Trigger = true;
                        }
                    else
                        {
                        //Message = "啦啦啦，不想理你！";
                        //Trigger = true;
                        }

                    }
                else
                    {
                    Trigger = true;
                    }

                try
                    {

                    if (Trigger)
                        {
                        bot.ReplyMessage ( ReceivedMessage.events[0].replyToken, Message );
                        }

                    return Ok ( );
                    }

                catch (Exception ex)
                    {
                    //bot.ReplyMessage ( ReceivedMessage.events[0].replyToken, "POST ERR:" + ex.ToString ( ) );
                    return Ok ( );
                    }
                }
            }
        void AddID(String UserID, String UserName, string IDtype)
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
                sw.Write ( "LineID,Name,type,CreateTime", true );
                sw.Write ( Environment.NewLine, true );
                sw.Close ( );
                }


            string csvStr = "";
            System.Data.Odbc.OdbcConnection csvCn;
            System.Data.Odbc.OdbcCommand csvCmd;
            System.Data.Odbc.OdbcDataReader csvRes;
            csvCn = new System.Data.Odbc.OdbcConnection ( @"Driver={Microsoft Text Driver (*.txt; *.csv)};extensions=csv,txt;DBQ=" + HttpContext.Current.Request.PhysicalApplicationPath + ";" );
            csvCn.Open ( );
            csvStr = @"SELECT Name FROM LineID.csv WHERE LineID = '" + UserID + "'";
            csvCmd = new System.Data.Odbc.OdbcCommand ( csvStr, csvCn );
            var tmp = csvCmd.ExecuteScalar ( );
            if (tmp == null)
                {
                //add id
                file = new FileInfo ( strPath );
                fs = new FileStream ( strPath, FileMode.Append, FileAccess.Write );
                sw = new StreamWriter ( fs, Encoding.Default );
                sw.Write ( UserID + "," + UserName + "," + IDtype + "," + DateTime.Now.ToString ( "yyyyMMdd_HHmmssfff" ), true );
                sw.Write ( Environment.NewLine, true );
                sw.Close ( );
                }
            else if (tmp.ToString ( ) != UserName.ToString ( ) && IDtype == "UserID")
                {
                //add id
                file = new FileInfo ( strPath );
                fs = new FileStream ( strPath, FileMode.Append, FileAccess.Write );
                sw = new StreamWriter ( fs, Encoding.Default );
                sw.Write ( UserID + "," + UserName + "," + IDtype + "," + DateTime.Now.ToString ( "yyyyMMdd_HHmmssfff" ), true );
                sw.Write ( Environment.NewLine, true );
                sw.Close ( );
                }
            else
                {


                }
            csvCn.Close ( );
            }

        string REPLAYMSG(string RECEIVE)
            {
            int step = 0;
            string msg = "";
            try
                {

                string csvStr = "";
                string SqlStr = "";
                System.Data.Odbc.OdbcConnection Cn;
                System.Data.Odbc.OdbcCommand Cmd;
                System.Data.Odbc.OdbcDataReader Res;
                System.Data.Odbc.OdbcDataAdapter da;
                Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
                Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
                step = 1;
                Cn.Open ( );
                step = 2;
                SqlStr = @"SELECT keyValue ,returnMSG FROM Replymsg ";
                Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
                Res = Cmd.ExecuteReader ( );
                step = 3;
                while (Res.Read ( ))
                    {
                    if (RECEIVE.ToLower ( ).IndexOf ( Res[0].ToString ( ).ToLower ( ), 0 ) > -1)
                        {
                        msg = Res[1].ToString ( );
                        }
                    }

                Cn.Close ( );
                return msg;
                }
            catch (Exception ex)
                {
                return "";
                //return "REPLAYMSG ERR:" + ex.ToString ( );
                }
            }

        string REPLAYMSG_oledb(string RECEIVE)
            {
            string reStr = "";
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + ";Extended Properties='Text;HDR=NO;IMEX=1'";
            OleDbConnection GetCSV = new OleDbConnection ( strCon );
            DataTable Table = new DataTable ( );
            OleDbDataAdapter daCSV = new OleDbDataAdapter ( "SELECT * FROM [messagepool.csv]", GetCSV );
            daCSV.Fill ( Table );
            foreach (DataRow dr in Table.Rows)
                {
                foreach (DataColumn dc in Table.Columns)
                    {
                    reStr = dr[dc.ColumnName].ToString ( );


                    }
                }
            return reStr + "monk";

            }

        void AddMsg(String UserID, String RoomID, string msg)
            {

            string SqlStr = "";
            System.Data.Odbc.OdbcConnection Cn;
            System.Data.Odbc.OdbcCommand Cmd;
            System.Data.Odbc.OdbcDataReader Res;
            string Time = DateTime.Now.ToString ( "yyyy/MM/dd HH:mm:ss.fff" );
            Cn = new System.Data.Odbc.OdbcConnection ( @"Driver={ODBC Driver 13 for SQL Server};Server=tcp:monkdb.database.windows.net,1433;Database=monkdb;Uid=monk;Pwd=!@#$qwer19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;" );
            Cn.Open ( );
            SqlStr = @"insert into Receivemsg (  MSG, fromUser, fromRoom ) values (  N'" + msg + "',  '" + UserID + "', '" + RoomID + "' );  ";
            Cmd = new System.Data.Odbc.OdbcCommand ( SqlStr, Cn );
            Cmd.ExecuteNonQuery ( );
            Cn.Close ( );

            }
        }

    }
