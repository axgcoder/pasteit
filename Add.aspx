<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PasteIt</title>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/semantic-ui/2.2.11/semantic.css">
    <link rel="stylesheet" type="text/css" href="/stylesheets/app.css">
</head>
<body>
  <form id="form1" runat="server">
    <div>
         <div class = "ui fixed inverted menu">
            <div class = "ui container">
                <div class = "header item"><i class = "sticky note icon"></i>PasteIt</div>
                <a href = "Default.aspx" class = "item">Home</a>
                <a href = "Add.aspx" class = "item">New Post</a>
            </div>   
        </div>
        <div class = "ui main text container segment">
    <div class = "ui huge header">New Post</div>
    <div class = "ui form" runat="server">
        <div class = "field">
            <label>Title</label>
            <%--<input type = "text" name = "" value = "">--%>
            <asp:TextBox ID="Title" runat="server"></asp:TextBox>
        </div>
        <div class = "field">
            <label>Image</label>
            <%--<input type = "text" name = "blog[image]" value = "">--%>
            <asp:TextBox ID="Image" runat="server"></asp:TextBox>
        </div>
        <div class = "field">
            <label>Blog Content</label>
            <textarea id ="ContentID" runat="server"></textarea>
        </div>
            <asp:Button ID="submit" class = "ui secondary button big" runat="server" Text="Submit" OnClick="Submit_Click"/>
        <%--<button class = "ui secondary button big">Submit</button>--%>
    </div>
</div>
   </div> 
  </form>
</body>
</html>

