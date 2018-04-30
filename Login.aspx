<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
                <div class="right menu">
                    <a href = "Signup.aspx" class = "item">Sign Up</a>
                </div>
            </div>
        </div>

        <div class = "ui main text container">
    <div class = "ui top attached segment">
        <div class = "ui divided items">
            <h1 class = "huge header">Welcome to PasteIt<i class = "sticky note icon"></i></h1>
            
                <div class="ui inverted segment">
                    <div class="ui inverted form">
                        <div class="two fields">
                            <div class="field">
                                <label>Username</label>
                                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                            </div>
                            <div class="field">
                                <label>Password</label>
                                <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="submit" class = "ui submit button" runat="server" Text="Login" OnClick="Submit_Click"/>
                    </div>
                </div>
            
        </div>
    </div>
</div>
    </div>
    </form>
</body>
</html>
