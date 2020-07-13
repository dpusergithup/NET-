<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNewsList.aspx.cs" Inherits="Web一般处理程序ashx.WebNewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="scripts/jquery-easyui-1.5.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="scripts/jquery-easyui-1.5.2/themes/icon.css" rel="stylesheet" />
    <script src="scripts/jquery-easyui-1.5.2/jquery.min.js"></script>
    <script src="scripts/jquery-easyui-1.5.2/jquery.easyui.min.js"></script>
    <script src="scripts/jquery-easyui-1.5.2/locale/easyui-lang-zh_CN.js"></script>
    <script src="scripts/datapattern.js"></script><%--日期插件--%>

    <script type="text/javascript">
        $(function () {
            initTable();//加载页面数据
        });

        //加载页面数据
        function initTable() {
            $.post("/ashx/NewsList.ashx", {}, function (date) {

                $("#tbodyid").html("");
                var jsondate = $.parseJSON(date);
                
                for (var key in jsondate) {
                    var str = "<tr>";
                    str += "<td>" + jsondate[key].Nid + "</td>";
                    str += "<td>" + jsondate[key].Ntitle + "</td>";
                    str += "<td>" + newdate(jsondate[key].Ndate) + "</td>";
                    str += "<td>" + jsondate[key].Ncontent + "</td>";
                    str += "<td><a href='/WebNewsedit.aspx?id=" + jsondate[key].Nid + "'>修改</a>&nbsp;</td>";
                    str += "</tr>";

                    $("#tbodyid").append(str);
                }
            });
        }

        function newdate(value,row,index){
            return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s.S");
        }

        //function bindedit()
        //{
        //    $("#tbodyid a:contains('修改')").click(function () {
        //        var vid = $(this).Attr("newsID");
        //        $.getJSON("/ashx/Newseidt.ashx", { id: vid }, function (date) {

        //        });
        //    });
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <thead>
                <tr><th>编号</th><th>标题</th><th>时间</th><th>内容</th></tr>
            </thead>
            <tbody id="tbodyid">

            </tbody>
        </table>
    </form>
</body>
</html>
