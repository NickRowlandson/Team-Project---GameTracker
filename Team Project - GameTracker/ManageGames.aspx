<%@ Page Title="Manage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageGames.aspx.cs" Inherits="Team_Project___GameTracker.ManageGames" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Manage Games</h1>
        <a href="GameDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Game</a>
        <div>
            <asp:Calendar
                ID="Calendar1"
                runat="server"
                OnDayRender="Calendar1_DayRender"
                SelectionMode="DayWeek"
                OnSelectionChanged="Calendar1_SelectionChanged">
            </asp:Calendar>
        </div>
    </div>
</asp:Content>
