<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Team_Project___GameTracker.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-offset-2 col-md-6">
                <div class="jumbotron">
                    <h1 id="JumbotronH1" runat="server">Welcome to GameTracker!</h1>
                    <h3 id="JumbotronH3" runat="server">Choose a calendar week...</h3>
                </div>
            </div>
            <div class="col-md-2">
                <div class="jumbotron">
                    <div>
                        <asp:Calendar
                            ID="Calendar1"
                            runat="server"
                            OnDayRender="Calendar1_DayRender"
                            SelectionMode="DayWeek"
                            OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:DataList ID="GameDataList"
            RepeatDirection="Horizontal"
            RepeatLayout="Flow"
            RepeatColumns="0" runat="server" DataKeyField="GameID">
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong><%#Eval("GameName") %></strong>
                            <h3><%#Eval("CalendarWeek") %></h3>
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
                            <%#Eval("GameResult") %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
