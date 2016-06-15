<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.0.0
Description: Main page which will display game stats AND team stats to user - logged in users will also be given an option to edit any of the 4 games--%>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Game for the Top</h1>

    <h2>Volleyball Games this Week</h2>

    <asp:GridView runat="server" ID="GamesGridView" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="Week" HeaderText="Week" Visible="true" />
            <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" />
            <asp:BoundField DataField="TeamOneID" HeaderText="Team One" Visible="true" />
            <asp:BoundField DataField="TeamOnePoints" HeaderText="Team One Pts" Visible="true" />
            <asp:BoundField DataField="TeamTwoID" HeaderText="Team Two" Visible="true" />
            <asp:BoundField DataField="TeamTwoID" HeaderText="Team Two Points" Visible="true" />
            <asp:BoundField DataField="Spectators" HeaderText="Spectators" Visible="true" />
            <asp:BoundField DataField="Winner" HeaderText="Winner" Visible="true" />
        </Columns>
    </asp:GridView>

    <h2>Teams</h2>

    <asp:GridView runat="server" ID="TeamsGridView" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="TeamName" HeaderText="Team Name" Visible="true" />
            <asp:BoundField DataField="TeamDescription" HeaderText="Slogan" Visible="true" />
        </Columns>
    </asp:GridView>



</asp:Content>
