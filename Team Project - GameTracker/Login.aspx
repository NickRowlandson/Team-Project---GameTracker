<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Team_Project___GameTracker.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <div class="alert alert-danger" id="AlertFlash" runat="server" visible="false">
                    <asp:Label runat="server" ID="StatusLabel" />
                </div>
                <h1>Login</h1>
                <div class="form-group">
                    <label class="control-label" for="UserNameTextBox">Username:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="PasswordTextBox">Password</label>
                    <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="PasswordTextBox" placeholder="Password" required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is required!" ControlToValidate="PasswordTextBox" SetFocusOnError="true" Display="Dynamic" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="text-right">
                    <asp:Button runat="server" CssClass="btn btn-primary btn-lg" ID="LoginButton" Text="Login" OnClick="LoginButton_Click" CausesValidation="true" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
