<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webNewsList.aspx.cs" Inherits="web一般处理程序.webNewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="webNewsAdd.aspx">添加</a>
        <table>
            <tr><th>编号</th><th>标题</th><th>时间</th><th>内容</th><th>编辑</th></tr>
            <%foreach (var item in pageNewslist)
                {%>
                  <tr><td><%=item.Nid %></td><td><%=item.Ntitle %></td><td><%=item.Ndate %></td><td><%=item.Ncontent %></td><td><a href="webNewsEdit.aspx?id=<%=item.Nid %>">修改</a></td></tr>
               <% } %>
        </table>
    </div>
        <div>
            <%=pageList %>
        </div>
    </form>
</body>
</html>
