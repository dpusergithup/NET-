<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webNewsEdit.aspx.cs" Inherits="web一般处理程序.webNewsEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><td>编号：</td><td><input type="hidden" name="ptnId" value="<%=list.Nid %>" /></td></tr>
            <tr><td>标题：</td><td><input type="text" name="ptnName" value="<%=list.Ntitle %>" /></td></tr>
            <tr><td>时间：</td><td><input type="text" name="ptnDate" value="<%=list.Ndate %>" /></td></tr>
            <tr><td>内容：</td><td><input type="text" name="ptnContent" value="<%=list.Ncontent %>" /></td></tr>
            <tr><td><input type="submit" value="修改" /></td></tr>
        </table>
    </form>
</body>
</html>
