<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.0.0
Description: A registration page allowing new users to register for an account --%>

<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col col-md-8 col-md-offset-2">
        <div class="mainTitle">
            <h1>
                <img src="/Assets/Images/logo.png" alt="Logo" />
                Game for the Top
            </h1>
        </div>
        <div class="subTitle">
            <h2>Register</h2>
        </div>
        <br />
        <div class="panel panel-warning">
            <div class="panel-heading">Registration Form</div>
            <div class="panel-body">
                <h6>All Fields are Required</h6>
                <br />
                <asp:Label runat="server" ID="registerErrorMessage" Text="" CssClass="alert-danger" Display="Dynamic"></asp:Label>
                <div class="form-group">
                    <label class="control-label" for="UserNameTextBox">Username:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="EmailTextBox">Email:</label>
                    <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="EmailTextBox" placeholder="Email" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="PasswordTextBox">Password:</label>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="ConfirmPasswordTextBox">Confirm:</label>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="ConfirmPasswordTextBox" placeholder="Confirm Password" required="true" TabIndex="0"></asp:TextBox>
                    <asp:CompareValidator ErrorMessage="Your Passwords Must Match" Type="String" Operator="Equal" ControlToValidate="ConfirmPasswordTextBox" runat="server"
                        ControlToCompare="PasswordTextBox" CssClass="label label-danger" />
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />
                    <asp:Button Text="Register" ID="RegisterButton" runat="server" CssClass="btn btn-primary" OnClick="RegisterButton_Click" TabIndex="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
