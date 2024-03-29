﻿<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 2.0.0
Description: User control for the nav bar that will be shown to users who are logged in--%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="COMP2007_GameTracker_Emma.Navbar" %>

<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <img src="../Assets/Images/logoSmall.png" alt="Logo" /><a class="navbar-brand" href="Default.aspx"> Game for the Top</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <asp:PlaceHolder ID="GreetUser" runat="server">
                    <li id="greeting" class="greeting" runat="server" ></li>
                </asp:PlaceHolder>                
                <li id="home" runat="server"><a href="Default.aspx"><i class="fa fa-trophy fa-lg"></i> Home</a></li>
                <asp:PlaceHolder ID="PublicUser" runat="server">
                    <li id="login" runat="server"><a href="Login.aspx"><i class="fa fa-sign-in fa-lg"></i> Login</a></li>
                    <li id="register" runat="server"><a href="Register.aspx"><i class="fa fa-plus-square-o fa-lg"></i> Register</a></li>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="RegisteredUser" runat="server">
                    <li id="profile" runat="server"><a href="Profile.aspx"><i class="fa fa-user fa-lg"></i> Profile</a></li>
                    <li id="logout" runat="server"><a href="Logout.aspx"><i class="fa fa-sign-out fa-lg"></i> Logout</a></li>
                </asp:PlaceHolder>
            </ul>
        </div>
    </div>
</nav>
