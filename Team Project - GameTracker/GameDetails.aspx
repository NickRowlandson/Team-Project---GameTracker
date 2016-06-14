<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="Team_Project___GameTracker.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Game Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="GameNameTextBox">Game Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="GameNameTextBox" placeholder="Game Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamOneTextBox">Team One</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOneTextBox" placeholder="Team One" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamOneScoreTextBox">Team One Score</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOneScoreTextBox" placeholder="Team One Score" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoTextBox">Team Two</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoTextBox" placeholder="Team Two" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoScoreTextBox">Team Two Score</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoScoreTextBox" placeholder="Team Two Score" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                <div class="form-group">
                    <label class="control-label" for="GameResultTextBox">Game Result</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="GameResultTextBox" placeholder="Game Result" required="true"></asp:TextBox>
                </div>
                    <label class="control-label" for="CalendarWeekTextBox">Calendar Week</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="CalendarWeekTextBox" placeholder="Date mm/dd/yyyy" required="true"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Invalid Date! Format: mm/dd/yyyy" ControlToValidate="CalendarWeekTextBox" MinimumValue="01/01/2000" MaximumValue="01/01/2099" Type="Date" Display="Dynamic" BackColor="Red" ForeColor="White" Font-Size="Large"></asp:RangeValidator>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" UseSubmitBehaviour="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
