<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.0.0
Description: Profile page which will allow a user who is logged in to edit their profile information --%>

<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainTitle">
        <h1>
            <img src="/Assets/Images/logo.png" alt="Logo" />
            Game for the Top
        </h1>
    </div>
    <div class="subTitle">
        <h2>Edit Your Profile</h2>
    </div>
    <div class="col col-md-8 col-md-offset-2">
        <div class="panel panel-warning">
            <div class="panel-heading">Profile Details</div>
            <div class="panel-body">
                <h6>All Fields are Required</h6>
                <br />
                <asp:Label runat="server" ID="updateErrorMessage" Text="" CssClass="alert-danger" Display="Dynamic"></asp:Label>
                <div class="form-group">
                    <label class="control-label" for="userNameTextBox">Username:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="userNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="emailTextBox">Email:</label>
                    <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="emailTextBox" placeholder="Email" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />
                    <asp:Button Text="Update" ID="UpdateButton" runat="server" CssClass="btn btn-primary" OnClick="UpdateButton_Click" TabIndex="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
