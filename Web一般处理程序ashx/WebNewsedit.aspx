<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNewsedit.aspx.cs" Inherits="Web一般处理程序ashx.WebNewsedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="scripts/jquery-easyui-1.5.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#ptnbtn').click(function () {
                var Jsondate = $("#form1").serializeArray();
                $.post("/ashx/Newseidt.ashx", Jsondate, function (date) {
                    if (date == "OK")
                    {
                        window.location.href = "/WebNewsList.aspx";
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><td>编号</td><td><input type="hidden" name="ptnId" value="<%=list.Nid %>" /></td></tr>
            <tr><td>标题</td><td><input type="text" name="ptnName" value="<%=list.Ntitle%>" /></td></tr>
            <tr><td>时间</td><td><input type="text" name="ptndate" value="<%=list.Ndate%>" /></td></tr>
            <tr><td>内容</td><td><input type="text" name="ptnContent" value="<%=list.Ncontent%>" /></td></tr>
            <tr><td><input id="ptnbtn" type="button" value="修改" /></td></tr>
        </table>
    </form>
</body>
</html>
