<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.0.0
Description: Main page which will display game stats AND team stats to user - logged in users will also be given an option to edit any of the 4 games--%>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainTitle">
        <h1>Game for the Top</h1>
    </div>
    <div class="subTitle">
        <h2>Volleyball Games this Week</h2>
    </div>
    <div class="col col-md-8 col-md-offset-2">

    <div class="panel panel-warning">
        <div class="panel-heading">Games</div>
        <div class="panel-body">
            <asp:GridView runat="server" ID="GamesGridView" AutoGenerateColumns="false"
                CssClass="table table-striped table-bordered table-hover">
                <Columns>                    
                    <asp:BoundField DataField="GameNum" HeaderText="Game" Visible="true" />
                    <asp:BoundField DataField="Week" HeaderText="Week" Visible="true" />
                    <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" />
                    <asp:BoundField DataField="TeamOne" HeaderText="Team One" Visible="true" />
                    <asp:BoundField DataField="TeamTwo" HeaderText="Team Two" Visible="true" />
                    <asp:BoundField DataField="TotalPoints" HeaderText="Total Points" Visible="true" />
                    <asp:BoundField DataField="Spectators" HeaderText="Spectators" Visible="true" />
                    <asp:BoundField DataField="GameWinner" HeaderText="Winner" Visible="true" />
                    <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i>Edit"
                            NavigateUrl="~/GameDetails.aspx" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="GameID" DataNavigateUrlFormatString="GameDetails.aspx?GameID={0}" />
                </Columns>
            </asp:GridView>
        </div>
        </div>
    </div>
    <h2>Teams</h2>

    <asp:GridView runat="server" ID="TeamsGridView" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="TeamName" HeaderText="Team Name" Visible="true" />
            <asp:BoundField DataField="TeamDescription" HeaderText="Slogan" Visible="true" />
        </Columns>
    </asp:GridView>

</asp:Content>
