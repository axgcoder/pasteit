<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PasteIt</title>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/semantic-ui/2.2.11/semantic.css"/>
    <link rel="stylesheet" type="text/css" href="/stylesheets/app.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <div class = "ui fixed inverted menu">
            <div class = "ui container">
                <div class = "header item"><i class = "sticky note icon"></i>PasteIt</div>
                <a href = "Default.aspx" class = "item">Home</a>
                <a href = "Add.aspx" class = "item">New Post</a>
                <div class="right menu">
                    <asp:LinkButton id="btnLogout" class ="item" Text="Logout" runat="server" OnClick="Logout"/>
                </div>
            </div>
        </div>
         <div class ="banner_img">

        </div>
        <div class = "ui main text container">
            <div class = "ui huge header">Welcome to PasteIt<i class = "sticky note icon"></i></div>
            <div class = "ui top attached segment">
                <div id="dynamic" class = "ui divided items" runat="server">
                    
                    </div>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
