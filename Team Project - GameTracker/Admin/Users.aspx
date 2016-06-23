<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Team_Project___GameTracker.Admin.Users" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-users fa-lg"></i> Users</h1>
            </div>
            <div class="panel-body table-padding">
                <a href="/Admin/UserDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Register New User</a>
                <div class="table-padding">
                    <asp:GridView runat="server" ID="UsersGridView" AutoGenerateColumns="false"
                        CssClass="table table-bordered table-striped table-hover table-padding" OnRowDeleting="UsersGridView_RowDeleting" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" Visible="true" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" Visible="true" />
                            <asp:BoundField DataField="Email" HeaderText="Email" Visible="true" />
                            <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" NavigateUrl="~/Admin/UserDetails.aspx"
                                DataNavigateUrlFields="Id" DataNavigateUrlFormatString="UserDetails.aspx?Id={0}"
                                ControlStyle-CssClass="btn btn-primary btn-sm" />
                            <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                                ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm delete" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
