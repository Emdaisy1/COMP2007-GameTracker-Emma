﻿<%@ Page Title="GameDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="COMP2007_GameTracker_Emma.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col col-md-8 col-md-offset-2">
        <div class="mainTitle">
            <h1>Game for the Top</h1>
        </div>
        <div class="subTitle">
            <h2>Edit Game</h2>
        </div>

        <br />

        <div class="panel panel-warning">
            <div class="panel-heading">Game Details</div>
            <div class="panel-body">
                <h6>All fields are required.</h6>
                <br />
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Team One</label>
                    <asp:DropDownList ID="TeamOneDropDown" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Team Two</label>
                    <asp:DropDownList ID="TeamTwoDropDown" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamOnePointsTextBox">Team One Points</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOnePointsTextBox" placeholder="Team One Points" required="true" MaxLength="2"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoPointsTextBox">Team Two Points</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoPointsTextBox" placeholder="Team Two Points" required="true" MaxLength="2"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="SpectatorsTextBox">Spectators</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Spectators" required="true" MaxLength="3"></asp:TextBox>
                </div>
                <%--        <div class="text-right">
            <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning btn-lg" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
            <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary btn-lg" OnClick="SaveButton_Click" />
        </div>--%>
            </div>
        </div>
    </div>


</asp:Content>