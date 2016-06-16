<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Team_Project___GameTracker.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <div class="jumbotron">
                    <h2 id="JumbotronH1" runat="server">Welcome to GAMETRACK!</h2>
                    <h3 id="JumbotronH3" runat="server">Choose a calendar week...</h3>
                </div>
                <div style="position:absolute; right:25px; top:10px;">
                    <asp:Calendar
                        ID="Calendar1"
                        runat="server"
                        OnDayRender="Calendar1_DayRender"
                        SelectionMode="DayWeek"
                        OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </div>
                <asp:DataList ID="GameDataList"
                    RepeatDirection="Horizontal"
                    RepeatLayout="Flow"
                    RepeatColumns="0" runat="server" DataKeyField="GameID" EnableViewState="true">
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
                                <div class="panel-footer panel-primary text-center">
                                    <h2><strong><%#Eval("GameResult") %></strong></h2>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
