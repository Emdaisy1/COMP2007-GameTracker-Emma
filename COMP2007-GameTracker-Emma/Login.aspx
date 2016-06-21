<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.0.0
Description: A login page to allow registered users to log in --%>

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col col-md-8 col-md-offset-2">
        <div class="mainTitle">
            <img src="/Assets/Images/logo.png" alt="Logo" />
            <h1>Game for the Top</h1>
        </div>
        <div class="subTitle">
            <h2>Login</h2>
        </div>
        <br />
        <div class="panel panel-warning">
            <div class="panel-heading">Login Form</div>
            <div class="panel-body">
                <asp:Label runat="server" ID="loginErrorMessage" Text="" CssClass="alert-danger" Display="Dynamic"></asp:Label>
                <div class="form-group">
                    <label class="control-label" for="UserNameTextBox">Username:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="PasswordTextBox">Password:</label>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" />
                    <asp:Button Text="Login" ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" TabIndex="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
