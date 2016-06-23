<%--Author: Emma Hilborn - 200282755
Date: June 6, 2016
Version: 1.5.0
Description: Main page which will display game stats AND team stats to user - logged in users will also be given an option to edit any of the 4 games--%>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COMP2007_GameTracker_Emma.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainTitle">
        <h1>
            <img src="/Assets/Images/logo.png" alt="Logo" />
            Game for the Top
        </h1>
    </div>
    <div class="subTitle">
        <h2>Volleyball Games - Week <asp:Label runat="server" ID="showWeekLabel" Text=""></asp:Label></h2>
    </div>
    <div class="col col-md-8 col-md-offset-2">
        <div class="form-group">
            <label class="control-label" for="WeekDropDown">Select a week to view: </label>
            <asp:DropDownList ID="WeekDropDown" runat="server" AutoPostBack="true"></asp:DropDownList>
        </div>
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
    <div class="col col-md-8 col-md-offset-2">
        <div class="panel panel-warning">
            <div class="panel-heading">Teams</div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="TeamsGridView" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="TeamName" HeaderText="Team Name" Visible="true" />
                        <asp:BoundField DataField="TeamDescription" HeaderText="Slogan" Visible="true" />
                        <asp:BoundField DataField="GameOneScores" HeaderText="Game #1 Scores" Visible="true" />
                        <asp:BoundField DataField="GameTwoScores" HeaderText="Game #2 Scores" Visible="true" />
                        <asp:BoundField DataField="GameThreeScores" HeaderText="Game #3 Scores" Visible="true" />
                        <asp:BoundField DataField="GameFourScores" HeaderText="Game #4 Scores" Visible="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
