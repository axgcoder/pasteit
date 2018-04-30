<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PasteIt</title>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/semantic-ui/2.2.11/semantic.css"/>
    <link rel="stylesheet" type="text/css" href="/stylesheets/app.css"/>
</head>
<body>
    
         <div class = "ui fixed inverted menu">
            <div class = "ui container">
                <div class = "header item"><i class = "sticky note icon"></i>PasteIt</div>
                <a href = "Default.aspx" class = "item">Home</a>
                <a href = "Add.aspx" class = "item">New Post</a>
            </div>
            
        </div>
        <div class = "ui main text container segment">
    <div class = "ui huge header">Edit Post</div>
    <form id ="dynamic" class = "ui form" runat="server">
        <div class = "field">
            <label>Title</label>
            <asp:TextBox ID="Title" runat="server" value=""></asp:TextBox>
        </div>
        <div class = "field">
            <label>Image</label>
            <asp:TextBox ID="Image" runat="server" value=""></asp:TextBox>
        </div>
        <div class = "field">
            <label>Blog Content</label>
            <textarea id ="ContentID" runat="server"></textarea>
        </div>
            <asp:Button ID="submit" class = "ui secondary button big" runat="server" Text="Submit" OnClick="Submit_Click"/>
    </form>
</div>
    
</body>
</html>
