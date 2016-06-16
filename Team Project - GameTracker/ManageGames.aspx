<%@ Page Title="Manage Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageGames.aspx.cs" Inherits="Team_Project___GameTracker.ManageGames" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Manage Games</h1>
        <a href="GameDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Game</a>
        <h3>Choose a calendar week to manage...</h3>
        <asp:Calendar
            ID="Calendar1"
            runat="server"
            OnDayRender="Calendar1_DayRender"
            SelectionMode="DayWeek"
            OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

        <asp:DataList ID="GameDataList"
            RepeatDirection="Horizontal"
            RepeatLayout="Flow"
            RepeatColumns="0" runat="server" OnDeleteCommand="GameDataList_DeleteCommand" DataKeyField="GameID">
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3><%#Eval("GameName") %></h3>
                            <strong><%#Eval("CalendarWeek", "{0:d}") %></strong>
                        </div>
                        <div class="panel-body">
                            <div class="text-center">
                                <h2><%#Eval("TeamOne") %></h2>
                                <h1><%#Eval("TeamOneScore") %></h1>
                                <h2><%#Eval("TeamTwo") %></h2>
                                <h1><%#Eval("TeamTwoScore") %></h1>
                            </div>
                        </div>
                        <div class="panel-footer text-center">
                            <h2><%#Eval("GameResult") %></h2>
                            <asp:LinkButton ID="DeleteButton" Runat="server" 
                               Text="<i class='fa fa-trash fa-lg'></i> Delete" 
                               CommandName="delete" CssClass="btn btn-danger btn-sm delete"/>
                            <a href='GameDetails.aspx?GameID=<%#Eval("GameID")%>' class="btn btn-primary btn-sm"><i class='fa fa-pencil-square-o fa-lg'></i> Edit</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
