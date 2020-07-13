<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webNewsAdd.aspx.cs" Inherits="web一般处理程序.webNewsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><td>标题：</td><td><input type="text" name="ptnName" /></td></tr>

            <tr><td>内容：</td><td><input type="text" name="ptnContent" /></td></tr>

            <tr><td><input type="submit" value="添加" /></td></tr>
        </table>
    </form>
</body>
</html>
