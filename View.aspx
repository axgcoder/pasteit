<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

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
                 <div id ="" class="right menu">
                    <asp:LinkButton id="btnLogout" class ="item" Text="Logout" runat="server" OnClick="Logout"/>
                </div>
            </div>
        </div>
        <div id ="dynamic" class = "ui main text container segment" runat="server">
            
        </div>
           <div id ="BuildButton" class = "BuildButtons" runat="server">
            
        </div>
        <div class="BuildButtons"><asp:Button ID="delete" class = "ui red basic button " runat="server" Text="Delete Post" OnClick="Delete"/></div> 
    </div>
    </form>
</body>
</html>
