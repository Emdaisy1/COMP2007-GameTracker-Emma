<%--Author: Emma Hilborn - 200282755
Date: June 15, 2016
Version: 2.0.0
Description: Loads the page to allow the user to edit a game--%>

<%@ Page Title="GameDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="COMP2007_GameTracker_Emma.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col col-md-8 col-md-offset-2">
        <div class="mainTitle">
            <img src="/Assets/Images/logo.png" alt="Logo" />
            <h1>Game for the Top</h1>
        </div>
        <div class="subTitle">
            <h2>Edit Game</h2>
        </div>

        <br />

        <div class="panel panel-warning">
            <div class="panel-heading">Game Details</div>
            <div class="panel-body">
                <h6>All fields are required, except game description. Team One and Team Two cannot be the same team.</h6>
                <br />

                <div class="form-group">
                    <label class="control-label" for="DescriptionTextBox">Game Description (optional)</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DescriptionTextBox" placeholder="Game description (optional)" required="true" MaxLength="50"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="DescriptionTextBox" ValidationExpression="^[\s\S]{0,50}$" ErrorMessage="You can only enter a maximum of 50 characters" CssClass="alert-danger" Display="Dynamic" ></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamOneDropDown">Team One</label>
                    <asp:DropDownList ID="TeamOneDropDown" runat="server" OnSelectedIndexChanged="DropDownCheck" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoDropDown">Team Two</label>
                    <asp:DropDownList ID="TeamTwoDropDown" runat="server" OnSelectedIndexChanged="DropDownCheck" AutoPostBack="true"></asp:DropDownList>
                </div>
                <asp:Label runat="server" id="errorMessage" Text="" CssClass="alert-danger" Display="Dynamic"></asp:Label>
                <div class="form-group">
                    <label class="control-label" for="TeamOnePointsTextBox">Team One Points</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOnePointsTextBox" placeholder="Team One Points" required="true" MaxLength="2"></asp:TextBox>
                    <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="40" ControlToValidate="TeamOnePointsTextBox" ErrorMessage="Please enter a valid number from 1-40!" CssClass="alert-danger" Display="Dynamic" />
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoPointsTextBox">Team Two Points</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoPointsTextBox" placeholder="Team Two Points" required="true" MaxLength="2"></asp:TextBox>
                    <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="40" ControlToValidate="TeamTwoPointsTextBox" ErrorMessage="Please enter a valid number from 1-40!" CssClass="alert-danger" Display="Dynamic" />
                </div>
                <div class="form-group">
                    <label class="control-label" for="SpectatorsTextBox">Spectators</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Spectators" required="true" MaxLength="3"></asp:TextBox>
                    <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="999" ControlToValidate="SpectatorsTextBox" ErrorMessage="Please enter a valid number from 1-999!" CssClass="alert-danger" Display="Dynamic" />
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning btn-lg" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary btn-lg" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
